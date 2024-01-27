using AutoMapper;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_WebAPI.Models;
using WebApplication_WebAPI.Models.DTOs;
using WebApplication_WebAPI.Repository;
using WebApplication_WebAPI.Repository.IRepository;

namespace WebApplication_WebAPI.Controllers
{
    [Route("api/Trail")]
    [ApiController]
    //[Authorize]
    public class TrailController : ControllerBase
    {
        private readonly ITrailRepository _trailRepository;
        private readonly IMapper _mapper;
        public TrailController(ITrailRepository trailRepository, IMapper mapper)
        {
            _trailRepository = trailRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetTrails()
        {
            return Ok(_trailRepository.GetTrails().ToList().Select(_mapper.Map<Trail, TrailDto>));
        }
        [HttpGet("{trailId:int}", Name = "GetTrail")]
        public IActionResult GetTrail(int trailId)
        {
            var trail = _trailRepository.GetTrail(trailId);
            if (trail == null) return NotFound();
            return Ok(_mapper.Map<TrailDto>(trail));
        }
        [HttpPost]
        public IActionResult CreateTrail([FromBody]TrailDto trailDto)
        {
            if (trailDto == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            if (_trailRepository.TrailExists(trailDto.Name))
            {
                ModelState.AddModelError("", $"Trail in Db: {trailDto.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
            var trail = _mapper.Map<Trail>(trailDto);
            if (!_trailRepository.CreateTrail(trail))
            {
                ModelState.AddModelError("",$"Something went wrong while save trail");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }  
            return CreatedAtRoute("GetTrail",new {trailid=trail.Id},trail);
            
        }
        [HttpPut]
        public IActionResult UpdateTrail([FromBody] TrailDto trailDto)
        {
            if (trailDto == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();           
            var trail = _mapper.Map<Trail>(trailDto);
            if (!_trailRepository.UpdateTrail(trail))
            {
                ModelState.AddModelError("", $"Something went wrong while Update trail");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return NoContent();

        }
        [HttpDelete("{trailId:int}")]
        public IActionResult DeleteTrail(int trailId)
        {
            if (!_trailRepository.TrailExists(trailId)
                ) return NotFound();
            var trail =_trailRepository.GetTrail(trailId);
            if (trail == null) return NotFound();
            if (!_trailRepository.DeleteTrail(trail))
            {
                ModelState.AddModelError("", $"Something went wrong while Delete trail:{trail.Name}");
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }

    }
}
