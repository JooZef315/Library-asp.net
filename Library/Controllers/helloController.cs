using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models;

namespace Library.Controllers
{
    public class helloController : Controller
    {
        library db = new library();

        [HttpGet]
        public ActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Registration(visitor v)
        {
            if (ModelState.IsValid)
            {
                if (db.visitors.FirstOrDefault(x => x.email == v.email) == null)
                {
                    db.visitors.Add(v);
                    db.SaveChanges();
                    Session["user"] = v.Uid;
                    Session["name"] = v.Fname;
                    return RedirectToAction("Index", "hello");
                }
                else
                {
                    return Content("<script>alert('User aleady exists!');</script>");
                }
            }
            else
            {
                return View();
            }
           
        }
        [HttpPost]
        public ActionResult LogIn(string LogAs, string email, string password)
        {            
            if (LogAs == "visitors")
            {
                var v = db.visitors.FirstOrDefault(x => x.email.Equals(email) && x.password.Equals(password));
                if (v != null)
                {
                    Session["user"] = v.Uid;
                    Session["name"] = v.Fname;
                    return RedirectToAction("Index");
                }
                else
                {
                    return Content("<script>alert('user email or password is wrong!');</script>");
                }
            }
            else
            {
                var e = db.employees.FirstOrDefault(x => x.email == email && x.password == password);
                if (e != null)
                {
                    Session["emp"] = e.empId;
                    Session["empName"] = e.name;
                    return RedirectToAction("Index");
                }
                else
                {
                    return Content("<script>alert('employee email or password is wrong!');</script>");
                }
            }
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            Session.Clear();                 
            return RedirectToAction("Index");
        }
    }
}