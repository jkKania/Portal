using System;

namespace PortalDataPresentation.ViewModels
{
    public class PostMeasurementsVM
    {
        public int ID { get; set; }
        public string DataTypeName { get; set; }
        public string InstalationName { get; set; }
        public string LocationName { get; set; }
        public string Value { get; set; }

        public PostMeasurementsVM()
        {
            
        }
    }
}