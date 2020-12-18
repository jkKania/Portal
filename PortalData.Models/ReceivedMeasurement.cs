using System;
using System.Collections.Generic;
using System.Text;

namespace PortalData.Models
{
    public class ReceivedMeasurement : IEntity<int>
    {
        public int ID { get; set; }
        public string DataTypeKeyName { get; set; }
        public double Value { get; set; }
        public DateTime RecordCreateTime { get; set; } = DateTime.UtcNow;
    }
}
