using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BTCN_02_ToMau
{
    class EllipseObj : ShapeObj
    {
        public EllipseObj(List<Point> _points)
            : base(_points)
        {
            getMostLeftSize();
        }

        Point mostLeft;
        Size size;

        private void getMostLeftSize()
        {
            mostLeft = new Point(Math.Min(points[0].X, points[1].X),
                Math.Min(points[0].Y, points[1].Y));
            size = new Size(Math.Abs(points[0].X - points[1].X),
                Math.Abs(points[0].Y - points[1].Y));
        }

        public override void draw(Bitmap bitmap)
        {
            // can dung 2 diem de ve ellipse
            if (points.Count != 2)
            {
                return;
            }

            using (Graphics graphics = Graphics.FromImage(bitmap))
            using (Pen pen = new Pen(Color.Black))
            {
                Rectangle rectangle = new Rectangle(mostLeft, size);
                graphics.DrawEllipse(pen, rectangle);
            }

        }

        public override bool isPrecisePointInsde(Point p)
        {
            using (GraphicsPath graphicsPath = new GraphicsPath())
            using (Pen pen = new Pen(Color.Black))
            {
                Rectangle rectangle = new Rectangle(mostLeft, size);
                graphicsPath.AddEllipse(rectangle);
                return graphicsPath.IsVisible(p) && !graphicsPath.IsOutlineVisible(p, pen);
            }
        }

        public override bool isApproxPointInside(Point p)
        {
            if (points.Count != 2)
            {
                return false;
            }

            List<Point> p_around = getPointsAround(p, 5);

            using (GraphicsPath graphicsPath = new GraphicsPath())
            {
                Rectangle rectangle = new Rectangle(mostLeft, size);
                graphicsPath.AddEllipse(rectangle);
                for (int i = 0; i < p_around.Count; ++i)
                {
                    if (graphicsPath.IsVisible(p_around[i]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        protected override int get_y_min()
        {
            return mostLeft.Y;
        }

        protected override int get_y_max()
        {
            return mostLeft.Y + size.Height;
        }

        protected override bool laDinhCao(int index)
        {
            return false;
        }

        protected override bool laDinhThap(int index)
        {
            return false;
        }

        private Point getCenterPoint()
        {
            return new Point(mostLeft.X + size.Width / 2, mostLeft.Y + size.Height / 2);
        }

        public override void fillScanLine(Bitmap bitmap, Color fillColor)
        {
            int y_min = get_y_min();
            int y_max = get_y_max();

            Point center = getCenterPoint();

            for (int y = y_min; y <= y_max; ++y)
            {
                List<int> x_cross = new List<int>();
                int a = size.Width / 2;
                int b = size.Height / 2;
                int x_x0 = (int)Math.Round(Math.Sqrt((1 - (y - center.Y) * (y - center.Y)
                    / (float)(b * b)) * a * a));
                x_cross.Add(center.X - x_x0);
                x_cross.Add(center.X + x_x0);

                for (int i = x_cross[0] + 1; i <= x_cross[1] - 1; ++i)
                {
                    bitmap.SetPixel(i, y, fillColor);
                }
            }
        }

        public override void fillBoundary(Bitmap bitmap, Color fillColor, Color boundaryColor)
        {
            Point seed = getCenterPoint();

            fillBoundaryPerPixel(seed, bitmap, fillColor, boundaryColor);
        }

        public override void fillBoundaryNoRecursive(Bitmap bitmap, Color fillColor, Color boundaryColor)
        {
            Stack<Point> stackPoints = new Stack<Point>();

            Point seed = getCenterPoint();
            stackPoints.Push(seed);

            while (stackPoints.Count != 0)
            {
                Point curSeed = stackPoints.Pop();

                // not boundary and not fill yet
                if (curSeed.X >= 0 && curSeed.X < bitmap.Width
                    && curSeed.Y >= 0 && curSeed.Y < bitmap.Height
                    && bitmap.GetPixel(curSeed.X, curSeed.Y).ToArgb() != boundaryColor.ToArgb()
                    && bitmap.GetPixel(curSeed.X, curSeed.Y).ToArgb() != fillColor.ToArgb())
                {
                    bitmap.SetPixel(curSeed.X, curSeed.Y, fillColor);
                    // 4-way around curSeed
                    stackPoints.Push(new Point(curSeed.X, curSeed.Y - 1));
                    stackPoints.Push(new Point(curSeed.X + 1, curSeed.Y));
                    stackPoints.Push(new Point(curSeed.X, curSeed.Y + 1));
                    stackPoints.Push(new Point(curSeed.X - 1, curSeed.Y));
                }
            }
        }
    }
}
