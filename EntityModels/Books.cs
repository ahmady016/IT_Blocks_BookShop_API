using System;
using System.Collections.Generic;

namespace Web_API.EntityModels
{
    public partial class Books
    {
        public Books()
        {
            Borrowings = new HashSet<Borrowings>();
            Purchases = new HashSet<Purchases>();
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

        public Users User { get; set; }
        public ICollection<Borrowings> Borrowings { get; set; }
        public ICollection<Purchases> Purchases { get; set; }
    }
}
