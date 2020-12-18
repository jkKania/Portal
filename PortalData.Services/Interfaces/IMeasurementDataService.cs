using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortalData.Models;
using PortalDataPresentation.ViewModels;

namespace PortalData.Services
{
    public interface IMeasurementDataService
    {
        AnalysisVM ParseData(AnalysisVM viewModel);
        IQueryable<ReceivedMeasurement> ExtractData(int? portalID, string dataTypeName, DateTime? minDate, DateTime? maxDate);
        LineChartVM CreateViewModel(int? portalID, string controllerName,string dataTypeName, DateTime? minDate, DateTime? maxDate,
            IEnumerable<string> operations,IQueryable<ReceivedMeasurement> measurements, int? resultWidth, int? resultHeight);
        void AddMeasurement(PostMeasurementsVM measurementVM);
        StringBuilder CreateCsv(IQueryable<ReceivedMeasurement> measurements);
    }
}