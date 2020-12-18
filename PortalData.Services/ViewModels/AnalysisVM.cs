using System;

namespace PortalDataPresentation.ViewModels
{
    public class AnalysisVM
    {
        public string minDate { get; set; }
        public string maxDate { get; set; }
        public string dataTypeName { get; set; }
        public int polynomialDegree { get; set; }
        public string predictionDate { get; set; }
        public string regressionMethod { get; set; }
    }
}