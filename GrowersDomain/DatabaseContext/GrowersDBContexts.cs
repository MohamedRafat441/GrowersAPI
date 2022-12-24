using GrowersDomain.Models.Customers;
using GrowersDomain.Models.Growers;
using GrowersDomain.Models.SystemUser;
using Microsoft.EntityFrameworkCore;

namespace GrowersDomain.DatabaseContext
{
    public class GrowersDBContexts : DbContext
    {
        public GrowersDBContexts()
        {

        }

        public GrowersDBContexts(DbContextOptions<GrowersDBContexts> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Grower> Growers { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SystemUser> SystemUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemUser>()
        .HasData(
            new SystemUser
            {
                Id = 1,
                UserName = "Grower",
                Password = "112233",
                Email="grower@gmail.com"
            },
            new SystemUser
            {
                Id = 2,
                UserName = "Grower",
                Password = "112233",
                Email = "grower@gmail.com"
            }
        );

            modelBuilder.Entity<Grower>()
       .HasData(
           new Grower
           {
               Id = 1,
               SystemUserId = 1,
               NameEn="Grower",   
           }
       );
            modelBuilder.Entity<Customer>()
      .HasData(
          new Customer
          {
              Id=1,
              SystemUserId = 2,
              NameEn = "Customer",
          }
      );
            modelBuilder.Entity<Category>()
      .HasData(
          new Category
          {
              Id = 1,
              NameEn = "Fruits",  
          }
      );
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {

            builder.UseSqlServer("Server=DESKTOP-96STMPK;Database=GrowersDBV1;Trusted_Connection=True;");
        }
    }
}
