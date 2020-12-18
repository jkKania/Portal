using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDataPresentation.ViewModels
{
    public class LineChartViewModel
    {
        public List<MeasurementDataViewModel> Data { get; set; }
        public int? ChartWidth { get; set; }
        public int? ChartHeight { get; set; }
    }
}
