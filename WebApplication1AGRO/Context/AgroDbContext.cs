protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<ProductCategories>()
        .HasKey(pc => pc.Category_id);

    modelBuilder.Entity<Products>()
        .HasKey(p => p.Product_id);

    modelBuilder.Entity<Collections>()
        .HasKey(c => c.CollectionPoint_id);

    modelBuilder.Entity<ProductDetails>()
        .HasKey(pd => pd.ProdDeta_id);

    modelBuilder.Entity<Offers>()
        .HasKey(o => o.Offer_id);

    modelBuilder.Entity<Users>()
        .HasKey(u => u.User_id);

    modelBuilder.Entity<UserTypes>()
        .HasKey(ut => ut.UserType_id);

    modelBuilder.Entity<Contacts>()
        .HasKey(c => c.Contact_id);

    modelBuilder.Entity<Documents>()
        .HasKey(d => d.Document_id);

    modelBuilder.Entity<DataTypes>()
        .HasKey(dt => dt.DataType_id);

    modelBuilder.Entity<Bills>()
        .HasKey(b => b.Bill_id);

    modelBuilder.Entity<PaymentMethods>()
        .HasKey(pm => pm.Method_id);

    modelBuilder.Entity<BillDetails>()
        .HasKey(bd => bd.BillDeta_id);
}

