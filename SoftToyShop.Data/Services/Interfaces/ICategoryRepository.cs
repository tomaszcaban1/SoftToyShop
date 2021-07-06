using SoftToyShop.Repository.Models;
using System.Collections.Generic;

namespace SoftToyShop.Repository.Services.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories { get; }
    }
}
