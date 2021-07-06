using System.Collections.Generic;
using SoftToyShop.Repository.Models;

namespace SoftToyShop.ViewModels
{
    public class SoftToyListViewModel
    {
        public IEnumerable<SoftToy> SoftToys { get; set; }
        public string CurrentCategory { get; set; }
    }
}
