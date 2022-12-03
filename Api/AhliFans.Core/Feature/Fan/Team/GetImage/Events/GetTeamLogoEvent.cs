using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Team.GetImage.Events;

public class GetTeamLogoEvent : IRequest<ActionResult>
{
  public GetTeamLogoEvent(int teamId)
  {
    TeamId = teamId;
  }

  public int TeamId { get; set; }
}
