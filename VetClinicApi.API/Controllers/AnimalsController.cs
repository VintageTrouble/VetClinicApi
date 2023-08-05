using MapsterMapper;

using Microsoft.AspNetCore.Mvc;

using System.Net;

using VetClinicApi.API.Controllers.Abstract;
using VetClinicApi.Application.Services.AnimalHandling;
using VetClinicApi.Contracts.AnimalContracts;
using VetClinicApi.Contracts.AnimalTypeContracts;
using VetClinicApi.Core.Entities;

namespace VetClinicApi.API.Controllers;

[Route("api/[controller]")]
public class AnimalsController : BaseController
{
    private readonly IMapper _mapper;
    private readonly IAnimalService _animalService;
    public AnimalsController(IMapper mapper, IAnimalService animalService)
    {
        _mapper = mapper;
        _animalService = animalService;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(AnimalResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAnimal(int id)
    {
        var animal = await _animalService.GetAnimal(id);
        var response = _mapper.Map<AnimalResponse>(animal);

        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpGet("customer/{id}")]
    [ProducesResponseType(typeof(IEnumerable<AnimalResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAnimalsByCustomer(int id)
    {
        var animals = await _animalService.GetAnimalsByCustomer(id);
        var response = animals.Select(x => _mapper.Map<AnimalResponse>(x));

        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpPut("create")]
    [ProducesResponseType(typeof(AnimalResponse), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Conflict)]
    public async Task<IActionResult> CreateAnimal(CreateAnimalRequest animalRequest)
    {
        var animal = _mapper.Map<Animal>(animalRequest);
        var newAnimal = await _animalService.CreateAnimal(animal);
        var response = _mapper.Map<AnimalResponse>(newAnimal);

        return StatusCode((int)HttpStatusCode.Created, response);
    }

    [HttpPost("update")]
    [ProducesResponseType(typeof(AnimalResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Conflict)]
    public async Task<IActionResult> UpdateAnimal(UpdateAnimalRequest animalRequest)
    {
        var animal = _mapper.Map<Animal>(animalRequest);
        var newAnimal = await _animalService.UpdateAnimal(animal);
        var response = _mapper.Map<AnimalResponse>(newAnimal);

        return StatusCode((int)HttpStatusCode.OK, response);
    }

    [HttpDelete("delete/{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.Conflict)]
    public async Task<IActionResult> DeleteAnimal(int id)
    {
        await _animalService.DeleteAnimal(id);

        return StatusCode((int)HttpStatusCode.OK);
    }

    //AnimalType endpoints
    [HttpGet("type")]
    [ProducesResponseType(typeof(IEnumerable<AnimalTypeResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllAnimalTypes()
    {
        var animalTypes = await _animalService.GetAllAnimalTypes();
        var response = animalTypes.Select(x => _mapper.Map<AnimalTypeResponse>(x));

        return StatusCode((int) HttpStatusCode.OK, response);
    }

    [HttpPut("type/create")]
    [ProducesResponseType(typeof(AnimalTypeResponse), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreateAnimalType(string name)
    {
        if (string.IsNullOrEmpty(name))
            return Problem(title: "Name can't be null or empty", statusCode: (int)HttpStatusCode.BadRequest);
        
        var animalType = new AnimalType { Name = name };
        var newAnimalType = await _animalService.CreateAnimalType(animalType);
        var response = _mapper.Map<AnimalTypeResponse>(newAnimalType);

        return StatusCode((int)HttpStatusCode.Created, response);
    }

    [HttpDelete("type/delete/{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteAnimalType(int id)
    {
       await _animalService.DeleteAnimalType(id);

        return StatusCode((int)HttpStatusCode.OK);
    }
}
