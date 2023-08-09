using Moq;

using VetClinicApi.Application.Common.Exceptions;
using VetClinicApi.Application.Services.PriceListHandling;
using VetClinicApi.Core.Entities;
using VetClinicApi.Database.Repositories;

using Xunit;

namespace VetClinicApi.Application.Tests.Services.PriceListHandling;

public class PriceListService_Test
{
    private readonly Mock<IPriceListRepository> _priceListRepository = new();

    [Fact]
    public async Task Create_PriceListIsNull_Test()
    {
        var priceListService = new PriceListService(_priceListRepository.Object);

        await Assert.ThrowsAsync<ArgumentNullException>(async () => await priceListService.CreatePriceList(null));
    }

    [Fact]
    public async Task Delete_PriceListNotFound_Test()
    {
        _priceListRepository.Setup(x => x.Delete(It.IsAny<int>())).ThrowsAsync(new ArgumentOutOfRangeException());
        var priceListService = new PriceListService(_priceListRepository.Object);

        await Assert.ThrowsAsync<EntityNotFoundException>(async () => await priceListService.DeletePriceList(1));
    }

    [Fact]
    public async Task Update_PriceListIsNull_Test()
    {
        var priceListService = new PriceListService(_priceListRepository.Object);

        await Assert.ThrowsAsync<ArgumentNullException>(async () => await priceListService.UpdatePriceList(null));
    }

    [Fact]
    public async Task Update_RepositoryUpdateThrowsArgumentOutOfRangeException_PriceListNotFoundExceptionResult_Test()
    {
        var priceList = new PriceList() { Id = 1 };

        _priceListRepository.Setup(x => x.Update(It.IsAny<PriceList>())).ThrowsAsync(new ArgumentOutOfRangeException());
        var priceListService = new PriceListService(_priceListRepository.Object);

        var exception = await Assert.ThrowsAsync<EntityNotFoundException>(async () => await priceListService.UpdatePriceList(priceList));

        Assert.Equal("priceList with id = 1 not found.", exception.Message);
    }
}
