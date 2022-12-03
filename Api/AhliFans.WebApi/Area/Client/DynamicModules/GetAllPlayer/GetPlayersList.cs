using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Fan.SquadList.Get.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.DynamicModules.GetAllPlayer;

public class GetPlayersList : Controller
{
    private readonly IMediator _mediator;

    public GetPlayersList(IMediator mediator)
    {
        _mediator = mediator;
    }
}

    //[Authorize]
    //[HttpGet($"{DTO.RoutesConfig.ClientGetSquadList}")]
    //[ApiExplorerSettings(GroupName = nameof(Areas.Client))]
    //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
    //[SwaggerOperation(
    //  Summary = "Client Get General Position",
    //  Description = "Client Get General Position",
    //  OperationId = "Client.GetGeneralPosition",
    //  Tags = new[] { "Player Position Endpoints" })
    //]
    //public async Task<ActionResult> Get([FromQuery] GetSquadListRequest request, CancellationToken cancellationToken = default)
    //{
    //    return await _mediator.Send(request, cancellationToken);
    //}
//}
