using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Honor.GetById.Events;

public record GetHonorByIdEvent(int HonorId,string Lang):IRequest<ActionResult>;
