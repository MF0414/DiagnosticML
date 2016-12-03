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
            if (classID == 0)
            {
                var classModel = new ClassificationChoice { choiceName = className, choiceID = classID };
                return View(classModel);
            }
            else
            {
                var classModel = new ClassificationChoice { choiceName = className, choiceID = classID };
                return View(classModel);
            }


        }
    }
}