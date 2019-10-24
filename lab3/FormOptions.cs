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
    public partial class FormOptions : Form
    {
        private const string RAND = "RAND";
        private const string NORAND = "NORAND";

        private const int x = 10;
        private const int y = 220;
        private const int width = 60;
        private const int height = 25;
        // For tune parameters of dots
        GroupBox grDot;
        Button buttonColorDot;
        Label labelColorDot;
        TrackBar tbDotSize;
        // For tune parameters of Line
        GroupBox grLine;
        Button buttonColorLine;
        Label labelColorLine;
        TrackBar tbLineSize;
        // move control
        Button buttonRandom, buttonDetermine;
        // for draw square around curve
        Point[] previewPlace = {new Point(10, 10), new Point(200, 10), new Point(200, 200), new Point(10, 200)};
        // for preview curve
        Point[] points = { new Point(190, 40), new Point(110, 50), new Point(70, 170) };
        // some pens
        
        Pen grayPen = new Pen(Color.Gray, 1f);
        
        // the changing pens
        Pen dotPen = new Pen(Color.Black, 2f);
        Pen linePen = new Pen(Color.Black, 2f);

        SolidBrush dotBrush = new SolidBrush(Color.Black);
        Size dotSize = new Size(3, 3);

        public FormOptions()
        {
            FormBorderStyle = FormBorderStyle.FixedToolWindow;   
            InitializeComponent();
            addDotsControls();
            addLineControls();
            addMoveControl();            
        }

        void addDotsControls()
        {
            // For tune parameters of dots
            grDot = new GroupBox();
            grDot.Location = new Point(5, 215);
            grDot.Size = new Size(210, 65);
            grDot.Text = "Dots options";

            int x = 10;
            int y = 20;

            buttonColorDot = new Button();
            grDot.Controls.Add(buttonColorDot);
            buttonColorDot.Text = "Color";
            buttonColorDot.Location = new Point(x, y);
            buttonColorDot.Size = new Size(width, height);
            buttonColorDot.Click += new EventHandler(buttonDotColorHandler);


            labelColorDot = new Label();
            grDot.Controls.Add(labelColorDot);
            labelColorDot.Location = new Point(2 * x + width, y);
            labelColorDot.Size = new Size(height, height);
            labelColorDot.BackColor = Color.Black;


            tbDotSize = new TrackBar();
            grDot.Controls.Add(tbDotSize);
            tbDotSize.Location = new Point(3 * x + width + height, y);
            tbDotSize.Size = new Size(70, 25);
            tbDotSize.Maximum = 15;
            tbDotSize.Minimum = 2;
            tbDotSize.TickFrequency = 1;
            tbDotSize.LargeChange = 2;
            tbDotSize.SmallChange = 2;
            tbDotSize.Scroll += new EventHandler(tbDotSizeHandler);

            Controls.Add(grDot);
        }

        void addLineControls()
        {
            // For tune parameters of Line
            grLine = new GroupBox();
            grLine.Location = new Point(5, 280);
            grLine.Size = new Size(210, 65);
            grLine.Text = "Line options";

            int x = 10;
            int y = 20;

            // button
            buttonColorLine = new Button();
            grLine.Controls.Add(buttonColorLine);
            buttonColorLine.Text = "Color";
            buttonColorLine.Location = new Point(x, y);
            buttonColorLine.Size = new Size(width, height);
            buttonColorLine.Click += new EventHandler(buttonLineColorHandler);
            // colored label
            labelColorLine = new Label();
            grLine.Controls.Add(labelColorLine);
            labelColorLine.Location = new Point(2 * x + width, y);
            labelColorLine.Size = new Size(height, height);
            labelColorLine.BackColor = Color.Black;
            // Scroll bar
            tbLineSize = new TrackBar();
            grLine.Controls.Add(tbLineSize);
            tbLineSize.Location = new Point(3 * x + width + height, y);
            tbLineSize.Size = new Size(70, 25);
            tbLineSize.Maximum = 15;
            tbLineSize.Minimum = 2;
            tbLineSize.TickFrequency = 1;
            tbLineSize.LargeChange = 2;
            tbLineSize.SmallChange = 2;
            tbLineSize.Scroll += new EventHandler(tbLineSizeHandler);

            Controls.Add(grLine);
        }

        void addMoveControl()
        {
            Size buttonSize = new Size(105, 25);
            buttonRandom = new Button();
            Controls.Add(buttonRandom);
            buttonRandom.Text = "Random";
            buttonRandom.Name = RAND;
            buttonRandom.TextAlign = ContentAlignment.MiddleRight;
            buttonRandom.Image = lab3.Properties.Resources.buttonUnset;
            buttonRandom.ImageAlign = ContentAlignment.MiddleLeft;
            
            buttonRandom.Size = buttonSize;
            buttonRandom.Location = new Point(5, 350);
            buttonRandom.Click += new EventHandler(changeModeHandler);

            buttonDetermine = new Button();
            Controls.Add(buttonDetermine);
            buttonDetermine.Text = "Save form";
            buttonDetermine.TextAlign = ContentAlignment.MiddleRight;
            buttonDetermine.Name = NORAND;
            buttonDetermine.Image = lab3.Properties.Resources.buttonSet;
            buttonDetermine.ImageAlign = ContentAlignment.MiddleLeft;
            buttonDetermine.Size = buttonSize;
            buttonDetermine.Location = new Point(110, 350);
            buttonDetermine.Click += new EventHandler(changeModeHandler);
        }

        // set color for dots
        protected void buttonDotColorHandler(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
                Painter.DotBrush.Color = dotBrush.Color = labelColorDot.BackColor = colorDialog.Color;

            Refresh();
        }

        // set size for dots
        protected void tbDotSizeHandler(object sender, EventArgs e)
        {
            Painter.DotRadius = tbDotSize.Value;
            dotSize = new Size(tbDotSize.Value, tbDotSize.Value);
            Refresh();
        }

        // set color for lines
        protected void buttonLineColorHandler(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
                Painter.LinePen.Color = linePen.Color = labelColorLine.BackColor = colorDialog.Color;

            Refresh();
        }

        // set size for lines
        protected void tbLineSizeHandler(object sender, EventArgs e)
        {
            Painter.LinePen.Width = linePen.Width = tbLineSize.Value;
            Refresh();
        }

        private void changeModeHandler(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Name.Equals(RAND))
            {
                buttonRandom.Image = lab3.Properties.Resources.buttonSet;
                buttonDetermine.Image = lab3.Properties.Resources.buttonUnset;
                Painter.IsRandomMove = true;
            }
            else
            {
                buttonRandom.Image = lab3.Properties.Resources.buttonUnset;  
                buttonDetermine.Image = lab3.Properties.Resources.buttonSet;
                Painter.IsRandomMove = false;
            }
        }

        // hide form on close "X"
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // draw place for preview of curve
            e.Graphics.DrawRectangle(grayPen, new Rectangle(10, 10, 200, 200) );

            // draw line
            e.Graphics.DrawCurve(linePen, points);

            // draw dots
            for (int i = 0; i < points.Length; i++)
                //e.Graphics.DrawEllipse(dotPen, new Rectangle(points[i], dotSize));
                e.Graphics.FillEllipse(dotBrush, points[i].X - dotSize.Width / 2, points[i].Y - dotSize.Height / 2, dotSize.Width, dotSize.Height);
        }
    }
}
