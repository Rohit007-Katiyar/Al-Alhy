using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhliFans.Core.Feature.Admin.Category.Add.Events;
using AhliFans.Core.Feature.Admin.Season.Add.Events;

namespace AhliFans.Core.Feature.Admin.Category.Add.Mapper;
public class NormalVideoMapper  : AutoMapper.Profile
{
  public NormalVideoMapper()
  {
    CreateMap<AddCategoryEvent, Entities.Category>()
      .ForMember(dest => dest.CreatedOn,
        src => src.MapFrom(src => DateTime.Now))
       .ForMember(dest => dest.CreatedById,
        src => src.MapFrom(src => Guid.Parse(src.AdminId)))
       .ForMember(dest => dest.IsDeleted,
        src => src.MapFrom(src => false))
      .ReverseMap();
  }
}
