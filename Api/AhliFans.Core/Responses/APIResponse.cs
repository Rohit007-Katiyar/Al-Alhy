namespace AhliFans.Core.Responses;
public class APIResponse<T>
{
  private dynamic isExist;
  public string message
  {
    get => this.res != null && this.res.Count != 0 ? "Success" : "Error";
    set => isExist = value;
  }
  public bool status
  {
    get =>
      this.res != null && this.res.Count != 0 ? true : false;
    set =>
      this.isExist = value;
  }
  public dynamic res { get; set; }
}
