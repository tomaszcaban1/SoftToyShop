using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SoftToyShop.Repository.Services;

namespace SoftToyShop.Repository.Models
{
    public class ShoppingCart
    {
        private readonly SoftToyShopDbContext _dbContext;
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(SoftToyShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            var session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<SoftToyShopDbContext>();

            var cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(SoftToy softToy, int amount)
        {
            var shoppingCartItem =
                _dbContext.ShoppingCartItems.SingleOrDefault(
                    s => s.SoftToy.Id == softToy.Id && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    SoftToy = softToy,
                    Amount = 1
                };

                _dbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            _dbContext.SaveChanges();
        }

        public int RemoveFromCart(SoftToy softToy)
        {
            var shoppingCartItem =
                _dbContext.ShoppingCartItems.SingleOrDefault(
                    s => s.SoftToy.Id == softToy.Id && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _dbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _dbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _dbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.SoftToy)
                           .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _dbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _dbContext.ShoppingCartItems.RemoveRange(cartItems);

            _dbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _dbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.SoftToy.Price * c.Amount).Sum();
            return total;
        }
    }
}
