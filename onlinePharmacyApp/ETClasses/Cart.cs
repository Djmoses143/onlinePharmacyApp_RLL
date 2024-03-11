using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlinePharmacyApp.ETClasses
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        
        public int UserId { get; set; }
        public int MedicineId { get; set; }
        public int Quantity { get; set; }

        public string Mname { get; set; }

        public double Price { get; set; }

        public double itemTotal { get; set; }

        [ForeignKey("MedicineId")]
        public virtual Medicine Medicine { get; set; }
    }
}