using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.Image.Update.Events;

public class UpdateImageEventHandler : IRequestHandler<UpdateImageEvent,ActionResult>
{
  private readonly IFileManager _fileManager;
  private readonly IRepository<Entities.Player> _playerRepository;
  public UpdateImageEventHandler(IFileManager fileManager, IRepository<Entities.Player> playerRepository)
  {
    _fileManager = fileManager;
    _playerRepository = playerRepository;
  }
  public async Task<ActionResult> Handle(UpdateImageEvent request, CancellationToken cancellationToken)
  {
    var player = await _playerRepository.GetByIdAsync(request.PlayerId,cancellationToken);
    if (player is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));
    
    bool image = await UpdateImageAsync(request, player);
    if (!image)
    {
      return new OkObjectResult(new AdminResponse("Failed to upload image to server", ResponseStatus.Warning));
    }
    player.Pic = request.PlayerImage.FileName;
    await _playerRepository.UpdateAsync(player,cancellationToken);
    await _playerRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }

  private Task<bool> UpdateImageAsync(UpdateImageEvent request, Entities.Player player)
  {
    return _fileManager.UpdateFileAsync<Entities.Player>(request.PlayerImage, player.Pic!, request.PlayerImage.FileName,
      player.Id.ToString());
  }
}
