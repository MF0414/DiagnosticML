using DiagnosticML.ViewModels;
using System.Web.Mvc;
using System.Linq;
using System;
using DotNet.Highcharts.Options;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Enums;
using System.Drawing;
using DotNet.Highcharts;

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

        [HttpPost]
        public ActionResult Results(ClassificationChoice model)
        {


           
        

                return View(calculateDiagnosis(model));
            
              
            

        }

        public Highcharts calculateDiagnosis(ClassificationChoice model)
        {
            ML_DBEntities dbML = new ML_DBEntities();


            if (model.choiceName == "Pre-1996 Classification")
            {

                var priorProbabilityM = Convert.ToDouble(
                   (from c in dbML.pre96
                    where c.Metric == "Percent Malignant"
                    select new { c.Value }).Single().Value);

                var priorProbabilityB = Convert.ToDouble(
                        (from c in dbML.pre96
                         where c.Metric == "Percent Benign"
                         select new { c.Value }).Single().Value);

                string[,] allkeys = new string[,] {
                { "Avg Clump Thickness", "stdev Clump Thickness" },
                { "Avg Uniformity Shape", "stdev Uniformity Shape" },
                { "Avg Uniformity Size", "stdev Uniformity Size" },
                { "Avg Bland Chromatin", "stdev Bland Chromatin" },
                { "Avg Marginal Adhesion", "stdev Marginal Adhesion" },
                { "Avg Normal Nucleoli", "stdev Normal Nucleoli" },
                { "Avg Single Epithelial Cell Size", "stdev Single Epithelial Cell Size" },
                { "Avg Bare Nuclei", "stdev Bare Nuclei" },
                { "Avg Mitosis", "stdev Mitosis" }
                  };

                double[][] numbers = new double[allkeys.Length][];
                var lout = "";
                for (int i = 0; i < 9; i++)
                {
                    double[] statsValues = new double[2];


                    string key1 = allkeys[i, 0].ToString();
                    string key2 = allkeys[i, 1].ToString();

                    statsValues[0] = Convert.ToDouble(
                    (from c in dbML.pre96
                     where c.Metric == key1
                     select new { c.Value }).Single().Value);

                    statsValues[1] = Convert.ToDouble(
                    (from c in dbML.pre96
                     where c.Metric == key2
                     select new { c.Value }).Single().Value);

                    numbers[i] = statsValues;


                }

                string[,] allkeysM = new string[,] {
                { "Avg Clump Thickness M", "stdev Clump Thickness M" },
                { "Avg Uniformity Shape M", "stdev Uniformity Shape M" },
                { "Avg Uniformity Size M", "stdev Uniformity Size M" },
                { "Avg Bland Chromatin M", "stdev Bland Chromatin M" },
                { "Avg Marginal Adhesion M", "stdev Marginal Adhesion M" },
                { "Avg Normal Nucleoli M", "stdev Normal Nucleoli M" },
                { "Avg Single Epithelial Cell Size M", "stdev Single Epithelial Cell Size M" },
                { "Avg Bare Nuclei M", "stdev Bare Nuclei M" },
                { "Avg Mitosis M", "stdev Mitosis M" }
            };

                double[][] numbersM = new double[allkeysM.Length][];
                for (int i = 0; i < 9; i++)
                {
                    double[] statsValues = new double[2];

                    string key1 = allkeysM[i, 0].ToString();
                    string key2 = allkeysM[i, 1].ToString();

                    statsValues[0] = Convert.ToDouble(
                    (from c in dbML.pre96
                     where c.Metric == key1
                     select new { c.Value }).Single().Value);

                    statsValues[1] = Convert.ToDouble(
                    (from c in dbML.pre96
                     where c.Metric == key2
                     select new { c.Value }).Single().Value);

                    numbersM[i] = statsValues;
                }


                var diagnosisLikelihoodB =
                calculateProbability(model.clumpThickness, numbers[0]) *
                calculateProbability(model.uniformityShape, numbers[1]) *
                calculateProbability(model.uniformitySize, numbers[2]) *
                calculateProbability(model.blandChromatin, numbers[3]) *
                calculateProbability(model.marginalAdhesion, numbers[4]) *
                calculateProbability(model.normalNucleoli, numbers[5]) *
                calculateProbability(model.singleEpithelial, numbers[6]) *
                calculateProbability(model.bareNuclei, numbers[7]) *
                calculateProbability(model.mitosis, numbers[8]);



                var diagnosisLikelihoodM =
                calculateProbability(model.clumpThickness, numbersM[0]) *
                calculateProbability(model.uniformityShape, numbersM[1]) *
                calculateProbability(model.uniformitySize, numbersM[2]) *
                calculateProbability(model.blandChromatin, numbersM[3]) *
                calculateProbability(model.marginalAdhesion, numbersM[4]) *
                calculateProbability(model.normalNucleoli, numbersM[5]) *
                calculateProbability(model.singleEpithelial, numbersM[6]) *
                calculateProbability(model.bareNuclei, numbersM[7]) *
                calculateProbability(model.mitosis, numbersM[8]);


                if ((diagnosisLikelihoodB * priorProbabilityB) >= (diagnosisLikelihoodM * priorProbabilityM))
                {
                    ViewBag.diagnosis = "Diagnosis: Benign";
                    ViewBag.probabilityB = "The Likelihood Maximum of a Benign Tumor: " + (diagnosisLikelihoodB * priorProbabilityB).ToString();
                    ViewBag.probabilityM = "The Likelihood Maximum of a Malignant Tumor: " + (diagnosisLikelihoodM * priorProbabilityM).ToString();


                    Highcharts chart = new Highcharts("chart")
                 .InitChart(new Chart { DefaultSeriesType = ChartTypes.Bar })
                 .SetTitle(new Title { Text = "Patient Data Comparison" })
                 .SetSubtitle(new Subtitle { Text = "Data for Patient " + model.patientID })
                 .SetXAxis(new XAxis
                 {
                     Categories = new[] { "Clump Thickness", "Uniformity Size", "Uniformity Shape", "Marginal Adhesion", "Single Epithelial Cell Size",
                     "Bare Nuclei",
                     "Bland Chromatin",
                     "Normal Nucleoli",
                     "Mitosis"},

                     Title = new XAxisTitle { Text = "Cell Attributes" }
                 })
                 .SetYAxis(new YAxis
                 {
                     Min = 0,
                     Title = new YAxisTitle
                     {
                         Text = "Value 1-10",
                         Align = AxisTitleAligns.High
                     }
                 })
                 .SetTooltip(new Tooltip { Formatter = "function() { return ''+ this.series.name +': '+ this.y; }" })
                 .SetPlotOptions(new PlotOptions
                 {
                     Bar = new PlotOptionsBar
                     {
                         DataLabels = new PlotOptionsBarDataLabels { Enabled = false }
                     }
                 })
                 .SetCredits(new Credits { Enabled = false })
                 .SetSeries(new[]
                 {
                    new Series { Name = "Average Benign Patient", Data = new Data(new object[] { numbers[0][0], numbers[1][0], numbers[2][0], numbers[3][0], numbers[4][0], numbers[5][0],
                                                                                                numbers[6][0], numbers[7][0], numbers[8][0]})},
                    new Series { Name = "Average Malignant Patient", Data = new Data(new object[] { numbersM[0][0], numbersM[1][0], numbersM[2][0], numbersM[3][0], numbersM[4][0], numbersM[5][0],
                                                                                                numbersM[6][0], numbersM[7][0], numbersM[8][0]})},
                    new Series { Name = "Patient " + model.patientID.ToString(), Data = new Data(new object[] { model.clumpThickness, model.uniformitySize, model.uniformityShape, model.marginalAdhesion,
                                                                                                                model.singleEpithelial, model.bareNuclei, model.blandChromatin, model.normalNucleoli, model.mitosis}) }
            });

                    return chart;
                }
                else
                {
                    ViewBag.diagnosis = "Diagnosis: Malignant";
                    ViewBag.probabilityB = "The Likelihood Maximum of a Benign Tumor: " + (diagnosisLikelihoodB * priorProbabilityB).ToString();
                    ViewBag.probabilityM = "The Likelihood Maximum of a Malignant Tumor: " + (diagnosisLikelihoodM * priorProbabilityM).ToString();



                    Highcharts chart = new Highcharts("chart")
                 .InitChart(new Chart { DefaultSeriesType = ChartTypes.Bar })
                 .SetTitle(new Title { Text = "Patient Data Comparison" })
                 .SetSubtitle(new Subtitle { Text = "Data for Patient " + model.patientID })
                 .SetXAxis(new XAxis
                 {
                     Categories = new[] { "Clump Thickness", "Uniformity Size", "Uniformity Shape", "Marginal Adhesion", "Single Epithelial Cell Size",
                     "Bare Nuclei",
                     "Bland Chromatin",
                     "Normal Nucleoli",
                     "Mitosis"},

                     Title = new XAxisTitle { Text = "Cell Attributes" }
                 })
                 .SetYAxis(new YAxis
                 {
                     Min = 0,
                     Title = new YAxisTitle
                     {
                         Text = "Value 1-10",
                         Align = AxisTitleAligns.High
                     }
                 })
                 .SetTooltip(new Tooltip { Formatter = "function() { return ''+ this.series.name +': '+ this.y; }" })
                 .SetPlotOptions(new PlotOptions
                 {
                     Bar = new PlotOptionsBar
                     {
                         DataLabels = new PlotOptionsBarDataLabels { Enabled = false }
                     }
                 })
                 .SetCredits(new Credits { Enabled = false })
                 .SetSeries(new[]
                 {
                    new Series { Name = "Average Benign Patient", Data = new Data(new object[] { numbers[0][0], numbers[1][0], numbers[2][0], numbers[3][0], numbers[4][0], numbers[5][0],
                                                                                                numbers[6][0], numbers[7][0], numbers[8][0]})},
                    new Series { Name = "Average Malignant Patient", Data = new Data(new object[] { numbersM[0][0], numbersM[1][0], numbersM[2][0], numbersM[3][0], numbersM[4][0], numbersM[5][0],
                                                                                                numbersM[6][0], numbersM[7][0], numbersM[8][0]})},
                    new Series { Name = "Patient " + model.patientID.ToString(), Data = new Data(new object[] { model.clumpThickness, model.uniformitySize, model.uniformityShape, model.marginalAdhesion,
                                                                                                                model.singleEpithelial, model.bareNuclei, model.blandChromatin, model.normalNucleoli, model.mitosis}) }
            });

                    return chart;
                }
            }
            else
            {
                model.radius = (model.radius - 6.981) / (28.11 - 6.981);
                model.texture = (model.texture - 9.71) / (39.28 - 9.71);
                model.perimeter = (model.perimeter - 43.79) / (188.5 - 43.79);
                model.area = (model.area - 143.5) / (2501 - 143.5);

                var priorProbabilityM = Convert.ToDouble(
                    (from c in dbML.post96
                     where c.Metric == "Percent Malignant"
                     select new { c.Value }).Single().Value);

                var priorProbabilityB = Convert.ToDouble(
                        (from c in dbML.post96
                         where c.Metric == "Percent Benign"
                         select new { c.Value }).Single().Value);


                string[,] allkeys = new string[,] {
                { "Avg Radius", "stdev Radius" },
                { "Avg Texture", "stdev Texture" },
                { "Avg Perimeter", "stdev Perimeter" },
                { "Avg Area", "stdev Area" },
                { "Avg Smoothness", "stdev Smoothness" },
                { "Avg Compactness", "stdev Compactness" },
                { "Avg Concavity", "stdev Concavity" },
                { "Avg Concave Points", "stdev Concave Points" },
                { "Avg Symmetry", "stdev Symmetry" },
                { "Avg Fractal Dimension", "Avg Fractal Dimension" }
            };

                double[][] numbers = new double[allkeys.Length][];
                var lout = "";
                for (int i = 0; i < 10; i++)
                {
                    double[] statsValues = new double[2];


                    string key1 = allkeys[i, 0].ToString();
                    string key2 = allkeys[i, 1].ToString();

                    statsValues[0] = Convert.ToDouble(
                    (from c in dbML.post96
                     where c.Metric == key1
                     select new { c.Value }).Single().Value);

                    statsValues[1] = Convert.ToDouble(
                    (from c in dbML.post96
                     where c.Metric == key2
                     select new { c.Value }).Single().Value);

                    numbers[i] = statsValues;

                    lout += " " + statsValues[0] + statsValues[1];
                }

                string[,] allkeysM = new string[,] {
                        { "Avg Radius M", "stdev Radius M" },
                        { "Avg Texture M", "stdev Texture M" },
                        { "Avg Perimeter M", "stdev Perimeter M" },
                        { "Avg Area M", "stdev Area M" },
                        { "Avg Smoothness M", "stdev Smoothness M" },
                        { "Avg Compactness M", "stdev Compactness M" },
                        { "Avg Concavity M", "stdev Concavity M" },
                        { "Avg Concave Points M", "stdev Concave Points M" },
                        { "Avg Symmetry M", "stdev Symmetry M" },
                        { "Avg Fractal Dimension M", "Avg Fractal Dimension M" }

                     };

                double[][] numbersM = new double[allkeysM.Length][];
                for (int i = 0; i < 10; i++)
                {
                    double[] statsValues = new double[2];

                    string key1 = allkeysM[i, 0].ToString();
                    string key2 = allkeysM[i, 1].ToString();

                    statsValues[0] = Convert.ToDouble(
                    (from c in dbML.post96
                     where c.Metric == key1
                     select new { c.Value }).Single().Value);

                    statsValues[1] = Convert.ToDouble(
                    (from c in dbML.post96
                     where c.Metric == key2
                     select new { c.Value }).Single().Value);

                    numbersM[i] = statsValues;
                }


                var postdiagnosisLikelihoodB =
                calculateProbability(model.radius, numbers[0]) *
                calculateProbability(model.texture, numbers[1]) *
                calculateProbability(model.perimeter, numbers[2]) *
                calculateProbability(model.area, numbers[3]) *
                calculateProbability(model.smoothness, numbers[4]) *
                calculateProbability(model.compactness, numbers[5]) *
                calculateProbability(model.concavity, numbers[6]) *
                calculateProbability(model.concavePts, numbers[7]) *
                calculateProbability(model.symmetry, numbers[8]) *
                calculateProbability(model.fractalDimension, numbers[9]);



                var postdiagnosisLikelihoodM =
                calculateProbability(model.radius, numbersM[0]) *
                calculateProbability(model.texture, numbersM[1]) *
                calculateProbability(model.perimeter, numbersM[2]) *
                calculateProbability(model.area, numbersM[3]) *
                calculateProbability(model.smoothness, numbersM[4]) *
                calculateProbability(model.compactness, numbersM[5]) *
                calculateProbability(model.concavity, numbersM[6]) *
                calculateProbability(model.concavePts, numbersM[7]) *
                calculateProbability(model.symmetry, numbersM[8]) *
                calculateProbability(model.fractalDimension, numbersM[9]);


                if ((postdiagnosisLikelihoodB * priorProbabilityB) >= (postdiagnosisLikelihoodM * priorProbabilityM))
                {
                    ViewBag.diagnosis = "Diagnosis: Benign";
                    ViewBag.probabilityB = "The Likelihood Maximum of a Benign Tumor: " + (postdiagnosisLikelihoodB * priorProbabilityB).ToString();
                    ViewBag.probabilityM = "The Likelihood Maximun of a Malignant Tumor: " + (postdiagnosisLikelihoodM * priorProbabilityM).ToString();



                    Highcharts chart = new Highcharts("chart")
                 .InitChart(new Chart { DefaultSeriesType = ChartTypes.Bar })
                 .SetTitle(new Title { Text = "Patient Data Comparison" })
                 .SetSubtitle(new Subtitle { Text = "Data for Patient " + model.patientID })
                 .SetXAxis(new XAxis
                 {
                     Categories = new[] { "Radius", "Texture", "Perimeter", "Area", "Smoothness",
                     "Compactness",
                     "Concavity",
                     "Concave Points",
                     "Symmetry", "Fractal Dimension"},

                     Title = new XAxisTitle { Text = "Cell Attributes" }
                 })
                 .SetYAxis(new YAxis
                 {
                     Min = 0,
                     Title = new YAxisTitle
                     {
                         Text = "Values",
                         Align = AxisTitleAligns.High
                     }
                 })
                 .SetTooltip(new Tooltip { Formatter = "function() { return ''+ this.series.name +': '+ this.y; }" })
                 .SetPlotOptions(new PlotOptions
                 {
                     Bar = new PlotOptionsBar
                     {
                         DataLabels = new PlotOptionsBarDataLabels { Enabled = false }
                     }
                 })
                 .SetCredits(new Credits { Enabled = false })
                 .SetSeries(new[]
                 {
                    new Series { Name = "Average Benign Patient", Data = new Data(new object[] { numbers[0][0], numbers[1][0], numbers[2][0], numbers[3][0], numbers[4][0], numbers[5][0],
                                                                                                numbers[6][0], numbers[7][0], numbers[8][0], numbers[9][0]})},
                    new Series { Name = "Average Malignant Patient", Data = new Data(new object[] { numbersM[0][0], numbersM[1][0], numbersM[2][0], numbersM[3][0], numbersM[4][0], numbersM[5][0],
                                                                                                numbersM[6][0], numbersM[7][0], numbersM[8][0], numbersM[9][0]})},
                    new Series { Name = "Patient " + model.patientID.ToString(), Data = new Data(new object[] { model.radius, model.texture, model.perimeter, model.area,
                                                                                                                model.smoothness, model.compactness, model.concavity, model.concavePts, model.symmetry, model.fractalDimension}) }
            });

                    return chart;
                }
            
                else
                {
                    ViewBag.diagnosis = "Diagnosis: Malignant";
                    ViewBag.probabilityB = "The Likelihood Maximum of a Benign Tumor: " + (postdiagnosisLikelihoodB * priorProbabilityB).ToString();
                    ViewBag.probabilityM = "The Likelihood Maximum of a Malignant Tumor: " + (postdiagnosisLikelihoodM * priorProbabilityM).ToString();



                    Highcharts chart = new Highcharts("chart")
                 .InitChart(new Chart { DefaultSeriesType = ChartTypes.Bar })
                 .SetTitle(new Title { Text = "Patient Data Comparison" })
                 .SetSubtitle(new Subtitle { Text = "Data for Patient " + model.patientID })
                 .SetXAxis(new XAxis
                 {
                     Categories = new[] { "Radius", "Texture", "Perimeter", "Area", "Smoothness",
                     "Compactness",
                     "Concavity",
                     "Concave Points",
                     "Symmetry", "Fractal Dimension"},

                     Title = new XAxisTitle { Text = "Cell Attributes" }
                 })
                 .SetYAxis(new YAxis
                 {
                     Min = 0,
                     Title = new YAxisTitle
                     {
                         Text = "Values",
                         Align = AxisTitleAligns.High
                     }
                 })
                 .SetTooltip(new Tooltip { Formatter = "function() { return ''+ this.series.name +': '+ this.y; }" })
                 .SetPlotOptions(new PlotOptions
                 {
                     Bar = new PlotOptionsBar
                     {
                         DataLabels = new PlotOptionsBarDataLabels { Enabled = false }
                     }
                 })
                 .SetCredits(new Credits { Enabled = false })
                 .SetSeries(new[]
                 {
                    new Series { Name = "Average Benign Patient", Data = new Data(new object[] { numbers[0][0], numbers[1][0], numbers[2][0], numbers[3][0], numbers[4][0], numbers[5][0],
                                                                                                numbers[6][0], numbers[7][0], numbers[8][0], numbers[9][0]})},
                    new Series { Name = "Average Malignant Patient", Data = new Data(new object[] { numbersM[0][0], numbersM[1][0], numbersM[2][0], numbersM[3][0], numbersM[4][0], numbersM[5][0],
                                                                                                numbersM[6][0], numbersM[7][0], numbersM[8][0], numbersM[9][0]})},
                    new Series { Name = "Patient " + model.patientID.ToString(), Data = new Data(new object[] { model.radius, model.texture, model.perimeter, model.area,
                                                                                                                model.smoothness, model.compactness, model.concavity, model.concavePts, model.symmetry, model.fractalDimension}) }
            });

                    return chart;
                }


            }
        }

        //Calculates Gaussian Probability
        public double calculateProbability(double x, double[] statsArray)
        {
            var mean = statsArray[0];
            var stdev = statsArray[1];


            var exponent = Math.Exp(-(Math.Pow(x - mean, 2) / (2 * Math.Pow(stdev, 2))));



            return (1/(Math.Sqrt(2*Math.PI)*stdev)) * exponent;
        }




    }
}