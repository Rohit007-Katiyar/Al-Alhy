using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Enums;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.SocialMediaAccounts.Add.Events;

public class AddPlayerAccountEventHandler : IRequestHandler<AddPlayerAccountsEvent,ActionResult>
{
  private readonly IRepository<SocialMediaAccount> _accountRepository;

  public AddPlayerAccountEventHandler(IRepository<SocialMediaAccount> accountRepository)
  {
    _accountRepository = accountRepository;
  }
  public async Task<ActionResult> Handle(AddPlayerAccountsEvent request, CancellationToken cancellationToken)
  {
    await _accountRepository.AddAsync(new SocialMediaAccount()
    {
      PlayerId = request.PlayerId, SocialMediaAccount1 = request.FaceBookAccount, Date = DateTime.Now,Type = SocialMediaTypes.FaceBook
    },cancellationToken); 
    await _accountRepository.AddAsync(new SocialMediaAccount()
    {
      PlayerId = request.PlayerId, SocialMediaAccount1 = request.InstaAccount, Date = DateTime.Now,Type = SocialMediaTypes.Instagram
    },cancellationToken);
    await _accountRepository.AddAsync(new SocialMediaAccount()
    {
      PlayerId = request.PlayerId, SocialMediaAccount1 = request.TwitterAccount, Date = DateTime.Now,Type = SocialMediaTypes.Twitter
    },cancellationToken);
    await _accountRepository.SaveChangesAsync(cancellationToken);
    
    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }
}
