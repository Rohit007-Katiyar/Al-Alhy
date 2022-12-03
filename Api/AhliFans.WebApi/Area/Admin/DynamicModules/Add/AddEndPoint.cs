using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.LegendBirthdays.Add;

public class AddEndPoint : Controller
{
  private readonly IMediator _mediator;
  public AddEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  //[Authorize]
  [HttpPost(DTO.RoutesConfig.DynamicModules)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(Summary = "Admin Add Dynamic Modules", Description = "Admin Add On this day and calendar management", 
    OperationId = "Admin.AddDynamicModules", Tags = new[] { "Dynamic Modules Endpoints" })]
  public async Task<ActionResult> AddDynamicModules([FromForm] DTO.DynamicModules request, CancellationToken cancellationToken = default)
  {
    return await _mediator.Send(request, cancellationToken);
  }

  //[Authorize]
  [HttpPut(DTO.RoutesConfig.DynamicModules)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(Summary = "Admin Update Dynamic Modules", Description = "Admin Update On this day and Calendar management",
    OperationId = "Admin.UpdateDynamicModules", Tags = new[] { "Dynamic Modules Endpoints" })]
  public async Task<ActionResult> UpdateDynamicModules([FromForm] DTO.DynamicModules request, CancellationToken cancellationToken = default)
  {
    request.IsDelete = request.IsDelete ? true : false;
    return await _mediator.Send(request, cancellationToken);
  }
}
