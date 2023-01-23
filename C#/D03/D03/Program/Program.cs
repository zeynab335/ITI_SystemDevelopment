using D03;

namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new(10, 1200);
            employee.SetHireDate(10, 20, 2000);
            
            Console.WriteLine(employee.ToString());
            Console.WriteLine(employee.GetHireDate());

        }
    }
}