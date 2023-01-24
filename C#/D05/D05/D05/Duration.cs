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
        private int Days;

        public Duration() { }
        public Duration(int hours, int minutes, int seconds)
        {

            if (hours < 24)
            {
                Hours = hours;
                Days = 0;

            }
            else
            {
                Hours = hours % 24;
                Days = hours / 24;
            }

            if (seconds < 60 && seconds > 0)
            {
                Seconds = seconds;

            }
            else
            {
                Seconds = seconds % 60;
                minutes += (seconds / 60);
            }
            if (minutes > 60 && minutes > 0)
            {
                Hours = hours + minutes / 60;
                Minutes = minutes % 60;
            }
            else
            {
                Minutes = minutes;
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
            if(Days > 0)
            {
                return $"Day: {Days} , Hours: {Hours}, Minutes : {Minutes} , Seconds : {Seconds}";

            }
            else
            {
                return $"Hours: {Hours}, Minutes : {Minutes} , Seconds : {Seconds}";

            }
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

        //D1-D2;
        public static Duration operator -(Duration a , Duration b)
        {
            return new Duration(System.Math.Abs(a.Hours - b.Hours), System.Math.Abs(a.Minutes - b.Minutes), System.Math.Abs(a.Seconds - b.Seconds));

        }
        //D1=-D2
        public static Duration operator -(Duration a)
        {
            return new Duration(-a.Hours, -a.Minutes,  - a.Seconds);

        }

        // D1 > D2
        public static bool operator >(Duration a, Duration b)
        {
            return a.Hours > b.Hours;
        }

        // D1 < D2
        public static bool operator <(Duration a, Duration b)
        {
            return a.Hours < b.Hours;

        }
        // D1 >= D2

        public static bool operator >=(Duration a, Duration b)
        {
            return a.Hours >= b.Hours;

        }
        // D1 <= D2

        public static bool operator <=(Duration a, Duration b)
        {
            return a.Hours <= b.Hours;

        }

        //* if(D1)
        // the defining property of a short circuiting operator is that it doesn't need to evaluate the right side if the left side already determines the result
        public static bool operator true(Duration a)
        {
            return (a.Hours > 0 ) || (a.Minutes > 0) || (a.Seconds > 0);

        }
        public static bool operator false(Duration a)
        {
            return (a.Hours <= 0) && (a.Minutes <= 0) && (a.Seconds <= 0);

        }
        // DateTime operatot overloading
        public static explicit operator DateTime(Duration a)
        {
            Console.WriteLine(a.ToString());
            
            string time = a.Hours + ":" + a.Minutes + ":" + a.Seconds;
            if(a.Hours < 24)
            {
                return DateTime.Parse(time);

            }
            else
            {
                Console.WriteLine(DateTime.Now.Date.Year);
                DateTime d1 = new DateTime();
                return d1
                .AddYears(DateTime.Now.Date.Year - 1)
                .AddDays(DateTime.Now.Date.Day - 1)
                .AddHours(a.Hours)
                .AddMinutes(a.Minutes)
                .AddSeconds(a.Seconds);

            }


        }



    }
}
