using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class Sensor
    {
        public int SensorId { get; set; }
        public string Description { get; set; }
        public float MaximumValue { get; set; }

        public Device Device { get; set; }

        public IEnumerable<Record> Records { get; set; }
    }
}
