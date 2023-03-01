namespace PrototypeDP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee Employee1 = new Employee()
            {
                Id = 1234,
                Name = "Employee1",
                DepartmentID = 150,
                AddressDetails = new Address()
                {
                    DoorNumber = 10,
                    StreetNumber = 20,
                    Zipcode = 90025,
                    Country = "US"
                }
            };

           
            Console.WriteLine(Employee1.ToString());

            Employee Employee2 = (Employee)Employee1.DeepCopy();

            Employee2.Name = "Employee2";
            Employee2.DepartmentID = 151;
            Employee2.AddressDetails.StreetNumber = 21;
            Employee2.AddressDetails.DoorNumber = 11;

            Console.WriteLine(Employee2.ToString());

            Console.WriteLine("\nModified Details of Employee1\n");
            Employee1.AddressDetails.DoorNumber = 30;
            Employee1.AddressDetails.StreetNumber = 40;

            Employee1.DepartmentID = 160;
            Console.WriteLine(Employee1.ToString());
            Console.WriteLine(Employee2.ToString());
            Console.ReadLine();
        }
    }
}