using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mvIMPACT_NET;
using mvIMPACT_NET.acquire;
using mvIMPACT_NET.datamatrix;
using System.Threading;
using System.Collections;
using System.Diagnostics;

namespace iPRINT.INSPECTION
{
    class MatrixVision : IRedInspection
    {
        private mvIMPACT_NET.acquire.Device pDev;
        private mvIMPACT_NET.datamatrix.DatamatrixConfiguration config;
        private mvIMPACT_NET.datamatrix.DatamatrixResults results;
        private mvIMPACT_NET.Image image;
        DeviceManager devMgr;

        private bool isTerminated = false;


        public string deviceName
        {
            get { return "Matrix"; }
        }
     
        public void Init()
        {
            config = new mvIMPACT_NET.datamatrix.DatamatrixConfiguration();
            //config.blackOnWhite = true;
            //config.setContrast(20, 40, 10);
            //config.contrast = 30;
            //config.setGradientWidth(1, 5);
            //config.trimming = GridTrimming.gt4Adj;
         
            config.maxCodes = 1;
            config.timeout = 2000;
        }

        public void SetSymbology(List<UTIL.TemplateFields> templateScema)
        {
        }

        public bool Connect()
        {
            bool retVal = false;
            devMgr = new DeviceManager();
            pDev = devMgr.getDevice(0);
            try
            {
                pDev.open();          
                Init();
                isTerminated = false;
                captureContinuous();
                retVal = true;
            }
            catch (ImpactAcquireException ex)
            {
                Trace.TraceError("{0}, Connect Camera, {1}", DateTime.Now, ex.Message);
            }
            return retVal;
        }

        public bool Disconnect()
        {
            bool retVal = false;

            if (pDev != null)
            {
                isTerminated = true;
                pDev.close();
                retVal = true;
            }
            return retVal;
        }

        public bool IsConnected()
        {
            bool retVal = false;

            if (pDev != null)
            {
                retVal = pDev.isOpen();
            }
            return retVal;
        }

