using System.Collections.Generic;
using SoftToyShop.Repository.Models;

namespace SoftToyShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<SoftToy> SoftToysGreatOffer { get; set; }
    }
}
