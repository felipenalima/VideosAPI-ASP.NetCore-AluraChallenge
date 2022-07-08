using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideosAPI_ASP.NetCore_AluraChallenge.Models
{
    public class Video
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }   
        public string Description { get; set; }
        public string Url { get; set; }
    }
}