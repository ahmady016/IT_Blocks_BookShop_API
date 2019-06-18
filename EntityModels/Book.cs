using System;
using System.Collections.Generic;

namespace Web_API.EntityModels
{
    public partial class Book
    {
        public Book()
        {
            Borrowings = new HashSet<Borrowing>();
            Purchases = new HashSet<Purchase>();
            Authors = "0";
            IsDeleted = false;
        }

        public int BookId { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ThumbnailUrl { get; set; }
        public short PageCount { get; set; }
        public string Description { get; set; }
        public string Authors { get; set; }
        public short InventoryCount { get; set; }
        public decimal UnitPrice { get; set; }
        public int? UserId { get; set; }
        public bool IsDeleted { get; set; }

        public User User { get; set; }
        public ICollection<Borrowing> Borrowings { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
    }
}
