using System;
using DiagnosticML;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RDotNet;
using Microsoft.Win32;
using System.IO;
using DiagnosticML.ViewModels;

namespace DiagnosticML.Controllers
{
    public class HomeController : Controller
    {
       
        ClassifierController classifierController = new ClassifierController();
        

        public ActionResult Index()
        {

            ViewBag.Message = "Index Message: Should not see";
            
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


        public ActionResult Classifier()  //Controls the Page
        {

            var classifications = new List<ClassificationType>
            {
                new ClassificationType {classID = 0, className = "Pre-1996 Classification" },
                new ClassificationType {classID = 1, className = "Post-1996 Classification" }
            };

            return View(classifications);
            
           
        }


    }
}