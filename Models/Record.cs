using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class Record
    {
        public int RecordId { get; set; }

        [ForeignKey("Sensor")]
        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }
        public DateTime Timestamp { get; set; }
        public float EnergyConsumption { get; set; }
    }
}
