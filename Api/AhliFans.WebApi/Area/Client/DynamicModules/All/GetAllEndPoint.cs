using System.Web;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.DTO;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.DynamicModules.All;

public class GetAllEndPoint : EndpointBaseAsync.WithRequest<GetAllDynamicModules>.WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  //[Authorize]
  [HttpGet(RoutesConfig.ClientGetAllDynamicModules)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<GetAllDynamicModules>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(GetAllDynamicModules))]
  [SwaggerOperation(
    Summary = "Dynamic Get All Category",
    Description = "Dynamic Get All Category",
    OperationId = "Admin.GetAllDynamicModules",
    Tags = new[] { "Dynamic Modules Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetAllDynamicModules request,
   CancellationToken cancellationToken = default)
  {
    var decodedWord = HttpUtility.UrlDecode(request.SearchWord);
    return await _mediator.Send(request, cancellationToken);
  }
}
