using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D08
{

    public class LibraryEngine
    {
         //using User Defined Delegate 
        public static void ProcessBooks(List<Book> bList, bookDelegate fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }

        // using BCL
        public static void ProcessBooks(List<Book> bList, Func<Book, string> fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
    }

}
