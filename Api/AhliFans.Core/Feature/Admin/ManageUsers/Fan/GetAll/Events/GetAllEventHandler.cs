using AhliFans.Core.Feature.Admin.ManageUsers.Fan.GetAll.Dto;
using AhliFans.Core.Feature.Admin.ManageUsers.Fan.GetAll.Specifications;
using AhliFans.Core.Feature.Security.Token.JWTHelpers;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AhliFans.Core.Feature.Admin.ManageUsers.Fan.GetAll.Events;
public class GetAllEventHandler : IRequestHandler<GetAllEvent,ActionResult>
{
  private readonly ILogger<GetAllEventHandler> _logger;
  private readonly IRepository<Security.Entities.Fan> _fanRepository;
  public GetAllEventHandler(ILogger<GetAllEventHandler> logger, IRepository<Security.Entities.Fan> fanRepository)
  {
    _logger = logger;
    _fanRepository = fanRepository;
  }
  public async Task<ActionResult> Handle(GetAllEvent request, CancellationToken cancellationToken)
  {
    var fans = await _fanRepository.ListAsync(
      new GetFanByName(request.PageIndex, request.PageSize, request.SearchWord, request.IsBlocked), cancellationToken);
    if (fans.Count == 0) return new BadRequestObjectResult(new AdminResponse("No fans yet",ResponseStatus.Error));
    _logger.LogInformation("Admin get fans");
    return new OkObjectResult(fans.Select(f => new FanInfoDto(f.Id, f.FullName, f.Email == f.PhoneNumber+RootAdmin.TempEmail?"":f.Email, f.PhoneNumber,
      f.Gender, f.BirthDate.ToString(),f.IsBlocked)));
  }
}
