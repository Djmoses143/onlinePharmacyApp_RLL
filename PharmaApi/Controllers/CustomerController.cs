using onlinePharmacyApp.Data;
using onlinePharmacyApp.ETClasses;
using onlinePharmacyApp.Repostories;
using PharmaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PharmaApi.Controllers
{
    public class CustomerController : ApiController
    {

        public readonly PharmaService ps;
        public CustomerController()
        {
            ps = new PharmaService();
        }

        // GET: api/customer
        [HttpGet]
            public IEnumerable<Customer> GetAllCustomers()
            {
                return ps.GetAllCustomers();
            }

            // GET: api/customer/5
            [HttpGet]
            public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = ps.GetCustomerById(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return Ok(customer);
            }

            // POST: api/customer
            [HttpPut]
            public IHttpActionResult UpdateCustomer(Customer customer)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                ps.UpdateCustomer(customer);
            return StatusCode(HttpStatusCode.NoContent);
        }

            // PUT: api/customer/5
            [HttpPost]
            public IHttpActionResult PostCustomer(int id, Customer customer)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (id != customer.CustomerId)
                {
                    return BadRequest();
                }
                ps.AddCustomer(customer);
                return StatusCode(System.Net.HttpStatusCode.NoContent);
            }

            // DELETE: api/customer/5
            [HttpDelete]
            public IHttpActionResult DeleteCustomer(int id)
            {
            
            Customer customer = ps.GetCustomerById(id);
                if (customer == null)
                {
                    return NotFound();
                }
                ps.DeleteCustomer(id);
                return Ok(customer);
            }
        }
    }

