using WebApplication1AGRO.Model;
using Microsoft.EntityFrameworkCore;


namespace WebApplication1AGRO.Context
{
    public class AgroDbContext : DbContext

    {
        public AgroDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Collections> Collections { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<Offers> Offers { get; set; }
        public DbSet<Users> Users { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductCategories>()
                .HasKey(pc => pc.Category_id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Products>()
                .HasKey(p => p.Product_id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Collections>()
                .HasKey(c => c.CollectionPoint_id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductDetails>()
                .HasKey(pd => pd.ProdDeta_id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Offers>()
                .HasKey(o => o.Offer_id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>()
                .HasKey(u => u.User_id);

        }

              
    }
}
