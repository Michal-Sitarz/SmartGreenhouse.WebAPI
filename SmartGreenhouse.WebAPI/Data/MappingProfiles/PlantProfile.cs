using AutoMapper;
using SmartGreenhouse.WebAPI.Dtos.Plants;
using SmartGreenhouse.WebAPI.Models;

namespace SmartGreenhouse.WebAPI.Data.MappingProfiles
{
    public class PlantProfile : Profile
    {
        public PlantProfile()
        {
            CreateMap<Plant, PlantReadDto>();
            CreateMap<PlantCreateDto, Plant>();
            CreateMap<PlantUpdateDto, Plant>();
        }
    }
}
