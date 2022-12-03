using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MomentVideo.GetAll.Events;
public record GetAllMomentVideoEvent(string? SearchWord, string Lang, int PageIndex, int PageSize, bool IsDeleted) : IRequest<ActionResult>;
