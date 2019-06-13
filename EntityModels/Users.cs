using System;
using System.Collections.Generic;

namespace Web_API.EntityModels
{
    public partial class Users
    {
        public Users()
        {
            Authors = new HashSet<Authors>();
            Books = new HashSet<Books>();
            Borrowings = new HashSet<Borrowings>();
            Customers = new HashSet<Customers>();
            Purchases = new HashSet<Purchases>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public ICollection<Authors> Authors { get; set; }
        public ICollection<Books> Books { get; set; }
        public ICollection<Borrowings> Borrowings { get; set; }
        public ICollection<Customers> Customers { get; set; }
        public ICollection<Purchases> Purchases { get; set; }
    }
}
