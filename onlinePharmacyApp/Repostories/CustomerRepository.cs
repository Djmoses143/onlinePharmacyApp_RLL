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
    public class CustomerRepository
    {
        private readonly PharmaDbContext dbContext; //define database class object

        public CustomerRepository()
        {
            dbContext = new PharmaDbContext(); //intialize database object 
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return dbContext.Customers.ToList();
        }
        public void InsertCustomer(Customer Customers)
        {
            dbContext.Customers.Add(Customers);
            dbContext.SaveChanges();
        }
        public void UpdateCustomer(Customer Customers)
        {
            dbContext.Entry(Customers).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
        public bool checkCustomerLogin(Customer Customers)
        {
            return dbContext.Customers.Any(d => d.Email == Customers.Email && d.Password == Customers.Password);
        }
        public void DeleteCustomer(int id)
        {
            Customer found = dbContext.Customers.Find(id);
            if (found != null)
            {
                dbContext.Customers.Remove(found);
                dbContext.SaveChanges();
            }
        }
        public Customer FindCustomerById(int id)
        {
            return dbContext.Customers.Find(id);
        }
        public Customer FindCustomerByEmail(string Email)
        {
            return dbContext.Customers.FirstOrDefault(pro => pro.Email == Email);
        }
        //datatype
        public IEnumerable<Customer> FindCustomerWithName(string Name)
        {
            return dbContext.Customers.Where(meds => meds.Name.ToLower().Contains(Name.ToLower()));
        }
    }
}
