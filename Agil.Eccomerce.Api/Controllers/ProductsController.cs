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

        // GET api/<ProductsController>
        [HttpGet]
        public string GetProducts()
        {
            return context.products;
        }

        // GET api/<ProductsController>/productId
        [HttpGet("{id}")]
        public string GetProductById(int id)
        {
            return "value";
        }

        // GET api/<ProductsController>/categoryId
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

        // PUT api/<ProductsController>/productId
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Product product)
        {
        }

        // DELETE api/<ProductsController>/productId
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
