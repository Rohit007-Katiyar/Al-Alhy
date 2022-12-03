using AhliFans.DTO;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Ocsp;

namespace AhliFans.Core.Feature.Admin.DynamicModules.Add;
public class AddLegendsBirthdaysEventHandler : IRequestHandler<DTO.DynamicModules, ActionResult>
{
    private readonly IRepository<Entities.DynamicModules> _DynamicModulesRepo;
    private readonly IMapper _mapper;
    private readonly IFileManager _fileManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AddLegendsBirthdaysEventHandler(IRepository<Entities.DynamicModules> DynamicModulesRepo,
      IMapper mapper, IHttpContextAccessor httpContextAccessor, IFileManager fileManager)
    {
        _DynamicModulesRepo = DynamicModulesRepo;
        _httpContextAccessor = httpContextAccessor;
        _fileManager = fileManager;
        _mapper = mapper;
    }

    public async Task<ActionResult> Handle(DTO.DynamicModules request, CancellationToken cancellationToken)
    {
        int? applicationType = 0;
        string fileName = "";
        if (request is null)
        {
            return new BadRequestObjectResult(new AdminResponse("Invalid request found.", ResponseStatus.Error));
        }
        var dynamicModules = new Entities.DynamicModules();
        if (request.Id == 0)
        {
            var _section = ValidateRequest.ValidateRequestPayload(request, applicationType);
            if (_section is null)
            {
                return new BadRequestObjectResult(new AdminResponse("Request has been decline to save.", ResponseStatus.Error));
            }

            if (request.Media != null)
            {
                fileName = Guid.NewGuid().ToString() + "." + request.Media.ContentType.Split("/")[1];
                _section.Media = fileName;
            }

            dynamicModules = new Entities.DynamicModules
            {
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsDeleted = false,
                ModuleType = (byte)request.ModuleType,
                SectionType = (byte)request.SectionType,
                Section = JsonConvert.SerializeObject(_section)
            };
        }
        else
        {
            dynamicModules = await _DynamicModulesRepo.GetByIdAsync(request.Id, cancellationToken);
            if (dynamicModules is null)
            {
                return new BadRequestObjectResult(new AdminResponse("Request has been not valid.", ResponseStatus.Error));
            }
            if (!string.IsNullOrEmpty(request.Section))
            {
                var _section = string.IsNullOrEmpty(request.Section) ? null : ValidateRequest.ValidateRequestPayload(request, applicationType);
                if (_section is null)
                {
                    return new BadRequestObjectResult(new AdminResponse("Request has been decline to save.", ResponseStatus.Error));
                }
                if (request.Media != null)
                {
                    _section.Media = Enum.GetName(typeof(Sections), request.SectionType) + "/" + fileName;
                }
                dynamicModules.Section = string.IsNullOrEmpty(request.Section) ? dynamicModules.Section : JsonConvert.SerializeObject(_section);
            }

            dynamicModules.IsDeleted = request.IsDelete;
            dynamicModules.UpdatedDate = DateTime.Now;
        }

        await (request.Id != 0
          ? _DynamicModulesRepo.UpdateAsync(dynamicModules, cancellationToken)
          : _DynamicModulesRepo.AddAsync(dynamicModules, cancellationToken));
        await _DynamicModulesRepo.SaveChangesAsync(cancellationToken);
        if (request.Media != null)
        {
            await UploadMedia(request.Media, request, fileName);
        }
        return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
    }

    private async Task UploadMedia(IFormFile formFile, DTO.DynamicModules request, string fileName)
    {
        bool saveProfile = await _fileManager.SaveFileAsync<dynamic>(formFile,
         fileName, Enum.GetName(typeof(Sections), request.SectionType));
    }
}
