using System.Collections.Generic;
using PortalData.Models;
using PortalDataPresentation.ViewModels;

namespace PortalData.Services
{
    public interface IAnalysisComputationService
    {
        ComputationResultVM Average(List<ReceivedMeasurement> measurements, AnalysisVM viewmodel);
        ComputationResultVM Max(List<ReceivedMeasurement> measurements, AnalysisVM viewmodel);
        ComputationResultVM Trend(List<ReceivedMeasurement> measurements, AnalysisVM viewmodel);
        ComputationResultVM Prediction(List<ReceivedMeasurement> measurements, AnalysisVM viewmodel);
    }
}