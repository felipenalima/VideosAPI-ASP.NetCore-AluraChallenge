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

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } 

        [Required(ErrorMessage = "Description is required")]  
        public string Description { get; set; }

        [Required(ErrorMessage = "Url is required")]
        public string Url { get; set; }
    }
}