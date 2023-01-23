using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D05
{
    internal class Duration
    {
        private int Hours;
        private int Minutes;
        private int Seconds;

        public Duration() { }
        public Duration(int hours, int minutes, int seconds)
        {
            if(hours < 24 && hours > 0)
            {
                Hours = hours;
            }
            else
            {
                Hours = 23;
            }
            if (minutes > 60 && minutes > 0)
            {
                Hours = hours + minutes / 60;
                Minutes = minutes % 60;
            }
            else
            {
               Minutes= minutes;
            }
            if (seconds < 60 && seconds > 0)
            {
                Seconds = seconds;

            }
            else
            {
                Seconds = 59;

            }
        }

        public Duration(int time)
        {
            Hours = time / 3600;
            if(time > 3600)
            {
                time = time % 3600;    
            }
            Seconds = time % 60;
            Minutes = time / 60;

        }



        public override string ToString()
        {
            
            return $"Hours: {Hours}, Minutes : {Minutes} , Seconds : {Seconds}";
        }


        //* Operator Overloading
        // D3=D1+D2
        public static Duration operator +(Duration a, Duration b)
        {
            return new Duration(a.Hours + b.Hours, a.Minutes + b.Minutes, a.Seconds + b.Seconds);
        }


        //D3=D1 + 7800
        public static Duration operator +(Duration a, int Duration)
        {
            Duration b = new Duration(Duration);
            return new Duration(a.Hours + b.Hours, a.Minutes + b.Minutes, a.Seconds + b.Seconds);

        }


        //D3=666+D3
        public static Duration operator +(int Duration, Duration a)
        {
            Duration b = new Duration(Duration);
            return new Duration(a.Hours + b.Hours, a.Minutes + b.Minutes, a.Seconds + b.Seconds);

        }

        //D3=D1++ (Increase One Minute)
        public static Duration operator ++(Duration a)
        {
            return new Duration(a.Hours , a.Minutes+ 1 , a.Seconds );
        }

        //D3 =--D2; (Decrease One Minute)
        public static Duration operator --(Duration a)
        {
            return new Duration(a.Hours, a.Minutes-1, a.Seconds);
        }

        //D1= -D2;
        public static Duration operator -(Duration a , Duration b)
        {
            return new Duration(System.Math.Abs(a.Hours - b.Hours), System.Math.Abs(a.Minutes - b.Minutes), System.Math.Abs(a.Seconds - b.Seconds));

        }

        // D1 > D2
        public static bool operator >(Duration a, Duration b)
        {
            return a.Hours > b.Hours;
        }
        public static bool operator <(Duration a, Duration b)
        {
            return a.Hours < b.Hours;

        }
        public static bool operator >=(Duration a, Duration b)
        {
            return a.Hours >= b.Hours;

        }

        public static bool operator <=(Duration a, Duration b)
        {
            return a.Hours <= b.Hours;

        }

        public static explicit operator DateTime(Duration a)
        {
            string time = a.Hours + ":" + a.Minutes + ":" + a.Seconds;  
            return DateTime.Parse(time);
        }

        

    }
}
