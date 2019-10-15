using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCL.MVC.Week6.Day1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Test()
        {
            //ViewBag.Message = "user defined action.";
            //return View("Contact"); //returning the view page of contact action
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Result()
        {
            return View();
        }

        [Route("ByOwnStatement/{id}/{Name}")]
        public ActionResult checking(string id,string Name)
        {
            return Content("Id:"+id +" "+"Name:"+Name);
            //return View("check");
        }
    }
}