using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agil.Eccomerce.Api.Data;
using Agil.Eccomerce.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        // GET: api/<CartsController>
        [HttpGet]
        public ActionResult<IEnumerable<Cart>> GetCarts()
        {
            if (_context.Carrito.Any())
                return Ok(_context.Carrito.Include(c => c.Product));
            else
                return NoContent();
        }

        // GET api/<CartsController>/email
        [HttpGet("{email}")]
        public ActionResult<IEnumerable<Cart>> GetCartByEmail(String email)
        {
            if (_context.Carrito.Any(c => c.Email.ToLower().Trim() == email.ToLower().Trim()))
                return Ok(_context.Carrito.Include(c => c.Product).Where(c => c.Email.ToLower().Trim() == email.ToLower().Trim()));
            else
                return NoContent();
        }

        // POST api/<CartsController>
        [HttpPost]
        public IActionResult Add([FromBody] Cart cart)
        {
            if (!_context.Carrito.Any(c => c.Id == cart.Id))
            {
                _context.Carrito.Add(cart);
                _context.SaveChanges();
                return Ok();

            }
            else
            {
                return BadRequest($"Exists a cart with id{cart.Id}");
            }

        }

        // PUT api/<CartsController>/email/idProduct
        [HttpPut("{email}/{idProduct}")]
        public IActionResult Update(String email, int idProduct, [FromBody] int cantidad)
        {
            if (_context.Carrito.Any(c => c.Email.ToLower().Trim() == email.ToLower().Trim() && c.Id == idProduct))
            {
                var CartToUpdate = _context.Carrito.Single(c => c.Email.ToLower().Trim() == email.ToLower().Trim() && c.Id == idProduct);
                CartToUpdate.Quantity = cantidad;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"Doesn't exist a cart with email {email} and productId {idProduct}");
            }

        }

        // DELETE api/<CartsController>/email
        [HttpDelete("{email}")]
        public IActionResult DeleteCarts(String email)
        {
            if (_context.Carrito.Any(c => c.Email.ToLower().Trim() == email.ToLower().Trim()))
            {
                var CartsToDelete = _context.Carrito.Where(c => c.Email.ToLower().Trim() == email.ToLower().Trim());
                _context.Carrito.RemoveRange(CartsToDelete);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"Don't exist any cart with email {email}");
            }

        }

        // DELETE api/<CartsController>/email/idProduct
        [HttpDelete("{email}/{idProduct}")]
        public IActionResult DeleteCart(String email, int idProduct)
        {
            if (_context.Carrito.Any(c => c.Email.ToLower().Trim() == email.ToLower().Trim() && c.Id == idProduct))
            {
                var CartToDelete = _context.Carrito.Single(c => c.Email.ToLower().Trim() == email.ToLower().Trim() && c.Id == idProduct);
                _context.Carrito.Remove(CartToDelete);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"Doesn't exist a cart with email {email} and productId {idProduct}");
            }

        }
    }
}
