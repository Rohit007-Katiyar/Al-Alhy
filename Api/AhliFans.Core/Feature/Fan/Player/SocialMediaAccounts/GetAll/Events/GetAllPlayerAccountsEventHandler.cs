using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Fan.Player.SocialMediaAccounts.GetAll.DTO;
using AhliFans.Core.Feature.Fan.Player.SocialMediaAccounts.GetAll.Specification;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Player.SocialMediaAccounts.GetAll.Events;

public class GetAllPlayerAccountsEventHandler : IRequestHandler<GetAllPlayerAccountsEvent,ActionResult>
{
  private readonly IRepository<SocialMediaAccount> _accountRepository;

  public GetAllPlayerAccountsEventHandler(IRepository<SocialMediaAccount> accountRepository)
  {
    _accountRepository = accountRepository;
  }
  public async Task<ActionResult> Handle(GetAllPlayerAccountsEvent request, CancellationToken cancellationToken)
  {
    var accounts = await _accountRepository.ListAsync(new GetAccountsOfPlayer(request.PlayerId), cancellationToken);
    if (accounts.Count == 0) return new OkObjectResult(Enumerable.Empty<PlayerAccountsDto>());
    return new OkObjectResult(accounts.Select(a => new PlayerAccountsDto(a.Id, a.SocialMediaAccount1)));
  }
}
