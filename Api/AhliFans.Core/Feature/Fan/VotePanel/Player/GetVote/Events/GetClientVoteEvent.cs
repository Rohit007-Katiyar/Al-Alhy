using AhliFans.Core.Feature.Localization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.VotePanel.Player;

public record GetClientVoteEvent(string Language = Languages.Ar) : IRequest<ActionResult>;
