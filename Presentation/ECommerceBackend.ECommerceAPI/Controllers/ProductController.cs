using ECommerceBackend.Application.Repositories;
using ECommerceBackend.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceBackend.ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository = null)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async void GetAsync()
        {
            await _productWriteRepository.AddRangeAsync(
                new()
                {
                    new() { id = Guid.NewGuid(), Name = "product1", Price = 100, CreationDate = DateTime.UtcNow, Stock = 10 },
                    new() { id = Guid.NewGuid(), Name = "product2", Price = 200, CreationDate = DateTime.UtcNow, Stock = 20 },
                    new() { id = Guid.NewGuid(), Name = "product3", Price = 300, CreationDate = DateTime.UtcNow, Stock = 30 }
                });
            await _productWriteRepository.SaveAsync();
        }
    }
}
