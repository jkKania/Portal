using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalData.Models
{
    public class Location:IEntity<int>
    {
        public int OutID { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime RecordCreateTime { get; set; } = DateTime.UtcNow;

        [ForeignKey("ArtisticInstalation")]
        public int ? InstalationID { get; set; }
        public ArtisticInstalation Instalation { get; set; }

        public ICollection<MeasurementData> MeasurementDatas { get; set; }

    }
}