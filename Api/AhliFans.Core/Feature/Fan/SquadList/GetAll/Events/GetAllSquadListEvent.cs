using AhliFans.Core.Feature.Localization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhliFans.Core.Feature.Fan.SquadList.GetAll.Events;
public class GetAllSquadListEvent : IRequest<ActionResult>
{
    public GetAllSquadListEvent(string language)
    {
        if (!string.IsNullOrEmpty(language))
        {
            Language = language;
        }
    }

    public string Language { get; set; } = Languages.Ar;
}
