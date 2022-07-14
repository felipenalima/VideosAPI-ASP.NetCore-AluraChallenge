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
        [StringLength(30,ErrorMessage= "Title longer than 30 characters")]
        public string Title { get; set; } 

        [Required(ErrorMessage = "Description is required")]
        [StringLength(50 ,ErrorMessage= "Title longer than 50 characters")]  
        public string Description { get; set; }

        
        [Required(ErrorMessage = "Url is required")]
        [RegularExpression(@"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$", ErrorMessage = "Url Invalid")]
        public string Url { get; set; }
    }
}