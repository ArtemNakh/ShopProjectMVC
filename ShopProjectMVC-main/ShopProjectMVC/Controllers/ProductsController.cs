using Microsoft.AspNetCore.Mvc;
using ShopProjectMVC.Core.Interfaces;

namespace ShopProjectMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var orders = _productService.GetAll();
            return View(orders);
        }
    }
}
