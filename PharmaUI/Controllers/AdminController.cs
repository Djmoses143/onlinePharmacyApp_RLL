using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using onlinePharmacyApp.ETClasses;
using PharmaApi.Models;


namespace PharmaUI.Controllers
{
    
    public class AdminController : Controller
    {
        private PharmaService pharmaService;

        public AdminController()
        {
            pharmaService = new PharmaService(); // Initialize 
        }

        // GET: Admin Login
        public ActionResult AdminLogin()
        {
            return View();
        }




        
        public ActionResult MedicineList()
        {
            if (Session["SId"] != null)
            {
                return View(pharmaService.GetAllMedicines());
            }
            return RedirectToAction("AdminLogin", "Login");
        }

     



        //Add Medicine to list
        public ActionResult AddMedicine()
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("MedicineList", "Admin");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMedicine([Bind(Include = "MedicineId,MName,MType,Price,Stock")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                pharmaService.AddMedicine(medicine);
                return RedirectToAction("MedicineList");
            }
            return View(medicine);
        }



        // Delete Medicine
        public ActionResult Delete(int id)
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("MedicineList", "Admin");
            }
            Medicine medicine = pharmaService.GetMedicineById(id);
            if(medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pharmaService.DeleteMedicine(id);
            return RedirectToAction("MedicineList");//medicine list view 
        }


        //Update Medicine
        public ActionResult Edit(int id)
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("MedicineList", "Admin");
            }
            Medicine medicine = pharmaService.GetMedicineById(id);
            return View(medicine);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]//it is used to prevent the Cross sites Request Forgery
        public ActionResult Edit([Bind(Include = "MedicineId,MName,MType,Price,Stock")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                pharmaService.UpdateMedicine(medicine);
                return RedirectToAction("MedicineList");
            }
            return View(medicine);
        }



        [HttpPost]
        public ActionResult Medicine(string MediType)
        {
            IEnumerable<Medicine> medicine = pharmaService.FindMedicineBySearch(MediType);
            if (medicine != null)
            {
                return View(medicine);
            }
            return View(medicine);
        }

        //    ***************************************************************************  customer ***************************************************************  //
        public ActionResult CustomerList()
        {
            if (Session["SId"] != null)
            {
                return View(pharmaService.GetAllCustomers());
            }
            return RedirectToAction("AdminLogin", "Login");
        }

        [HttpPost]
        public ActionResult Customer(int CustId)
        {
            Customer customer = pharmaService.GetCustomerById(CustId);
            if (customer != null)
            {
                return View(customer);
            }
            return View(customer);
        }


        //Adding Customer View
        public ActionResult AddCustomer()
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("CustomerList", "Admin");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer([Bind(Include = "CustomerId,Name,Phone,Address,Email,Password")] Customer customer)
        {
           
            if (ModelState.IsValid)
            {
                pharmaService.AddCustomer(customer);
                return RedirectToAction("CustomerList");
            }
            return View();
        }


        ////Update Customer
        public ActionResult CustomerUpdate(int id)
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("CustomerList", "Admin");
            }
            Customer customer = pharmaService.GetCustomerById(id);
            return View(customer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]//it is used to prevent the Cross sites Request Forgery
        public ActionResult CustomerUpdate([Bind(Include = "CustomerId,Name,Phone,Address,Email,Password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                pharmaService.UpdateCustomer(customer);
                return RedirectToAction("CustomerList");
            }
            return View(customer);
        }

        

        //delete customer 

        public ActionResult CustomerDelete(int id)
        {
            if (Session["SId"] == null)
            {
                return RedirectToAction("CustomerList", "Admin");
            }
            Customer customer = pharmaService.GetCustomerById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost, ActionName("CustomerDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult CustomersDelete(int id)
        {
            pharmaService.DeleteCustomer(id);
            return RedirectToAction("CustomerList");
        }




        // GET: Logout
        public ActionResult Logout()
        {
            Session.Clear(); // Clear session data
            return RedirectToAction("AdminLogin");
        }

     
    }
}