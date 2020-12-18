using System;

namespace PortalData.Models
{
    public interface IEntity<Type>
    {
        Type ID { get; set; }
        DateTime RecordCreateTime { get; set; }
    }
}