using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Transactions;

namespace LibraryManagementSystem.Models
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions options):base(options) {
        }
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Fine> Fine { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserCategory> UserCategory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Book)
                .HasForeignKey(b => b.AuthorID);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Book)
                .HasForeignKey(b => b.PublisherID);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Book)
                .HasForeignKey(b => b.CategoryID);

            modelBuilder.Entity<Transactions>()
                .HasOne(t => t.Book)
                .WithMany()
                .HasForeignKey(t => t.BookID);

            modelBuilder.Entity<Transactions>()
                .HasOne(t => t.Member)
                .WithMany(m => m.Transactions)
                .HasForeignKey(t => t.MemberID);

            modelBuilder.Entity<Transactions>()
                .HasOne(t => t.Staff)
                .WithMany(s => s.Transactions)
                .HasForeignKey(t => t.StaffID);

            modelBuilder.Entity<Fine>()
                .HasOne(f => f.Transactions)
                .WithMany()
                .HasForeignKey(f => f.TransactionID);
            modelBuilder.Entity<User>()
            .HasOne(u => u.UserCategory)                // One User has one Category
            .WithMany(c => c.User)                 // One Category has many Users
            .HasForeignKey(u => u.CategoryId);
        }
    }
}
