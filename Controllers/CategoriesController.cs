using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideosAPI_ASP.NetCore_AluraChallenge.Data;
using VideosAPI_ASP.NetCore_AluraChallenge.Models;
using AutoMapper;
using VideosAPI_ASP.NetCore_AluraChallenge.Data.DTO;

namespace VideosAPI_ASP.NetCore_AluraChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CategoriesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
            ReadCategoryDto readCategoryDto = _mapper.Map<ReadCategoryDto>(category);

            return Ok(readCategoryDto);
        }
        
        [HttpPost]
        public IActionResult CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            Category category = _mapper.Map<Category>(createCategoryDto); 

            _context.Categories.Add(category);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCategoryById), new {Id = category.Id}, category);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            Category category = _context.Categories.FirstOrDefault(category => category.Id == id);

            if(category == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCategoryDto,category);

            _context.SaveChanges();

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            Category category = _context.Categories.FirstOrDefault(category => category.Id == id);

            if(category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();
            
            return Ok("Delete Category Successfull");

        }

    }
}