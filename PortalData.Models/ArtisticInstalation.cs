using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PortalData.Models
{
    public class ArtisticInstalation : IEntity<int>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime RecordCreateTime { get; set; } = DateTime.UtcNow;

        [ForeignKey("CurentLocation")]
        public int ? CurentLocationId { get; set; }
        public Location CurentLocation { get; set; }

        protected ICollection<Location> LocationHistory { get; set; }
        public  ICollection<MeasurementData> MeasurementDatas { get; set; }

    }
}
