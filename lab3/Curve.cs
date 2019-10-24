using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Curve
    {
        private static Curve curve = new Curve();
        private Point[] points;
        private int initialSize = 10;
        // count of added dots
        public int Count { get; private set; } = 0;

        public static Curve GetInstance()
        {
            return curve;
        }

        public void AddDot(int x, int y)
        {
            if (Count == points.Length)
                Resize();

            for (int i = 0; i < points.Length; i++)
            {
                if (points[i].IsEmpty)
                {
                    points[i].X = x;
                    points[i].Y = y;
                    Count++;
                    return;
                }
            }
        }

        public void Clear()
        {
            Array.Clear(points, 0, points.Length);
            Count = 0;
        }

        public Point this[int i]
        {
            get
            {
                if (i >= 0 && i < Count)
                    return points[i];
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (!value.IsEmpty)
                    points[i] = value;
                else
                    throw new FormatException();
            }
        }

        public Point[] GetDots()
        {
            Point[] p = new Point[Count];

            for (int i = 0; i < Count; i++)
                p[i] = points[i];

            return p;
        }
        
        private Curve()
        {
            points = new Point[initialSize];
        }

        private void Resize()
        {
            Point[] p = new Point[(int)(Count * 1.5)];
            Array.Copy(points, p, Count);
            points = p;
        }
    }
}
