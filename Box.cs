using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Demo1
{
    public class Point
    {
        public double X;
        public double Y;
        public double Z;

        public Point()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public void Move(Point translation)
        {
            X += translation.X;
            Y += translation.Y;
            Z += translation.Z;
        }
    }

    public class Box
    {
        public Point Min;
        public Point Max;

        public Box(Point min, Point max)
        {
            Min = min;
            Max = max;
        }
        public Box(double minX, double minY, double minZ, double maxX, double maxY, double maxZ)
        {
            Min = new Point(minX, minY, minZ);
            Max = new Point(maxX, maxY, maxZ);
        }

        public void Move(Point translation)
        {
            Min.Move(translation);
            Max.Move(translation);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
