using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Fan.Preferences.Get.DTO;
using AhliFans.Core.Feature.Fan.Preferences.Get.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Preferences.Get.Events;

public class GetEventHandler : IRequestHandler<GetPreferenceEvent, ActionResult>
{
  private readonly IRepository<FanPreference> _fanPreferenceRepository;
  private readonly string _userId;
  public GetEventHandler(IRepository<FanPreference> fanPreferenceRepository, IHttpContextAccessor context)
  {
    _fanPreferenceRepository = fanPreferenceRepository;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;
  }
  public async Task<ActionResult> Handle(GetPreferenceEvent request, CancellationToken cancellationToken)
  {
    var fanPreference = await _fanPreferenceRepository.GetBySpecAsync(new GetPreferenceByUser(Guid.Parse(_userId)), cancellationToken);
    if (fanPreference is null) return new NotFoundObjectResult(new FanResponse("No Data Yet", ResponseStatus.Error));

    var isEnglish = request.Lang == Languages.En;
    var favMatch = isEnglish
      ? fanPreference.Match?.OpponentTeam.Name ?? string.Empty
      : fanPreference.Match?.OpponentTeam.NameAr ?? string.Empty;
    if (fanPreference.Match?.OpponentTeam != null)
    {
      var extra = isEnglish ? " Vs Al-Ahly" : "ضد الاهلي ";
      favMatch = favMatch.Concat(extra).ToString();
    }
    var fanPreferenceDto = new PreferenceDto(new PlayerDto(fanPreference.Player?.Id ?? 0, isEnglish ? fanPreference.Player?.Name ?? string.Empty : fanPreference.Player?.NameAr ?? string.Empty),
      new FavMatchDto(fanPreference.Match?.Id ?? 0, favMatch ?? string.Empty), new LocalTrophyDto(fanPreference.LocalTrophy?.Id ?? 0, isEnglish ? fanPreference.LocalTrophy?.Name ?? string.Empty : fanPreference.LocalTrophy?.NameAr ?? string.Empty),
      new AfricanTrophyDto(fanPreference.AfricanTrophy?.Id ?? 0, isEnglish ? fanPreference.AfricanTrophy?.Name ?? string.Empty : fanPreference.AfricanTrophy?.NameAr ?? string.Empty), fanPreference.FavoritePlayerAllTime ?? string.Empty,
      fanPreference.FavoriteMoment ?? string.Empty, fanPreference.FavoriteCoachAllTime ?? string.Empty);
    return new OkObjectResult(fanPreferenceDto);
  }
}
