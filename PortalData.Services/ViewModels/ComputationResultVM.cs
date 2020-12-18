using System.Collections.Generic;

namespace PortalDataPresentation.ViewModels
{
    public class ComputationResultVM
    {
        public List<string> X_values { get; set; }
        public List<string> X2_values { get; set; }
        public List<double> Y_values { get; set; }
        public List<double> Y2_values { get; set; }
        public string Formula { get; set; }
    }
}