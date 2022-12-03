using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.Image.Get.Events;
public class GetTrophyImageEventHandler : IRequestHandler<GetPlayerImageEvent,ActionResult>
{
  private readonly IRepository<Entities.Player> _playerRepository;
  private readonly IFileManager _fileManager;
  public GetTrophyImageEventHandler(IRepository<Entities.Player> playerRepository, IFileManager fileManager)
  {
    _playerRepository = playerRepository;
    _fileManager = fileManager;
  }
  public async Task<ActionResult> Handle(GetPlayerImageEvent request, CancellationToken cancellationToken)
  {
    var player = await _playerRepository.GetByIdAsync(request.PlayerId,cancellationToken);
    if (player is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    var playerImage = string.IsNullOrEmpty(player.Pic) ?
      await _fileManager.FileProxy<Entities.Player>("defaultPlayer.png", "") :
      await _fileManager.FileProxy<Entities.Player>(player.Pic, player.Id.ToString());

    try
    {
      var streamReader = await playerImage.ReadStreamAsync();
      return new FileStreamResult(streamReader, _fileManager.GetContentType(string.IsNullOrEmpty(player.Pic) ? "defaultPlayer.png" : player.Pic));
    }
    catch
    {
      return new BadRequestObjectResult(new AdminResponse("Can't get the image", ResponseStatus.Error));
    }
  }
}
