using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Stadium.GetById.Events;

public record GetStadiumByIdEvent(int StadiumId,string Lang) :IRequest<ActionResult>;
