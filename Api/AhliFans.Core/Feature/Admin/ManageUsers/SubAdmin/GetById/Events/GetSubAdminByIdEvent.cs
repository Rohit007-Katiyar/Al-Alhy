using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.GetById.Events;

public record GetSubAdminByIdEvent(Guid AdminId) : IRequest<ActionResult>;
