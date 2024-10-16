using WebApplication1AGRO.Model;
using Microsoft.EntityFrameworkCore;

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

            // Definiciones de claves primarias
            modelBuilder.Entity<Products>().HasKey(p => p.Product_id);
            modelBuilder.Entity<Collections>().HasKey(c => c.CollectionPoint_id);
            modelBuilder.Entity<ProductCategories>().HasKey(pc => pc.Category_id);
            modelBuilder.Entity<ProductDetails>().HasKey(pd => pd.ProdDeta_id);
            modelBuilder.Entity<Offers>().HasKey(o => o.Offer_id);
            modelBuilder.Entity<Users>().HasKey(u => u.User_id);
            modelBuilder.Entity<UserTypes>().HasKey(u => u.UserType_id);
            modelBuilder.Entity<Contacts>().HasKey(c => c.Contact_id);
            modelBuilder.Entity<Documents>().HasKey(d => d.Document_id);
            modelBuilder.Entity<DataTypes>().HasKey(dt => dt.DataType_id);
            modelBuilder.Entity<PaymentMethods>().HasKey(pm => pm.Method_id);
            modelBuilder.Entity<BillDetails>().HasKey(bd => bd.BillDeta_id);
            modelBuilder.Entity<Bills>().HasKey(b => b.Bill_id);

            // Relaciones

            // Relaciones de Users
            modelBuilder.Entity<Users>()
                .HasOne<UserTypes>(u => u.UserTypes)
                .WithMany()
                .HasForeignKey(u => u.UserType_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Users>()
                .HasOne<Documents>(u => u.Documents)
                .WithMany()
                .HasForeignKey(u => u.Document_id)
                .OnDelete(DeleteBehavior.Restrict);

            // Relaciones de Bills
            modelBuilder.Entity<Bills>()
                .HasOne<Users>(b => b.Users)
                .WithMany()
                .HasForeignKey(b => b.User_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bills>()
                .HasOne<PaymentMethods>(b => b.PaymentMethods)
                .WithMany()
                .HasForeignKey(b => b.Method_id)
                .OnDelete(DeleteBehavior.Restrict);

            // Relaciones de BillDetails
            modelBuilder.Entity<BillDetails>()
                .HasOne<Bills>(bd => bd.Bills)
                .WithMany()
                .HasForeignKey(bd => bd.Bill_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BillDetails>()
                .HasOne<Products>(bd => bd.Products)
                .WithMany()
                .HasForeignKey(bd => bd.Product_id)
                .OnDelete(DeleteBehavior.Restrict);

            // Relaciones para Products
            modelBuilder.Entity<Products>()
                .HasOne(p => p.ProductCategories)
                .WithMany()
                .HasForeignKey(p => p.Category_id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
