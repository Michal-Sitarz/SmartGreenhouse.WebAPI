using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGreenhouse.WebAPI.Models
{
    public class ConditionsReading
    {
        public int Id { get; set; }

        public double AirTemperature { get; set; }

        public double AirHumidity { get; set; }

        public double SoilMoisture { get; set; }

        public int LightIntensity { get; set; }

        public DateTime TimeStamp { get; set; }

        public string SensorNodeId { get; set; }

        public SensorNode SensorNode { get; set; }
    }
}
