using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SoftToyShop.ViewModels;
using SoftToyShop.Repository.Services.Interfaces;
using SoftToyShop.Repository.Models;
using SoftToyShop.Constants;

namespace SoftToyShop.Controllers
{
    public class SoftToyController : Controller
    {
        private readonly ISoftToyRepository _softToyRepository;

        public SoftToyController(ISoftToyRepository softToyRepository)
        {
            _softToyRepository = softToyRepository;
        }

        public ViewResult List(string category)
        {
            IEnumerable<SoftToy> softToys;

            if (string.IsNullOrEmpty(category))
            {
                softToys = _softToyRepository.GetAllSoftToys.OrderBy(t => t.Id);
                category = Constants.Category.allCategories;
            }
            else
            {
                softToys = _softToyRepository.GetSoftToysByCategory(category);
            }

            return View(new SoftToyListViewModel()
            {
                SoftToys = softToys,
                CurrentCategory = category
            });
        }

        public IActionResult Details(int id)
        {
            var softToy = _softToyRepository.GetSoftToyById(id);

            if (softToy == null)
            {
                Response.StatusCode = ResponseCode._notFoundException;
                return View("SoftToyNotFound", new NotFoundViewModel()
                {
                    EntityName = EntityName.softToy,
                    EntityId = id
                });
            }

            return View(softToy);
        }
    }
}
