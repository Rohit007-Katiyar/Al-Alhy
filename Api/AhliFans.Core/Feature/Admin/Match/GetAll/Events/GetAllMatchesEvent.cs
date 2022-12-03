using AhliFans.Core.Feature.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Match.GetAll.Events;

public record GetAllMatchesEvent(int PageIndex, int PageSize, int LeagueId, int LeagueDataId, string Lang,bool IsDeleted, 
  bool? IsAvailable, MatchTypes MatchTypes) :IRequest<ActionResult>;
