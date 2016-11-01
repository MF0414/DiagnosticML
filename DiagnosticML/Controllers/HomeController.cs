using System;
using DiagnosticML;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiagnosticML.Controllers
{
    public class HomeController : Controller
    {
        ML_DBEntities dbML = new ML_DBEntities();
        

        public ActionResult Index()
        {
            var x = (from m in dbML.temptables select m).ToList();
            ViewBag.Message = x.FirstOrDefault().text;
            
            
           // List<temptable> StudentCountTrend = dbML.temptable(id, "text").ToList();

            return View();
        }

        public ActionResult About()
        {
            
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Classifier()
        {
            ViewBag.Message = "Application Page";

            return View();

        }
    }
}