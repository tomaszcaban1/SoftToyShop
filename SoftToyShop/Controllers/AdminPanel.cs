using Microsoft.AspNetCore.Mvc;
using SoftToyShop.Repository.Models;
using SoftToyShop.Repository.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SoftToyShop.Controllers
{
    public class AdminPanel : Controller
    {
        private readonly ISoftToyRepository _softToyRepository;

        public AdminPanel(ISoftToyRepository softToyRepository)
        {
            _softToyRepository = softToyRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<SoftToy> softToys;

            softToys = _softToyRepository.GetAllSoftToys.OrderBy(t => t.Id);

            return View(softToys);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SoftToy softToy)
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
