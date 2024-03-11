using System;
using System.Collections.Generic;
using onlinePharmacyApp.ETClasses;
using PharmaApi.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PharmaApi.Controllers
{
    public class CartController : ApiController
    {
        public readonly PharmaService ps;
        public CartController()
        {
            ps = new PharmaService();
        }
        // GET: Admin
        [HttpGet]
        public IEnumerable<Cart> Index()
        {
            return ps.GetAllCartItems();
        }

        //GET:
        
        [ResponseType(typeof(Cart))]
        [Route("api/cart/{cartId}")]
        public IHttpActionResult GetCartById(int CartId)
        {
          Cart cart = ps.GetCartById(CartId);
            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }

        [ResponseType(typeof(Cart))]
        public IHttpActionResult PostCart(Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ps.AddCartItem(cart);

            return CreatedAtRoute("DefaultApi", new { id = cart.CartId }, cart);
        }

        // DELETE: 
        [ResponseType(typeof(Cart))]
        public IHttpActionResult DeleteCart(int id)
        {
            ps.RemoveCartItem(id);
            if (id == null)
            {
                return NotFound();
            }
            ps.DeleteMedicine(id);
            return Ok(id);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutCart(int id, Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cart.CartId)
            {
                return BadRequest();
            }

            ps.UpdateCartItem(cart);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
