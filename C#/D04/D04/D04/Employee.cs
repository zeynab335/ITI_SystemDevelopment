using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D04
{
    public enum GenderType
    {
        Male, Female
    }

    [Flags]
    public enum SecurityLevels
    {
        Guest, Developer, Secretary, DBA
    }

    public struct Employee
    {
        public Date hireDate;


        public Employee(int _ID, string name,decimal _salary, string g)
        {
            ID = _ID;
            Salary = _salary;
            Name = name;
            try
            {
                Gender = (GenderType)Enum.Parse(typeof(GenderType), g);
            }
            catch
            {
                Console.WriteLine("Gender Must be Male or Female");
            }
        }


        //* Setter getter
        public int ID { set; get; }
        public string Name { set; get; } 
        public decimal Salary { set; get; }

 
        public Date HireDate { set; get; }  

     
        public GenderType Gender { set; get; } 
        public SecurityLevels SecurityLevel{ set ;get; }
     
        public override string ToString()
        {
            
                if(ID> 0)
                {
                    return $"Employee Id = {this.ID} , Salary = {Salary} , Gender =  {Gender} ";

                }
                else
                {
                    return "Employee Not Found";
                }
            
        }


        


    }
}
