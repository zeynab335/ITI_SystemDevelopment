using D03_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;


namespace DesctopApplication.Controllers
{
    public class InstructorController : Controller
    {
        HttpClient client;
        public InstructorController() {
            client = new HttpClient();
            client.BaseAddress= new Uri("https://localhost:7185/api/Instructors");
         }
        // GET: InstructorController
        public async Task<ActionResult<Instructor>> Index()
        {
            // get all instructors
            HttpResponseMessage res = client.GetAsync("").Result;
            List<Instructor> instructors;
            if (res.IsSuccessStatusCode)
            {
                instructors = res.Content.ReadAsAsync<List<Instructor>>().Result;
            }
            else
            {
                return View("Error");

            }

            return View(instructors);
        }


        // GET: InstructorController/Create
        public async Task<ActionResult<Instructor>> Create()
        {
            
            return View();
        }

        // POST: InstructorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Instructor instructor)
        {
            try
            {
                // get all instructors
                HttpResponseMessage InsertRes = client.PostAsJsonAsync("", instructor).Result;
                if (InsertRes.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return View("Error");

                }
            }
            catch
            {
                return View();
            }
        }

        // GET: InstructorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InstructorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InstructorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InstructorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
