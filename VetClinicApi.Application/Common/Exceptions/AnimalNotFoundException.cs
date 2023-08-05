namespace VetClinicApi.Application.Common.Exceptions;

public class AnimalNotFoundException : EntityNotFoundException
{
    public AnimalNotFoundException(int id) : base(id, "Animal")
    {
    }
}

