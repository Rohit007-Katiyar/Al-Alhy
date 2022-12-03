using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.MatchCenter.Coach.GetAll.Events;

public record GetAllCurrentCoachesEvent(string Lang):IRequest<ActionResult>;
