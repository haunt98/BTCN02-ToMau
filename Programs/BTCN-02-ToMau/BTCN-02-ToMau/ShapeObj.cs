using System;
using System.Collections.Generic;
using System.Drawing;

namespace BTCN_02_ToMau
{
    abstract class ShapeObj
    {
        protected List<Point> points;

        public ShapeObj(List<Point> _points)
        {
            points = new List<Point>(_points);
        }

        public abstract void draw(Bitmap bitmap);

        public abstract bool isPrecisePointInsde(Point p);

        public abstract bool isApproxPointInside(Point p);

        protected List<Point> getPointsAround(Point p, int size)
        {
            // nhung diem xung quanh p
            List<Point> p_around = new List<Point>();
            for (int i = -size / 2; i <= size / 2; ++i)
            {
                for (int j = -size / 2; j <= size / 2; ++j)
                {
                    p_around.Add(new Point(p.X + i, p.Y + j));
                }
            }

            return p_around;
        }

        protected abstract int get_y_min();

        protected abstract int get_y_max();

        protected int get_x_cross(int y, Point p1, Point p2)
        {
            float x_float = (y * (p1.X - p2.X) + (p1.Y * p2.X - p1.X * p2.Y))
                / (float)(p1.Y - p2.Y);
            return (int)Math.Round(x_float);
        }

        protected abstract bool laDinhCao(int index);

        protected abstract bool laDinhThap(int index);

        public abstract void fillScanLine(Bitmap bitmap, Color fillColor);

        protected void fillBoundaryPerPixel(Point p, Bitmap bitmap, Color fillColor, Color boundaryColor)
        {
            if (p.X < 0 || p.X >= bitmap.Width || p.Y < 0 || p.Y >= bitmap.Height)
            {
                return;
            }

            // not boundary and not fill yet
            if (bitmap.GetPixel(p.X, p.Y).ToArgb() != boundaryColor.ToArgb()
                && bitmap.GetPixel(p.X, p.Y).ToArgb() != fillColor.ToArgb())
            {
                bitmap.SetPixel(p.X, p.Y, fillColor);
                // 4-way around p
                fillBoundaryPerPixel(new Point(p.X, p.Y - 1), bitmap, fillColor, boundaryColor);
                fillBoundaryPerPixel(new Point(p.X + 1, p.Y), bitmap, fillColor, boundaryColor);
                fillBoundaryPerPixel(new Point(p.X, p.Y + 1), bitmap, fillColor, boundaryColor);
                fillBoundaryPerPixel(new Point(p.X - 1, p.Y), bitmap, fillColor, boundaryColor);
            }
        }

        protected Point getSeedPoint()
        {
            List<Point> p_around = getPointsAround(points[0], 100);
            int i;
            for (i = 0; i < p_around.Count; ++i)
            {
                if (isPrecisePointInsde(p_around[i]))
                {
                    break;
                }
            }

            return p_around[i];
        }

        public abstract void fillBoundary(Bitmap bitmap, Color fillColor, Color boundaryColor);

        public abstract void fillBoundaryNoRecursive(Bitmap bitmap, Color fillColor, Color boundaryColor);
    }
}
