using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.GetAll.Events;

public record AdminsEvent
  (int PageIndex, int PageSize, bool IsBlocked, string Name, string Email, string PhoneNumber) : IRequest<ActionResult>;
