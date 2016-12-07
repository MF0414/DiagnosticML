using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticML.ViewModels
{
    public class ClassificationChoicePre
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

        
    }
}