using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D05
{
    internal class Point3D:Point
    {
        public int X { set; get; }
        public int Y { set; get; }
        public int Z { set; get; }

        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"Point Coordinates: ( {X} , {Y} , {Z} )";
        }

        public static explicit operator string (Point3D p)
        {
            return p.ToString();
        }
    }
}
