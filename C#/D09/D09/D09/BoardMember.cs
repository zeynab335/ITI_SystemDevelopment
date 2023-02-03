using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D09
{
    public class BoardMember : Employee
    {

        public void Resign()
        {
            OnEmployeeLayOff(new() { Cause = LayOffCause.NotAchievedTarget });
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