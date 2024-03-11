using onlinePharmacyApp.Data;
using onlinePharmacyApp.ETClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace onlinePharmacyApp.Repostories
{

    public class OrderRepository
    {

        private readonly PharmaDbContext _context;

        public OrderRepository( )
        {
            _context = new PharmaDbContext();
        }

        // Add a new order to the database
        public void AddOrder(Orders order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
        public void AddOrderItems(OrderItem order)
        {
            _context.OrderItems.Add(order);
            _context.SaveChanges();
        }

        public double TotalCost(int id)
        {
            Orders od= _context.Orders.FirstOrDefault(o => o.CustomerId == id);
            return od.TotalPrice;
        }
        public bool FirstUser(int id)
        {
            return _context.Orders.Any(o => o.CustomerId == id);
        }
    
        public int getId(int id)
        {
            Orders od = _context.Orders.FirstOrDefault(o => o.CustomerId == id);
            return od.OrderId;
        }
        // Get all orders
        public IEnumerable<Orders> GetAllOrders()
        {
            return _context.Orders.ToList();
        }
        public IEnumerable<Orders> GetUserOrder(int id)
        {
            IEnumerable<Orders> userOrders = _context.Orders.Where(a => a.CustomerId == id);
            return userOrders;
        }
        public IEnumerable<OrderItem> GetUserOrderItems(int id)
        {
            IEnumerable<OrderItem> userOrders = _context.OrderItems.Where(a => a.CustomerId == id);
            return userOrders;
        }
        // Get order by ID
        public Orders GetOrderById(int orderId)
        {
            return _context.Orders.Find(orderId);
        }
        public IEnumerable<Orders> FindOrderByUser(int id)
        {
            return _context.Orders.Where(o => o.CustomerId==id);
        }
        // Update an existing order

        public void UpdateOrder(Orders updatedOrder)
        {
            using (var context = new PharmaDbContext())
            {
                var existingOrder = context.Orders.Find(updatedOrder.OrderId);

                if (existingOrder != null)
                {
                    
                    existingOrder.OrderStatus= updatedOrder.OrderStatus;
                  
                    context.SaveChanges();
                }
}
        }

        // Remove an order
        public void RemoveOrder(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}
