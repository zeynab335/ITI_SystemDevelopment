using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D04
{
    public struct Date
    {
        internal int Day;
        internal int Month;
        internal int Years;



        public void setDate(int day, int month, int year)
        {
            try
            {
               
                if (month == 2 && day <= 28)
                {
                    this.Day = day;
                    this.Month = month;
                    this.Years = year;


                }
                //April, June, September, and November days => days less than 31
                else if ((month == 4 || month == 6 || month == 9 || month == 11) && day < 31)
                {
                    this.Day = day;
                    this.Month = month;
                    this.Years = year;

                }
                else if ((month == 1 || month == 3 || month == 5 || month == 10 || month == 12 || month == 7 || month == 8) && day <= 31)
                {
                    Console.WriteLine("ddd");
                    this.Day = day;
                    this.Month = month;
                    this.Years = year;



                }
                else
                {
                    throw new Exception();
                }
            }
            catch
                {
                    Console.WriteLine("Please Enter Valid Date");
                }
            
           

        }
        public string getDate()
        {
            return this.Years + " : " + this.Day + " : " + this.Month;
        }


    }
}
