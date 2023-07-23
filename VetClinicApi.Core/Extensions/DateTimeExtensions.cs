namespace VetClinicApi.Core.Extensions;

public static class DateTimeExtensions
{
    public static DateTime ToUtcKind(this DateTime dateTime) =>
        dateTime.ToKind(DateTimeKind.Utc);

    public static DateTime? ToUtcKind(this DateTime? dateTime) =>
        dateTime.ToKind(DateTimeKind.Utc);

    public static DateTime ToUnspecifiedKind(this DateTime dateTime) =>
        dateTime.ToKind(DateTimeKind.Unspecified);

    public static DateTime? ToUnspecifiedKind(this DateTime? dateTime) =>
        dateTime.ToKind(DateTimeKind.Unspecified);

    public static DateTime ToKind(this DateTime dateTime, DateTimeKind kind) =>
        DateTime.SpecifyKind(dateTime, kind);

    public static DateTime? ToKind(this DateTime? dateTime, DateTimeKind kind) =>
        dateTime?.ToKind(kind);
}
