using DiagnosticML.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiagnosticML.Controllers
{
    public class ClassifierController : Controller
    {
        // GET: Classifier

        public ActionResult Classify(string className, int classID)
        {
            var classModel = new ClassificationChoice { choiceName = className, choiceID = classID };
            return View(classModel);


        }

        public ActionResult Results(string messageIn)
        {
            var classModel = new Results { message = messageIn };
            return View(classModel);


        }



    }
}