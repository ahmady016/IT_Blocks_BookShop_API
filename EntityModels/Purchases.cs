using System;
using System.Collections.Generic;

namespace Web_API.EntityModels
{
    public partial class Purchases
    {
        public int PurchaseId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public short Quantity { get; set; }
        public int PaidAmount { get; set; }
        public int? BookId { get; set; }
        public int? CustomerId { get; set; }
        public int? UserId { get; set; }

        public Books Book { get; set; }
        public Customers Customer { get; set; }
        public Users User { get; set; }
    }
}
