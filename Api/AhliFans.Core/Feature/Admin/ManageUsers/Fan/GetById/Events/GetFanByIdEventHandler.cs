using AhliFans.Core.Feature.Admin.ManageUsers.Fan.GetById.DTO;
using AhliFans.Core.Feature.Admin.ManageUsers.Fan.GetById.Specifications;
using AhliFans.Core.Feature.Security.Token.JWTHelpers;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.ManageUsers.Fan.GetById.Events;

public class GetFanByIdEventHandler : IRequestHandler<GetFanByIdEvent,ActionResult>
{
  private readonly IRepository<Security.Entities.Fan> _fanRepository;
  public GetFanByIdEventHandler(IRepository<Security.Entities.Fan> fanRepository)
  {
    _fanRepository = fanRepository;
  }
  public async Task<ActionResult> Handle(GetFanByIdEvent request, CancellationToken cancellationToken)
  {
    var fan = await _fanRepository.GetBySpecAsync(new GetFanById(request.FanId),cancellationToken);
    if (fan is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    return new OkObjectResult(new FanDto(fan.FullName, fan.Email == fan.PhoneNumber+RootAdmin.TempEmail ? null:fan.Email,fan.PhoneNumber, fan.BirthDate, fan.Gender,
      fan.City?.Country.Name!, fan.City?.Name!));
  }
}
