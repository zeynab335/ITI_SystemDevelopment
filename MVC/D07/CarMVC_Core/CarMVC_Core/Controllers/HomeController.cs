using CarAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarMVC_Core.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllCars()
        {
            ViewBag.Cars = CarList.carLists.ToList();
            return View();
        }

        public IActionResult GetCar(int id)
        {
            ViewBag.carDetails = CarList.carLists.FirstOrDefault(c => c.Num == id);
            return View();
        }
        public IActionResult Edit(int id)
        {
            ViewBag.editedCar = CarList.carLists.FirstOrDefault(c => c.Num == id);
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, string Model, string Manfacture, string Color)
        {
            Car editedCar = CarList.carLists.FirstOrDefault(c => c.Num == id);

            ViewBag.editedCar = editedCar;

            if (editedCar != null)
            {
                editedCar.Color = Color;
                editedCar.Model = Model;
                editedCar.Manfacture = Manfacture;
            }
            else
            {
                CarList.carLists.Add(new Car { Color = Color, Num = id, Manfacture = Manfacture, Model = Model });
            }


            return RedirectToAction("GetAllCars");
        }


        public IActionResult Delete(int id)
        {
            Car selectedCar = CarList.carLists.FirstOrDefault(c => c.Num == id);

            CarList.carLists.Remove(selectedCar);
            return RedirectToAction("GetAllCars");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(int id, string Model, string Manfacture, string Color)
        {
            Car AddedCar = CarList.carLists.FirstOrDefault(c => c.Num == id);

            ViewBag.AddedCar = AddedCar;

            if (AddedCar != null)
            {
                return RedirectToAction("GetCar", new { id = id });
            }
            else
            {
                CarList.carLists.Add(new Car { Color = Color, Num = id, Manfacture = Manfacture, Model = Model });
            }


            return RedirectToAction("GetAllCars");
        }
    }
}
