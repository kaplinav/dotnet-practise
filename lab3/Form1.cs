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
    enum enumMode
    {
        DOTS,
        MOVING,
        CURVE,
        BROKEN,
        BEZIER,
        FILLED,
        NONE
    }

    public partial class Form1 : Form
    {

        private const int controlsCount = 8;
        private const int x = 10;
        private const int y = 10;
        private const int width = 60;
        private const int height = 25;

        // form for tune lines and dots
        FormOptions formOptions = new FormOptions();
        // Buttons
        private ButtonBase[] controls;
        // button "Dots"
        bool buttonDotsIsPressed;
        // button "Move"
        bool buttonMoveIsPressed;
        // true when drag the dot
        bool IsDragging;
        int IndexOfDot;

        Size FormSize;

        Timer moveTimer;
        Keys Direct = Keys.Up;

        public Form1(Size formSize)
        {
            InitializeComponent();
            this.Text = "Curves";
            Painter.DrawMode = enumMode.DOTS;
            this.FormSize = formSize;
            
            addControls();
            moveTimer = new Timer();
            moveTimer.Interval = 30;
            moveTimer.Tick += new EventHandler(TimerTickHandler);
            MouseClick += new MouseEventHandler(mouseClick);
            MouseDown += new MouseEventHandler(mouseDownHandler);
            MouseMove += new MouseEventHandler(mouseMoveHandler);
            MouseUp += new MouseEventHandler(mouseUpHandler);
            KeyPreview = true;
            KeyDown += new KeyEventHandler(formKeyHandler);
            ResizeEnd += new EventHandler(formResizeHandler);
        }

        private void addControls()
        {
            // добавить на форму 8 кнопок управления 
            controls = new ButtonBase[controlsCount];
            for (int i = 0; i < controlsCount; i++)
            {
                controls[i] = new Button();
                switch (i)
                {
                    case 0:
                        controls[i].Name = enumMode.DOTS.ToString();
                        controls[i].Text = "Dots";
                        controls[i].TextAlign = ContentAlignment.MiddleRight;
                        controls[i].Image = lab3.Properties.Resources.buttonUnset;
                        controls[i].ImageAlign = ContentAlignment.MiddleLeft;
                        controls[i].Click += new EventHandler(buttonDotsMoveHandler);
                        break;
                    case 1:
                        controls[i].Name = enumMode.MOVING.ToString();
                        controls[i].Text = "Moving";
                        controls[i].TextAlign = ContentAlignment.MiddleRight;
                        controls[i].Image = lab3.Properties.Resources.buttonUnset;
                        controls[i].ImageAlign = ContentAlignment.MiddleLeft;
                        controls[i].Click += new EventHandler(buttonDotsMoveHandler);
                        break;
                    case 2:
                        controls[i].Name = enumMode.CURVE.ToString();
                        controls[i].Text = "Curve";
                        controls[i].Click += new EventHandler(buttonClickHandler);
                        break;
                    case 3:
                        controls[i].Name = enumMode.BROKEN.ToString();
                        controls[i].Text = "Broken";
                        controls[i].Click += new EventHandler(buttonClickHandler);
                        break;
                    case 4:
                        controls[i].Name = enumMode.BEZIER.ToString();
                        controls[i].Text = "Bezier";
                        controls[i].Click += new EventHandler(buttonClickHandler);
                        break;
                    case 5:
                        controls[i].Name = enumMode.FILLED.ToString();
                        controls[i].Text = "Filled";
                        controls[i].Click += new EventHandler(buttonClickHandler);
                        break;
                    case 6:
                        controls[i].Text = "Clear";
                        controls[i].Click += new EventHandler(buttonClickHandler);
                        break;
                    case 7:
                        controls[i].Text = "Options";
                        controls[i].Click += new EventHandler(buttonClickHandler);
                        break;
                    default:
                        controls[i].Text = "button" + (i + 1);
                        break;
                }
                controls[i].Size = new Size(width, height);
                controls[i].Location = new Point(x + (width + x) * i, y);
                this.Controls.Add(controls[i]);
            }
        }

        void buttonDotsMoveHandler(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            switch (b.Text)
            {
                case "Dots":
                    if (buttonDotsIsPressed)
                    {
                        b.Image = lab3.Properties.Resources.buttonUnset;
                        buttonDotsIsPressed = false;
                    }
                    else
                    {
                        b.Image = lab3.Properties.Resources.buttonSet;
                        buttonDotsIsPressed = true;
                        //Painter.DrawMode = enumMode.DOTS;
                        // button "Moving"
                        controls[1].Image = lab3.Properties.Resources.buttonUnset;
                        buttonMoveIsPressed = false;
                        moveTimer.Stop();
                    }
                    break;

                case "Moving":
                    if (buttonMoveIsPressed)
                    {
                        b.Image = lab3.Properties.Resources.buttonUnset;
                        buttonMoveIsPressed = false;

                        moveTimer.Stop();

                        //Painter.DrawMode = enumMode.DOTS;
                    }
                    else
                    {
                        b.Image = lab3.Properties.Resources.buttonSet;
                        buttonMoveIsPressed = true;

                        moveTimer.Start();

                        //Painter.DrawMode = enumMode.MOVING;
                        // button "Dots"
                        controls[0].Image = lab3.Properties.Resources.buttonUnset;
                        buttonDotsIsPressed = false;
                    }
                    break;
            }

            //Refresh();
        }

        void buttonClickHandler(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            switch (b.Text)
            {
                case "Curve":
                    Painter.DrawMode = enumMode.CURVE;
                    break;
                case "Broken":
                    Painter.DrawMode = enumMode.BROKEN;
                    break;
                case "Bezier":
                    Painter.DrawMode = enumMode.BEZIER;
                    break;
                case "Filled":
                    Painter.DrawMode = enumMode.FILLED;
                    break;
                case "Clear":
                    Curve.GetInstance().Clear();
                    moveTimer.Stop();
                    break;
                case "Options":
                    moveTimer.Stop();
                    formOptions.Size = new Size(230, 410);
                    formOptions.StartPosition = FormStartPosition.CenterParent;
                    formOptions.ShowDialog(this);
                    break;
            }
            Refresh();
        }

        private void formKeyHandler(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // clear by ESC key
                case Keys.Escape:
                    Curve.GetInstance().Clear();
                    break;
                case Keys.Space:
                    Button b = (Button)controls[1];
                    b.PerformClick();
                    break;
                case Keys.OemMinus:
                case Keys.Subtract:
                    Painter.Speed = Painter.Speed == 1 ? 1 : --Painter.Speed;
                    break;
                case Keys.Oemplus:
                case Keys.Add:
                    Painter.Speed++;
                    break;
            }
            Refresh();
            e.Handled = true;
        }

        private void formResizeHandler(object sender, EventArgs e)
        {
            Form f = (Form)sender;
            FormSize = f.Size;
        }

        // add new dots
        void mouseClick(object sender, MouseEventArgs e)
        {
            if (buttonDotsIsPressed)
            {
                if (e.Y > 2 * y + height)
                {
                    Curve.GetInstance().AddDot(e.X, e.Y);
                    Refresh();
                }
            }
        }

        // try selecting dot
        void mouseDownHandler(object sender, MouseEventArgs e)
        {
            for(int i = 0; i < Curve.GetInstance().Count; i++)
            {
                if (Math.Abs(Curve.GetInstance()[i].X - e.X) <= 5 &&
                    Math.Abs(Curve.GetInstance()[i].Y - e.Y) <= 5)
                {
                    IndexOfDot = i;
                    IsDragging = true;
                }
            }
        }

        // moving the dot
        void mouseMoveHandler(object sender, MouseEventArgs e)
        {
            if (IsDragging)
            {
                Curve.GetInstance()[IndexOfDot] = new Point(e.X, e.Y);
                Refresh();
            }
        }

        // set the dot
        void mouseUpHandler(object sender, MouseEventArgs e)
        {
            IsDragging = false;
            Refresh();
        }

        private void TimerTickHandler(object sender, EventArgs e)
        {
            Timer t = (Timer)sender;
            Painter.Move(Direct, FormSize);
            Refresh();
        }

        // TRUE if pressed key UP, DOWN, LEFT, RIGHT
        private bool IsDirectKey(Keys key)
        {
            bool IsDirectKey = false;
            switch (key)
            {
                case Keys.Up: IsDirectKey = true; break;
                case Keys.Down: IsDirectKey = true; break;
                case Keys.Left: IsDirectKey = true; break;
                case Keys.Right: IsDirectKey = true; break;
            }
            return IsDirectKey;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (IsDirectKey(keyData))
            {
                if (buttonMoveIsPressed)
                {
                    Direct = keyData;
                    Painter.ChangeDirect(keyData);
                }
                else
                {
                    Painter.Move(keyData, FormSize);
                    Refresh();
                    
                }
                return true;
            }
                
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Painter.draw(e);   
        }
    }
}
