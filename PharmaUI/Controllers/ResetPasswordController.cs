using onlinePharmacyApp;
using onlinePharmacyApp.ETClasses;
using PharmaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace PharmaUI.Controllers
{
    public class ResetPasswordController : Controller
    {
        private readonly PharmaService pharmaService;
        public ResetPasswordController()
        {
            pharmaService = new PharmaService();
        }
        public bool Checkpass(string p1, string p2)//logic for pass
        {
            if (p1 == p2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ActionResult ResetAdmin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ResetAdmin(string email, string pass1, string pass2)
        {
            
            
                if (Checkpass(pass1, pass2))
                {
                    Admin ad = pharmaService.FindAdminByEmail(email);
                    if (ad == null)
                    {
                        ModelState.AddModelError("", "Email is not valid");
                        return View();
                    }
                    ad.Password = pass1;
                    pharmaService.UpdateAdmin(ad);
                    return RedirectToAction("AdminLogin", "Login");
                }
                else
                {
                    ModelState.AddModelError("", "Both Password Must Be Same");
               
            }
            return View();
        }
        public ActionResult ResetCustomer()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult ResetCustomer(string email, string pass1, string pass2)
        {
            
            
                if (Checkpass(pass1, pass2))
                {
                    Customer customer = pharmaService.FindCustomerByEmail(email);
                    if (customer == null)
                    {
                        ModelState.AddModelError("", "Email is not valid");
                        return View();
                    }
                    customer.Password = pass1;
                    pharmaService.UpdateCustomer(customer);
                    return RedirectToAction("CustomerLogin", "Login");
                }
                else
                {
                    ModelState.AddModelError("", "Both Password Must Be Same");
                }
           
            return View();
        }
        
       
    }
}