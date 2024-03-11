using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PharmaApi.Models;
using onlinePharmacyApp.ETClasses;
using System.Web.Services.Description;

namespace PharmaUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly PharmaService pharmaService;
        public CustomerController() {
            pharmaService = new PharmaService();
        }
   
        //Register
        public ActionResult RegisterCustomer(Customer customer) {

            if (ModelState.IsValid)
            {
                pharmaService.AddCustomer(customer);
                return RedirectToAction("RegSuccess", "Customer");
            }
            return View();
        }
        
        public ActionResult RegSuccess()
        {
            return View();
        }
        
        //Update
        public ActionResult EditProfile()
        {
            if (Session["SId"] != null)
            {
                var obj = Session["CustObject"] as Customer;
                return View(obj);
            }
            return RedirectToAction("CustomerLogin", "Login");
        }

        [HttpPost]
        public ActionResult EditProfile([Bind(Include = "CustomerId,Name,Phone,Address,Email,Password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                pharmaService.UpdateCustomer(customer);
                return RedirectToAction("MedicineList", "Customer");
            }
            return View();
        }//Medicine list

        public ActionResult MedicineList()
        {
            if (Session["SId"] != null)
            {
                return View(pharmaService.GetAllMedicines());
            }

            return RedirectToAction("CustomerLogin", "Login");
        }

        [HttpPost]
        public ActionResult MedicineList(string MediType)
        {
            IEnumerable<Medicine> result = pharmaService.FindMedicineBySearch(MediType);

          
            return View(result);
        }



        [HttpPost]
        public ActionResult AddOrder(int id)
        {
            var medicine = pharmaService.GetMedicineById(id);

            Cart cart = new Cart();
            var cust = Session["CustObject"] as Customer;

            var existingItem = pharmaService.FindExistingMedicine(id);
            if (medicine.stock > 0)
            {
                if (existingItem != null)
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
                    cart.UserId = cust.CustomerId;
                    cart.MedicineId = medicine.MedicineId;
                    cart.Mname = medicine.MName;
                    cart.Quantity = 1;
                    cart.Price = medicine.Price;
                    cart.itemTotal = medicine.Price;
                    pharmaService.AddCartItem(cart);
                    medicine.stock -= 1;
                    pharmaService.UpdateMedicine(medicine);
                    return RedirectToAction("GetCartItems", "Cart");
                }
            }
            return RedirectToAction("MedicineList", "Customer");
            //SaveCartItemsToSession(cartItems)'
        }


      
       
        public ActionResult GetMedicine()
        {
            if (Session["SId"] != null)
            {
                List<Medicine> medicines = pharmaService.GetAllMedicines();
                foreach (var med in medicines)
                {
                    med.Price = (float)(med.Price- med.Discount);
                }
                return View(medicines);
            }
            return RedirectToAction("PatientLogin", "Login");
        }

        [HttpPost]
        public ActionResult GetMedicine(string MediType)
        {
            IEnumerable<Medicine> result = pharmaService.FindMedicineBySearch(MediType);
            return View(result);
        }
        //Login
        public ActionResult Login()
        {
            Session.Clear(); // Clear session data
            return RedirectToAction("CustomerLogin");
        }
    }
}