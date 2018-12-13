using System;
using System.Collections.Generic;
using System.Drawing;

namespace BTCN_02_ToMau
{
    class ShapeBuilder
    {
        public static PolygonObj randPoly(Random random, int width, int height)
        {
            int num_point = random.Next(3, 6);
            List<Point> points = new List<Point>();

            for (int i = 0; i < num_point; ++i)
            {
                points.Add(new Point(random.Next(width), random.Next(height)));
            }

            return new PolygonObj(points);
        }

        public static EllipseObj randElli(Random random, int width, int height)
        {
            int num_point = 2;
            List<Point> points = new List<Point>();

            for (int i = 0; i < num_point; ++i)
            {
                points.Add(new Point(random.Next(width), random.Next(height)));
            }

            return new EllipseObj(points);
        }
    }
}
