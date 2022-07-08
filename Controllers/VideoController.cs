using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideosAPI_ASP.NetCore_AluraChallenge.Data;

namespace VideosAPI_ASP.NetCore_AluraChallenge.Controllers
{
    [ApiController]
    [Route("controller")]
    public class VideoController : ControllerBase
    {
        private VideoContext _context ;

        public VideoController(VideoContext context)
        {
            _context = context;
        }
    }
}