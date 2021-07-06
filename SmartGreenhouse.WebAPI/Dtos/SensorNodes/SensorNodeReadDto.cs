using System;
using System.ComponentModel.DataAnnotations;

namespace SmartGreenhouse.WebAPI.Dtos.SensorNodes
{
    public class SensorNodeReadDto
    {
        public string Id { get; set; }

        public string DeviceType { get; set; }

        public string Label { get; set; }

        public string Location { get; set; }
    }
}
