using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MediaPhoto.Image.Edit.Events;
public record UpdateMediaPhotoImageEvent(int PhotoId, IFormFile PhotoImage) : IRequest<ActionResult>;
