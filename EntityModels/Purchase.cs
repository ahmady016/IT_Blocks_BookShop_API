using System;
using System.Collections.Generic;

namespace Web_API.EntityModels
{
  public partial class Purchase
  {
    public Purchase()
    {
      IsDeleted = false;
    }
    public int PurchaseId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public short Quantity { get; set; }
    public int PaidAmount { get; set; }
    public int? BookId { get; set; }
    public int? CustomerId { get; set; }
    public int? UserId { get; set; }
    public bool IsDeleted { get; set; }

    public Book Book { get; set; }
    public Customer Customer { get; set; }
    public User User { get; set; }
  }
}
