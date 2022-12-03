using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Season.GetById.Event;

public record GetSeasonByIdEvent(int SeasonId, string Lang) : IRequest<ActionResult>;
