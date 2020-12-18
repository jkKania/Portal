using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalData.Models
{
    public class DataType : IEntity<int>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string KeyName { get; set; }
        public DateTime RecordCreateTime { get; set; } = DateTime.UtcNow;

        public ICollection<MeasurementData> MeasurementDatas { get; set; }
    }
}