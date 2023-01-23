namespace D03_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees = new Employee[3];
            int id;
            decimal Salary;
            string gender;
           
                for (int i=0 ; i<3 ; i++){
                    Console.WriteLine($"Please Enter Employee {i + 1} Details");

                    Console.WriteLine("Id = ");
                    id = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine("Salary = ");
                    Salary = decimal.Parse(Console.ReadLine());
                    
                    Console.WriteLine("Gender = ");
                    gender = Console.ReadLine();


                    employees[i] = new Employee(id, Salary, gender);

                     Console.WriteLine("Day of HireDate = ");
                    int day = int.Parse(Console.ReadLine());

                    Console.WriteLine("Month of HireDate = ");
                    int month = int.Parse(Console.ReadLine());


                    Console.WriteLine("Year of HireDate = ");
                    int year = int.Parse(Console.ReadLine());

                    employees[i].SetHireDate(day , month , year);

                    Console.WriteLine("Enter Security Level {guest, Developer ,secretary ,DBA ,securityOfficer}");
                    employees[i].setSecurityLevel(Console.ReadLine());
                }



            Console.WriteLine("Print All Data Of All Employee");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(employees[i].ToString());
                Console.WriteLine(employees[i].GetHireDate());
            }


          

        }
    }
}