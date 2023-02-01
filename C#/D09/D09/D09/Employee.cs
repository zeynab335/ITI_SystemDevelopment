using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D09
{
    internal class Employee
    {
        // fields
        int vacationStock;

        // Event
        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;

        // Invoke Event
        protected virtual void OnEmployeeLayOff (EmployeeLayOffEventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);
        }

        public int EmployeeID { get; set; }
        public DateTime BirthDate
        {
            get;
            set;
        }
        public int VacationStock
        {
            get { return vacationStock; }
            set {
                if (value < 0)
                {
                    // fire event
                    OnEmployeeLayOff(new() { Cause = LayOffCause.VacationStockLessThan0 });
                }
                else vacationStock = value;
            }
        }
        public bool RequestVacation(DateTime From, DateTime To)
        {
            int numOfDays = (To.Day - From.Day);

            if (vacationStock > 0 && numOfDays > vacationStock)
            {
                // fire event
                OnEmployeeLayOff(new() { Cause = LayOffCause.VacationStockLessThan0 });
                return false;
            }
            else
            {
                // calculate number of days of vacation
                vacationStock -= numOfDays;
                return true;
            }
        }
        public void EndOfYearOperation()
        {
            if (DateTime.Now.Year - BirthDate.Year > 60)
            {
                // fire event
                OnEmployeeLayOff(new() { Cause = LayOffCause.AgeGreaterThan60 });
            }
            
        }
    }
}