        private void captureContinuous()
        {
            System.Drawing.Bitmap bmp = null;
            try
            {
                FunctionInterface fi = new FunctionInterface(ref pDev);
                Thread thread = new Thread(delegate()
                    {
                        TDMR_ERROR result = TDMR_ERROR.DMR_NO_ERROR;
                        while ((result = (TDMR_ERROR)fi.imageRequestSingle()) == TDMR_ERROR.DMR_NO_ERROR)
                        { };
                        if (result != TDMR_ERROR.DEV_NO_FREE_REQUEST_AVAILABLE)
                        {
                            string txt = "'FunctionInterface.imageRequestSingle' returned with an unexpected result:" + result;// +", " + ImpactAcquireException.getErrorCodeAsString(result);
                        }
                        if (pDev.acquisitionStartStopBehaviour.read() == TAcquisitionStartStopBehaviour.assbUser)
                        {
                            if ((result = (TDMR_ERROR)fi.acquisitionStart()) != TDMR_ERROR.DMR_NO_ERROR)
                            {
                                string txt = "'FunctionInterface.acquisitionStart' returned with an unexpected result: " + result;// +"," + ImpactAcquireException.getErrorCodeAsString(result);
                            }
                        }
                        // run thread loop  
                        Request pRequest = null;
                        int timeout_ms = 5000;
                        int requestNr = 1;// Device.INVALID_ID;

                        while (!isTerminated)
                        {
                            requestNr = fi.imageRequestWaitFor(timeout_ms);
                            pRequest = fi.isRequestNrValid(requestNr) ? fi.getRequest(requestNr) : null;
                            if (pRequest != null)
                            {
                                if (pRequest.isOK())
                                {
                                    // display/process/store or do whatever you like with the image here  
                                    using (Image data = pRequest.getIMPACTImage())
                                    {
                                        try
                                        {

                                            bmp = data.convertToBitmap();
                                            DecodeData(pRequest, bmp);

                                        }
                                        catch (ImpactAcquireException ex)
                                        {
                                            throw ex;
                                        }
                                    }
                                }
                                else
                                {
                                    string txt = "Error: {0}" + pRequest.requestResult.readS();
                                }
                                pRequest.unlock();
                                // send a new image request into the capture queue
                                fi.imageRequestSingle();
                            }
                            else
                            {
                                // If the error code is -2119(DEV_WAIT_FOR_REQUEST_FAILED), the documentation will provide      
                                // additional information under TDMR_ERROR in the interface reference    
                                string txt = "imageRequestWaitFor failed " + requestNr;// +"," + ImpactAcquireException.getErrorCodeAsString(requestNr) + ", timeout value too small?";
                            }
                        }
                        // Stop the acquisition manually if this was requested 
                        if (pDev.acquisitionStartStopBehaviour.read() == TAcquisitionStartStopBehaviour.assbUser)
                        {
                            if ((result = (TDMR_ERROR)fi.acquisitionStop()) != TDMR_ERROR.DMR_NO_ERROR)
                            {
                                string txt = "'FunctionInterface.acquisitionStop' returned with an unexpected result: " + result;// +"," + ImpactAcquireException.getErrorCodeAsString(result);
                            }
                        }
                        // clear the request queue  
                        fi.imageRequestReset(0, 0);
                        // extract and unlock all requests that are now returned as 'aborted' 
                        requestNr = 1;// Device.INVALID_ID;
                        while ((requestNr = fi.imageRequestWaitFor(0)) >= 0)
                        {
                            pRequest = fi.getRequest(requestNr);
                            string txt = "Request {0} did return with status " + requestNr + "," + pRequest.requestResult.readS();
                            pRequest.unlock();
                        }

                    });
                thread.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DecodeData(mvIMPACT_NET.acquire.Request pRequest, System.Drawing.Bitmap oImage)
        {
            try
            {
                ArrayList dmVis = new ArrayList();

                image = pRequest.getIMPACTImage();
                String code = string.Empty;
                // pWin.buffer = image;

                //decode image
                results = gDatamatrix.decodeDM(image, config);

                //get total decoding time
                double totalTime = results.totalDecodingTime;

                //get candidates and decoding time
                int candidates = results.numberOfCandidates;

                //count the number of codes
                int numberOfCodes = 0;

                //clear decoding results from previous iteration
                for (int counter = 0; counter < dmVis.Count; counter++)
                {
                    DatamatrixVisualizer dmV = (DatamatrixVisualizer)dmVis[counter];
                    dmV.visible = false;
                }

                //step through all candidates
                for (int candCounter = 0; candCounter < candidates; candCounter++)
                {
                    int codes = results.getNumberOfCodes(candCounter);

                    //get the loacation of this candidate
                    Array points = results.getLocation(candCounter);
                    //get decoding time for the candidate
                    double candTime = results.getDecodingTime(candCounter);

                    //step through all codes
                    for (int codeCounter = 0; codeCounter < codes; codeCounter++)
                    {
                        //get information
                        code = results.getCode(candCounter, codeCounter);
                        Size size = results.getDatamatrixDims(candCounter, codeCounter);

                        numberOfCodes++;
                    }

                }
                InspectionFeedback(InspectionEVENTS.ResultArrived, oImage, code + "\n", "DataReceived");

            }
            catch (ImpactException ex)
            {
                Trace.TraceError("{0}, Read Data, {1}", DateTime.Now, ex.Message);
            }
        }

        public event EventHandler InspectionFeedbackEvent;
        event EventHandler IRedInspection.OnInspectionFeedback
        {
            add
            {
                if (InspectionFeedbackEvent != null)
                {
                    lock (InspectionFeedbackEvent)
                    {
                        InspectionFeedbackEvent += value;
                    }
                }
                else
                {
                    InspectionFeedbackEvent = new EventHandler(value);
                }
            }
            remove
            {
                if (InspectionFeedbackEvent != null)
                {
                    lock (InspectionFeedbackEvent)
                    {
                        InspectionFeedbackEvent -= value;
                    }
                }
            }
        }
        public void InspectionFeedback(InspectionEVENTS rcvdEvent,System.Drawing.Bitmap oImage, string result, string Msg)
        {
            EventHandler handler = InspectionFeedbackEvent;
            if (handler != null)
            {
                InspectionArgs cmd = new InspectionArgs();
                cmd.ImageResult = oImage;
                cmd.rcvdEvent = rcvdEvent;
                cmd.Result = result;
                cmd.CodeType = Msg;
                handler(this, cmd);
            }
        }
    }
}