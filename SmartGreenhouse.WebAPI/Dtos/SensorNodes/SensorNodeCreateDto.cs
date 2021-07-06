using System;
using System.ComponentModel.DataAnnotations;

namespace SmartGreenhouse.WebAPI.Dtos.SensorNodes
{
    public class SensorNodeCreateDto
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string DeviceType { get; set; }

        [Required]
        public string Label { get; set; }

        [Required]
        public string Location { get; set; }
    }
}
