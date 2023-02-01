using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace D09
{
    internal class Department
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        List<Employee> Staff;

        public Department()
        {
            Staff = new List<Employee>();
        }
        public void AddStaff(Employee E)
        {
            ///Try Register for EmployeeLayOff Event Here
            
            Staff.Add(E);
            E.EmployeeLayOff += this.RemoveStaff;

        }

       
        ///CallBackMethod
        public void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
        {
            if ((sender is Employee em) && em!=null )
            {
                Staff.Remove(em);
                Console.WriteLine($"Employee {em.EmployeeID} Will Fire From Department Because of  ${e.Cause} ");

            }
        }
    }
}
