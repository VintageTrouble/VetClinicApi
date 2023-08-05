namespace VetClinicApi.Application.Common.Exceptions;

public class CustomerNotFoundException : EntityNotFoundException
{
    public CustomerNotFoundException(int id) : base(id, "Customer")
    {
    }
}
