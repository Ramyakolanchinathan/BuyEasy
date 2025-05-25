using Microsoft.EntityFrameworkCore;
using BuyEasy.Models.DataModel;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Contact> ContactUs { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<Product>().ToTable("Products");
        modelBuilder.Entity<Cart>().ToTable("CartViewModel");
        modelBuilder.Entity<Contact>().ToTable("ContactUs");
    }
}
