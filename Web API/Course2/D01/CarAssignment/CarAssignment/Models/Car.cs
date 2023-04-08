using CarAssignment.Validators;
using System.Reflection;
using System.Xml.Linq;

namespace CarAssignment.Models
{
    public class Car
    {
        public int Id { get; set; }

        [DateInPast]
        public DateTime ProductionDate { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int NumberModel { get; set; }

        public string Type { get; set; } = string.Empty;

        public Car(int id ,int numberModel , string type, string brand, DateTime productionDate, decimal price)
        {
            Id = id;
            NumberModel = numberModel;
            Brand = brand;
            Price = price;
            Type = type;
            ProductionDate = productionDate;   
        }

        public static List<Car> Cars { get; set;} = new List<Car>()
        {
            new(1,100,"Gas" , "Tesla" , DateTime.Now , 120000.0m),
            new(2,200 ,"Gas" , "BMW" , DateTime.Now , 200000.0m),
            new(3,300,"Gas" , "BMW" , DateTime.Now , 300000.0m)


        };

    }
}
