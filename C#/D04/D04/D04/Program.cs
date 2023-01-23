using D04;

internal class Program
{
    private static void Main(string[] args)
    {
        //* indexer 
        EmployeeSearch em = new EmployeeSearch(4);

        em.setEntry(0, 1, new Employee(1,  "emp1", 1000, "Female"));
        em.setEntry(1, 5, new Employee(5, "emp2", 1000, "Female"));
        em.setEntry(2, 10, new Employee(10, "emp3", 1000, "Female"));
        
        Date date = new Date();
        date.setDate(15, 10, 2000);

        Employee e5 = new Employee(15, "emp4", 1000, "Female");
        e5.HireDate= date;

        em.setEntry(3, 15,e5);


        Console.WriteLine(em[5]);
        Console.WriteLine(em["emp3"]);
        Console.WriteLine(em[e5.HireDate]);



        Employee[] employees = new Employee[3];
        int id = 0;
        decimal Salary=0;
        string gender= "male" , level="DBA" , name="";

        int day = 0, year=0 , month=0;

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Please Enter Employee {i + 1} Details");
           
            try
            {
                Console.WriteLine("Id = ");
                id = int.Parse(Console.ReadLine());
                if (id < 0)
                {
                    throw new Exception();
                }
            }

            catch
            {
                Console.WriteLine("please enter valid id");
            }

            //* name
            try
            {
                Console.WriteLine("Name = ");
                name = Console.ReadLine();
                if (name == "")
                {
                    throw new Exception();
                }
            }

            catch
            {
                Console.WriteLine("Please Enter valid name❌");
            }

            //* salary 
            try
            {
                Console.WriteLine("Salary = ");
                Salary = decimal.Parse(Console.ReadLine());
                if (Salary < 0)
                {
                    throw new Exception();
                }
            }

            catch
            {
                Console.WriteLine("please enter valid salary");
            }

            //* Gender
            try
            {
                Console.WriteLine("Gender = ");
                gender = Console.ReadLine();
                if (gender == "")
                {
                    throw new Exception();
                }
            }

            catch
            {
                Console.WriteLine("Gender Must be Male or Female ❌");
            }



            employees[i] = new Employee(id,name ,Salary, gender);

            try
            {
                Console.WriteLine("Day of HireDate = ");
                day = int.Parse(Console.ReadLine());

            }
            catch
            {
                Console.WriteLine("please enter valid Day");

            }

            try
            {
                Console.WriteLine("Month of HireDate = ");
               month = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("please enter valid Month");

            }

            try
            {
                Console.WriteLine("Year of HireDate = ");
                year = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("please enter valid Year");

            }



            employees[i].HireDate.setDate(day, month, year);

            try
            {
                Console.WriteLine("Enter Security Level {Guest, Developer ,secretary ,DBA ,securityOfficer}");
                level = Console.ReadLine();
                employees[i].SecurityLevel = (SecurityLevels)Enum.Parse(typeof(SecurityLevels), level);
            }
            catch
            {
                Console.WriteLine("SecurityLevels Must be Guest or Secretary or Developer Or DBA ");

            }


        }



        Console.WriteLine("Print All Data Of All Employee");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(employees[i].ToString());
            Console.WriteLine(employees[i].HireDate.getDate());
        }

       
    }


}