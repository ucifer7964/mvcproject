using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerApplication.Models;

namespace CustomerApplication.Controllers
{
    
    public class HomeController : Controller
    {
        // GET: Home
        DbServices db = new DbServices();
        public ActionResult Index()
        {
            return View();
        }
       
        
      
        public ActionResult get()
        {
            DataSet ds = db.Get();
            List<customer> cstlist = new List<customer>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                cstlist.Add(new customer
                {
                    Id = Convert.ToInt32(dr[0]),
                    Name = dr[1].ToString(),
                    Amount = Convert.ToInt32(dr[2]),
                    City = dr[3].ToString()
                }) ; 
            }

            return Json(cstlist, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( customer obj)
        {
      
            if (ModelState.IsValid == true)
            {
                db.Create(obj);
                ModelState.Clear();
                ViewBag.Msg = "<script>alert('Data saved successfully')</script>";
            }
            else
            {
                //ViewBag.Msg = "<script>alert('Something went wrong')</script>";
            }
            var data = new { status = "ok", msg = "Data saved successfully" };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}