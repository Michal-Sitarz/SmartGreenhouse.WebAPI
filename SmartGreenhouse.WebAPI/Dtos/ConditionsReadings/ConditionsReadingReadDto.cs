using System;
using System.ComponentModel.DataAnnotations;

namespace SmartGreenhouse.WebAPI.Dtos.ConditionsReadings
{
    public class ConditionsReadingReadDto
    {
        public int Id { get; set; }

        public double AirTemperature { get; set; }

        public double AirHumidity { get; set; }

        public double SoilMoisture { get; set; }

        public int LightIntensity { get; set; }

        public DateTime TimeStamp { get; set; }

        public string SensorNodeId { get; set; }

    }
}
