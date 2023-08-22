using MapsterMapper;

using Microsoft.AspNetCore.Mvc;

using System.Net;

using VetClinicApi.API.Controllers.Abstract;
using VetClinicApi.Application.Services.ProvidedServiceHandling;
using VetClinicApi.Contracts.ProvidedServicesContracts;
using VetClinicApi.Core.Entities;

namespace VetClinicApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProvidedServicesController : BaseController
{
    private readonly IMapper _mapper;
    private readonly IProvidedServiceService _providedService;

	public ProvidedServicesController(IProvidedServiceService providedService, IMapper mapper)
	{
		_providedService = providedService;
		_mapper = mapper;
	}

	[HttpPut("create")]
    [ProducesResponseType(typeof(ProvidedServicesResponse), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> Create(CreateProvidedServiceRequest request)
	{
        var entity = _mapper.Map<ProvidedService>(request);
        var result = await _providedService.CreateProvidedService(entity);
        var response = _mapper.Map<ProvidedServicesResponse>(result);

        return StatusCode((int)HttpStatusCode.OK, response);
    }

	[HttpPost("update")]
    [ProducesResponseType(typeof(ProvidedServicesResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(UpdateProvidedServiceRequest request)
	{
		var entity = _mapper.Map<ProvidedService>(request);
		var result = await _providedService.UpdateProvidedService(entity);
		var response = _mapper.Map<ProvidedServicesResponse>(result);

		return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpDelete("delete/{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
	public async Task<IActionResult> Delete(int id)
	{
		await _providedService.DeleteProvidedService(id);

		return StatusCode((int)HttpStatusCode.OK);
	}

	[HttpGet("/")]
    [ProducesResponseType(typeof(IEnumerable<ProvidedServicesResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll()
	{
		var result = await _providedService.GetAllProvidedServices();
		var response = result.Select(x => _mapper.Map<ProvidedServicesResponse>(x));

		return StatusCode((int)HttpStatusCode.OK, response);
	}
}
