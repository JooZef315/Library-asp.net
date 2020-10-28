using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models;

namespace Library.Controllers
{
    public class homeController : Controller
    {
        library db = new library(); 

        [HttpGet]
        public ActionResult lib()
        {
            if (Session["user"] != null)
            {
                var b = db.books.ToList();
                return View(b);
            }
            else
            {
                return Content("<script>alert('please log in first');</script>");
            }
        }

        [HttpGet]
        public ActionResult Mylib()
        {
            if (Session["user"] != null)
            {
                int v = (int)Session["user"];
                var vv = db.visitors.FirstOrDefault(vis => vis.Uid == v);
                var b = vv.books.ToList();
                return View(b);
            }
            else
            {
                return Content("<script>alert('please log in first');</script>");
            }           
        }

        [HttpGet]
        public ActionResult details(string isbn)
        {
            var b = db.books.Find(isbn);
            return View(b);
        }

        [HttpGet]
        public ActionResult AddToMyList(string isbn, int Uid)
        {
            var vv = db.visitors.FirstOrDefault(v => v.Uid == Uid);
            var b = db.books.FirstOrDefault(v => v.isbn == isbn);
            vv.books.Add(b);
            db.SaveChanges();
            return RedirectToAction("Mylib");
        }

        [HttpGet]
        public ActionResult RemoveFromMyList(string isbn, int Uid)
        {
            var vv = db.visitors.FirstOrDefault(v => v.Uid == Uid);
            var b = vv.books.FirstOrDefault(v => v.isbn == isbn);
            vv.books.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Mylib");
        }

        public ActionResult DeleteAcc(int Uid)
        {
            var v = db.visitors.Find(Uid);
            v.books.Clear();
            db.visitors.Remove(v);
            db.SaveChanges();
            Session.Clear();
            return RedirectToAction("Index", "hello");
        }

        [HttpGet]
        public ActionResult admin()
        {
            if (Session["emp"] != null)
            {
                var b = db.books.ToList();
                return View(b);
            }
            else
            {
                return Content("<script>alert('please log in first');</script>");
            } 
        }

        [HttpGet]
        public ActionResult add()
        {
            if (Session["emp"] != null)
            {
                int e = (int)Session["emp"];
                ViewBag.emp = new SelectList(db.employees.ToList(), "empId", "name", e);
                return View();
            }
            else
            {
                return Content("<script>alert('please log in first');</script>");
            }
        }

        [HttpPost]
        public ActionResult add(book b)
        {
            if (db.books.FirstOrDefault(bb => bb.isbn == b.isbn) == null)
            {
                b.empBId = (int)Session["emp"];
                db.books.Add(b);
                db.SaveChanges();
                return RedirectToAction("admin");
            }
            else
            {
                return Content("<script>alert('book aleady added!');</script>");
            }
        }

        [HttpGet]
        public ActionResult removeBook(string isbn)
        {
            var b = db.books.Find(isbn);
            db.books.Remove(b);
            db.SaveChanges();
            return RedirectToAction("admin");
        }
    }
}