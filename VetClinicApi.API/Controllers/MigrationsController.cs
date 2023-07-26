using FluentMigrator.Runner;

using Microsoft.AspNetCore.Mvc;
using System.Net;

using VetClinicApi.API.Controllers.Abstract;

namespace VetClinicApi.API.Controllers;


[Route("api/[controller]")]
public class MigrationsController : BaseController
{
    private readonly IMigrationRunner _migrationRunner;
    private readonly IConfiguration _configuration;

    public MigrationsController(IMigrationRunner migrationRunner, IConfiguration configuration)
    {
        _migrationRunner = migrationRunner;
        _configuration = configuration;
    }

    [HttpPatch("up")]
    public IActionResult Up(int targetVersion)
    {
        return HandleMigration(() => {
            var maxDatabaseVersion = int.Parse(_configuration["DatabaseVersion"] ?? "");

            if (targetVersion < 0)
                return BadRequest("Value should be upper or equals 0.");

            if (targetVersion > maxDatabaseVersion)
                return BadRequest($"Value should be less or equals {maxDatabaseVersion}.");

            _migrationRunner.MigrateUp(targetVersion);

            return Ok();
        });
    }

    [HttpPatch("down")]
    public IActionResult Down(int targetVersion)
    {
        return HandleMigration(() =>
        {
            var maxDatabaseVersion = int.Parse(_configuration["DatabaseVersion"] ?? "");

            if (targetVersion < 0)
                return BadRequest("Value should be upper or equals 0.");

            if (targetVersion > maxDatabaseVersion)
                return BadRequest($"Value should be less or equals {maxDatabaseVersion}.");

            _migrationRunner.MigrateDown(targetVersion);

            return Ok();
        });
    }

    [HttpPatch("drop")]
    public IActionResult Drop()
    {
        return HandleMigration(() =>
        {
            _migrationRunner.MigrateDown(0);

            return Ok();
        });
    }

    [HttpPatch("max")]
    public IActionResult Max()
    {
        return HandleMigration(() =>
        {
            var maxDatabaseVersion = int.Parse(_configuration["DatabaseVersion"] ?? "");

            _migrationRunner.MigrateUp(maxDatabaseVersion);

            return Ok();
        });
    }

    private IActionResult HandleMigration(Func<IActionResult> action)
    {
        try
        {
            return action();
        }
        catch (ArgumentNullException)
        {
            return StatusCode(
                (int)HttpStatusCode.InternalServerError,
                "Enviroment variable 'DatabaseVersion' is not declared.");
        }
        catch (FormatException)
        {
            return StatusCode(
                (int)HttpStatusCode.InternalServerError,
                "Enviroment variable 'DatabaseVersion' has wrong value.");
        }
    }
}
