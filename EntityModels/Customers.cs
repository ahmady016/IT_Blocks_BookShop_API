using System;
using System.Collections.Generic;

namespace Web_API.EntityModels
{
    public partial class Customers
    {
        public Customers()
        {
            Borrowings = new HashSet<Borrowings>();
            Purchases = new HashSet<Purchases>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? UserId { get; set; }

        public Users User { get; set; }
        public ICollection<Borrowings> Borrowings { get; set; }
        public ICollection<Purchases> Purchases { get; set; }
    }
}
