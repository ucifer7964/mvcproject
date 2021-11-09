using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCEmployee.Models;

namespace MVCEmployee.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        // database company1

        DbServices db = new DbServices();

        public ActionResult Index()
        {
            return View(db.Get());
        }
        public ActionResult Edit(int id)
        {
            var row = db.Get().Find(model => model.Id == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Employee obj)
        {
            db.Update(obj);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var row = db.Get().Find(model => model.Id == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(Employee obj)
        {

            db.Del(obj);
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult Add(Employee e)
        {
            if(ModelState.IsValid == true)
            {
                db.Add(e);
                ModelState.Clear();
                ViewBag.AddMsg = "<script>alert('data saved successfully!!!')</script>";
            }
            else
            {
                ViewBag.AddMsg = "<script>alert('Something went wrong!!!')</script>";
            }
           
            return View();
        }
    }
}