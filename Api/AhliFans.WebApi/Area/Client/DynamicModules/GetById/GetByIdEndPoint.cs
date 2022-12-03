using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.DynamicModules.GetById;

public class GetByIdEndPoint : Controller
{
  private readonly IMediator _mediator;
  public GetByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  //[Authorize]
  [HttpGet($"{DTO.RoutesConfig.ClientDynamicModules}")]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(Summary = "Get Event Data by ID", Description = "Get Event Data by ID",
    OperationId = "Admin.GetDynamicModules", Tags = new[] { "Dynamic Modules Endpoints" })]
  public async Task<ActionResult> Get([FromQuery]DTO.GetById model, CancellationToken cancellationToken = default)
  {
    model.Type = (int)Areas.Client;
    return await _mediator.Send(model, cancellationToken);
  }
}
