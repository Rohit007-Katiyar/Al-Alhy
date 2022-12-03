using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.ChangeStatus.Events;
public record ChangeAdminStatusEvent(Guid AdminId):IRequest<ActionResult>;
