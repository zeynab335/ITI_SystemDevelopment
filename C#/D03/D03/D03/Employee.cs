using D03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace D03
{
    public enum GenderType
    {
        Male , Female
    }

    public struct Employee
    {

        // Fields

        public int ID;
        //public SecurityLevel SecurityLevel;
        public decimal salary;
        public Date hireDate;
        public GenderType gender;


        public Employee(int _ID, decimal _salary)
        {
            this.ID = _ID;
            this.salary = _salary;
        }


        //* Setter getter
        public void SetID(int id) { ID = id; }
        public int GetId() { return ID; }

        public void SetSalary(decimal sal) { salary = sal; }
        public decimal GetSalary() {return this.salary;}
        
        public void SetHireDate(int years, int month, int day) {this.hireDate.setDate(day, month, years);}
        public string GetHireDate() {return this.hireDate.getDate(); }

        public void SetGender(string gender) { this.gender = (GenderType)Enum.Parse(typeof(GenderType), gender); }
        public GenderType GetGender() { return gender; }



        public override string ToString()
        {
            return $"Employee Id = {this.ID} , Salary = {salary} ";
        }


    }
   

 
}
