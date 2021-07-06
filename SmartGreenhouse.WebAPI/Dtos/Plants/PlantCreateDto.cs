using System;
using System.ComponentModel.DataAnnotations;

namespace SmartGreenhouse.WebAPI.Dtos.Plants
{
    public class PlantCreateDto
    {
        [Required]
        public string Name { get; set; }

        public string Variety { get; set; }

        public int CurrentHeight { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DatePlanted { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateHarvested { get; set; }
    }
}
