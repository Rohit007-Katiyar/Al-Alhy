using FluentValidation;

namespace AhliFans.Core.Feature.Fan.Profile.Image.Update.Events;
public class UpdateImageValidator : AbstractValidator<UpdateImageEvent>
{
  public UpdateImageValidator()
  {
    RuleFor(req => req.ProfileImage).Must((_, req) =>
      req != null && ".jpg,.png,.jpeg,.gif".Contains(Path.GetExtension(req.FileName).ToLowerInvariant()));

    RuleFor(req => req.ProfileImage).Must((_, req) => req.Length / (1024 * 1024) <= 10).WithMessage("File size must be 10 MB at most.");
  }
}
