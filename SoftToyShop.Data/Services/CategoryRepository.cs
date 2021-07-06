using System.Collections.Generic;
using SoftToyShop.Repository.Models;
using SoftToyShop.Repository.Services.Interfaces;

namespace SoftToyShop.Repository.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SoftToyShopDbContext _softToyShopDbContext;

        public CategoryRepository(SoftToyShopDbContext softToyShopDbContext)
        {
            _softToyShopDbContext = softToyShopDbContext;
        }

        public IEnumerable<Category> GetAllCategories => _softToyShopDbContext.Categories;
    }
}
