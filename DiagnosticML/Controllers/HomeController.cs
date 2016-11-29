using System;
using DiagnosticML;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RDotNet;
using Microsoft.Win32;

namespace DiagnosticML.Controllers
{
    public class HomeController : Controller
    {
        ML_DBEntities dbML = new ML_DBEntities();
        

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

       

        public ActionResult Classifier()
        {
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\R-core\R");
            string rPath = (string)registryKey.GetValue("InstallPath");
            string rVersion = (string)registryKey.GetValue("Current Version");
            registryKey.Dispose();

            REngine.SetEnvironmentVariables();
            REngine engine = REngine.GetInstance();
            engine.Initialize();

            NumericVector testVector = engine.CreateNumericVector(new double[] { 30.02, 29.99, 30.11, 29.97, 30.01, 29.99 });
            var x = (from m in dbML.R_Functions select m).ToList();
            //(from m in dbML.R_Functions where m.functionName=="stats" select m).ToList();
            var statsFunction = engine.Evaluate(x.FirstOrDefault().script).AsFunction();

            var result = statsFunction.Invoke(new SymbolicExpression[] { testVector }).AsVector();
            int vecLen = result.Length;
            object[] resultArray = new object[vecLen];
            result.CopyTo(resultArray,vecLen);
            string message = "";
            for(int i = 0; i<vecLen; i++)
            {
                message += " ";
                message += resultArray[i].ToString();
            }

            ViewBag.message = message;
            ViewBag.statsDesc = "StatsDesc";
            return View();

        }

    }
}