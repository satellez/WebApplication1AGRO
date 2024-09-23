using WebApplication1AGRO.Model;
using Microsoft.EntityFrameworkCore;


namespace WebApplication1AGRO.Context
{
    public class AgroDbContext : DbContext

    {
        public AgroDbContext(DbContextOptions options) : base(options)
        {

        }
       
        public DbSet<Users> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }

        public DbSet<ProductDetails> ProductDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>().HasKey(u => u.User_id);
            

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasKey(u => u.Product_id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductCategories>().HasKey(u => u.Category_id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductDetails>().HasKey(u => u.Product_id);

           
        }

              
    }
}
