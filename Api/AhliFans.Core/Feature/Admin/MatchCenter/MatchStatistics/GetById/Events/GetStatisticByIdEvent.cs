using AhliFans.Core.Feature.Localization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics;

public record GetStatisticByIdEvent(int Id, string Language = Languages.Ar) : IRequest<ActionResult>;