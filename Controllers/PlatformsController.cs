using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOs;
using PlatformService.Models;
using PlatformService.SynchDataServices.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;
        private ICommandDataClient _commandDataClient;

        public PlatformsController(IPlatformRepo respository, IMapper mapper, ICommandDataClient commandDataClient)
        {
            _repository = respository;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDTO>> GetPlatforms()
        {
            Console.WriteLine("--->Getting Platforms");

            var platformItem = _repository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDTO>>(platformItem));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDTO> GetPlatformById(int id)
        {
            var platformItem = _repository.GetPlatformById(id);
            if (platformItem != null)
            {

                return Ok(_mapper.Map<PlatformReadDTO>(platformItem));
            }

            return NotFound();


        }

        [HttpPost]
        public async Task<ActionResult<PlatformReadDTO>> CreatePlatformAsync(PlatformCreateDTO platformCreateDTO)
        {
            var platformModel = _mapper.Map<Platform>(platformCreateDTO);

            _repository.CreatePlatform(platformModel);

            _repository.SaveChanges();

            var platformReadDto = _mapper.Map<PlatformReadDTO>(platformModel);

            try
            {
                await _commandDataClient.SendPlatformToCommand(platformReadDto);

            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> Could not send asynchronously: {ex.Message}");
            }

            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto.Id }, platformReadDto);

        }

    }
}
