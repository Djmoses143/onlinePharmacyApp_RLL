using onlinePharmacyApp.ETClasses;
using PharmaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PharmaApi.Controllers
{
    public class AdminController : ApiController
    {
        public readonly PharmaService ps;
        public AdminController()
        {
            ps = new PharmaService();
        }
        // GET: Admin
        [System.Web.Http.HttpGet]
        public List<Admin> Index()
        {
            return ps.GetAllAdmins();
        }
    }
}
