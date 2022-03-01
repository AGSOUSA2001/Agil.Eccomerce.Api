﻿using System;
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
        public IEnumerable<Category> Get()
        {
            return _context.Categoria;
        }

        // GET api/<CategorysController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategorysController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategorysController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategorysController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
