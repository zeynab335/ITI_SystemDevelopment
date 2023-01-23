using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D05
{
    internal class Point
    {
        public int X { set; get; }
        public int Y { set; get; }

        public Point(int x , int y){
            X = x; 
            Y = y;
        }

        public override string ToString()
        {
            return $"Point Coordinates: ( {X} , {Y} )";
        }

        public static bool operator ==(Point P1 , Point P2)
        {
            //if ( (P1!= null) && (P2 != null))
            //{
            //}
            return (P1.X == P2.X) && (P1.Y == P2.Y);


            
        }

        public static bool operator !=(Point P1, Point P2)
        {

            return (P1.X != P2.X) || (P1.Y != P2.Y);

        }


    }
}
