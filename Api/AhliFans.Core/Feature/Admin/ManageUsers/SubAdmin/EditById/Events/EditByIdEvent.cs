using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.EditById.Events;

public record EditByIdEvent(Guid AdminId, string Name, string Email, string PhoneNumber) : IRequest<ActionResult>;
