using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalData.Models;

namespace PortalDataPresentation.ViewModels
{
    public class LineChartVM
    {
        public List<ReceivedMeasurement> Data { get; set; }
        public int? ChartWidth { get; set; }
        public int? ChartHeight { get; set; }
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public string DataTypeName { get; set; }
        public IEnumerable<string> Operations { get; set; }
        public string Controller { get; set; }

        public List<SelectListItem> DataTypeNames { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = String.Empty, Text = "All"},
            new SelectListItem { Value = "Temperature", Text = "Temperature" },
            new SelectListItem { Value = "Humidity", Text = "Humidity" },
            new SelectListItem { Value = "Photoresistor", Text = "Photoresistor"  },
            new SelectListItem { Value = "Pressure", Text = "Pressure"  },
            new SelectListItem { Value = "Lux", Text = "Lux"  },
            new SelectListItem { Value = "TEMP", Text = "TEMP"  },
        };
    }
}