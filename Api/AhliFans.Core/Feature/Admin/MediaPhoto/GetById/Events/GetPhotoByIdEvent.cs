using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MediaPhoto.GetById.Events;
public record GetPhotoByIdEvent(int PhotoId, string Lang) : IRequest<ActionResult>;
