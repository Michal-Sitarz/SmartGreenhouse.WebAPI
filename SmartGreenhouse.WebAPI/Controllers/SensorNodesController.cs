using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SmartGreenhouse.WebAPI.Dtos.SensorNodes;
using SmartGreenhouse.WebAPI.Models;
using SmartGreenhouse.WebAPI.Services.Contracts;

namespace SmartGreenhouse.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorNodesController : ControllerBase
    {
        private readonly ISensorNodesDataService _dataService;
        private readonly IMapper _mapper;

        public SensorNodesController(ISensorNodesDataService service, IMapper mapper)
        {
            _dataService = service;
            _mapper = mapper;
        }

        // GET: api/SensorNodes
        [HttpGet]
        public ActionResult<IEnumerable<SensorNodeReadDto>> GetAllSensorNodes()
        {
            var allSensorNodes = _dataService.GetAllSensorNodes();
            var allSensorNodeDtos = _mapper.Map<IEnumerable<SensorNodeReadDto>>(allSensorNodes);

            return Ok(allSensorNodeDtos); // 200 OK
        }

        // GET: api/SensorNodes/{id}
        [HttpGet("{id}", Name = "GetSensorNodeById")]
        public ActionResult<SensorNodeReadDto> GetSensorNodeById(int id)
        {
            var SensorNode = _dataService.GetSensorNodeById(id);
            if (SensorNode == null)
            {
                return NotFound(); // 404 Not Found
            }

            var SensorNodeReadDto = _mapper.Map<SensorNodeReadDto>(SensorNode);

            return Ok(SensorNodeReadDto); // 200 OK
        }

        // POST: api/SensorNodes
        [HttpPost]
        public ActionResult<SensorNodeReadDto> CreateSensorNode(SensorNodeCreateDto SensorNodeCreateDto)
        {
            var SensorNode = _mapper.Map<SensorNode>(SensorNodeCreateDto);
            _dataService.CreateSensorNode(SensorNode);

            var SensorNodeReadDto = _mapper.Map<SensorNodeReadDto>(SensorNode);

            return CreatedAtRoute(nameof(GetSensorNodeById), new { Id = SensorNodeReadDto.Id }, SensorNodeReadDto); // 201 Created

        }

        // PUT: api/SensorNodes/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateSensorNode(int id, SensorNodeUpdateDto SensorNodeUpdateDto)
        {
            var SensorNode = _dataService.GetSensorNodeById(id);
            if(SensorNode == null)
            {
                return NotFound(); // 404 Not Found
            }

            _mapper.Map(SensorNodeUpdateDto, SensorNode);
            _dataService.UpdateSensorNode(SensorNode);

            return NoContent(); // 204 No Content
        }

        // DELETE: api/SensorNodes/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteSensorNode(int id)
        {
            var SensorNode = _dataService.GetSensorNodeById(id);
            if (SensorNode == null)
            {
                return NotFound(); // 404 Not Found
            }

            _dataService.DeleteSensorNode(SensorNode);

            return NoContent(); // 204 No Content
        }
    }
}
