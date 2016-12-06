using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticML.ViewModels
{
    public class ClassificationChoice
    {
        public string choiceName { get; set; }
        public int choiceID { get; set; }

        public int patientID { get; set; }

       

        //Pre
        public double clumpThickness { get; set; }
        public double uniformitySize { get; set; }
        public double uniformityShape { get; set; }
        public double marginalAdhesion { get; set; }
        public double singleEpithelial { get; set; }
        public double bareNuclei { get; set; }
        public double blandChromatin { get; set; }
        public double normalNucleoli { get; set; }
        public double mitosis { get; set; }

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