namespace D09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee();
            e1.VacationStock = 1;
            e1.EmployeeID = 1;
            e1.BirthDate = new DateTime(1990,2,10); 
            
            Department d1 = new Department();
            d1.AddStaff(e1);

            Club c1 = new Club();
            

            // fire Employee when EndOfYearOperation 
            e1.EndOfYearOperation();

            // fire Employee when Vaction Stock
            e1.RequestVacation(DateTime.Now, new DateTime(2023 , 2 , 10));


            // SalesPerson
            SalesPerson s1 = new SalesPerson();
            s1.EmployeeID = 2;
            s1.VacationStock= 1;
            s1.BirthDate = new DateTime(1890, 2, 10);
            s1.AchievedTarget = 200;

            d1.AddStaff(s1);
            //
            c1.AddMember(s1);
            
            s1.EndOfYearOperation();
            s1.CheckTarget(100);


            BoardMember b1 = new BoardMember();
            b1.EmployeeID = 3;
            b1.VacationStock = 10;
            
            d1.AddStaff(b1);
            //b1.BirthDate = new DateTime(1890, 2, 10);
            //b1.RequestVacation(DateTime.Now, new DateTime(2023, 2, 15));

            b1.Resign();
            
        }


    }
}