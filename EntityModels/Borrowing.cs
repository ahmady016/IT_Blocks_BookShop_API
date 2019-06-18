using System;
using System.Collections.Generic;

namespace Web_API.EntityModels
{
  public partial class Borrowing
  {
    public Borrowing()
    {
      IsDeleted = false;
    }
    public int BorrowingId { get; set; }
    public DateTime BorrowingStartDate { get; set; }
    public DateTime BorrowingEndDate { get; set; }
    public int? BookId { get; set; }
    public string CustomerId { get; set; }
    public int? UserId { get; set; }
    public bool IsDeleted { get; set; }

    public Book Book { get; set; }
    public Customer Customer { get; set; }
    public User User { get; set; }
  }
}
