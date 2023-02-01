using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D09
{
    internal class SalesPerson : Employee
    {
        public int AchievedTarget { get; set; }

        //  Sales Employee will be Fired if Failed to Achieve Sales Target
        public bool CheckTarget(int Quota)
        {
            if(Quota < AchievedTarget )
            {
               OnEmployeeLayOff(new() { Cause = LayOffCause.NotAchievedTarget});
                return false;
            }
            return true;

        }

        protected override void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            if (e.Cause == LayOffCause.NotAchievedTarget)
            {
                base.OnEmployeeLayOff(e);
            }
        }
    }
}
