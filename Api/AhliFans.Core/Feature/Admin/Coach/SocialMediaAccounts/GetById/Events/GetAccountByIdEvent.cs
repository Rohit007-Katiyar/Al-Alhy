using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.SocialMediaAccounts.GetById.Events;

public record GetAccountByIdEvent(int AccountId) : IRequest<ActionResult>;
