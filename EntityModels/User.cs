using System;
using System.Collections.Generic;

namespace Web_API.EntityModels
{
  public partial class User
  {
    public User()
    {
      Authors = new HashSet<Author>();
      Books = new HashSet<Book>();
      Borrowings = new HashSet<Borrowing>();
      Customers = new HashSet<Customer>();
      Purchases = new HashSet<Purchase>();
      IsDeleted = false;
    }

    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public bool IsDeleted { get; set; }

    public ICollection<Author> Authors { get; set; }
    public ICollection<Book> Books { get; set; }
    public ICollection<Borrowing> Borrowings { get; set; }
    public ICollection<Customer> Customers { get; set; }
    public ICollection<Purchase> Purchases { get; set; }
  }
}
