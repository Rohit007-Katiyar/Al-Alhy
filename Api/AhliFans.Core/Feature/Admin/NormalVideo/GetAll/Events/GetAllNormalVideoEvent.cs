using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.NormalVideo.GetAll.Events;
public record GetAllNormalVideoEvent(string? SearchWord, string Lang, int PageIndex, int PageSize, bool IsDeleted) : IRequest<ActionResult>;
