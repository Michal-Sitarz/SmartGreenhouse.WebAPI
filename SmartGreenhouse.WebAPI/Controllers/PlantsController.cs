using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SmartGreenhouse.WebAPI.Dtos.Plants;
using SmartGreenhouse.WebAPI.Models;
using SmartGreenhouse.WebAPI.Services.Contracts;

namespace SmartGreenhouse.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly IPlantsDataService _dataService;
        private readonly IMapper _mapper;

        public PlantsController(IPlantsDataService service, IMapper mapper)
        {
            _dataService = service;
            _mapper = mapper;
        }

        // GET: api/plants
        [HttpGet]
        public ActionResult<IEnumerable<PlantReadDto>> GetAllPlants()
        {
            var allPlants = _dataService.GetAllPlants();
            var allPlantDtos = _mapper.Map<IEnumerable<PlantReadDto>>(allPlants);

            return Ok(allPlantDtos); // 200 OK
        }

        // GET: api/plants/{id}
        [HttpGet("{id}", Name = "GetPlantById")]
        public ActionResult<PlantReadDto> GetPlantById(int id)
        {
            var plant = _dataService.GetPlantById(id);
            if (plant == null)
            {
                return NotFound(); // 404 Not Found
            }

            var plantReadDto = _mapper.Map<PlantReadDto>(plant);

            return Ok(plantReadDto); // 200 OK
        }

        // POST: api/plants
        [HttpPost]
        public ActionResult<PlantReadDto> CreatePlant(PlantCreateDto plantCreateDto)
        {
            var plant = _mapper.Map<Plant>(plantCreateDto);
            _dataService.CreatePlant(plant);

            var plantReadDto = _mapper.Map<PlantReadDto>(plant);

            return CreatedAtRoute(nameof(GetPlantById), new { Id = plantReadDto.Id }, plantReadDto); // 201 Created

        }

        // PUT: api/plants/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePlant(int id, PlantUpdateDto plantUpdateDto)
        {
            var plant = _dataService.GetPlantById(id);
            if(plant == null)
            {
                return NotFound(); // 404 Not Found
            }

            _mapper.Map(plantUpdateDto, plant);
            _dataService.UpdatePlant(plant);

            return NoContent(); // 204 No Content
        }

        // DELETE: api/plants/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePlant(int id)
        {
            var plant = _dataService.GetPlantById(id);
            if (plant == null)
            {
                return NotFound(); // 404 Not Found
            }

            _dataService.DeletePlant(plant);

            return NoContent(); // 204 No Content
        }
    }
}
