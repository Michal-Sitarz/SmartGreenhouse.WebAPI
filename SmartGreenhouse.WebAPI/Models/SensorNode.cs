using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGreenhouse.WebAPI.Models
{
    public class SensorNode
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string DeviceType { get; set; }

        [Required]
        public string Label { get; set; }

        [Required]
        public string Location { get; set; }

        public ICollection<ConditionsReading> Readings { get; set; } = new List<ConditionsReading>();
    }
}
