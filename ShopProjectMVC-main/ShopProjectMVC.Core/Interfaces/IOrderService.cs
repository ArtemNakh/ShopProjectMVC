using ShopProjectMVC.Core.Models;

namespace ShopProjectMVC.Core.Interfaces;

public interface IOrderService
{
    IEnumerable<Order> GetOrders(int userId);
    IEnumerable<Order> GetOrders(int userId, int offset, int size);

    Task<Order> GetOrderById(int id);
    Task UpdateOrder(Order order);
    Task DeleteOrder(int id);


}