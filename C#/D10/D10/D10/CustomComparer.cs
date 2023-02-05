using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D10
{
    public class CustomComparer : IComparer<string>
    {
        

        int IComparer<string>.Compare(string? x, string? y)
        {
            return x.ToString().ToLower().FirstOrDefault().CompareTo(y?.ToString()?.ToLower().FirstOrDefault());
            //throw new NotImplementedException();
        }
    }
}
