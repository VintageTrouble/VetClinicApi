namespace VetClinicApi.Application.Infrastructure.DateTimeProvider;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
