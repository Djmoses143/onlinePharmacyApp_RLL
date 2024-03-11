using onlinePharmacyApp.Data;
using onlinePharmacyApp.ETClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlinePharmacyApp.Repostories
{

    public class CartRepository
    {
        private readonly PharmaDbContext dbContext;
        public CartRepository()
        {
            dbContext = new PharmaDbContext();
        }

        //Add a cart item to the database
        public void AddCartItem(Cart cartItem)
        {
            dbContext.Carts.Add(cartItem);
            dbContext.SaveChanges();
        }


        // Get all cart items
        public IEnumerable<Cart> GetAllCartItems()
        {
            return dbContext.Carts.ToList();
        }

        // Get cart items for a specific order
        public Cart GetCartById(int CartId)
        {
            return dbContext.Carts.FirstOrDefault(s => s.CartId == CartId);
        }

      
        public Cart FindExistingMedicine(int id) {
            return dbContext.Carts.FirstOrDefault(x => x.MedicineId == id);
        }

        public IEnumerable<Cart> GetAllUserCart(int id)
        {
            IEnumerable<Cart> userCart = dbContext.Carts.Where(a => a.UserId == id);
            return userCart;
        }
        //Update a cart item
        
        public void UpdateCartItem(Cart cartItem)
        {
            var existingCartItem = dbContext.Carts.Find(cartItem.CartId);
            if (existingCartItem != null)
            {
                dbContext.Entry(existingCartItem).CurrentValues.SetValues(cartItem);
                dbContext.SaveChanges();
            }
        }
        public void DeleteCartItemsByUserId(int userId)
        {
            var cartItemsToDelete = dbContext.Carts.Where(ci => ci.UserId == userId);

            dbContext.Carts.RemoveRange(cartItemsToDelete);
            dbContext.SaveChanges();
        }
        // Remove a cart item
        public void RemoveCartItem(int cartItemId)
        {
            var cartItem = dbContext.Carts.Find(cartItemId);
            if (cartItem != null)
            {
                dbContext.Carts.Remove(cartItem);
                dbContext.SaveChanges();
            }
        }
    }
}
