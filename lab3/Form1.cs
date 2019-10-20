using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        private Button[] buttons;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Curves";
            addButtons();
            
        }

        private void addButtons()
        {
            // добавить на форму 8 кнопок управления 
            buttons = new Button[8];
            int x, y;
            x = y = 10;
            int width = 60;
            int height = 20;

            for (int i = 0; i < 8; i++)
            {
                buttons[i] = new Button();
                buttons[i].Size = new Size(width, height);
                buttons[i].Text = "button " + (i + 1);
                buttons[i].Location = new Point(x + (width + x) * i, y);
                this.Controls.Add(buttons[i]);
            }

            //int horizotal = 30;
            //int vertical = 30;

            //Button button1 = new Button();
            //button1.Size = new Size(60, 23);
            //button1.Text = "Press me";
            //button1.Location = new Point(horizotal, vertical);

            //this.Controls.Add(button1);

            
        }

       
    }
}
