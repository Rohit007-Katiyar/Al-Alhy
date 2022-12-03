using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Jersey.Add.Events;

public class AddJerseyEventHandler : IRequestHandler<AddJerseyEvent, ActionResult>
{
  private readonly IRepository<Entities.Jersey> _jerseyRepository;
  private readonly IFileManager _fileManager;
  private readonly IMapper _mapper;
  
  public AddJerseyEventHandler(IRepository<Entities.Jersey> jerseyRepository, IFileManager fileManager, IMapper mapper)
  {
    _jerseyRepository = jerseyRepository;
    _fileManager = fileManager;
    _mapper = mapper;
  }

  public async Task<ActionResult> Handle(AddJerseyEvent request, CancellationToken cancellationToken)
  {
    var jersey = _mapper.Map<Entities.Jersey>(request);

    await _jerseyRepository.AddAsync(jersey, cancellationToken);
    await _jerseyRepository.SaveChangesAsync(cancellationToken);

    bool saveProfile = await SavePic(request.Picture, jersey.Id);
    if (!saveProfile) return new OkObjectResult(new AdminResponse("New jersey has been added successfully,but saving picture failed.", ResponseStatus.Warning));

    return new OkObjectResult(new AdminResponse("New jersey has been added successfully", ResponseStatus.Success));
  }

  private async Task<bool> SavePic(IFormFile? request, int jerseyId)
  {
    if (request is null)
      return true;

    bool saveProfile = await _fileManager.SaveFileAsync<Entities.Jersey>
      (request, request.FileName, jerseyId.ToString());
    
    return saveProfile;
  }
}
