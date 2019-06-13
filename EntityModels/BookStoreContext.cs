using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Web_API.EntityModels
{
  public partial class BookStoreContext : DbContext
  {
    public BookStoreContext()
    {
    }

    public BookStoreContext(DbContextOptions<BookStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<Borrowing> Borrowings { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Purchase> Purchases { get; set; }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
        optionsBuilder.UseSqlServer(BaseHelpers.GetService<IConfiguration>().GetValue<string>("ConnectionStrings:BookStore"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Author>(entity =>
      {
        entity.HasKey(e => e.AuthorId);

        entity.Property(e => e.AuthorId)
                  .HasColumnName("authorId")
                  .ValueGeneratedNever();

        entity.Property(e => e.AuthorName)
                  .IsRequired()
                  .HasColumnName("authorName")
                  .HasMaxLength(100);

        entity.Property(e => e.BirthDate)
                  .HasColumnName("birthDate")
                  .HasColumnType("smalldatetime");

        entity.Property(e => e.UserId).HasColumnName("userId");

        entity.HasOne(d => d.User)
                  .WithMany(p => p.Authors)
                  .HasForeignKey(d => d.UserId)
                  .OnDelete(DeleteBehavior.SetNull)
                  .HasConstraintName("FK_Authors_Users");
      });

      modelBuilder.Entity<Book>(entity =>
      {
        entity.HasKey(e => e.BookId);

        entity.Property(e => e.BookId)
                  .HasColumnName("bookId")
                  .ValueGeneratedNever();

        entity.Property(e => e.Authors)
                  .IsRequired()
                  .HasColumnName("authors")
                  .IsUnicode(false);

        entity.Property(e => e.Description).HasColumnName("description");

        entity.Property(e => e.InventoryCount)
                  .HasColumnName("inventoryCount")
                  .HasDefaultValueSql("((1))");

        entity.Property(e => e.PageCount).HasColumnName("pageCount");

        entity.Property(e => e.PublishedDate)
                  .HasColumnName("publishedDate")
                  .HasColumnType("smalldatetime");

        entity.Property(e => e.Subtitle)
                  .IsRequired()
                  .HasColumnName("subtitle")
                  .HasMaxLength(100);

        entity.Property(e => e.ThumbnailUrl)
                  .IsRequired()
                  .HasColumnName("thumbnailURL")
                  .HasMaxLength(250)
                  .IsUnicode(false);

        entity.Property(e => e.Title)
                  .IsRequired()
                  .HasColumnName("title")
                  .HasMaxLength(100);

        entity.Property(e => e.UnitPrice)
                  .HasColumnName("unitPrice")
                  .HasColumnType("decimal(5, 2)")
                  .HasDefaultValueSql("((10.00))");

        entity.Property(e => e.UserId).HasColumnName("userId");

        entity.HasOne(d => d.User)
                  .WithMany(p => p.Books)
                  .HasForeignKey(d => d.UserId)
                  .OnDelete(DeleteBehavior.SetNull)
                  .HasConstraintName("FK_Books_Users");
      });

      modelBuilder.Entity<Borrowing>(entity =>
      {
        entity.HasKey(e => e.BorrowingId);

        entity.Property(e => e.BorrowingId)
                  .HasColumnName("borrowingId")
                  .ValueGeneratedNever();

        entity.Property(e => e.BookId).HasColumnName("bookId");

        entity.Property(e => e.BorrowingEndDate)
                  .HasColumnName("borrowingEndDate")
                  .HasColumnType("smalldatetime");

        entity.Property(e => e.BorrowingStartDate)
                  .HasColumnName("borrowingStartDate")
                  .HasColumnType("smalldatetime");

        entity.Property(e => e.CustomerId).HasColumnName("customerId");

        entity.Property(e => e.UserId).HasColumnName("userId");

        entity.HasOne(d => d.Book)
                  .WithMany(p => p.Borrowings)
                  .HasForeignKey(d => d.BookId)
                  .HasConstraintName("FK_Borrowings_Books");

        entity.HasOne(d => d.Customer)
                  .WithMany(p => p.Borrowings)
                  .HasForeignKey(d => d.CustomerId)
                  .HasConstraintName("FK_Borrowings_Customers");

        entity.HasOne(d => d.User)
                  .WithMany(p => p.Borrowings)
                  .HasForeignKey(d => d.UserId)
                  .OnDelete(DeleteBehavior.SetNull)
                  .HasConstraintName("FK_Borrowings_Users");
      });

      modelBuilder.Entity<Customer>(entity =>
      {
        entity.HasKey(e => e.CustomerId);

        entity.Property(e => e.CustomerId)
                  .HasColumnName("customerId")
                  .ValueGeneratedNever();

        entity.Property(e => e.BirthDate)
                  .HasColumnName("birthDate")
                  .HasColumnType("smalldatetime");

        entity.Property(e => e.CustomerName)
                  .IsRequired()
                  .HasColumnName("customerName")
                  .HasMaxLength(100);

        entity.Property(e => e.UserId).HasColumnName("userId");

        entity.HasOne(d => d.User)
                  .WithMany(p => p.Customers)
                  .HasForeignKey(d => d.UserId)
                  .OnDelete(DeleteBehavior.SetNull)
                  .HasConstraintName("FK_Customers_Users");
      });

      modelBuilder.Entity<Purchase>(entity =>
      {
        entity.HasKey(e => e.PurchaseId);

        entity.Property(e => e.PurchaseId)
                  .HasColumnName("purchaseId")
                  .ValueGeneratedNever();

        entity.Property(e => e.BookId).HasColumnName("bookId");

        entity.Property(e => e.CustomerId).HasColumnName("customerId");

        entity.Property(e => e.PaidAmount).HasColumnName("paidAmount");

        entity.Property(e => e.PurchaseDate)
                  .HasColumnName("purchaseDate")
                  .HasColumnType("smalldatetime");

        entity.Property(e => e.Quantity)
                  .HasColumnName("quantity")
                  .HasDefaultValueSql("((1))");

        entity.Property(e => e.UserId).HasColumnName("userId");

        entity.HasOne(d => d.Book)
                  .WithMany(p => p.Purchases)
                  .HasForeignKey(d => d.BookId)
                  .HasConstraintName("FK_Purchases_Books");

        entity.HasOne(d => d.Customer)
                  .WithMany(p => p.Purchases)
                  .HasForeignKey(d => d.CustomerId)
                  .HasConstraintName("FK_Purchases_Customers");

        entity.HasOne(d => d.User)
                  .WithMany(p => p.Purchases)
                  .HasForeignKey(d => d.UserId)
                  .OnDelete(DeleteBehavior.SetNull)
                  .HasConstraintName("FK_Purchases_Users");
      });

      modelBuilder.Entity<User>(entity =>
      {
        entity.HasKey(e => e.UserId);

        entity.Property(e => e.UserId)
                  .HasColumnName("userId")
                  .ValueGeneratedNever();

        entity.Property(e => e.Email)
                  .IsRequired()
                  .HasColumnName("email")
                  .IsUnicode(false);

        entity.Property(e => e.PasswordHash)
                  .IsRequired()
                  .HasColumnName("passwordHash")
                  .IsUnicode(false);

        entity.Property(e => e.PasswordSalt)
                  .IsRequired()
                  .HasColumnName("passwordSalt")
                  .IsUnicode(false);

        entity.Property(e => e.UserName)
                  .IsRequired()
                  .HasColumnName("userName")
                  .HasMaxLength(100);
      });
    }
  }
}
