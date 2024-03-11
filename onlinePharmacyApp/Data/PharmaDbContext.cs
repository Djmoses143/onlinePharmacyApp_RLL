using onlinePharmacyApp.ETClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace onlinePharmacyApp.Data
{
    public class PharmaDbContext : DbContext
    {
        public PharmaDbContext() : base("name = PharmasDb")
        {

        }
        public DbSet<Admin> Admin => Set<Admin>();
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Medicine> Medicines => Set<Medicine>();
        public DbSet<Orders> Orders => Set<Orders>();

        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    }
}
