using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D09
{
    public enum LayOffCause
    {
        ///Implement it YourSelf 
        VacationStockLessThan0 , AgeGreaterThan60 , NotAchievedTarget , Resign 
    }

    public class EmployeeLayOffEventArgs:EventArgs
    {
        public LayOffCause Cause { get; set; }
    }
}
