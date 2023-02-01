using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D09
{
    internal class BoardMember : Employee
    {
        public void Resign()
        {
            OnEmployeeLayOff(new() { Cause = LayOffCause.Resign });

        }

        protected override void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            if (e.Cause == LayOffCause.Resign)
            {
                base.OnEmployeeLayOff(e);
            }
        }
    }
}
