using SoftToyShop.Repository.Models;
using System.Collections.Generic;

namespace SoftToyShop.Repository.Services.Interfaces
{
    public interface ISoftToyRepository
    {
        IEnumerable<SoftToy> GetAllSoftToys { get; }
        IEnumerable<SoftToy> GetSoftToyGreatOffer { get; }
        SoftToy GetSoftToyById(int softToyId);
        IEnumerable<SoftToy> GetSoftToysByCategory(string category);
    }
}
