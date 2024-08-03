using ShopProjectMVC.Core.Interfaces;
using ShopProjectMVC.Core.Models;

namespace ShopProjectMVC.Core.Services;

public class OrderService : IOrderService
{
    private readonly IRepository _repository;    

    public OrderService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<Order> GetOrderById(int id)
    {
        // Отримуємо замовлення за його ідентифікатором
        return await _repository.GetById<Order>(id);
    }

    public async Task UpdateOrder(Order order)
    {
        // Оновлюємо існуюче замовлення
        await _repository.Update(order);
    }

    public async Task DeleteOrder(int id)
    {
        // Видаляємо замовлення за його ідентифікатором
        await _repository.Delete<Order>(id);
    }

    public IEnumerable<Order> GetOrders(int userId)
    {
        return _repository.GetAll<Order>()
            .Where(order => order.User.Id == userId);
    }

    public IEnumerable<Order> GetOrders(int userId, int offset, int size)
    {
        return GetOrders(userId).Skip(offset)
            .Take(size);
    }

   
}
