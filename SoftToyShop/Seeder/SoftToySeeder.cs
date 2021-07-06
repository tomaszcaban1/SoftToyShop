using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SoftToyShop.Repository.Models;
using SoftToyShop.Repository.Services;

namespace SoftToyShop.Seeder
{
    public class SoftToySeeder
    {
        private readonly SoftToyShopDbContext _dbContext;

        public SoftToySeeder(SoftToyShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

                if (!_dbContext.SoftToys.Any())
                {
                    var basicSoftToys = GetSoftToys();
                    _dbContext.SoftToys.AddRange(basicSoftToys);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<SoftToy> GetSoftToys() =>
            new List<SoftToy>()
            {
                new()
                {
                    Name = "Octopus Plush",
                    ShortDescription = "Cute and soft plush doll",
                    LongDescription = "The unique octopus flip design provides you with different visual and sensory experiences. This is a great children's toy, birthday gift, Valentine's day gift, Christmas gift. Cute octopus plush soft toys are perfect for playing, collecting & cuddling. A cute reversible plush toy with two different expressions",
                    Price = 10.00M,
                    ImageUrl = "~/images/toys/octopus.png",
                    ImageThumbnailUrl = "~/images/toys/octopus.png",
                    IsGreatOffer = true,
                    InStock = true,
                    Category = new Category()
                    {
                        CategoryName = "Stuffed Animal",
                        Description = "Soft toy is manufactured using excellent poly-staple and conjugate filling fibre, giving it a soft and cuddly feeling, making it extremely huggable."
                    }
                },
                new()
                {
                    Name = "Giraffe Animal",
                    ShortDescription = "Small Good quality materials",
                    LongDescription = "Soft and squishy, doll is ready for playtime, bedtime, and anything-you-want time play pretend for hours on end, squish and sleep with this softie at home",
                    Price = 12.95M,
                    ImageUrl = "~/images/toys/giraffe.png",
                    ImageThumbnailUrl = "~/images/toys/giraffe.png",
                    IsGreatOffer = true,
                    InStock = true,
                    Category = new Category()
                    {
                        CategoryName = "Plush Pillow",
                        Description = "Constructed with premium plush and PP cotton, it is super soft and comfortable."
                    }
                },
                new()
                {
                    Name = "Unicorn",
                    ShortDescription = "Unicorn Soft Toy",
                    LongDescription = "Constructed with premium plush and PP cotton, it is super soft and comfortable. Cute and creative unicorn pattern design makes it more attractive to kids. Makes a great party favor or stocking stuffer for children. Wonderful gift for children to bring them more fun and surprise.",
                    Price = 9.00M,
                    ImageUrl = "~/images/toys/unicorn.png",
                    ImageThumbnailUrl = "~/images/toys/unicorn.png",
                    IsGreatOffer = true,
                    InStock = true,
                    Category = new Category()
                    {
                        CategoryName = "Plush Puppet",
                        Description = "Cute and soft plush doll with realistic expression, clear outline and lifelike."
                    }
                },
            };
    }
}
