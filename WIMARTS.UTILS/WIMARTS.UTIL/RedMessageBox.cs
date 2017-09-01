using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace WIMARTS.UTIL
{
    public partial class RedMessageBox : Form
    {
        public static int MsgCounts = 0;
        public static bool CustomMsg = true;
        public static string MsgBoxTitle = "Dialog Box";
        public static Image MsgBoxLogo;// = (Image) Resources.LOGO;
        private object m_store;
        public RedMessageBox.MessageHandler OnMessageClose;
        private bool m_IsAsync;

        public bool IsAsync
        {
            get
            {
                return this.m_IsAsync;
            }
            set
            {
                if (this.m_IsAsync == value)
                    return;
                this.m_IsAsync = value;
                if (!this.m_IsAsync)
                    return;
                foreach (Control control in (ArrangedElementCollection)this.BTN_Panel.Controls)
                    control.Click += new EventHandler(this.MessageBoxEx_Click);
            }
        }

        public RedMessageBox(string title, string MessageText, Image iconSet, RedMessageBox.RedMessageBoxButtons btns)
        {
            this.Font = SystemFonts.MessageBoxFont;
            this.ForeColor = SystemColors.WindowText;
            this.InitializeComponent();
            this.Text = title;
            this.Header.Text = title;
            this.HeaderMessage.Text = string.IsNullOrEmpty(MessageText) ? string.Empty : MessageText;
            this.pictureBox1.Image = iconSet;
            switch (btns)
            {
                case RedMessageBox.RedMessageBoxButtons.AbortRetryIgnore:
                    this.AddButton(((object)DialogResult.Ignore).ToString(), 2, DialogResult.Ignore);
                    this.AddButton(((object)DialogResult.Retry).ToString(), 1, DialogResult.Retry);
                    this.AddButton(((object)DialogResult.Abort).ToString(), 0, DialogResult.Abort);
                    break;
                case RedMessageBox.RedMessageBoxButtons.OK:
                    this.AddButton(((object)DialogResult.OK).ToString(), 0, DialogResult.OK);
                    break;
                case RedMessageBox.RedMessageBoxButtons.OKCancel:
                    this.AddButton(((object)DialogResult.Cancel).ToString(), 1, DialogResult.Cancel);
                    this.AddButton(((object)DialogResult.OK).ToString(), 0, DialogResult.OK);
                    break;
                case RedMessageBox.RedMessageBoxButtons.RetryCancel:
                    this.AddButton(((object)DialogResult.Cancel).ToString(), 0, DialogResult.Cancel);
                    this.AddButton(((object)DialogResult.Retry).ToString(), 1, DialogResult.Retry);
                    break;
                case RedMessageBox.RedMessageBoxButtons.YesNo:
                    this.AddButton(((object)DialogResult.No).ToString(), 0, DialogResult.No);
                    this.AddButton(((object)DialogResult.Yes).ToString(), 1, DialogResult.Yes);
                    break;
                case RedMessageBox.RedMessageBoxButtons.YesNoCancel:
                    this.AddButton(((object)DialogResult.Cancel).ToString(), 0, DialogResult.Cancel);
                    this.AddButton(((object)DialogResult.No).ToString(), 1, DialogResult.No);
                    this.AddButton(((object)DialogResult.Yes).ToString(), 2, DialogResult.Yes);
                    break;
                case RedMessageBox.RedMessageBoxButtons.PauseStopCancel:
                    this.AddButton("Cancel", 0, DialogResult.Cancel);
                    this.AddButton("Stop", 1, DialogResult.No);
                    this.AddButton("Pause", 2, DialogResult.Yes);
                    break;
                case RedMessageBox.RedMessageBoxButtons.LoadNewCancel:
                    this.AddButton("Cancel", 2, DialogResult.Cancel);
                    this.AddButton("New", 1, DialogResult.No);
                    this.AddButton("Load", 0, DialogResult.Yes);
                    break;
                case RedMessageBox.RedMessageBoxButtons.Start:
                    this.AddButton("START", 2, DialogResult.OK);
                    break;
            }
        }

        private RedMessageBox(string title, string MessageText, Image iconSet, string btn1, string btn2, string btn3)
        {
            this.Font = SystemFonts.MessageBoxFont;
            this.ForeColor = SystemColors.WindowText;
            this.InitializeComponent();
            this.Text = title;
            this.Header.Text = title;
            this.HeaderMessage.Text = string.IsNullOrEmpty(MessageText) ? string.Empty : MessageText;
            this.pictureBox1.Image = iconSet;
            int num1 = 0;
            if (!string.IsNullOrEmpty(btn3))
                this.AddButton(btn3, num1++, DialogResult.Cancel);
            if (!string.IsNullOrEmpty(btn2))
                this.AddButton(btn2, num1++, DialogResult.No);
            if (string.IsNullOrEmpty(btn1))
                return;
            string Name = btn1;
            int TabIndex = num1;
            int num2 = 1;
            int num3 = TabIndex + num2;
            int num4 = 6;
            this.AddButton(Name, TabIndex, (DialogResult)num4);
        }

        private void AddButton(string Name, int TabIndex, DialogResult res)
        {
            Button btn = new Button();
            btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn.BackColor = Color.FromArgb(192, 64, 0);
            btn.DialogResult = DialogResult.Cancel;
            btn.Font = new Font("Times New Roman", 14f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            btn.ForeColor = Color.White;
            btn.Name = Name;
            btn.Size = new Size(100, 40);
            btn.TabIndex = TabIndex;
            btn.BackColor = Color.Black;
           btn.Text = Name;
            btn.DialogResult = res;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Click += new EventHandler(this.button_Click);
            btn.FlatStyle = FlatStyle.Flat;
            this.BTN_Panel.Controls.Add((Control)btn);
        }

        private void button_Click(object sender, EventArgs e)
        {
            --RedMessageBox.MsgCounts;
            this.DialogResult = ((Button)sender).DialogResult;
        }

        private void MessageBoxEx_Click(object Sender, EventArgs e)
        {
            if (this.OnMessageClose == null)
                return;
            this.OnMessageClose(this.DialogResult, this.m_store);
        }


        public static DialogResult Show(string Text, int msgid)
        {
            if (!RedMessageBox.CustomMsg)
                return MessageBox.Show(Text, Application.ProductName);
            if (msgid > 0)
            {
                try
                {
                    //if (RedMessage.get_IsInit())
                    //{
                    //  Text = RedMessage.get_MsgList()[(object) msgid].ToString();
                    //  if (RedMessage.get_PrevFileIsNum() && RedMessage.get_PrevFile() != 0)
                    //    Text = RedMessage.get_PrevFile().ToString() + " " + Text;
                    //  else if (RedMessage.get_PrevFile() != 0)
                    //    Text = RedMessage.get_MsgList()[(object) RedMessage.get_PrevFile()].ToString() + " " + Text;
                    //  if (RedMessage.get_NextFileIsNum() && RedMessage.get_NextFile() != 0)
                    //    Text = Text + " " + RedMessage.get_NextFile().ToString();
                    //  else if (RedMessage.get_NextFile() != 0)
                    //    Text = Text + " " + RedMessage.get_MsgList()[(object) RedMessage.get_NextFile()].ToString();
                    //  RedMessage.Play(msgid);
                    //}
                }
                catch
                {
                }
            }
            using (RedMessageBox messageBoxEx = new RedMessageBox(RedMessageBox.MsgBoxTitle, Text, RedMessageBox.MsgBoxLogo, RedMessageBox.RedMessageBoxButtons.OK))
            {
                ++RedMessageBox.MsgCounts;
                DialogResult dialogResult = messageBoxEx.ShowDialog();
                messageBoxEx.Font.Dispose();
                messageBoxEx.Dispose();
                return dialogResult;
            }
        }

        public static DialogResult Show(string Text, string Caption, RedMessageBox.RedMessageBoxButtons btns, int msgid)
        {
            if (RedMessageBox.CustomMsg)
            {
                if (msgid > 0)
                {
                    try
                    {
                        //if (RedMessage.get_IsInit())
                        //{
                        //  Text = RedMessage.get_MsgList()[(object) msgid].ToString();
                        //  if (RedMessage.get_PrevFileIsNum() && RedMessage.get_PrevFile() != 0)
                        //    Text = RedMessage.get_PrevFile().ToString() + " " + Text;
                        //  else if (RedMessage.get_PrevFile() != 0)
                        //    Text = RedMessage.get_MsgList()[(object) RedMessage.get_PrevFile()].ToString() + " " + Text;
                        //  if (RedMessage.get_NextFileIsNum() && RedMessage.get_NextFile() != 0)
                        //    Text = Text + " " + RedMessage.get_NextFile().ToString();
                        //  else if (RedMessage.get_NextFile() != 0)
                        //    Text = Text + " " + RedMessage.get_MsgList()[(object) RedMessage.get_NextFile()].ToString();
                        //  RedMessage.Play(msgid);
                        //}
                    }
                    catch
                    {
                    }
                }
                using (RedMessageBox messageBoxEx = new RedMessageBox(Caption, Text, RedMessageBox.MsgBoxLogo, btns))
                {
                    ++RedMessageBox.MsgCounts;
                    DialogResult dialogResult = messageBoxEx.ShowDialog();
                    messageBoxEx.Font.Dispose();
                    messageBoxEx.Dispose();
                    return dialogResult;
                }
            }
            else
            {
                MessageBoxButtons buttons;
                switch (btns)
                {
                    case RedMessageBox.RedMessageBoxButtons.AbortRetryIgnore:
                        buttons = MessageBoxButtons.AbortRetryIgnore;
                        break;
                    case RedMessageBox.RedMessageBoxButtons.OK:
                        buttons = MessageBoxButtons.OK;
                        break;
                    case RedMessageBox.RedMessageBoxButtons.OKCancel:
                        buttons = MessageBoxButtons.OKCancel;
                        break;
                    case RedMessageBox.RedMessageBoxButtons.RetryCancel:
                        buttons = MessageBoxButtons.RetryCancel;
                        break;
                    case RedMessageBox.RedMessageBoxButtons.YesNo:
                        buttons = MessageBoxButtons.YesNo;
                        break;
                    case RedMessageBox.RedMessageBoxButtons.YesNoCancel:
                        buttons = MessageBoxButtons.YesNoCancel;
                        break;
                    case RedMessageBox.RedMessageBoxButtons.PauseStopCancel:
                        buttons = MessageBoxButtons.AbortRetryIgnore;
                        break;
                    case RedMessageBox.RedMessageBoxButtons.LoadNewCancel:
                        buttons = MessageBoxButtons.YesNoCancel;
                        break;
                    case RedMessageBox.RedMessageBoxButtons.Start:
                        buttons = MessageBoxButtons.OK;
                        break;
                    default:
                        buttons = MessageBoxButtons.OKCancel;
                        break;
                }
                return MessageBox.Show(Text, Caption, buttons);
            }
        }

        public static DialogResult Show(string Text, string Caption, RedMessageBox.RedMessageBoxButtons btns, int msgid, Point location)
        {
            if (RedMessageBox.CustomMsg)
            {
                if (msgid > 0)
                {
                    try
                    {
                        //if (RedMessage.get_IsInit())
                        //{
                        //  Text = RedMessage.get_MsgList()[(object) msgid].ToString();
                        //  if (RedMessage.get_PrevFileIsNum() && RedMessage.get_PrevFile() != 0)
                        //    Text = RedMessage.get_PrevFile().ToString() + " " + Text;
                        //  else if (RedMessage.get_PrevFile() != 0)
                        //    Text = RedMessage.get_MsgList()[(object) RedMessage.get_PrevFile()].ToString() + " " + Text;
                        //  if (RedMessage.get_NextFileIsNum() && RedMessage.get_NextFile() != 0)
                        //    Text = Text + " " + RedMessage.get_NextFile().ToString();
                        //  else if (RedMessage.get_NextFile() != 0)
                        //    Text = Text + " " + RedMessage.get_MsgList()[(object) RedMessage.get_NextFile()].ToString();
                        //  RedMessage.Play(msgid);
                        //}
                    }
                    catch
                    {
                    }
                }
                using (RedMessageBox messageBoxEx = new RedMessageBox(Caption, Text, RedMessageBox.MsgBoxLogo, btns))
                {
                    ++RedMessageBox.MsgCounts;
                    messageBoxEx.StartPosition = FormStartPosition.Manual;
                    messageBoxEx.Location = location;
                    DialogResult dialogResult = messageBoxEx.ShowDialog();
                    messageBoxEx.Font.Dispose();
                    messageBoxEx.Dispose();
                    return dialogResult;
                }
            }
            else
            {
                MessageBoxButtons buttons;
                switch (btns)
                {
                    case RedMessageBox.RedMessageBoxButtons.AbortRetryIgnore:
                        buttons = MessageBoxButtons.AbortRetryIgnore;
                        break;
                    case RedMessageBox.RedMessageBoxButtons.OK:
                        buttons = MessageBoxButtons.OK;
                        break;
                    case RedMessageBox.RedMessageBoxButtons.OKCancel:
                        buttons = MessageBoxButtons.OKCancel;
                        break;
                    case RedMessageBox.RedMessageBoxButtons.RetryCancel:
                        buttons = MessageBoxButtons.RetryCancel;
                        break;
                    case RedMessageBox.RedMessageBoxButtons.YesNo:
                        buttons = MessageBoxButtons.YesNo;
                        break;
                    case RedMessageBox.RedMessageBoxButtons.YesNoCancel:
                        buttons = MessageBoxButtons.YesNoCancel;
                        break;
                    case RedMessageBox.RedMessageBoxButtons.PauseStopCancel:
                        buttons = MessageBoxButtons.AbortRetryIgnore;
                        break;
                    case RedMessageBox.RedMessageBoxButtons.LoadNewCancel:
                        buttons = MessageBoxButtons.YesNoCancel;
                        break;
                    case RedMessageBox.RedMessageBoxButtons.Start:
                        buttons = MessageBoxButtons.OK;
                        break;
                    default:
                        buttons = MessageBoxButtons.OKCancel;
                        break;
                }
                return MessageBox.Show(Text, Caption, buttons);
            }
        }

        public static DialogResult Show(string Text, string Caption, string btn1, string btn2, string btn3, int msgid)
        {
            if (!RedMessageBox.CustomMsg)
                return MessageBox.Show(Text, Caption, MessageBoxButtons.YesNoCancel);
            if (msgid > 0)
            {
                try
                {
                    //if (RedMessage.get_IsInit())
                    //{
                    //  Text = RedMessage.get_MsgList()[(object) msgid].ToString();
                    //  if (RedMessage.get_PrevFileIsNum() && RedMessage.get_PrevFile() != 0)
                    //    Text = RedMessage.get_PrevFile().ToString() + " " + Text;
                    //  else if (RedMessage.get_PrevFile() != 0)
                    //    Text = RedMessage.get_MsgList()[(object) RedMessage.get_PrevFile()].ToString() + " " + Text;
                    //  if (RedMessage.get_NextFileIsNum() && RedMessage.get_NextFile() != 0)
                    //    Text = Text + " " + RedMessage.get_NextFile().ToString();
                    //  else if (RedMessage.get_NextFile() != 0)
                    //    Text = Text + " " + RedMessage.get_MsgList()[(object) RedMessage.get_NextFile()].ToString();
                    //  RedMessage.Play(msgid);
                    //}
                }
                catch
                {
                }
            }
            using (RedMessageBox messageBoxEx = new RedMessageBox(Caption, Text.ToUpper(), (Image)null, btn1, btn2, btn3))
            {
                ++RedMessageBox.MsgCounts;
                DialogResult dialogResult = messageBoxEx.ShowDialog();
                messageBoxEx.Font.Dispose();
                messageBoxEx.Dispose();
                return dialogResult;
            }
        }

        public void ShowAsync(string Text, string Caption, RedMessageBox.RedMessageBoxButtons btns, object param)
        {
            using (RedMessageBox messageBoxEx = new RedMessageBox(Caption, Text, RedMessageBox.MsgBoxLogo, btns))
            {
                ++RedMessageBox.MsgCounts;
                messageBoxEx.TopLevel = true;
                messageBoxEx.TopMost = true;
                messageBoxEx.Parent = (Control)this;
                this.m_store = param;
                ((Control)messageBoxEx).Show();
            }
        }

        public delegate void MessageHandler(DialogResult res, object param);

        public enum RedMessageBoxIcon
        {
            Error,
            Explorer,
            Find,
            Information,
            Mail,
            Media,
            Print,
            Question,
            RecycleBinEmpty,
            RecycleBinFull,
            Stop,
            User,
            Warning,
        }

        public enum RedMessageBoxButtons
        {
            AbortRetryIgnore,
            OK,
            OKCancel,
            RetryCancel,
            YesNo,
            YesNoCancel,
            PauseStopCancel,
            LoadNewCancel,
            Start,
        }
    }
}