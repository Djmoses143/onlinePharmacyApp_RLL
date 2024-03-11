using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlinePharmacyApp.ETClasses
{
   
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public double TotalPrice {  get; set; }

        public string OrderStatus { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }

    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        [Required(ErrorMessage = "Medicine is required")]
        public int MedicineId { get; set; }
        public int CustomerId { get; set; }
        public string MedicineName { get; set; }


        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double SubPrice { get; set; }

      
        [ForeignKey("MedicineId")]
        public virtual Medicine Medicine { get; set; }
    }
}
