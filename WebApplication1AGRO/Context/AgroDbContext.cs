using WebApplication1AGRO.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;


namespace WebApplication1AGRO.Context
{
    public class AgroDbContext : DbContext

    {
        public AgroDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Collections> Collections { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<Offers> Offers { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserTypes> UserTypes { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<DataTypes> DataTypes { get; set; }
        public DbSet<Bills> Bills { get; set; }
        public DbSet<PaymentMethods> PaymentMethods { get; set; }
        public DbSet<BillDetails> BillDetails { get; set; }
        public DbSet<Contacts> Contacts { get; set; }





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

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserTypes>()
                .HasKey(u => u.UserType_id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Contacts>()
                .HasKey(u => u.Contact_id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Documents>()
                .HasKey(u => u.Document_id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DataTypes>()
                .HasKey(u => u.DataType_id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Bills>()
                .HasKey(u => u.Bill_id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PaymentMethods>()
                .HasKey(u => u.Method_id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BillDetails>()
                .HasKey(u => u.BillDeta_id);


        }


    }
}