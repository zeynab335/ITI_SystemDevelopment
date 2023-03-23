using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Task2;
using Task2.Models;

namespace Task2.Controllers
{
    public class UsersController : Controller
    {
        private Context db = new Context();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Users/Register
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();


                var userIdentity = new ClaimsIdentity(new List<Claim>
                {
                    new Claim("Name" , user.Name),
                    new Claim("Password" , user.Password),
                    new Claim("Email" , user.Email),

                }, "AppCookie");

                // owin authentication sign in
                Request.GetOwinContext().Authentication.SignIn(userIdentity);

                return RedirectToAction("Index" , "Home");
            }

            return View(user);
        }

        // Login
        // GET: Users/Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
             var isLoggedIn =  db.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

                if (isLoggedIn!=null)
                {
                    var userIdentity = new ClaimsIdentity(new List<Claim>
                {
                    new Claim("Password" , user.Password),
                    new Claim("Email" , user.Email),

                }, "AppCookie");

                    // owin authentication sign in
                    Request.GetOwinContext().Authentication.SignIn(userIdentity);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Name", "user is not found");
                    return View(user);

                }



            

        }


        public ActionResult Logout()
        {  // destroy cookies
                Request.GetOwinContext().Authentication.SignOut("AppCookie");

                return RedirectToAction("Login");
            
        }
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
