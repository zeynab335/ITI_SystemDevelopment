using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D03_task
{
    public struct Date
    {
        public int Day;
        public int Month;
        public int Years;



        public void setDate(int day, int month, int year)
        {
            if(year > 0 && year < 2000)
            {
                this.Day = day;
                this.Month = month;
                this.Years = year;
            }
            else
            {
                Console.WriteLine("Year must be less than 2000 ");
            }
        
        }
        public string getDate()
        {
            return this.Years + " : "  + this.Day + " : " + this.Month  ;
        }

    }
}
