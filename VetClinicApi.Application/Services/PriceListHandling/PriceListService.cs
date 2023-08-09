using VetClinicApi.Application.Common.Exceptions;
using VetClinicApi.Core.Entities;
using VetClinicApi.Database.Repositories;

namespace VetClinicApi.Application.Services.PriceListHandling
{
    public class PriceListService : IPriceListService
    {
        private readonly IPriceListRepository _priceListRepository;

        public PriceListService(IPriceListRepository priceListRepository)
        {
            _priceListRepository = priceListRepository;
        }

        public async Task<PriceList> CreatePriceList(PriceList priceList)
        {
            if (priceList == null)
                throw new ArgumentNullException(nameof(priceList), "PriceList can't be null.");

            return await _priceListRepository.Add(priceList);
        }

        public async Task DeletePriceList(int id)
        {
            try
            {
                await _priceListRepository.Delete(id);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new EntityNotFoundException(id, "priceList");
            }
        }

        public async Task<IEnumerable<PriceList>> GetAllPriceList()
        {
            return await _priceListRepository.GetAll();
        }

        public async Task<PriceList> UpdatePriceList(PriceList priceList)
        {
            if (priceList == null)
                throw new ArgumentNullException(nameof(priceList), "PriceList can't be null.");

            try
            {
                return await _priceListRepository.Update(priceList);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new EntityNotFoundException(priceList.Id, "priceList");
            }

        }
    }
}
