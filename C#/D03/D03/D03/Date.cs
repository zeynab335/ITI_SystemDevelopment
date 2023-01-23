using System;
namespace D03
{
    public struct Date
    {
        public int Day;
        public int Month;
        public int Years;


     
        public void setDate(int day, int month, int year)
        {
            this.Day = day;
            this.Month = month;
            this.Years = year;


        }
        public string getDate()
        {
            return this.Day + " : " + this.Month + " : "  + this.Years;
        }
        
    }
}
