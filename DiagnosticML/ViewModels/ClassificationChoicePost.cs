using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticML.ViewModels
{
    public class ClassificationChoicePost
    {
        public string choiceName { get; set; }
        public int choiceID { get; set; }

        public int patientID { get; set; }

        //Post
        public double radius { get; set; }
        public double texture { get; set; }
        public double perimeter { get; set; }
        public double area { get; set; }
        public double smoothness { get; set; }
        public double compactness { get; set; }
        public double concavity { get; set; }
        public double concavePts { get; set; }
        public double symmetry { get; set; }
        public double fractalDimension { get; set; }

       

        
    }
}