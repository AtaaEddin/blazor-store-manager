using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnlineStoresManager.Goods;

namespace OnlineStoresManager.API.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<BasicGood> Goods { get; set; }
        public DbSet<Shirt> Shirts { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BasicGood>(good =>
            {
                good.ToTable("Goods")
                    .HasDiscriminator(g => g.Discriminator)
                    .HasValue<Book>(GoodDiscriminator.Books)
                    .HasValue<Shirt>(GoodDiscriminator.Shirt);

                good.HasKey(g => g.Id);

                good.Property(g => g.Name)
                  .HasColumnName("Name");

                good.Property(g => g.Price)
                    .HasColumnName("Price");

                good.Property(g => g.ImageUrls)
                    .HasConversion(
                    l => l != null ? string.Join(BasicGood.ImageUrlSeparetor, l) : null,
                    s => s != null ? s.Trim().Split(BasicGood.ImageUrlSeparetor, StringSplitOptions.TrimEntries).ToList() : null,
                    new ValueComparer<List<string>>(
                            (c1, c2) => c1.SequenceEqual(c2),
                            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                            c => c.ToList()))
                    .HasColumnName("ImageUrls");
                    

                good.Property(g => g.Description)
                    .HasColumnName("Description");

                good.Property(g => g.Gategory)
                    .HasConversion(
                    t => t != null ? t.Value.ToString().ToLower() : null,
                    s => s != null ? Enum.Parse<GoodGategory>(s, true) : null)
                    .HasColumnName("GoodGategory");

                good.Property(g => g.Discriminator)
                    .HasConversion(
                    t => t != null ? t.Value.ToString().ToLower() : null,
                    s => s != null ? Enum.Parse<GoodDiscriminator>(s, true) : null)
                    .HasColumnName("GoodType");
            });

            builder.Entity<Book>(book =>
            {
                book.HasBaseType<BasicGood>();
                book.ToTable("Goods");

                book.Property(b => b.BookType)
                  .HasConversion(
                    t => t != null ? t.Value.ToString().ToLower() : null,
                    s => s != null ? Enum.Parse<BookType>(s, true) : null)
                  .HasColumnName("BookType");

                book.Property(b => b.Author)
                    .HasColumnName ("Author");
            });

            builder.Entity<Shirt>(shirt =>
            {
                shirt.HasBaseType<BasicGood>();
                shirt.ToTable("Goods");

                shirt.Property(s => s.ShirtType)
                    .HasConversion(
                    t => t != null ? t.Value.ToString().ToLower() : null,
                    s => s != null ? Enum.Parse<ShirtType>(s, true) : null)
                    .HasColumnName("ShirtType");

                shirt.Property(s => s.Color)
                    .HasColumnName("Shirtcolor");
            });
        }
    }
}
