using AhliFans.Core.Feature.Admin.Category.GetById.Events;
using AhliFans.Core.Feature.Admin.Category.GetById.DTO;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using AhliFans.WebApi.Area.Admin.Jersey;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Category.GetById;

public class GetCategoryByIdEndPoint : EndpointBaseAsync
  .WithRequest<GetCategoryByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetCategoryByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetCategoryByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryDetailsDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Category By Id",
    Description = "Admin Get Category By Id",
    OperationId = "Admin.GetCategory",
    Tags = new[] { "Category Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetCategoryByIdRequest request,
    CancellationToken cancellationToken = default)
  {
    return await _mediator.Send(new GetCategoryByIdEvent(request.CategoryId, request.Lang),
      cancellationToken);
  }
}
