using System;
using System.Collections.Generic;

namespace Web_API.EntityModels
{
    public partial class Borrowings
    {
        public int BorrowingId { get; set; }
        public DateTime BorrowingStartDate { get; set; }
        public DateTime BorrowingEndDate { get; set; }
        public int? BookId { get; set; }
        public int? CustomerId { get; set; }
        public int? UserId { get; set; }

        public Books Book { get; set; }
        public Customers Customer { get; set; }
        public Users User { get; set; }
    }
}
