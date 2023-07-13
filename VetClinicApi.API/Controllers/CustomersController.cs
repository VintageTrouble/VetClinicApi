using MapsterMapper;

using Microsoft.AspNetCore.Mvc;

using VetClinicApi.API.Controllers.Abstract;
using VetClinicApi.Contracts.CustomerContracts;

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
            throw new NotImplementedException();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerRequest customerRequest)
        {
            throw new NotImplementedException();
        }
    }
}
