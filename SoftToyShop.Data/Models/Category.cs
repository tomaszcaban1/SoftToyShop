using System.Collections.Generic;

namespace SoftToyShop.Repository.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<SoftToy> SoftToys { get; set; }
    }
}