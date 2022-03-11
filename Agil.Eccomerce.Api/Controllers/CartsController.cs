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
    public class CartsController : ControllerBase
    {
        private readonly DBContext _context;

        public CartsController(DBContext context)
        {
            _context = context;
        }

        // POST api/<CartsController>
        /*[HttpPost]
        public IActionResult Add([FromBody] int id)
        {
            if (!_context.Producto.Any(p => p.Id == id))
            {
                _context.Carrito.Add(category);
                _context.SaveChanges();
                return Ok();

            }
            else
            {
                return BadRequest($"Exists a province with id{category.Id}");
            }

        }*/

        // GET api/<CartsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CartsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CartsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CartsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
