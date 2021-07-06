using Microsoft.AspNetCore.Mvc;
using SoftToyShop.Repository.Services.Interfaces;
using SoftToyShop.ViewModels;
using System.Diagnostics;

namespace SoftToyShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISoftToyRepository _softToyRepository;

        public HomeController(ISoftToyRepository softToyRepository)
        {
            _softToyRepository = softToyRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                SoftToysGreatOffer = _softToyRepository.GetSoftToyGreatOffer
            };
            return View(homeViewModel);
        }
    }
}
