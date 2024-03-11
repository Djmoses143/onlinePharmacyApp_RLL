using onlinePharmacyApp.ETClasses;
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
    public class MedicineController : ApiController
    {
        public readonly PharmaService ps;
        public MedicineController()
        {
            ps = new PharmaService();
        }
        // GET: Admin
        [HttpGet]
        public List<Medicine> Index()
        {
            return ps.GetAllMedicines();
        }

        // GET:
        [ResponseType(typeof(Medicine))]
        public IHttpActionResult GetMedicine(int id)
        {
            Medicine medicine = ps.GetMedicineById(id);
            if (medicine == null)
            {
                return NotFound();
            }

            return Ok(medicine);
        }

        [ResponseType(typeof(Medicine))]
        public IHttpActionResult PostMedicine(Medicine medicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ps.AddMedicine(medicine);

            return CreatedAtRoute("DefaultApi", new { id = medicine.MedicineId }, medicine);
        }

        // DELETE: 
        [ResponseType(typeof(Medicine))]
        public IHttpActionResult DeleteMedicine(int id)
        {
            Medicine medicine = ps.GetMedicineById(id);
            if (medicine == null)
            {
                return NotFound();
            }
            ps.DeleteMedicine(id);
            return Ok(medicine);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedicine(int id, Medicine medicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicine.MedicineId)
            {
                return BadRequest();
            }

            ps.UpdateMedicine(medicine);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
