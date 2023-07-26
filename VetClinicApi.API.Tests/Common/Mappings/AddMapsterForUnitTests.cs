using Mapster;

using MapsterMapper;

namespace VetClinicApi.API.Tests.Common.Mappings;

internal static class AddMapsterForUnitTests
{
    public static Mapper GetMapper()
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(IAssemblyMarker).Assembly);

        return new Mapper(config);
    }
}
