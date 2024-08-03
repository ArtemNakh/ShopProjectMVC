using Microsoft.AspNetCore.Mvc;
using ShopProjectMVC.Core.Interfaces;

namespace ShopProjectMVC.Controllers;

public class OrdersController : Controller
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [AuthFilter]
    public IActionResult Index()
    {
        var orders = _orderService.GetOrders(1).ToList();
        return View(orders);
    }




    [AuthFilter]
    public async Task<IActionResult> Details(int id)
    {
        var order = await _orderService.GetOrderById(id);
        if (order == null)
        {
            return NotFound();
        }
        return View(order);
    }

   

    [AuthFilter]
    public async Task<IActionResult> Delete(int id)
    {
        var order = await _orderService.GetOrderById(id);
        if (order == null)
        {
            return NotFound();
        }
        return View(order);
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [AuthFilter]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var order = await _orderService.GetOrderById(id);
        if (order != null)
        {
            await _orderService.DeleteOrder(id);
        }
        return RedirectToAction(nameof(Index));
    }

    private async Task<bool> OrderExists(int id)
    {
        var order = await _orderService.GetOrderById(id);
        return order != null;
    }
}


