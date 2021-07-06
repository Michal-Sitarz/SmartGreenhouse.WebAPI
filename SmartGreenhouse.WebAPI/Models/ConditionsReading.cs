using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGreenhouse.WebAPI.Models
{
    public class ConditionsReading
    {
        public int Id { get; set; }

        public int AirTemperature { get; set; }

        public int AirHumidity { get; set; }

        public int SoilMoisture { get; set; }

        public int LightIntensity { get; set; }

        public DateTime TimeStamp { get; set; }

        public int SensorNodeId { get; set; }

        public SensorNode SensorNode { get; set; }
    }
}
