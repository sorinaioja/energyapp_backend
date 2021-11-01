using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class Device
    {
        public int DeviceId { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        [ForeignKey("Sensor")]
        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public float MaximumEnergyConsumption { get; set; }
        public float AverageEnergyConsumption { get; set; }
    }
}
