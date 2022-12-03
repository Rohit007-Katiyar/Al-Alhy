using System.Security.Claims;
using AhliFans.Core.Feature.Admin.Category.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Category.Add;

public class AddCategoryEndPoint : EndpointBaseAsync.WithRequest<AddCategoryRequest>.WithActionResult
{
  private readonly IMediator _mediator;

  public AddCategoryEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(AddCategoryRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(Summary = "Admin Add Category", Description = "Admin Add Category", OperationId = "Admin.AddCategory", Tags = new[] { "Category Endpoints" })]
  public override async Task<ActionResult> HandleAsync([FromForm] AddCategoryRequest request, CancellationToken cancellationToken = default)
  {
    return await _mediator.Send(new AddCategoryEvent(
      request.Name,
      request.NameAr,
      request.photo,
      request.video,
      request.otd,
      request.Description,
      request.DescriptionAr,
      User.FindFirstValue("User Id")),
      cancellationToken);
  }
}
