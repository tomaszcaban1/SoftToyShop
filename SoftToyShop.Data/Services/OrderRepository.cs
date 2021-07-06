using System;
using System.Collections.Generic;
using SoftToyShop.Repository.Models;
using SoftToyShop.Repository.Services.Interfaces;

namespace SoftToyShop.Repository.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SoftToyShopDbContext _dbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(SoftToyShopDbContext dbContext, ShoppingCart shoppingCart)
        {
            _dbContext = dbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    SoftToyId = shoppingCartItem.SoftToy.Id,
                    Price = shoppingCartItem.SoftToy.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _dbContext.Orders.Add(order);

            _dbContext.SaveChanges();
        }
    }
}
