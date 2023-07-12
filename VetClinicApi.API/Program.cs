using VetClinicApi.API;
using VetClinicApi.API.Swagger;

using VetClinicApi.Application.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
var env = builder.Environment;
{
    var database = Environment.GetEnvironmentVariable("POSTGRES_DB");
    var user = Environment.GetEnvironmentVariable("POSTGRES_USER");
    var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
    var address = Environment.GetEnvironmentVariable("POSTGRES_ADDRESS");
    var connectionString = $"Server={address};Port=5432;Database={database};UserId={user};Password={password}";

    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddDatabase(connectionString)
        .AddMigrations(connectionString);
}


var app = builder.Build();
{
    app.UseAuthentication();
    app.UseAuthorization();

    app.ConfigueSwagger();

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}