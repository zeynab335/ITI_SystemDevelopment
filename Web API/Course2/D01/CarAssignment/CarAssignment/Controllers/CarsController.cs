using CarAssignment.Filters;
using CarAssignment.Models;
using CarAssignment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ILogger<CarsController> _logger;
        private readonly CounterServices _counterServices;



        // inject counter services 
        public CarsController(ILogger<CarsController> logger , CounterServices counterServices )
        {
            _logger = logger;
            _counterServices = counterServices; // increment this counter after each endpoint in this controller
        }

        #region Get Apis

        [HttpGet]
        public ActionResult<List<Car>> GetCars() {
           _logger.LogInformation("Get All Cars");

            // increment counter
            _counterServices.Counter++;

            return Car.Cars;
        }

        // Get Car By id
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Car> GetCarById(int id)
        {
            var car =  Car.Cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            // increment counter
            _counterServices.Counter++;

            return car;
        }

        // Delete
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Car> DeleteById(int id)
        {
            var car = Car.Cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            Car.Cars.Remove(car);

            // increment counter
            _counterServices.Counter++;

            return NoContent();
        }

        #endregion


        // add new car
        [HttpPost]
        [Route("v1")]
        public ActionResult<Car> Add(Car car)
        {
            // create random id
            car.Id = new Random().Next(1, 200);
            Car.Cars.Add(car);
            car.Type = "Gas";

            // increment counter
            _counterServices.Counter++;

            // return [Staus code 201 ==> created] + retuen object of created car
            return CreatedAtAction(
                actionName: nameof(GetCarById),
                routeValues: new { id = car.Id },
                value: car
           );

        }


        // add new car
        [HttpPost]
        [Route("v2")]
        [ServiceFilter(typeof(ValidateTypeCarAttribute))]
        public ActionResult<Car> AddV2(Car car)
        {
            // create random id
            car.Id = new Random().Next(1, 200);
            Car.Cars.Add(car);

            // increment counter
            _counterServices.Counter++;

            return Ok(car);

        }


        // edit Exsisting car
        [HttpPut]
        [Route("{id}")]

        public ActionResult<Car> Update(Car car , int id) { 

            var ExistingCar= Car.Cars.FirstOrDefault(c=>c.Id == id);

            if(ExistingCar is null)
            {
                return NotFound();  
            }

            ExistingCar.NumberModel = car.NumberModel;
            ExistingCar.Brand = car.Brand;
            ExistingCar.Price = car.Price;
            ExistingCar.ProductionDate = car.ProductionDate;
            ExistingCar.Type = car.Type;

            // increment counter
            _counterServices.Counter++;


            return NoContent();
        }



    }
}
