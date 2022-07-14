using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VideosAPI_ASP.NetCore_AluraChallenge.Data;
using VideosAPI_ASP.NetCore_AluraChallenge.Data.DTO;
using VideosAPI_ASP.NetCore_AluraChallenge.Models;

namespace VideosAPI_ASP.NetCore_AluraChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideosController : ControllerBase
    {
        private VideoContext _context ;
        private IMapper _mapper;

        public VideosController(VideoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetVideos()
        {
            return Ok(_context.Videos);
        }

        [HttpGet("{id}")]
        public IActionResult GetVideosById(int id)
        {
            Video video = _context.Videos.FirstOrDefault(video => video.Id == id);
            if(video != null)
            {
                ReadVideoDto readVideoDto = _mapper.Map<ReadVideoDto>(video);

                return Ok(readVideoDto);
            }            
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateVideo([FromBody] CreateVideoDto videoDto)
        {
            Video video = _mapper.Map<Video>(videoDto);

            _context.Videos.Add(video);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetVideosById), new {Id = video.Id}, video);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateVideo(int id, [FromBody] UpdateVideoDto videoDto)
        {
            Video video = _context.Videos.FirstOrDefault(video => video.Id == id);

            if(video == null)
            {
                return NotFound();
            }

            _mapper.Map(videoDto, video);

            _context.SaveChanges();

            return Ok(video);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVideo(int id)
        {
            Video video = _context.Videos.FirstOrDefault(video => video.Id == id);

            if(video == null)
            {
                return NotFound();
            }

            _context.Remove(video);
            _context.SaveChanges();
            
            return Ok("This video removed");
        }
    }
}