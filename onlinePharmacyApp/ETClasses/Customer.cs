using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlinePharmacyApp.ETClasses
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Please Enter Text Only")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Number")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Please Enter Ten Numbers Only")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]
        [StringLength(50)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Password must contains a Uppercase,Lowercase letter,number and symbol")]
        public string Password { get; set; }

    
    }
}
