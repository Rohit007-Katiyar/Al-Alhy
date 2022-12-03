using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Admin.Preferences.Get.DTO;
using AhliFans.Core.Feature.Admin.Preferences.Get.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Preferences.Get.Events;

public class GetEventHandler : IRequestHandler<GetPreferenceEvent,ActionResult>
{
  private readonly IRepository<FanPreference> _fanPreferenceRepository;
  public GetEventHandler(IRepository<FanPreference> fanPreferenceRepository)
  {
    _fanPreferenceRepository = fanPreferenceRepository;
  }
  public async Task<ActionResult> Handle(GetPreferenceEvent request, CancellationToken cancellationToken)
  {
    var fanPreference = await _fanPreferenceRepository.GetBySpecAsync(new GetPreferenceByUser(request.FanId),cancellationToken);
    if (fanPreference is null) return new BadRequestObjectResult(new AdminResponse("No Data Yet", ResponseStatus.Error));
    
    var fanPreferenceDto = new PreferenceDto(request.Lang == Languages.En?fanPreference.Player?.Name!: fanPreference.Player?.NameAr!,
      request.Lang == Languages.En ? fanPreference.LocalTrophy?.Name!:fanPreference.LocalTrophy?.NameAr!, 
      request.Lang == Languages.En ?fanPreference.AfricanTrophy?.Name!:fanPreference.AfricanTrophy?.NameAr!, fanPreference.FavoriteCoachAllTime!, fanPreference.FavoriteMoment!);
   
    return new OkObjectResult(fanPreferenceDto);
  }
}
