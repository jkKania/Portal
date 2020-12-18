using System;
using System.Collections.Generic;
using System.Text;
using PortalData.Models;
using PortalDataPresentation.ViewModels;

namespace PortalData.Services
{
    public interface IComputable
    {
        string Name { get; }
        void Analyze(List<ReceivedMeasurement> measurements, AnalysisVM viewmodel);
        ComputationResultVM GetResult();
    }
}
