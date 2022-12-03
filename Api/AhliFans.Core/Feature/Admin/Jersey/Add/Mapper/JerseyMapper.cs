using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhliFans.Core.Feature.Admin.Jersey.Add.Events;

namespace AhliFans.Core.Feature.Admin.Jersey.Mapper;
public class JerseyMapper : AutoMapper.Profile
{
  public JerseyMapper()
  {
    CreateMap<AddJerseyEvent, Entities.Jersey>()
      .ForMember(dest => dest.Picture,
        src => src.MapFrom(src => src.Picture!.FileName))
      .ForMember(dest => dest.CreatedById,
        src => src.MapFrom(src => src.AdminId))
      .ReverseMap();
  }
}
