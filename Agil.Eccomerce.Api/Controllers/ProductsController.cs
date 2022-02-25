using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agil.Eccomerce.Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Agil.Eccomerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        // GET api/<ProductsController>
        [HttpGet]
        public string GetProducts()
        {
            return "value";
        }

        // GET api/<ProductsController>
        [HttpGet("{id}")]
        public string GetProductById(int id)
        {
            return "value";
        }

        // GET api/<ProductsController>
        [HttpGet("category/{id}")]
        public string GetProductByCategoryId(Category id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Add([FromBody] Product product)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Product product)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
