using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _21_WCF_Assignment_1_Task2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string btnclickVal)
        {
            if (btnclickVal == "HTTPButton")
            {
                ServiceReference1.Service1Client Objhttp = new ServiceReference1.Service1Client("ephttp");
                Objhttp.Open();
                List<string> GetOpenings = Objhttp.GetJobOpenings().ToList();
                ViewBag.GetOpening = GetOpenings;                
                List<string> GetOpeningsByRole = Objhttp.GetJobOpeningsByRole("LEAD").ToList();
                ViewBag.GetOpeningByRole = GetOpeningsByRole;
                Objhttp.Close();
            }
            return View();
        }

        public ActionResult About()
        {
           
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}