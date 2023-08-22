namespace VetClinicApi.Application.Infrastructure.DateTimeProvider;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}
