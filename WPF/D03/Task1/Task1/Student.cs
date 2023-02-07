using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Student
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Image { get; set; }

        public int Age { get; set; }

        public int Grade { get; set; }


        public override string ToString()
        {
            return $"Name:{Name}";
        }
    }
}
