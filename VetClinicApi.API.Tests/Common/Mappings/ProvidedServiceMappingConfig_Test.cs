using MapsterMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinicApi.Contracts.CustomerContracts;
using VetClinicApi.Contracts.ProvidedServicesContracts;
using VetClinicApi.Core.Entities;

using Xunit;

namespace VetClinicApi.API.Tests.Common.Mappings;

public class ProvidedServiceMappingConfig_Test
{
    private readonly IMapper _mapper;

    public ProvidedServiceMappingConfig_Test()
    {
        _mapper = AddMapsterForUnitTests.GetMapper();
    }

    [Fact]
    public void Map_ProvidedServiceToProvidedServiceResponse_Test()
    {
        var ps = new ProvidedService
        {
            Id = 1,
            Name = "Test",
            Price = 99.99m
        };

        var result = _mapper.Map<ProvidedServicesResponse>(ps);

        Assert.Equal(ps.Id, result.Id);
        Assert.Equal(ps.Name, result.Name);
        Assert.Equal(ps.Price, result.Price);
    }

    [Fact]
    public void Map_CreateProvidedServiceToProvidedService_Test()
    {
        var request = new CreateProvidedServiceRequest("Test", 99.99m);

        var result = _mapper.Map<ProvidedService>(request);

        Assert.Equal(default, result.Id);
        Assert.Equal(request.Name, result.Name);
        Assert.Equal(request.Price, result.Price);
    }

    [Fact]
    public void Map_UpdateProvidedServiceRequestToProvidedService_Test()
    {
        var request = new UpdateProvidedServiceRequest(
            1,
            "Test",
            99.99m);

        var result = _mapper.Map<ProvidedService>(request);

        Assert.Equal(request.Id, result.Id);
        Assert.Equal(request.Name, result.Name);
        Assert.Equal(request.Price, result.Price);
    }
}
