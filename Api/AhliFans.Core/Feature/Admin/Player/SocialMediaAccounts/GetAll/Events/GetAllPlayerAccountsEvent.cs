using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.SocialMediaAccounts.GetAll.Events;

public record GetAllPlayerAccountsEvent(int PlayerId,bool IsDeleted):IRequest<ActionResult>;
