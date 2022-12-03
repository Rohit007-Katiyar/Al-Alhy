using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Cards;

public record ToggleMatchCardEvent(int CardId) : IRequest<ActionResult>;