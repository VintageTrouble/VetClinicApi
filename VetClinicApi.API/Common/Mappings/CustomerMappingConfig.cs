using Mapster;

using VetClinicApi.Contracts.CustomerContracts;
using VetClinicApi.Core.Entities;

namespace VetClinicApi.API.Common.Mappings
{
    public class CustomerMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Customer, CustomerResponse>();
            config.NewConfig<CreateCustomerRequest, Customer>();
            config.NewConfig<UpdateCustomerRequest, Customer>();
        }
    }
}
