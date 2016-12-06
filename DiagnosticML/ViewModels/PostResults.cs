using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticML.ViewModels
{
    public class PostResults
    {
        public double info { get; set; }

        public double patientID { get; set; }

        public string diagnosis { get; set; }

        public List<double> patientData { set; get; }
    }
}