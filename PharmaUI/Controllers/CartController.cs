using onlinePharmacyApp.ETClasses;
using PharmaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmaUI.Controllers
{
    public class CartController : Controller
    {
        private PharmaService pharmaService;

        public CartController()
        {
            pharmaService = new PharmaService(); // Initialize 
        }
        public ActionResult GetCartItems() {

            if (Session["SId"] != null)
            {
                var cust = Session["CustObject"] as Customer;
                IEnumerable<Cart> cartItems = pharmaService.GetAllUserCart(cust.CustomerId);
                ViewBag.visibleCart=false;
                if(cartItems.Count()>0)
                {
                    ViewBag.visibleCart = true;
                }
              
                return View(cartItems);
            }

            return RedirectToAction("MedicineList", "Customer");
        }

        [HttpPost]
        public ActionResult DeleteItem(int id) 
        {
            var cart=pharmaService.GetCartById(id);
            var medicine=pharmaService.GetMedicineById(cart.MedicineId);
            if(cart != null) {
                medicine.stock += cart.Quantity;
                pharmaService.UpdateMedicine(medicine);
                pharmaService.RemoveCartItem(cart.CartId);
                    }
            return RedirectToAction("GetCartItems","Cart");
        }


        [HttpPost]
        public ActionResult DecreaseQty(int id)
        {
            var existingItem = pharmaService.GetCartById(id);
            var medicine = pharmaService.GetMedicineById(existingItem.MedicineId);


            if (existingItem.Quantity >= 1)
            {

                existingItem.Quantity--;
                existingItem.itemTotal = existingItem.Price * existingItem.Quantity;
                pharmaService.UpdateCartItem(existingItem);
                medicine.stock += 1;
                pharmaService.UpdateMedicine(medicine);
                return RedirectToAction("GetCartItems", "Cart");
            }
            else
            {
                pharmaService.RemoveCartItem(existingItem.CartId);
                return RedirectToAction("GetCartItems", "Cart");
            }

        }
        [HttpPost]
        public ActionResult AddQty(int id)
        {
            var existingItem = pharmaService.GetCartById(id);
            var medicine = pharmaService.GetMedicineById(existingItem.MedicineId);


            if (medicine.stock >= 1)
            {
                existingItem.Quantity++;
                existingItem.itemTotal = existingItem.Price * existingItem.Quantity;
                pharmaService.UpdateCartItem(existingItem);
                medicine.stock -= 1;
                pharmaService.UpdateMedicine(medicine);
                return RedirectToAction("GetCartItems", "Cart");
            }
            else
            {

                return RedirectToAction("GetCartItems", "Cart");
            }

        }

       
    }
}