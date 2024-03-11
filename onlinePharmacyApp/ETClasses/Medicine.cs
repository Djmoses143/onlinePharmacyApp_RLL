using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlinePharmacyApp.ETClasses
{
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }

        [Required(ErrorMessage = "Please Enter Medicine Name")]

        public string MName { get; set; }
        [Required(ErrorMessage = "Please Enter Medicine Usage")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Please Enter Text Only")]
        public string MType { get; set; }

        public double Price { get; set; }

        public int Discount { get; set; }
        public int stock { get; set; }
    }
}
