using System.Diagnostics;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //* Task1

            #region Task1
            //int[] Arr;
            //int Distance = 0, FIndex = 0, LIndex = 0;

            //Console.WriteLine("Enter Size of Array");
            //int size = int.Parse(Console.ReadLine());

            //Arr = new int[size];

            //// insert data

            //for (int i = 0; i < size; i++)
            //{
            //    Console.WriteLine($"Enter Element {i + 1} ");
            //    Arr[i] = int.Parse(Console.ReadLine());
            //}

            //for (int i = 0; i < Arr.Length; i++)
            //{

            //    for (int j = i + 1; j < Arr.Length; j++)
            //    {
            //        Console.WriteLine($"{Arr[i]} , {Arr[j]} ");
            //        if (Arr[i] == Arr[j] && (Distance < (j - i)))
            //        {
            //            FIndex = i;
            //            LIndex = j;
            //            Distance = j - i;
            //            //Console.WriteLine($"{Distance} , {FIndex} ,{LIndex}" );

            //        }
            //    }
            //}
            //Console.WriteLine($"First-index = {FIndex} , Last-index = {LIndex} , Distance = {Distance} ");
            #endregion



            #region Task2
            //Console.WriteLine("");

            //string str = Console.ReadLine();

            //Console.WriteLine($"{String.Join(" ", str.Split(' ').Reverse())}");

            #endregion




            #region Task3
            //Math.Pow(10, 8)
            //Stopwatch stopwatch = new();
            //stopwatch.Start();

            //int count = 0;
            //for (int i = 0; i < Math.Pow(10, 8); i++)
            //{
            //    string num = i.ToString();

            //    for (int j = 0; j < num.Length; j++)
            //    {
            //        if (num[j] == '1')
            //        {
            //            count++;
            //        }
            //    }


            //}
            //stopwatch.Stop();

            //Console.WriteLine(stopwatch.ElapsedMilliseconds);
            //Console.WriteLine(count);

            #endregion


            //Stopwatch stopwatch2 = new();
            //stopwatch2.Start();
            //int count = 0;
            //int rem = 0;

            //for (int i = 0; i < Math.Pow(10, 8); i++)
            //{
            //    int num = i;

            //    while (num > 0)
            //    {
            //        rem = num % 10;
            //        if (rem == 1)
            //        {
            //            count++;
            //        }
            //        num /= 10;

            //    }
            //}

            //stopwatch2.Stop();

            //Console.WriteLine(stopwatch2.ElapsedMilliseconds);
            //Console.WriteLine(count);


        }
    }
}