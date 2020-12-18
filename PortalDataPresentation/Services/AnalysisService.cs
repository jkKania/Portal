using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortalData.Models;
using PortalData.Services.AnalysisComponents;
using PortalData.Services.Enums;
using PortalDataPresentation.ViewModels;

namespace PortalData.Services
{
    public class AnalysisService : IAnalysisComputationService
    {
        private ComputationResultVM Count(List<ReceivedMeasurement> measurements, IComputable analyzeComponent, AnalysisVM viewmodel)
        {
            analyzeComponent.Analyze(measurements, viewmodel);
            return analyzeComponent.GetResult();
        }
        public ComputationResultVM Average(List<ReceivedMeasurement> measurements, AnalysisVM viewmodel)
        {
            return Count(measurements, new AverageComponent(), viewmodel);
        }
        public ComputationResultVM Max(List<ReceivedMeasurement> measurements, AnalysisVM viewmodel)
        {
            return Count(measurements, new MaxComponent(), viewmodel);
        }
        public ComputationResultVM Trend(List<ReceivedMeasurement> measurements, AnalysisVM viewmodel)
        {
            return Count(measurements, new TrendComponent(), viewmodel);
        }

        public ComputationResultVM Prediction(List<ReceivedMeasurement> measurements, AnalysisVM viewmodel)
        {
            return Count(measurements, new PredictionComponent(), viewmodel);
        }
    }
}