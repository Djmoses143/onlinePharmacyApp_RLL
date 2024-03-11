using onlinePharmacyApp.Data;
using onlinePharmacyApp.ETClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlinePharmacyApp.Repostories
{
    public class AdminRepository
    {
        private readonly PharmaDbContext dbContext;
        public AdminRepository()
        {
            dbContext = new PharmaDbContext();
        }
        public Admin FindAdminByEmail(string email)
        {
            return dbContext.Admin.FirstOrDefault(m => m.Email == email);
        }
        public bool FindAdminByPassword(string password)
        {
            return dbContext.Admin.Any(m => m.Password == password);
        }

        public bool checkAdminLogin(Admin admin)
        {
            return dbContext.Admin.Any(e => e.Email == admin.Email && e.Password == admin.Password);
        }

        public void UpdateAdmin(Admin admin)
        {
            if (admin != null)
            {
                dbContext.Entry(admin).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }
        public List<Admin> GetAllAdmins()
        {
            return dbContext.Admin.ToList();
        }
    }
}
