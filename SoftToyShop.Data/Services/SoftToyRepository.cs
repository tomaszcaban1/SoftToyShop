using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SoftToyShop.Repository.Models;
using SoftToyShop.Repository.Services.Interfaces;

namespace SoftToyShop.Repository.Services
{
    public class SoftToyRepository : ISoftToyRepository
    {
        private readonly SoftToyShopDbContext _softToyShopDbContext;

        public SoftToyRepository(SoftToyShopDbContext softToyShopDbContext)
        {
            _softToyShopDbContext = softToyShopDbContext;
        }

        public IEnumerable<SoftToy> GetAllSoftToys
        {
            get
            {
                return _softToyShopDbContext.SoftToys.Include(c => c.Category);
            }
        }

        public IEnumerable<SoftToy> GetSoftToyGreatOffer
        {
            get
            {
                return _softToyShopDbContext.SoftToys.Include(c => c.Category)
                                                     .Where(t => t.IsGreatOffer);
            }
        }
        public SoftToy GetSoftToyById(int softToyId)
        {
            var softToy = _softToyShopDbContext.SoftToys.Include(c => c.Category)
                                                        .FirstOrDefault(t => t.Id == softToyId);

            return softToy;
        }

        public IEnumerable<SoftToy> GetSoftToysByCategory(string category)
        {
            var softToys = _softToyShopDbContext.SoftToys
                                                .Where(t => t.Category.CategoryName == category)
                                                .OrderBy(t => t.Id);

            return softToys;
        }
    }
}
