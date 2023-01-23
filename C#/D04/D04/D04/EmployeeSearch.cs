using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace D04
{
    public class EmployeeSearch
    {
        //{ int[] NationalIDs; Employee[] Employees  ….}
        int[] NationalIDs;
        Employee[] Employees;
        int Size;

        public EmployeeSearch(int size)
        {
            Size = size;
            NationalIDs = new int[size];
            Employees = new Employee[size]; 
        }
        public void setEntry(int index , int id , Employee e)
        {
            if(index > 0 && index < Size)
            {
                NationalIDs[index] = id;
                Employees[index] = e;

            }
        }


        //* indexer [int id] => return Employee object
        public Employee this[int id]
        {
            get
            {
                for(int i=0; i<Size; i++)
                {
                    if(Employees[i].ID == id)
                    {
                        return Employees[i];
                    }
                }
                return default ;
             }
        }


        //* indexer [int name] => return Employee object
        public Employee this[string name]
        {
            get
            {
                for (int i = 0; i < Size; i++)
                {
                    if (Employees[i].Name == name)
                    {
                        return Employees[i];
                    }
                }
                return default;
            }
        }

        //* indexer [Date Hiring Dates ] => return Employee object
        public Employee this[Date hireDate]
        {
            get
            {
                for (int i = 0; i < Size; i++)
                {
                    if (Employees[i].HireDate.getDate() == hireDate.getDate())
                    {
                        return Employees[i];
                    }
                }
                return default;
            }
        }


    }
}
