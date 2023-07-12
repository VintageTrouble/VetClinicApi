using FluentMigrator.Runner;

using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace VetClinicApi.API.Controllers;

[ApiController]
[Produces("application/json")]
[ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
[ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
[Route("api/migrations")]
public class MigrationsController : ControllerBase
{
    private readonly IMigrationRunner _migrationRunner;
    private readonly IConfiguration _configuration;

    public MigrationsController(IMigrationRunner migrationRunner, IConfiguration configuration)
    {
        _migrationRunner = migrationRunner;
        _configuration = configuration;
    }

    [HttpGet("up")]
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

    [HttpGet("down")]
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

    [HttpGet("drop")]
    public IActionResult Drop()
    {
        return HandleMigration(() =>
        {
            _migrationRunner.MigrateDown(0);

            return Ok();
        });
    }

    [HttpGet("max")]
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
