using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortalData.Models;
using PortalData.Services;
using PortalDataPresentation.ViewModels;

namespace PortalDataPresentation.Controllers
{
    public class AverageController : Controller
    {
        private readonly IMeasurementDataService _measurementsDataService;
        private readonly IAnalysisComputationService _analysisService;

        public AverageController(IAnalysisComputationService analysisService, IMeasurementDataService measurementsDataService)
        {
            _measurementsDataService = measurementsDataService;
            _analysisService = analysisService;
        }
        public IActionResult Index(int? portalID, string dataTypeName, DateTime? minDate, DateTime? maxDate, int? resultWidth, int? resultHeight)
        {
            IQueryable<ReceivedMeasurement> measurements;
            LineChartVM viewModel;

            measurements =
                _measurementsDataService.ExtractData(portalID, dataTypeName, minDate, maxDate);

            if (string.IsNullOrWhiteSpace(dataTypeName))
                dataTypeName = "All";

            viewModel = _measurementsDataService.CreateViewModel(null,"Average" , dataTypeName, minDate, maxDate, null, measurements, resultWidth, resultHeight);

            return View(viewModel);
        }

        [HttpPost]
        public JsonResult Average([FromBody] AnalysisVM viewModel)
        {
            if (viewModel != null)
            {
                List<ReceivedMeasurement> measurements;
                
                var parsedViewModel = _measurementsDataService.ParseData(viewModel);
                
                measurements =
                    _measurementsDataService.ExtractData(null, parsedViewModel.dataTypeName, DateTime.Parse(parsedViewModel.minDate),
                        DateTime.Parse(parsedViewModel.maxDate)).ToList();

                if (measurements.Count > 0)
                {
                    var result = _analysisService.Average(measurements, viewModel);

                    return Json(new { success = true, labels = result.X_values, result = result.Y_values});
                }
                else
                    return Json(new { success = false, result = "Selected conditions match no data" });
            }
            else
                return Json(new { success = false, result = "No data sent to server" });
        }
    }
}