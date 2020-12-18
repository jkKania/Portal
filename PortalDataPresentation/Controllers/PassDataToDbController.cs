using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;
using PortalDataPresentation.ViewModels;
using PortalData.Models;
using PortalData.Services;
using PortalDataPresentation.DAL;

namespace PortalDataPresentation.Controllers
{
    [Produces("application/json")]
    public class PassDataToDbController : Controller
    {
        private readonly IRepository<ReceivedMeasurement> _ReceivedMeasurementRepo;
        public PassDataToDbController(PortalContext context)
        {
            _ReceivedMeasurementRepo = new EfRepository<ReceivedMeasurement>(context);
        }
        [HttpPost]
        public async Task<IActionResult> Index([FromBody] ReceivedMeasurementVM MeasurementVM)
        {
            var Measurement = new ReceivedMeasurement
            {
                DataTypeKeyName = MeasurementVM.DataTypeKeyName,
                Value = MeasurementVM.Value
            };
            await _ReceivedMeasurementRepo.AddAsync(Measurement);

            return Ok();
        }
        [HttpGet]
        public JsonResult GetData()
        {
            var measurements = _ReceivedMeasurementRepo.Get().OrderByDescending(x => x.RecordCreateTime).Take(100).ToList();
            return Json(measurements);
        }
    }
}