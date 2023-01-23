using D03_task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace D03_task

{
    public enum GenderType
    {
        Male, Female
    }

    [Flags]
    public enum SecurityLevels
    {
        Guest , Developer, Secretary , DBA
    }

    public struct Employee
    {

        // Fields

        public int ID;
        public SecurityLevels securityLevel;
        public decimal salary;
        public Date hireDate;
        public GenderType gender;


        public Employee(int _ID, decimal _salary , string g)
        {
            this.ID = _ID;
            this.salary = _salary;
            this.gender = (GenderType) Enum.Parse(typeof(GenderType) , g);
        }


        //* Setter getter
        public void SetID(int id) { ID = id; }
        public int GetId() { return ID; }

        public void SetSalary(decimal sal) { salary = sal; }
        public decimal GetSalary() { return this.salary; }

        public void SetHireDate(int years, int month, int day) { this.hireDate.setDate(day, month, years); }
        public string GetHireDate() { return this.hireDate.getDate(); }

        public void SetGender(string gender) { this.gender = (GenderType)Enum.Parse(typeof(GenderType), gender); }
        public GenderType GetGender() { return gender; }


        public void setSecurityLevel(string s)
        {
            securityLevel = (SecurityLevels)Enum.Parse(typeof(SecurityLevels), s);
        }
        public SecurityLevels getSecurityLevel() { return securityLevel; }

        public override string ToString()
        {
            return $"Employee Id = {this.ID} , Salary = {salary} , Gender =  {gender} " ;
        }


    }



}
