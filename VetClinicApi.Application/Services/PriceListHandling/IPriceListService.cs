using VetClinicApi.Core.Entities;

namespace VetClinicApi.Application.Services.PriceListHandling
{
    public interface IPriceListService
    {
        Task<IEnumerable<PriceList>> GetAllPriceList();
        Task<PriceList> CreatePriceList(PriceList priceList);
        Task DeletePriceList(int id);
        Task<PriceList> UpdatePriceList(PriceList priceList);
    }
}
