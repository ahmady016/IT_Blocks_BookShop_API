using System.Collections.Generic;

namespace Web_API
{
  public class PageResult<T> where T : class
  {
    public List<T> PageItems { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
  }

  public class PageResult
  {
    public List<dynamic> PageItems { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
  }

}