using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideosAPI_ASP.NetCore_AluraChallenge.Data.DTO
{
    public class UpdateCategoryDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Color { get; set; }    
    }
}