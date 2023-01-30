using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D07
{
    internal class Subject
    {
        public string SubName { get; }
        public int SubID { get; }


        public Subject(string subName , int subID) { 
            SubName = subName;
            SubID = subID;
        }


    }
}
