using System;
using System.Collections.Generic;

namespace Web_API.EntityModels
{
    public partial class Customer
    {
        public Customer()
        {
            Borrowings = new HashSet<Borrowing>();
            Purchases = new HashSet<Purchase>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? UserId { get; set; }

        public User User { get; set; }
        public ICollection<Borrowing> Borrowings { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
    }
}
