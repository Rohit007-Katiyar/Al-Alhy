using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.DTO;

public class CustomHeader
{
  public int ModuleType { get; set; }
  public int SectionType { get; set; }
  public bool IsDelete { get; set; }
}

public class DynamicModules : CustomHeader, IRequest<ActionResult>
{
  public long Id { get; set; }
  public string Section { get; set; }
  public IFormFile Media { get; set; }
}

public class GetById : IRequest<ActionResult>
{
  public long Id { get; set; }

  public int? Type { get; set; }
}

public class GetAllDynamicModules : CustomHeader, IRequest<ActionResult>
{
  public string? SearchWord { get; set; }
  public int? Type { get; set; }
  public int PageIndex { get; set; } = 0;
  public int PageSize { get; set; } = 10;
}

public class GetDataByModuleType : IRequest<ActionResult>
{
    public int? Type { get; set; }
    public int ModuleType { get; set; }

    public int SectionType { get; set; }
}
public class GetAllGeneralPositionRequest : IRequest<ActionResult>
{
    public string Lang { get; set; }
}