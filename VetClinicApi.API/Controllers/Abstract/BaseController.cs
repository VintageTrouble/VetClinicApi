using Microsoft.AspNetCore.Mvc;

using System.Net;

namespace VetClinicApi.API.Controllers.Abstract;

[ApiController]
[Produces("application/json")]
[ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
[ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
public class BaseController : ControllerBase
{
}
