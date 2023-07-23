using MapsterMapper;

using Microsoft.AspNetCore.Mvc;

using VetClinicApi.API.Controllers.Abstract;
using VetClinicApi.Contracts.CustomerContracts;
using VetClinicApi.Core.Entities;

namespace VetClinicApi.API.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : BaseController
    {
        private readonly IMapper _mapper;

        public CustomersController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("get/id={id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCustomer(CreateCustomerRequest customerRequest)
        {
            var customer = _mapper.Map<Customer>(customerRequest);
            throw new NotImplementedException();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerRequest customerRequest)
        {
            var customer = _mapper.Map<Customer>(customerRequest);
            throw new NotImplementedException();
        }
    }
}
