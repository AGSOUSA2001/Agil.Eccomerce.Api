using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agil.Eccomerce.Api.Data;
using Agil.Eccomerce.Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Agil.Eccomerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DBContext _context;

        public ProductsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            if (_context.Producto.Any())
                return Ok(_context.Producto);
            else
                return NoContent();
        }

        // GET api/<ProductsController>/productId
        [HttpGet("{id}")]
        public ActionResult GetProductById(int id)
        {
            if (_context.Producto.Any(p => p.Id == id))
                return Ok(_context.Producto.FirstOrDefault(p => p.Id == id));
            else
                return NoContent();
        }

        // GET api/<ProductsController>/categoryId
        [HttpGet("category/{id}")]
        public ActionResult<IEnumerable<Product>> GetProductsByCategoryId(int id)
        {
            if (_context.Producto.Any(c => c.CategoryId == id))
                return Ok(_context.Producto.Where(c => c.CategoryId == id));
            else
                return NoContent();
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Add([FromBody] Product product)
        {
            if (!_context.Producto.Any(p => p.Id == product.Id))
            {
                _context.Producto.Add(product);
                _context.SaveChanges();
                return Ok();
                
            }
            else
            {
                return BadRequest($"Exists a product with id{product.Id}");
            }
            
        }

        // PUT api/<ProductsController>/productId
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Product product)
        {
            if (_context.Producto.Any(p => p.Id == id))
            {
                var ProductToUpdate = _context.Producto.Single(p => p.Id == id);
                _context.Producto.Remove(ProductToUpdate);
                _context.Producto.Add(product);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"Don't exist a product with id {id}");
            }
        }

        // DELETE api/<ProductsController>/productId
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_context.Producto.Any(p => p.Id == id))
            {
                var ProductToDelete = _context.Producto.Single(p => p.Id == id);
                _context.Producto.Remove(ProductToDelete);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"Don't exist a product with id {id}");
            }

        }
    }
}
