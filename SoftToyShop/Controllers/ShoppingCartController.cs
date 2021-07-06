using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SoftToyShop.Repository.Models;
using SoftToyShop.Repository.Services.Interfaces;
using SoftToyShop.ViewModels;

namespace SoftToyShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ISoftToyRepository _softToyRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(ISoftToyRepository softToyRepository, ShoppingCart shoppingCart)
        {
            _softToyRepository = softToyRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int softToyId)
        {
            var selectedToy = _softToyRepository.GetAllSoftToys.FirstOrDefault(p => p.Id == softToyId);

            if (selectedToy != null)
            {
                _shoppingCart.AddToCart(selectedToy, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int softToyId)
        {
            var selectedToy = _softToyRepository.GetAllSoftToys.FirstOrDefault(p => p.Id == softToyId);

            if (selectedToy != null)
            {
                _shoppingCart.RemoveFromCart(selectedToy);
            }
            return RedirectToAction("Index");
        }
    }
}
