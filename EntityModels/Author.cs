using System;
using System.Collections.Generic;

namespace Web_API.EntityModels
{
  public partial class Author
  {
    public Author()
    {
      IsDeleted = false;
    }
    public int AuthorId { get; set; }
    public string AuthorName { get; set; }
    public DateTime? BirthDate { get; set; }
    public int? UserId { get; set; }
    public bool IsDeleted { get; set; }

    public User User { get; set; }
  }
}
