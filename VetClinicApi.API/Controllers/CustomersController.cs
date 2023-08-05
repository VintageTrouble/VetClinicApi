using MapsterMapper;

using Microsoft.AspNetCore.Mvc;

using System.Net;

using VetClinicApi.API.Controllers.Abstract;
using VetClinicApi.Application.Services.CustomerHandlig;
using VetClinicApi.Contracts.CustomerContracts;
using VetClinicApi.Core.Entities;

namespace VetClinicApi.API.Controllers;

[Route("api/[controller]")]
public class CustomersController : BaseController
{
    private readonly IMapper _mapper;
    private readonly ICustomerService _customerService;
    public CustomersController(IMapper mapper, ICustomerService customerService)
    {
        _mapper = mapper;
        _customerService = customerService;
    }

    [HttpGet("get/{id}")]
    [ProducesResponseType(typeof(CustomerResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCustomer(int id)
    {
        var customer = await _customerService.GetCustomer(id);
        var response = _mapper.Map<CustomerResponse>(customer);

        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpPut("create")]
    [ProducesResponseType(typeof(CustomerResponse), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Conflict)]
    public async Task<IActionResult> CreateCustomer(CreateCustomerRequest customerRequest)
    {
        var customer = _mapper.Map<Customer>(customerRequest);
        var newCustomer = await _customerService.CreateCustomer(customer);
        var response = _mapper.Map<CustomerResponse>(newCustomer);

        return StatusCode((int)HttpStatusCode.Created, response);
    }

    [HttpPost("update")]
    [ProducesResponseType(typeof(CustomerResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Conflict)]
    public async Task<IActionResult> UpdateCustomer(UpdateCustomerRequest customerRequest)
    {
        var customer = _mapper.Map<Customer>(customerRequest);
        var newCustomer = await _customerService.UpdateCustomer(customer);
        var response = _mapper.Map<CustomerResponse>(newCustomer);

        return StatusCode((int)HttpStatusCode.OK, response);
    }
}
