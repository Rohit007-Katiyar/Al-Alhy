using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Match;

public record AddMatchMediaVideoEvent(List<string> Videos,int MatchId):IRequest<ActionResult>;
