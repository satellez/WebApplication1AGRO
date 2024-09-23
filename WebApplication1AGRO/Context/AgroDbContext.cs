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
        public DbSet<Offers> Offers { get; set; }
        public DbSet<Collections> Collections { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>().HasKey(u => u.User_id);
            

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasKey(u => u.Product_id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductCategories>().HasKey(u => u.ProdCat_id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductDetails>().HasKey(u => u.ProdDeta_id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Offers>().HasKey(u => u.Offer_id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Collections>().HasKey(u => u.CollectionPoint_id);

           
        }

              
    }
}
