using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MediaPhoto.Image.Get.Events;
public record GetMediaPhotoImageEvent(int PhotoId) : IRequest<ActionResult>;
