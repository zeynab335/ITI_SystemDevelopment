using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D09
{
    public enum LayOffCause
    { NotAchievedTarget, VacationStockLessThan0, AgeGreaterThan60, Resign }
   
        public class EmployeeLayOffEventArgs
        {
            public LayOffCause Cause { get; set; }
        }
    
}