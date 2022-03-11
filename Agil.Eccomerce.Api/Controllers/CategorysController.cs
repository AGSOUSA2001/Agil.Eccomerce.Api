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
    public class CategorysController : ControllerBase
    {
        private readonly DBContext _context;

        public CategorysController(DBContext context)
        {
            _context = context;
        }

        // GET: api/<CategorysController>
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategorys()
        {
            if (_context.Categoria.Any())
                return Ok(_context.Categoria);
            else
                return NoContent();
        }

        // GET api/<CategorysController>/categoryId
        [HttpGet("{id}")]
        public ActionResult GetCategoryById(int id)
        {
            if (_context.Categoria.Any(c => c.Id == id))
                return Ok(_context.Categoria.FirstOrDefault(c => c.Id == id));
            else
                return NoContent();
        }

        // POST api/<CategorysController>
        [HttpPost]
        public IActionResult Add([FromBody] Category category)
        {
            if (!_context.Categoria.Any(c => c.Id == category.Id))
            {
                _context.Categoria.Add(category);
                _context.SaveChanges();
                return Ok();

            }
            else
            {
                return BadRequest($"Exists a category with id{category.Id}");
            }

        }

        // PUT api/<CategorysController>/categoryId
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Category category)
        {
            if (_context.Categoria.Any(c => c.Id == id))
            {
                var CategoryToUpdate = _context.Categoria.Single(c => c.Id == id);
                _context.Categoria.Remove(CategoryToUpdate);
                _context.Categoria.Add(category);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"Don't exist a category with id {id}");
            }

        }

        // DELETE api/<CategorysController>/categoryId
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_context.Categoria.Any(c => c.Id == id))
            {
                var CategoryToDelete = _context.Categoria.Single(c => c.Id == id);
                _context.Categoria.Remove(CategoryToDelete);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"Don't exist a category with id {id}");
            }

        }
    }
}
