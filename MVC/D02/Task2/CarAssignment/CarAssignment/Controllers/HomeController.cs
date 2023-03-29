using CarAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarAssignment.Controllers
{
    /*
		GetAllCars
		SelectCarById
		CreateNewCar
		Edit/UpdateCar
		DeleteCar
     
     */
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       public ActionResult GetAllCars()
        {
            ViewBag.Cars = CarList.carLists.ToList();
            return View();
       }

        public ActionResult GetCar(int id)
        {
                ViewBag.carDetails = CarList.carLists.FirstOrDefault(c => c.Num == id);
                return View();
        }
        public ActionResult Edit(int id)
        {
            ViewBag.editedCar = CarList.carLists.FirstOrDefault(c => c.Num == id);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, string Model, string Manfacture , string Color)
        {
            Car editedCar = CarList.carLists.FirstOrDefault(c => c.Num == id);

            ViewBag.editedCar = editedCar;

            if(editedCar != null)
            {
                editedCar.Color = Color;
                editedCar.Model = Model;
                editedCar.Manfacture = Manfacture;
            }
            else
            {
                CarList.carLists.Add(new Car { Color= Color  , Num=id , Manfacture = Manfacture , Model = Model});
            }
           

            return RedirectToAction("GetAllCars");
        }
    
        
        public ActionResult Delete(int id)
        {
            Car selectedCar = CarList.carLists.FirstOrDefault(c => c.Num == id);

            CarList.carLists.Remove(selectedCar);
            return RedirectToAction("GetAllCars");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(int id, string Model, string Manfacture, string Color)
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
   
  


