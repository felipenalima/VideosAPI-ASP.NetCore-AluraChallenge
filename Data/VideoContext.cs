using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VideosAPI_ASP.NetCore_AluraChallenge.Models;

namespace VideosAPI_ASP.NetCore_AluraChallenge.Data
{
    public class VideoContext : DbContext
    {
        public VideoContext(DbContextOptions<VideoContext> options) : base(options)
        {
        }

        public DbSet<Video> Videos { get; set; }
    } 
}