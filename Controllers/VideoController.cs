using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public VideosController(VideoContext context)
        {
            _context = context;
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
                ReadVideoDto readVideoDto = new ReadVideoDto
                {
                    Title = video.Title,
                    Description = video.Description,
                    Url = video.Url,
                    Date = DateTime.Now
                };

                return Ok(readVideoDto);
            }            
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateVideo([FromBody] CreateVideoDto videoDto)
        {
            Video video = new Video 
            {
                Title = videoDto.Title,
                Description = videoDto.Description,
                Url = videoDto.Url
            };

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

            video.Title = videoDto.Title;
            video.Description = videoDto.Description;
            video.Url = videoDto.Url;

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