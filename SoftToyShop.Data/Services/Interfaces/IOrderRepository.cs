using SoftToyShop.Repository.Models;

namespace SoftToyShop.Repository.Services.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
