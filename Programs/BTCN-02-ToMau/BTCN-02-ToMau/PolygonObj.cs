using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BTCN_02_ToMau
{
    class PolygonObj : ShapeObj
    {
        public PolygonObj(List<Point> _points)
            : base(_points)
        { }

        public override void draw(Bitmap bitmap)
        {
            // da giac 3 diem tro len
            if (points.Count <= 2)
            {
                return;
            }

            using (Graphics graphics = Graphics.FromImage(bitmap))
            using (Pen pen = new Pen(Color.Black))
            {
                graphics.DrawPolygon(pen, points.ToArray());
            }
        }

        public override bool isPrecisePointInsde(Point p)
        {
            using (GraphicsPath graphicsPath = new GraphicsPath())
            using (Pen pen = new Pen(Color.Black))
            {
                graphicsPath.AddPolygon(points.ToArray());
                return graphicsPath.IsVisible(p) && !graphicsPath.IsOutlineVisible(p, pen);
            }
        }

        public override bool isApproxPointInside(Point p)
        {
            if (points.Count <= 2)
            {
                return false;
            }

            List<Point> p_around = getPointsAround(p, 5);

            using (GraphicsPath graphicsPath = new GraphicsPath())
            {
                graphicsPath.AddPolygon(points.ToArray());
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
            int y_min = points[0].Y;
            foreach (Point p in points)
            {
                if (p.Y < y_min)
                {
                    y_min = p.Y;
                }
            }

            return y_min;
        }

        protected override int get_y_max()
        {
            int y_max = points[0].Y;
            foreach (Point p in points)
            {
                if (p.Y > y_max)
                {
                    y_max = p.Y;
                }
            }

            return y_max;
        }

        protected override bool laDinhCao(int index)
        {
            int count = points.Count;
            // cao hon 2 dinh lan can
            if (points[index].Y > points[(index - 1 + count) % count].Y
               && points[index].Y > points[(index + 1 + count) % count].Y)
            {
                return true;
            }

            return false;
        }

        protected override bool laDinhThap(int index)
        {
            int count = points.Count;
            // thap hon 2 dinh lan can
            if (points[index].Y < points[(index - 1 + count) % count].Y
               && points[index].Y < points[(index + 1 + count) % count].Y)
            {
                return true;
            }

            return false;
        }

        public override void fillScanLine(Bitmap bitmap, Color fillColor)
        {
            int y_min = get_y_min();
            int y_max = get_y_max();

            // scan each line
            for (int y = y_min; y <= y_max; ++y)
            {
                List<int> x_cross = new List<int>();
                // get x cross each edge
                int count = points.Count;
                for (int i = 0; i < count; ++i)
                {
                    // canh khong duoc song song Ox
                    // y phai nam trong khoang cua canh 
                    if (points[i % count].Y != points[(i + 1) % count].Y
                        && y >= Math.Min(points[i % count].Y, points[(i + 1) % count].Y)
                        && y <= Math.Max(points[i % count].Y, points[(i + 1) % count].Y))
                    {
                        int x = get_x_cross(y, points[i % count], points[(i + 1) % count]);
                        Point p = new Point(x, y);
                        int index = points.IndexOf(p);
                        // p la dinh
                        if (index != -1)
                        {
                            // them 2 lan
                            if (laDinhCao(index) || laDinhThap(index))
                            {
                                x_cross.Add(x);
                            }
                            // them 1 lan
                            else
                            {
                                if (!x_cross.Contains(x))
                                {
                                    x_cross.Add(x);
                                }
                            }
                        }
                        else
                        {
                            x_cross.Add(x);
                        }
                    }
                }

                x_cross.Sort();

                // fill with color
                // get each pair of x_cross
                for (int i = 0; i < x_cross.Count - 1; i += 2)
                {
                    for (int j = x_cross[i] + 1; j <= x_cross[i + 1] - 1; ++j)
                    {
                        bitmap.SetPixel(j, y, fillColor);
                    }
                }
            }
        }

        public override void fillBoundary(Bitmap bitmap, Color fillColor, Color boundaryColor)
        {
            Point seed = getSeedPoint();

            fillBoundaryPerPixel(seed, bitmap, fillColor, boundaryColor);
        }

        public override void fillBoundaryNoRecursive(Bitmap bitmap, Color fillColor, Color boundaryColor)
        {
            Stack<Point> stackPoints = new Stack<Point>();

            Point seed = getSeedPoint();
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
