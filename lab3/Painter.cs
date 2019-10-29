using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    static class Painter
    {
        private static enumMode m_drawMode;
        //
        // for dots draw
        private static SolidBrush m_dotBrush = new SolidBrush(Color.Black);
        private static int m_dotRadius = 3;
        //
        // for line draw
        private static Pen m_linePen = new Pen(Color.Black, 2f);
        private static SolidBrush m_lineBrush = new SolidBrush(Color.Black);
        //
        // for auto move
        public static bool IsRandomMove { set; get; } = false;
        private static int m_dy = 0;
        private static int m_dx = 1;



        public static enumMode DrawMode
        {
            get { return m_drawMode; }
            set { m_drawMode = value; }
        }

        public static SolidBrush DotBrush
        {
            get { return m_dotBrush; }
            set { m_dotBrush = value; }
        }

        public static int DotRadius
        {
            get { return m_dotRadius; }
            set { m_dotRadius = value; }
        }

        public static Pen LinePen
        {
            get { return m_linePen; }
            set { m_linePen = value; }
        }

        public static SolidBrush LineBrush
        {
            get { return m_lineBrush; }
            set { m_lineBrush = value; }
        }

        public static void draw(PaintEventArgs e)
        {
            switch (m_drawMode)
            {
                //case enumMode.DOTS:
                //    drawDots(e);
                //    break;
                //case enumMode.MOVING:
                //    break;
                case enumMode.CURVE:
                    DrawCurve(e);
                    break;
                case enumMode.BROKEN:
                    DrawBroken(e);
                    break;
                case enumMode.BEZIER:
                    DrawBezier(e);
                    break;
                case enumMode.FILLED:
                    DrawFilled(e);
                    break;
            }
            DrawDots(e);
        }

        private static void DrawDots(PaintEventArgs e)
        {
            Point[] p = Curve.GetInstance().GetDots();
            for (int i = 0; i < p.Length; i++)
                e.Graphics.FillEllipse(m_dotBrush, p[i].X - (int)(m_dotRadius / 2), 
                    p[i].Y - (int)(m_dotRadius / 2), m_dotRadius, m_dotRadius);
        }

        private static void DrawCurve(PaintEventArgs e)
        {
            Point[] p = Curve.GetInstance().GetDots();

            if (p.Length < 3)
                return;

            e.Graphics.DrawClosedCurve(m_linePen, p);
        }

        private static void DrawBroken(PaintEventArgs e)
        {
            Point[] p = Curve.GetInstance().GetDots();

            if (p.Length < 2)
                return;

            e.Graphics.DrawPolygon(m_linePen, p);
        }

        private static void DrawBezier(PaintEventArgs e)
        {
            Point[] p = Curve.GetInstance().GetDots();

            if (p.Length == 0 || (p.Length != 1 + (int)(p.Length / 3) * 3))
                return;

            e.Graphics.DrawBeziers(m_linePen, p);
        }

        private static void DrawFilled(PaintEventArgs e)
        {
            Point[] p = Curve.GetInstance().GetDots();

            if (p.Length == 0)
                return;

            e.Graphics.FillClosedCurve(m_lineBrush, p);
        }

        private static int GetExtremeTopY()
        {
            int y = Curve.GetInstance()[0].Y;
            for (int i = 1; i < Curve.GetInstance().Count; i++)
            {
                if (y > Curve.GetInstance()[i].Y)
                    y = Curve.GetInstance()[i].Y;
            }
            return y;
        }

        private static int GetExtremeDownY()
        {
            int y = Curve.GetInstance()[0].Y;
            for (int i = 1; i < Curve.GetInstance().Count; i++)
            {
                if (y < Curve.GetInstance()[i].Y)
                    y = Curve.GetInstance()[i].Y;
            }
            return y;
        }

        private static int GetExtremeLeftX()
        {
            int x = Curve.GetInstance()[0].X;
            for (int i = 1; i < Curve.GetInstance().Count; i++)
            {
                if (x > Curve.GetInstance()[i].X)
                    x = Curve.GetInstance()[i].X;
            }
            return x;
        }

        private static int GetExtremeRightX()
        {
            int x = Curve.GetInstance()[0].X;
            for (int i = 1; i < Curve.GetInstance().Count; i++)
            {
                if (x < Curve.GetInstance()[i].X)
                    x = Curve.GetInstance()[i].X;
            }
            return x;
        }

        public static void ChangeDirect(Keys key)
        {
            switch (key)
            {
                case Keys.Up: m_dy--; break;
                case Keys.Down: m_dy++; break;
                case Keys.Left: m_dx--; break;
                case Keys.Right: m_dx++; break;
            }
        }

        // moving speed Plus
        public static void speedAdd()
        {
            if (m_dy != 0)
                m_dy = (m_dy > 0) ? ++m_dy : --m_dy;   
            if (m_dx != 0)
                m_dx = (m_dx > 0) ? ++m_dx : --m_dx;
        }

        // moving speed Minus
        public static void speedSub()
        {
            if (m_dy != 0)
                m_dy = (m_dy < 0) ? ++m_dy : --m_dy;
            if (m_dx != 0)
                m_dx = (m_dx < 0) ? ++m_dx : --m_dx;
        }

        private static void RandomMove (Size size)
        {
            int dx, dy;
            Random r = new Random();
            for (int i = 0; i < Curve.GetInstance().Count; i++)
            {
                dy = r.Next(-10, 10);
                dx = r.Next(-10, 10);

                if (Curve.GetInstance()[i].X + dx < 5 || Curve.GetInstance()[i].X + dx > (size.Width - 10))
                    dx = -dx;
                if (Curve.GetInstance()[i].Y + dy < 45 || Curve.GetInstance()[i].Y + dy > (size.Height - 30))
                    dy = -dy;

                Curve.GetInstance()[i] = new Point(Curve.GetInstance()[i].X + dx, Curve.GetInstance()[i].Y + dy);
            }
            return;
        }

        public static void Move(Keys key, Size size)
        {
            if (Curve.GetInstance().Count == 0)
                return;

            if (IsRandomMove)
            {
                RandomMove(size);
                return;
            }
            
            // https: //stackoverflow. com /questions/30554883/windows-forms-sizes-not-matching
            if ( (GetExtremeTopY() + m_dy) < 45 || (GetExtremeDownY() + m_dy) > (size.Height - 30))
                m_dy = -m_dy;
            if ((GetExtremeLeftX() + m_dx) < 5 || (GetExtremeRightX() + m_dx) > (size.Width - 10))
                m_dx = -m_dx;

            ChangeDots(m_dx, m_dy);
        }

        private static void ChangeDots(int dx, int dy)
        {
            for (int i = 0; i < Curve.GetInstance().Count; i++)
                Curve.GetInstance()[i] = new Point(Curve.GetInstance()[i].X + dx, Curve.GetInstance()[i].Y + dy);
        }
    }
}
