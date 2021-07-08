using AutoMapper;
using SmartGreenhouse.WebAPI.Dtos.ConditionsReadings;
using SmartGreenhouse.WebAPI.Models;

namespace SmartGreenhouse.WebAPI.Data.MappingProfiles
{
    public class ConditionsReadingProfile : Profile
    {
        public ConditionsReadingProfile()
        {
            CreateMap<ConditionsReading, ConditionsReadingReadDto>();
            CreateMap<ConditionsReadingCreateDto, ConditionsReading>();
            CreateMap<ConditionsReadingUpdateDto, ConditionsReading>();
        }
    }
}
