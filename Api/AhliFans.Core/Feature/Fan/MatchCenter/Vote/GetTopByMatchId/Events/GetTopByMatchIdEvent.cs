using AhliFans.Core.Feature.Localization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.MatchCenter.Vote;

public record GetTopByMatchIdEvent(int MatchId, int Top, string Language = Languages.Ar) : IRequest<ActionResult>;