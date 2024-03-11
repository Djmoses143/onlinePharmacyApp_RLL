using onlinePharmacyApp.ETClasses;
using onlinePharmacyApp.Repostories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PharmaApi.Models
{
    public class PharmaService
    {

        private readonly AdminRepository adminRepo;
        private readonly CartRepository cartRepo;
        private readonly CustomerRepository customerRepo;
        private readonly MedicineRepository medicineRepo;
        private readonly OrderRepository orderRepo;


        public PharmaService()
        {
            adminRepo = new AdminRepository();
            cartRepo = new CartRepository();
            customerRepo = new CustomerRepository();
            medicineRepo = new MedicineRepository();
            orderRepo = new OrderRepository();
        }
        public Admin FindAdminByEmail(string email)
        {
            return adminRepo.FindAdminByEmail(email);
        }
        public List<Admin> GetAllAdmins()
        {
            return adminRepo.GetAllAdmins();
        }
        public void UpdateAdmin(Admin admin)
        {
            adminRepo.UpdateAdmin(admin);
        }
        public bool checkAdminLogin(Admin admin)
        {
            return adminRepo.checkAdminLogin(admin);
        }
        // invoking medicine methods 

        public List<Medicine> GetAllMedicines()
        {
            return medicineRepo.GetAllMedicines();
        }

        public Medicine GetMedicineById(int medicineId)
        {
            return medicineRepo.GetMedicineById(medicineId);
        }
        public IEnumerable<Medicine> FindMedicineBySearch(string Mtype)
        {
            return medicineRepo.FindMedicineByType(Mtype);
        }

        public void AddMedicine(Medicine medicine)
        {
            medicineRepo.AddMedicine(medicine);
        }

        public void UpdateMedicine(Medicine medicine)
        {
            medicineRepo.UpdateMedicine(medicine);
        }
        public void DeleteMedicine(int medicineId)
        {
            medicineRepo.DeleteMedicine(medicineId);
        }


        // invoking methods for cart

        public void AddCartItem(Cart cartItem)
        {
            cartRepo.AddCartItem(cartItem);
        }


        public IEnumerable<Cart> GetAllCartItems()
        {
            return cartRepo.GetAllCartItems();
        }
       
        

        public IEnumerable<Cart> GetAllUserCart(int id)
        {
            return cartRepo.GetAllUserCart(id);
        }
        public Cart FindExistingMedicine(int id)
        {
            return cartRepo.FindExistingMedicine(id);
        }

        public IEnumerable<Orders> FindOrderByUser(int id)
        {
            return orderRepo.FindOrderByUser(id);
        }

        public Cart GetCartById(int CartId)
        {
            return cartRepo.GetCartById(CartId);
        }

        public void DeleteCartItemsByUserId(int userId)
        {
            cartRepo.DeleteCartItemsByUserId(userId);
        }
        public void UpdateCartItem(Cart CartItem)
        {
            cartRepo.UpdateCartItem(CartItem);
        }

        public void RemoveCartItem(int CartItemId)
        {
            cartRepo.RemoveCartItem(CartItemId);
        }


        // Invoking methods for Customer

        public IEnumerable<Customer> GetAllCustomers()
        {
            return customerRepo.GetAllCustomers();
        }

        public Customer GetCustomerById(int id)
        {
            return customerRepo.FindCustomerById(id);
        }
        public Customer FindCustomerByEmail(String email)
        {
            return customerRepo.FindCustomerByEmail(email);
        }
        public bool checkCustomerLogin(Customer customer)
        {
            return customerRepo.checkCustomerLogin(customer);
        }

        public void AddCustomer(Customer Customers)
        {
            customerRepo.InsertCustomer(Customers);
        }

        public void UpdateCustomer(Customer Customers)
        {
            customerRepo.UpdateCustomer(Customers);
        }
        public void DeleteCustomer(int Id)
        {
            customerRepo.DeleteCustomer(Id);
        }


        // invoking methos for Orders
        public IEnumerable<Orders> GetAllOrders()
        {
            return orderRepo.GetAllOrders();
        }

        public Orders GetOrderById(int OrderId)
        {
            return orderRepo.GetOrderById(OrderId);
        }
        
        public void AddOrder(Orders  Order)
        {
            orderRepo.AddOrder(Order);
        }
        public void AddOrderItems(OrderItem order)
        {
            orderRepo.AddOrderItems(order);
        }

        public double TotalCost(int id)
        {
           return  orderRepo.TotalCost(id);
        }
        public IEnumerable<Orders> GetUserOrder(int id)
        {
           return orderRepo.GetUserOrder(id);
        }
        public bool FirstUser(int id)
        {
            return orderRepo.FirstUser(id);
        }
        public int getId(int id)
        {
          return orderRepo.getId(id);
        }
        public IEnumerable<OrderItem> GetUserOrderItems(int id)
        {
           return orderRepo.GetUserOrderItems(id);
        }
        public void UpdateOrders(Orders UpdateOrders)
        {
            orderRepo.UpdateOrder(UpdateOrders);
        }
        public void RemoveOrder(int OrderId)
        {
            orderRepo.RemoveOrder(OrderId);
        }

        public bool checkbyPassword(string password)
        {
            return adminRepo.FindAdminByPassword(password);
        }


    }
}