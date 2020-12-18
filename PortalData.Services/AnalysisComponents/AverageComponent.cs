using System.Collections.Generic;
using System.Linq;
using PortalData.Models;
using PortalDataPresentation.ViewModels;

namespace PortalData.Services.AnalysisComponents
{
    public class AverageComponent :IComputable
    {

        private ComputationResultVM _result { get; set; }

        public string Name{ get { return "Average"; } }

        public void Analyze(List<ReceivedMeasurement> measurements, AnalysisVM viewmodel)
        {
            _result = new ComputationResultVM()
            {
                X_values = new List<string>(new[]
                {
                    "Result"
                }),
                Y_values = new List<double>(new[]
                {
                    measurements.Sum(m => m.Value) / measurements.Count
                })
            };
        }

        public ComputationResultVM GetResult()
        {
            return _result;
        }
    }
}