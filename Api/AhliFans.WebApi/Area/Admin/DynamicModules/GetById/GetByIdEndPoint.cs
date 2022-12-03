using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.DynamicModules.GetById;

public class GetByIdEndPoint : Controller
{
  private readonly IMediator _mediator;
  public GetByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  //[Authorize]
  [HttpGet($"{DTO.RoutesConfig.DynamicModules}")]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(Summary = "Get Dynamic Modules", Description = "Get On this day and calendar management",
    OperationId = "Admin.GetDynamicModules", Tags = new[] { "Dynamic Modules Endpoints" })]
  public async Task<ActionResult> Get([FromQuery]DTO.GetById model, CancellationToken cancellationToken = default)
  {
    return await _mediator.Send(model, cancellationToken);
  }
}
