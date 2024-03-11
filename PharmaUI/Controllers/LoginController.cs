using PharmaApi.Models;
using CaptchaMvc.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using onlinePharmacyApp.ETClasses;
using System.Web.Mvc;
using System.Diagnostics.Contracts;

namespace PharmaUI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private readonly PharmaService pharmaService;
        public LoginController()
        {
            pharmaService = new PharmaService();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminLogin()
        {
           // Session["SId"] = 1;
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            if (!ModelState.IsValid)
            {
                if (this.IsCaptchaValid("Validate your captcha"))
                {
                    if (pharmaService.checkAdminLogin(admin))
                    {
                        Session["SId"] = 1;
                        Admin ad = pharmaService.FindAdminByEmail(admin.Email);
                        Session["mngObject"] = ad;

                        return RedirectToAction("MedicineList", "Admin");
                    }
                
                  
                    else
                    {
                       
                        ModelState.AddModelError("", "Enter Valid Credentials");
                        return View();
                    }

                }


            }
            return View();
        }

        public ActionResult CustomerLogin()
        {
          //  Session["SId"] = 2;
            return View();
        }

        [HttpPost]
        public ActionResult CustomerLogin(Customer customer)
        {
            if (customer.Email != null && customer.Password != null)
            {
                if (this.IsCaptchaValid("Validate your captcha"))
                {
                    if (pharmaService.checkCustomerLogin(customer))
                    {
                        Session["SId"] = 2;
                        Customer CustomerObject = pharmaService.FindCustomerByEmail(customer.Email);
                        Session["CustObject"] = CustomerObject;
                        return RedirectToAction("MedicineList", "Customer");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Enter Valid Credentials");
                        return View();
                    }
                }

            }
            return View();



        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Login");
        }
    }
}