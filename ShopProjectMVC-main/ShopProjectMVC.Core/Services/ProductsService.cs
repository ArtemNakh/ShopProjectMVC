
using ShopProjectMVC.Core.Interfaces;
using ShopProjectMVC.Core.Models;

namespace ShopProjectMVC.Core.Services
{
    public class ProductsService : IProductService
    {
        private readonly IRepository _repository;

        public ProductsService(IRepository repository)
        {
            _repository = repository;
        }

        public Task<Product> AddProduct(Product product)
        {
            return _repository.Add(product);
        }


        public async Task<Order> BuyProduct(int userId, int productId)
        {
            var product = await _repository.GetById<Product>(productId);
            var user = await _repository.GetById<User>(userId);
            var order = new Order
            {
                User = user,
                Product = product,
                CreatedAt = DateTime.UtcNow
            };


            return await _repository.Add(order);
        }

        public async Task DeleteProduct(int id)
        {
            await _repository.Delete<Product>(id);
        }


        public IEnumerable<Product> GetAll()
        {
            return _repository.GetAll<Product>();
        }

        public Task<Product> GetProductById(int id)
        {
            return _repository.GetById<Product>(id);
        }

        public Task<Product> UpdateProduct(Product product)
        {
            return _repository.Update(product);
        }
    }
}
