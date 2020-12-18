using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalData.Models;
using PortalData.Services;
using PortalDataPresentation.DAL;
using System.Threading.Tasks;
using AutoMapper;
using PortalDataPresentation.ViewModels;

namespace PortalDataPresentation.Controllers
{
    [Produces("application/json")]
    public class MeasurementDatasController : Controller
    {
        private readonly IMeasurementDataService _measurementsDataService;
        private readonly IEnumerable<IComputable> _analysisOptions;
        public MeasurementDatasController(IMapper mapper, IMeasurementDataService measurementsDataService, IEnumerable<IComputable> analysisOptions)
        {
            _measurementsDataService = measurementsDataService;
            _analysisOptions = analysisOptions;
        }
        public async Task<IActionResult> Index(int? portalID, string dataTypeName, DateTime? minDate, DateTime? maxDate, int? resultWidth, int? resultHeight)
        {
            IQueryable<ReceivedMeasurement> measurements;
            LineChartVM viewModel;

            measurements =
                _measurementsDataService.ExtractData(portalID, dataTypeName, minDate, maxDate);

            if (string.IsNullOrWhiteSpace(dataTypeName))
                dataTypeName = "All";

            viewModel = _measurementsDataService.CreateViewModel(null, "MeasurementDatas", dataTypeName, minDate, maxDate, _analysisOptions.Select(a => a.Name), measurements,  resultWidth, resultHeight);

            return View(viewModel);
        }

        public async Task<PartialViewResult> RefreshTable(int? portalID, string dataTypeName, DateTime? minDate, DateTime? maxDate)
        {
            IQueryable<ReceivedMeasurement> measurements;
            measurements = _measurementsDataService.ExtractData(portalID, dataTypeName, minDate, maxDate);

            return PartialView(measurements);
        }

        public async Task<IActionResult> LineChart(int? portalID, string dataTypeName, DateTime? minDate, DateTime? maxDate, int? resultWidth, int? resultHeight)
        {
            LineChartVM viewModel;
            IQueryable<ReceivedMeasurement> measurements;

            measurements = _measurementsDataService.ExtractData(portalID, dataTypeName, minDate, maxDate);

            viewModel = _measurementsDataService.CreateViewModel(null, "MeasurementDatas", null, null, null,null, measurements, resultWidth, resultHeight);
            return PartialView(viewModel);
        }

        public IActionResult DownloadCsv(string dataTypeName, DateTime? minDate, DateTime? maxDate)
        {
            IQueryable<ReceivedMeasurement> measurements;
            StringBuilder builder;

            measurements = _measurementsDataService.ExtractData(null, dataTypeName, minDate, maxDate);
            builder = _measurementsDataService.CreateCsv(measurements);

            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Measurements.csv");
        }

        public async Task<PartialViewResult> MapLocation()
        {
            return PartialView();
        }

        //ADMIN PANEL FEATURES
        public async Task<IActionResult> GetMeasurements(string key, string value)
        {
            return RedirectToAction(nameof(Index));
        }

        public IActionResult PostMeasurements()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PostMeasurements(PostMeasurementsVM measurementVM)
        {
            _measurementsDataService.AddMeasurement(measurementVM);
           
            return RedirectToAction(nameof(Index));
        }
    }
}