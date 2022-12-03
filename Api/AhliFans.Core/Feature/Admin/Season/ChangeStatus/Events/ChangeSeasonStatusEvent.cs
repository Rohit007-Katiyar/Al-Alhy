using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Season.ChangeStatus.Events;
public record ChangeSeasonStatusEvent(int SeasonId) :IRequest<ActionResult>;
