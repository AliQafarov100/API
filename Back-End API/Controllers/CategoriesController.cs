using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_End_API.DAL;
using Back_End_API.DTOs.CategoryDtos;
using Back_End_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back_End_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("get/{id?}")]
        public IActionResult Get(int id)
        {
            Category category = _context.Categories.FirstOrDefault(p => p.Id == id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpGet("all")]

        public async Task<IActionResult> GetAll()
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpPost("create")]
        public IActionResult Create(CategoryPostDto categoryDto)
        {
            Category category = new()
            {
                Name = categoryDto.Name
            };
            _context.Categories.Add(category);
            _context.SaveChanges();

            return Ok(category);
        }

        [HttpPut("edit/{id?}")]

        public IActionResult Edit(int id, Category category)
        {
            Category existedCategory = _context.Categories.FirstOrDefault(p => p.Id == id);

            if (existedCategory == null) return NotFound();

            existedCategory.Name = category.Name;
            _context.SaveChanges();
            _context.Entry(existedCategory).CurrentValues.SetValues(category);
            return Ok(existedCategory);
        }

        [HttpDelete("delete")]

        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.FirstOrDefault(p => p.Id == id);
            if (category == null) return NotFound();
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return Ok(category);
        }
        

    }
}
