using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace lab5
{
    public static class PopUp
    {
        private const int INDENT_BOTTOM = 70;
        private const float FONT_SIZE = 9;
        private const string FONT_NAME = "Microsoft Sans Serif";

        private static Form messageForm = new Form();
        private static Label text = new Label();
        private static Button buttonOK = new Button();
        private static Button buttonYES = new Button();
        private static Button buttonNO = new Button();
        private static bool isYesAnswer = false;

        static PopUp()
        {
            // Form tune
            messageForm.Size = new Size(300, 130);
            messageForm.StartPosition = FormStartPosition.CenterParent;
            messageForm.Text = "Message";
            messageForm.MinimizeBox = false;
            messageForm.MaximizeBox = false;
            messageForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            messageForm.ShowIcon = false;
            buttonYES.Text = "Yes";
            buttonYES.Size = new Size(80, 25);
            buttonNO.Text = "No";
            buttonNO.Size = new Size(80, 25);
            buttonOK.Text = "OK";
            buttonOK.Size = new Size(80, 25);
            // set Handlers
            buttonOK.Click += new EventHandler(buttonNoHandler);
            buttonYES.Click += new EventHandler(buttonYesHandler);
            buttonNO.Click += new EventHandler(buttonNoHandler);
        }

        public static void Show(System.Windows.Forms.IWin32Window owner)
        {
            messageForm.ShowDialog(owner);
        }

        public static void Show(IWin32Window owner, string message)
        {
            messageForm.Controls.Clear();
            messageForm.Size = new Size(message.Length * 7, 130);
            addText(message);
            addButtonOK();
            messageForm.ShowDialog(owner);
        }

        public static bool ShowYesNo(IWin32Window owner, string message)
        {
            messageForm.Controls.Clear();
            addText(message);
            addButtonsYesNo();
            messageForm.ShowDialog(owner);
            return isYesAnswer;
        }

        private static void addText(string message)
        {
            messageForm.Controls.Add(text);
            text.Location = new System.Drawing.Point(10, 10);
            text.Size = new System.Drawing.Size((int)(message.Length * FONT_SIZE), (int)FONT_SIZE * 2);
            text.Font = new Font(FONT_NAME, FONT_SIZE);
            text.Text = message;
        }

        private static void addButtonOK()
        {
            // OK
            messageForm.Controls.Add(buttonOK);
            buttonOK.Location = new Point(messageForm.Width / 2 - buttonOK.Width / 2, messageForm.Height - INDENT_BOTTOM);
        }

        private static void addButtonsYesNo()
        {
            // YES
            messageForm.Controls.Add(buttonYES);
            buttonYES.Location = new Point(messageForm.Width / 2 - (buttonYES.Width + 2), messageForm.Height - INDENT_BOTTOM);
            // NO
            messageForm.Controls.Add(buttonNO);
            buttonNO.Location = new Point(messageForm.Width / 2 + 2, messageForm.Height - INDENT_BOTTOM);
        }

        private static void buttonYesHandler(object sender, EventArgs e)
        {
            isYesAnswer = true;
            messageForm.Close();
        }

        private static void buttonNoHandler(object sender, EventArgs e)
        {
            isYesAnswer = false;
            messageForm.Close();
        }
    }
}
