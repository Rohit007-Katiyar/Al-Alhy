using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Category.GetAll.Specification;
public class GetAllCategories : Specification<Entities.Category>
{
  public GetAllCategories(int pageIndex, int pageSize, string? SearchWord, bool isDeleted, string type)
  {
    if (pageIndex == 0 && pageSize == 0)
    {
      if (!string.IsNullOrEmpty(type) && type.ToLower() == "photo")
      {
        Query
      .Where(x => x.IsDeleted == isDeleted &&
      !x.photo.HasValue || x.photo.HasValue && x.photo.Value == (type.ToLower() == "photo" ? true : false)).OrderByDescending(m => m.CreatedOn);
      }
      if (!string.IsNullOrEmpty(type) && type.ToLower() == "video")
      {
        Query
      .Where(x => x.IsDeleted == isDeleted &&
      !x.video.HasValue || x.video.HasValue && x.video.Value == (type.ToLower() == "video" ? true : false)).OrderByDescending(m => m.CreatedOn);
      }
      if (string.IsNullOrEmpty(type))
      {
        Query
      .Where(x => x.IsDeleted == isDeleted).OrderByDescending(m => m.CreatedOn);
      }
    }
    else if (true)
    {
      if (!string.IsNullOrEmpty(type) && type.ToLower() == "photo")
      {
        Query
       .Where(x => x.IsDeleted == isDeleted &&
        x.photo.HasValue && x.photo.Value == (type.ToLower() == "photo" ? true : false)).OrderByDescending(m => m.CreatedOn)
       .Skip(((pageIndex - 1) * pageSize)).Take(pageSize);
      }
      if (!string.IsNullOrEmpty(type) && type.ToLower() == "photo")
      {
        Query
       .Where(x => x.IsDeleted == isDeleted &&
        x.video.HasValue && x.video.Value == (!string.IsNullOrEmpty(type) ? type.ToLower() == "video" ? true : false : true)).OrderByDescending(m => m.CreatedOn)
       .Skip(((pageIndex - 1) * pageSize)).Take(pageSize);
      }
      if (string.IsNullOrEmpty(type))
      {
        Query
        .Where(x => x.IsDeleted == isDeleted).OrderByDescending(m => m.CreatedOn)
        .Skip(((pageIndex - 1) * pageSize)).Take(pageSize);
      }
    }

    if (!string.IsNullOrEmpty(SearchWord))
    {
      //if (!string.IsNullOrEmpty(type))
      //{
      //  Query
      // .Where(x => x.IsDeleted == isDeleted &&
      //  x.photo.HasValue && x.photo.Value == (type.ToLower() == "photo" ? true : false) &&
      //  x.video.HasValue && x.video.Value == (!string.IsNullOrEmpty(type) ? type.ToLower() == "video" ? true : false : true)).OrderByDescending(m => m.CreatedOn)
      // .Skip(((pageIndex - 1) * pageSize)).Take(pageSize);
      //}
      //else
      //{
      Query
   .Where(x => x.Name.Contains(SearchWord) || x.NameAr.Contains(SearchWord) || x.Description.Contains(SearchWord) || x.Description.Contains(SearchWord)).OrderByDescending(m => m.CreatedOn);
      //}
    }
  }
}
