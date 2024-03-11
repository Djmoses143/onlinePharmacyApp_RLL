using onlinePharmacyApp.ETClasses;
using PharmaApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmaUI.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        private readonly PharmaService pharmaService;
        public OrderController()
        {
            pharmaService = new PharmaService();
        }
        //OrderList
        public ActionResult OrderCheckOut()
        {
            var cust = Session["CustObject"] as Customer;
            var UserCartList = pharmaService.GetAllUserCart(cust.CustomerId);
            double TotalAmount = 0;
            foreach (var userCart in UserCartList)
            {
                TotalAmount += userCart.itemTotal;
            }
            var BeforeAmt = TotalAmount;
            var AfterAmt= TotalAmount;
            double discount = 0;
            if (!pharmaService.FirstUser(cust.CustomerId) )
            {
                discount = ((TotalAmount * 10) / 100);
                AfterAmt-=discount;
            }
            else
            {
                discount = ((TotalAmount * 5) / 100);
                AfterAmt -= discount;
            }
            ViewBag.BefDis = BeforeAmt;
            ViewBag.Dis = discount;
            ViewBag.AfterDis =AfterAmt;
            Session["TolAmt"] = AfterAmt;
            return View(UserCartList);
        }

        [HttpPost]
        public ActionResult PlaceOrder()
        {
            List<OrderItem> orderMedicinesItems = new List<OrderItem>();
            var cust = Session["CustObject"] as Customer;
            var UserCartList = pharmaService.GetAllUserCart(cust.CustomerId);
              
            foreach(var  userCart in UserCartList)
            {
                OrderItem orderItem = new OrderItem
                {
                    MedicineId = userCart.MedicineId,
                    MedicineName = userCart.Mname,
                    Price = userCart.Price,
                    CustomerId=userCart.UserId,
                    Quantity = userCart.Quantity,
                    SubPrice = userCart.itemTotal
                };

                pharmaService.AddOrderItems(orderItem);
                orderMedicinesItems.Add(orderItem); 
            } 
            Orders orders = new Orders();
          
            orders.CustomerId = cust.CustomerId;
            orders.OrderDate= DateTime.Now;
            orders.OrderStatus = "Booked";
            orders.TotalPrice = (double)Session["TolAmt"];
            orders.OrderItems= orderMedicinesItems;

            pharmaService.AddOrder(orders);

           
            return RedirectToAction("OrderPage","Order");
        }

        public ActionResult MyOrders()
        {
            var cust = Session["CustObject"] as Customer;
            
            IEnumerable<Orders> OrderItems = pharmaService.FindOrderByUser(cust.CustomerId);
            ViewBag.visibleCart = false;
            
            if (OrderItems.Count() > 0)
            {
                ViewBag.visibleCart = true;
            }
            pharmaService.DeleteCartItemsByUserId(cust.CustomerId);
            return View(OrderItems);
        }


        public ActionResult OrderPage()
        {
            var cust = Session["CustObject"] as Customer;
            var CustOrderList=pharmaService.GetUserOrder(cust.CustomerId);
            var CustUser = pharmaService.GetAllUserCart(cust.CustomerId);
            ViewBag.TotalAmount = Session["TolAmt"];

            
            return View(CustUser);
        }



        [HttpPost]
        public ActionResult CancelOrder (int id)
        {
            Orders orders= pharmaService.GetOrderById(id);
            orders.OrderStatus = "Cancelled";
            
            pharmaService.UpdateOrders(orders);
            return RedirectToAction("MyOrders");
        }


    }
}