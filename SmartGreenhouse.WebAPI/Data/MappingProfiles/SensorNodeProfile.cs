using AutoMapper;
using SmartGreenhouse.WebAPI.Dtos.SensorNodes;
using SmartGreenhouse.WebAPI.Models;

namespace SmartGreenhouse.WebAPI.Data.MappingProfiles
{
    public class SensorNodeProfile : Profile
    {
        public SensorNodeProfile()
        {
            CreateMap<SensorNode, SensorNodeReadDto>();
            CreateMap<SensorNodeCreateDto, SensorNode>();
            CreateMap<SensorNodeUpdateDto, SensorNode>();
        }
    }
}
