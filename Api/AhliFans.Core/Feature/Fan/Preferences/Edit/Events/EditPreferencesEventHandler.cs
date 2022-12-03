using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Fan.Preferences.Get.Specifications;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Preferences.Edit.Events;

public class EditPreferencesEventHandler : IRequestHandler<EditPreferencesEvent,ActionResult>
{
  private readonly IRepository<FanPreference> _preferenceRepository;
  private readonly string _userId;
  public EditPreferencesEventHandler(IRepository<FanPreference> preferenceRepository, IHttpContextAccessor context)
  {
    _preferenceRepository = preferenceRepository;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;
  }
  public async Task<ActionResult> Handle(EditPreferencesEvent request, CancellationToken cancellationToken)
  {
    var fanPreferences = await _preferenceRepository.GetBySpecAsync(new GetPreferenceByUser(Guid.Parse(_userId)),cancellationToken);
    if (fanPreferences == null) return new OkObjectResult(new FanResponse("No Data Yet",ResponseStatus.Error));

    MapPreference(request, ref fanPreferences);
    await _preferenceRepository.UpdateAsync(fanPreferences,cancellationToken);
    await _preferenceRepository.SaveChangesAsync(cancellationToken);
    
    return new OkObjectResult(new FanResponse("Operation done successfully", ResponseStatus.Success));
  }
  private static void MapPreference(EditPreferencesEvent request, ref FanPreference fanPreferences)
  {
    fanPreferences.PlayerId = request.PlayerId ?? fanPreferences.PlayerId;
    fanPreferences.LocalTrophyId = request.LocalTrophyId ?? fanPreferences.LocalTrophyId;
    fanPreferences.FavoritePlayerAllTime = request.FavoritePlayerAllTime ?? fanPreferences.FavoritePlayerAllTime;
    fanPreferences.FavoriteCoachAllTime = request.FavoriteCoachAllTime ?? fanPreferences.FavoriteCoachAllTime;
    fanPreferences.AfricanTrophyId = request.AfricanTrophyId ?? fanPreferences.AfricanTrophyId;
    fanPreferences.MatchId = request.MatchId ?? fanPreferences.MatchId;
    fanPreferences.FavoriteMoment = request.FavoriteMoment ?? fanPreferences.FavoriteMoment;
  }
}
