using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_End_API.DAL;
using Back_End_API.DTOs.ProductDtos;
using Back_End_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back_End_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("get/{id?}")]
        public IActionResult Get(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet("all")]

        public async Task<IActionResult> GetAll()
        {
            List<Product> products = await _context.Products.Where(p => p.DisplayStatus == true).ToListAsync();
            return Ok(products);
        }

        [HttpPost("create")]
        public IActionResult Create(ProductPostDto productDto)
        {
            Product product = new()
            {
                SoldPrice = productDto.SoldPrice,
                CostPrice = productDto.CostPrice,
                Name = productDto.Name,
                DisplayStatus = productDto.DisplayStatus
            };
            _context.Products.Add(product);
            _context.SaveChanges();

            return Ok(product);
        }

        [HttpPut("edit/{id?}")]

        public IActionResult Edit(int id, Product product)
        {
            Product existedProduct = _context.Products.FirstOrDefault(p => p.Id == id);

            if (existedProduct == null) return NotFound();

            existedProduct.Name = product.Name;
            existedProduct.SoldPrice = product.SoldPrice;
            existedProduct.CostPrice = product.CostPrice;
            _context.SaveChanges();
            _context.Entry(existedProduct).CurrentValues.SetValues(product);
            return Ok(existedProduct);
        }

        [HttpDelete("delete")]

        public IActionResult Delete(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok(product);
        }
        [HttpPatch("status/{id?}")]

        public IActionResult ChangeDisplayStatus(int id, string statusStr)
        {
            Product product = _context.Products.Find(id);
            if (product == null) return NotFound();

            bool status;
            bool result = bool.TryParse(statusStr, out status);

            if (!result) return BadRequest();

            product.DisplayStatus = true;

            _context.SaveChanges();
            return Ok(product);
        }

        [HttpGet("change")]

        public IActionResult Change()
        {
            List<Product> products = _context.Products.ToList();

            products.ForEach(p => p.DisplayStatus = true);
            _context.SaveChanges();
            return Ok();
        }
    }
}
