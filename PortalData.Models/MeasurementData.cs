using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace PortalData.Models
{
    public class MeasurementData: IEntity<int>
    {
        public int ID { get; set; }

        [ForeignKey("DataType")]
        public int DataTypeID { get; set; }
        public  DataType DataType { get; set; }

        [ForeignKey("Location")]
        public int LocationID { get; set; }
        public Location Location { get; set; }

        [ForeignKey("ArtisticInstalation")]
        public int InstalationID { get; set; }
        public  ArtisticInstalation Instalation { get; set; }

        public double Value { get; set; }
        public DateTime MeasurmentDate { get; set; }
        public DateTime RecordCreateTime { get; set; } = DateTime.UtcNow;

    }
}