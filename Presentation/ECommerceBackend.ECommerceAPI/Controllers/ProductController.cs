using ECommerceBackend.Application.Repositories;
using ECommerceBackend.Domain.Entities;
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


        //if return type becomes 'void' and context adds not singleton (scoped,transient vs), 'Cannot access a disposed context instance' error occures because of 'async' method. To avoid this error method return type must be 'Task' or context must add to IoC container by singleton.
        [HttpGet]
        public async Task GetAsync()
        {
            //await _productWriteRepository.AddRangeAsync(
            //    new()
            //    {
            //        new() { id = Guid.NewGuid(), Name = "product1", Price = 100, CreationDate = DateTime.UtcNow, Stock = 10 },
            //        new() { id = Guid.NewGuid(), Name = "product2", Price = 200, CreationDate = DateTime.UtcNow, Stock = 20 },
            //        new() { id = Guid.NewGuid(), Name = "product3", Price = 300, CreationDate = DateTime.UtcNow, Stock = 30 }
            //    });
            //await _productWriteRepository.SaveAsync();

            //false means is it will not track so if the 'product' update, changes are not saved when call save function of repository
            Product product = await _productReadRepository.GetByIdAsnc("1a57813f-21d5-4845-aed1-34c296d522b9", false);
            product.Name = "abuzer";
            //for now, write and read repository same. Thats why in here we can use write repository to save operation.
            await _productWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productReadRepository.GetByIdAsnc(id);
            return Ok(product);
        }
    }
}
