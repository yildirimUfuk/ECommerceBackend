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
        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private ICustomerWriteRepository _customerWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;

        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository = null, IOrderWriteRepository orderWriteRepository = null, ICustomerWriteRepository customerWriteRepository = null, IOrderReadRepository orderReadRepository = null)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
        }


        [HttpGet]
        public async Task GetAsync()
        {
            //var newCustomerId = Guid.NewGuid();
            //await _customerWriteRepository.AddAsync(new() { id = newCustomerId, Name = "abuzer"});

            //await  _orderWriteRepository.AddAsync(new() { Description = "order1", Address = "address1",CustomerId=newCustomerId});
            //await  _orderWriteRepository.AddAsync(new() { Description = "order2", Address = "address2" ,CustomerId=newCustomerId});
            //await _orderWriteRepository.SaveAsync();

            var data = await _orderReadRepository.GetByIdAsnc("58312741-13b4-4e19-8889-4d5f42b2d4a5");
            data.Address = "new addres";
            await _orderWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productReadRepository.GetByIdAsnc(id);
            return Ok(product);
        }
    }
}
