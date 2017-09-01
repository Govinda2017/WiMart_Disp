using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iPRINT.UTIL;
using System.Drawing;
//using iPRINT.CODEMGR;
using System.Diagnostics;
using DataMatrix.net; 

namespace iPRINT.PrintJob
{
    public class ImageHandler
    {
        public delegate void setImage();
        private DmtxImageEncoder EnCoder;
        private DmtxImageEncoderOptions encops;

        private Size m_ImageDisplaySize;
        private Font fnt;
        private Brush blackbrush;
        private Brush whietbrush ;
        int posX = 0;
        int posY = 0;
        int gap = 30;

        public ImageHandler()
        {
            EnCoder = new DmtxImageEncoder();
            encops = new DmtxImageEncoderOptions();
            m_ImageDisplaySize = new Size(400, 400);
            fnt = new Font("OCR-A BT", 14);
            blackbrush = new SolidBrush(Color.Black);
            whietbrush = new SolidBrush(Color.White);
        }

        public  Bitmap GetClearBitmap()
        {
            Bitmap bmMain = new Bitmap(m_ImageDisplaySize.Width, m_ImageDisplaySize.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            Graphics g = Graphics.FromImage(bmMain);
            g.FillRectangle(whietbrush, new Rectangle(0, 0, m_ImageDisplaySize.Width, m_ImageDisplaySize.Height));
            return bmMain;
        }
        public Bitmap GetBitmap(List<TemplateFields> lst)
        {
            try
            { 
                posY = 0;
                Bitmap bm = null;
                Bitmap bmMain = new Bitmap(m_ImageDisplaySize.Width, m_ImageDisplaySize.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                Graphics g = Graphics.FromImage(bmMain);
                g.FillRectangle(whietbrush, new Rectangle(0, 0, m_ImageDisplaySize.Width, m_ImageDisplaySize.Height));

                foreach (TemplateFields item in lst)
                {
                    if (item.FldType == TemplateFields.eFldType.IDFLDText)
                        continue;
                    if (TemplateFields.isIdCode(item.FldType))
                    {
                        if (item.Data == null)
                            continue;

                        List<AITagVal> lsttagVal = (List<AITagVal>)item.Data;
                        string StrIDcode = "";// iPRINT.CODEMGR.GS1Mgr.GetIDCode("", iPRINT.CODEMGR.GS1Mgr.GS1GroupSeparator, lsttagVal);
                        if (!string.IsNullOrEmpty(StrIDcode))
                        {
                            if (item.FldType == TemplateFields.eFldType.DATAMATRIX)
                            {
                                bm = EnCoder.EncodeImage(StrIDcode, encops);
                                g.DrawImage(bm, new Point(posX, posY));
                                posY += bm.Height;
                            }
                            else if (item.FldType == TemplateFields.eFldType.CODE128)
                            {
                                //TBD:for barcode
                            }
                        }
                    }
                    else
                    {
                        g.DrawString(item.Prefix + " " + item.Data + " " + item.Postfix, fnt, blackbrush, new PointF(posX, posY));
                    }
                    posY += gap;
                }
                g.Dispose();
                return bmMain;
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
            }
            return null;
        }
    }
}
