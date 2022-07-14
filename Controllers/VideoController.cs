using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideosAPI_ASP.NetCore_AluraChallenge.Data;
using VideosAPI_ASP.NetCore_AluraChallenge.Models;

namespace VideosAPI_ASP.NetCore_AluraChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideosController : ControllerBase
    {
        private AppDbContext _context ;

        public VideosController(AppDbContext context)
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
                return Ok(video);
            }            
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateVideo([FromBody] Video video)
        {
            _context.Videos.Add(video);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetVideosById), new {Id = video.Id}, video);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateVideo(int id, [FromBody] Video updateVideo)
        {
            Video video = _context.Videos.FirstOrDefault(video => video.Id == id);

            if(video == null)
            {
                return NotFound();
            }

            video.Title = updateVideo.Title;
            video.Description = updateVideo.Description;
            video.Url = updateVideo.Url;

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