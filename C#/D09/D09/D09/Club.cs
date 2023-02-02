using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D09
{
    internal class Club {
        public int ClubID { get; set; }
        public String ClubName { get; set; }
        List<Employee> Members;


        public Club() => Members = new List<Employee>();    
        public void AddMember(Employee E)
        {
            //throw new NotImplementedException();
            ///Try Register for EmployeeLayOff Event Here
            Members.Add(E);
            E.EmployeeLayOff += this.RemoveMember;
        }
        ///CallBackMethod
        public void RemoveMember
        (object sender, EmployeeLayOffEventArgs e)
        {
            ///Employee Will not be removed from the Club if Age>60

            ///Employee will be removed from Club if Vacation Stock < 0
            if ((sender is Employee em) && em != null && (e.Cause == LayOffCause.VacationStockLessThan0 || e.Cause == LayOffCause.NotAchievedTarget))
            {
                Members.Remove(em);
                Console.WriteLine($"Employee {em.EmployeeID} Will Fire Because of  ${e.Cause} ");

            }
        }
    }
    }
