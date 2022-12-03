using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.Create.Events;
public record CreateEvent(string FullName, string? Email, string Password, string ConfirmPassword, string PhoneNumber):IRequest<ActionResult>;
