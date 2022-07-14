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
    public class CategoriesController : ControllerBase
    {
        private AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(_context.Categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            Category category = _context.Categories.FirstOrDefault(category => category.Id == id);

            if(category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
        
        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category createCategory)
        {
            _context.Categories.Add(createCategory);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCategoryById), new {Id = createCategory.Id}, createCategory);
        }
    }
}