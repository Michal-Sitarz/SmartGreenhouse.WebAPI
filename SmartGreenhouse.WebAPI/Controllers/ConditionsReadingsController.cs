using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SmartGreenhouse.WebAPI.Dtos.ConditionsReadings;
using SmartGreenhouse.WebAPI.Models;
using SmartGreenhouse.WebAPI.Services.Contracts;

namespace SmartGreenhouse.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConditionsReadingsController : ControllerBase
    {
        private readonly IConditionsReadingsDataService _dataService;
        private readonly IMapper _mapper;

        public ConditionsReadingsController(IConditionsReadingsDataService service, IMapper mapper)
        {
            _dataService = service;
            _mapper = mapper;
        }

        // GET: api/ConditionsReadings
        [HttpGet]
        public ActionResult<IEnumerable<ConditionsReadingReadDto>> GetAllConditionsReadings()
        {
            var allConditionsReadings = _dataService.GetAllConditionsReadings();
            var allConditionsReadingDtos = _mapper.Map<IEnumerable<ConditionsReadingReadDto>>(allConditionsReadings);

            //var allConditionsReadingDtos = new List<ConditionsReadingReadDto>
            //{
            //    new ConditionsReadingReadDto {
            //        Id = 1,
            //        AirHumidity = 60,
            //        AirTemperature = 19,
            //        TimeStamp = System.DateTime.Now
            //    },
            //    new ConditionsReadingReadDto {
            //        Id = 2,
            //        AirHumidity = 65,
            //        AirTemperature = 25,
            //        TimeStamp = System.DateTime.Now
            //    }
            //};

            return Ok(allConditionsReadingDtos); // 200 OK
        }

        // GET: api/ConditionsReadings/{id}
        [HttpGet("{id}", Name = "GetConditionsReadingById")]
        public ActionResult<ConditionsReadingReadDto> GetConditionsReadingById(int id)
        {
            var ConditionsReading = _dataService.GetConditionsReadingById(id);
            if (ConditionsReading == null)
            {
                return NotFound(); // 404 Not Found
            }

            var ConditionsReadingReadDto = _mapper.Map<ConditionsReadingReadDto>(ConditionsReading);

            return Ok(ConditionsReadingReadDto); // 200 OK
        }

        // POST: api/ConditionsReadings
        [HttpPost]
        public ActionResult<ConditionsReadingReadDto> CreateConditionsReading(ConditionsReadingCreateDto ConditionsReadingCreateDto)
        {
            var ConditionsReading = _mapper.Map<ConditionsReading>(ConditionsReadingCreateDto);
            _dataService.CreateConditionsReading(ConditionsReading);

            var ConditionsReadingReadDto = _mapper.Map<ConditionsReadingReadDto>(ConditionsReading);

            return CreatedAtRoute(nameof(GetConditionsReadingById), new { Id = ConditionsReadingReadDto.Id }, ConditionsReadingReadDto); // 201 Created

        }

        // PUT: api/ConditionsReadings/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateConditionsReading(int id, ConditionsReadingUpdateDto ConditionsReadingUpdateDto)
        {
            var ConditionsReading = _dataService.GetConditionsReadingById(id);
            if (ConditionsReading == null)
            {
                return NotFound(); // 404 Not Found
            }

            _mapper.Map(ConditionsReadingUpdateDto, ConditionsReading);
            _dataService.UpdateConditionsReading(ConditionsReading);

            return NoContent(); // 204 No Content
        }

        // DELETE: api/ConditionsReadings/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteConditionsReading(int id)
        {
            var ConditionsReading = _dataService.GetConditionsReadingById(id);
            if (ConditionsReading == null)
            {
                return NotFound(); // 404 Not Found
            }

            _dataService.DeleteConditionsReading(ConditionsReading);

            return NoContent(); // 204 No Content
        }
    }
}
