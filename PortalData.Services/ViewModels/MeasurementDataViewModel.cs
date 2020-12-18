using System;
using PortalData.Models;

namespace PortalDataPresentation.ViewModels
{
    public class MeasurementDataViewModel
    {
        public int ID { get; set; }
        public DateTime MeasurmentDate { get; set; }
        public string DataTypeName { get; set; }
        public double Value { get; set; }

        public MeasurementDataViewModel()
        {
            
        }
    }
}