using DiagnosticML;
using DiagnosticML.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



    class NaiveBayes
    {

        public string calculateDiagnosis(ClassificationChoice model)
        {
            ML_DBEntities dbML = new ML_DBEntities();
            if (model.choiceID == 0)
            {
                var x = (from m in dbML.pre96 where m.Metric == "Avg Clump Thickness" select m).ToList().ToString();
                return x;
            }
            else
            {
                var x = "nope";
                return x;
            }


            
        }

        public double calculateProbability(double x, double mean, double stdev)
        {


            return 1.0;
        }

        













    





























}