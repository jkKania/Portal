using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortalData.Models;
using PortalDataPresentation.ViewModels;

namespace PortalData.Services.AnalysisComponents
{
    public class MaxComponent : IComputable
    {
        private ComputationResultVM _result { get; set; }
        public string Name { get { return "Max"; } }

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
                    measurements.Max(m => m.Value)
                })
            };
        }

        public ComputationResultVM GetResult()
        {
            return _result;
        }
    }
}