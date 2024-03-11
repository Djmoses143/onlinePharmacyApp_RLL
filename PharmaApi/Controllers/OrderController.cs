using onlinePharmacyApp.ETClasses;
using onlinePharmacyApp.Repostories;
using PharmaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmaApi.Controllers
{
    public class OrderController : ApiController
    {


        public readonly PharmaService ps;
        public OrderController()
        { 
            ps = new PharmaService();
        }

        // GET: api/orders
        [HttpGet]
            public IEnumerable<Orders> GetAllOrders()
            {
                return ps.GetAllOrders();
            }

            // GET: api/orders/5
            [HttpGet]
            public IHttpActionResult GetOrder(int id)
            {
                Orders order = ps.GetOrderById(id);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }

            // POST: api/orders
            [HttpPost]
            public IHttpActionResult PostOrder(Orders order)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
            ps.AddOrder(order);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

            // PUT: api/orders/id
            [HttpPut]
            public IHttpActionResult PutOrder(int id, Orders order)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (id != order.OrderId)
                {
                    return BadRequest();
                }
            
                return StatusCode(System.Net.HttpStatusCode.NoContent);
            }

            // DELETE: api/orders/id
            [HttpDelete]
            public IHttpActionResult DeleteOrder(int id)
            {
                Orders order = ps.GetOrderById(id);
                if (order == null)
                {
                    return NotFound();
                }
                ps.RemoveOrder(id);
                return Ok(order);
            }
        }
    }

