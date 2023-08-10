using Moq;

using VetClinicApi.Application.Common.Exceptions;
using VetClinicApi.Application.Services.ProvidedServiceHandling;
using VetClinicApi.Core.Entities;
using VetClinicApi.Database.Repositories;

using Xunit;

namespace VetClinicApi.Application.Tests.Services.ProvidedServiceHandling;

public class ProvidedServiceService_Test
{
    private readonly Mock<IProvidedServiceRepository> _providedServiceRepository = new();

    [Fact]
    public async Task Create_ProvidedServiceIsNull_Test()
    {
        var providedServiceService = new ProvidedServiceService(_providedServiceRepository.Object);

        await Assert.ThrowsAsync<ArgumentNullException>(async () => await providedServiceService.CreateProvidedService(null));
    }

    [Fact]
    public async Task Delete_ProvidedServiceNotFound_Test()
    {
        _providedServiceRepository.Setup(x => x.Delete(It.IsAny<int>())).ThrowsAsync(new ArgumentOutOfRangeException());
        var providedServiceService = new ProvidedServiceService(_providedServiceRepository.Object);

        await Assert.ThrowsAsync<EntityNotFoundException>(async () => await providedServiceService.DeleteProvidedService(1));
    }

    [Fact]
    public async Task Update_ProvidedServiceIsNull_Test()
    {
        var providedServiceService = new ProvidedServiceService(_providedServiceRepository.Object);

        await Assert.ThrowsAsync<ArgumentNullException>(async () => await providedServiceService.UpdateProvidedService(null));
    }

    [Fact]
    public async Task Update_RepositoryUpdateThrowsArgumentOutOfRangeException_ProvidedServiceNotFoundExceptionResult_Test()
    {
        var providedService = new ProvidedService() { Id = 1 };

        _providedServiceRepository.Setup(x => x.Update(It.IsAny<ProvidedService>())).ThrowsAsync(new ArgumentOutOfRangeException());
        var providedServiceService = new ProvidedServiceService(_providedServiceRepository.Object);

        var exception = await Assert.ThrowsAsync<EntityNotFoundException>(async () => await providedServiceService.UpdateProvidedService(providedService));

        Assert.Equal("providedService with id = 1 not found.", exception.Message);
    }
}
