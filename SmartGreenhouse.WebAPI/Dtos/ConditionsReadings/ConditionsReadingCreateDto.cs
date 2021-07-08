﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SmartGreenhouse.WebAPI.Dtos.ConditionsReadings
{
    public class ConditionsReadingCreateDto
    {
        public int AirTemperature { get; set; }

        public int AirHumidity { get; set; }

        public int SoilMoisture { get; set; }

        public int LightIntensity { get; set; }

        public DateTime TimeStamp { get; set; }

        public string SensorNodeId { get; set; }

    }
}