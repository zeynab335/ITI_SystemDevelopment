using Microsoft.VisualBasic;

namespace Array_Passing_ByRef_ByValue
{
    internal class Program
    {
      

        class Foo{
        
            internal int value;
            public Foo(int i)
            {
                value= i;
            }
        }

        static void Main(string[] args)
        {
            #region MyRegion
            //// create and initialize firstArray
            //int[] firstArray = { 1, 2, 3 };

            //// copy the reference in variable firstArray
            //int[] firstArrayCopy = firstArray;

            //Console.WriteLine("Test passing firstArray reference by value \n");

            //for (int i = 0; i < firstArray.Length; i++)
            //    Console.Write("{0} ", firstArray[i]);

            //// pass variable firstArray by value to FirstDouble
            //FirstDouble(firstArray);
            //Console.Write("Contents of firstArray " + "after calling FirstDouble: \n");

            //for (int i = 0; i < firstArray.Length; i++)
            //    Console.Write("{0} ", firstArray[i]);

            //for (int i = 0; i < firstArrayCopy.Length; i++)
            //    Console.Write("{0} ", firstArray[i]);

            //if (firstArray == firstArrayCopy)
            //    Console.WriteLine("The references refer to the same array");
            //else
            //    Console.WriteLine(" The references refer to different arrays");
            #endregion


            Foo foo = new Foo(1);
            Foo foo1 = new Foo(3);

            void Bar(ref Foo y)
            {
                y = new Foo(2);
            }
            void Bar1(Foo y)
            {
                y = new Foo(2);
            }

            Bar(ref foo);
            Bar1(foo1);

            Console.WriteLine(foo.value);
            Console.WriteLine(foo1.value);

        }
    }
}