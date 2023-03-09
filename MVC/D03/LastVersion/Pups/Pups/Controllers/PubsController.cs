using Pups.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pups.Controllers
{
    public class PubsController : Controller
    {
            pubsEntities1 context = new pubsEntities1();
        // GET: Pubs
        public ActionResult Index(string pub_id = "")
        {
            ViewBag.PublisherList = context.publishers.ToList();
            if (pub_id == "")
            {
                var pups = context.employees.ToList();
                return View(pups);
            }
            else
            {
                var pups = context.employees.Where(p => p.pub_id == pub_id).ToList();
                return View(pups);
            }
        }

        // GET: Pubs/Details/5
        public ActionResult Details(string emp_id)
        {
            return View(context.employees.ToList().Find(e=>e.emp_id.Equals(emp_id)));

        }

        // GET: Pubs/Create
        public ActionResult Create()
        {
            ViewBag.PublisherList = context.publishers.ToList();

            return View();
        }

        // POST: Pubs/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            ViewBag.PublisherList = context.publishers.ToList();

            try
            {

                employee emp = new employee();

            emp.pub_id = collection["pub_id"];
            emp.emp_id = collection["emp_id"];
            emp.lname = collection["lname"];
            emp.fname = collection["fname"];
            emp.minit = collection["minit"];
            emp.job_lvl = null;
            emp.hire_date= DateTime.Now;

             context.employees.Add(emp);

                context.SaveChanges();

                return RedirectToAction("Index");

        }
            catch
            {
                return View();
    }
}

        // GET: Pubs/Edit/5
        public ActionResult Edit(string emp_id)
        {
            ViewBag.PublisherList = context.publishers.ToList();

            return View(context.employees.ToList().Find(e=>e.emp_id== emp_id));
        }

        // POST: Pubs/Edit/5
        [HttpPost]
        public ActionResult Edit(string emp_id, FormCollection collection)
        {
            try
            {
                ViewBag.PublisherList = context.publishers.ToList();

                employee emp = context.employees.ToList().Find(e => e.emp_id == emp_id);

                emp.pub_id = collection["pub_id"];
                emp.emp_id = collection["emp_id"];
                emp.lname = collection["lname"];
                emp.fname = collection["fname"];
                emp.minit = collection["minit"].ToString().Trim();
                emp.job_lvl = null;
                emp.hire_date = DateTime.Now;

                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pubs/Delete/5
        public ActionResult Delete(string emp_id)
        {
            employee emp = context.employees.ToList().Find(e => e.emp_id == emp_id);

            return View(emp);
        }

        // POST: Pubs/Delete/5
        [HttpPost]
        public ActionResult Delete(string emp_id, FormCollection collection)
        {
            try
            {
                employee emp = context.employees.ToList().Find(e => e.emp_id == emp_id);
                context.employees.Remove(emp);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
