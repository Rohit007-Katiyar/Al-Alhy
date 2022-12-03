using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Referee.GetById.Event;

public record GetRefereeByIdEvent(int RefereeId,string Lang) : IRequest<ActionResult>;
