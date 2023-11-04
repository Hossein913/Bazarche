//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;

//namespace Scaffold.Models;

//public partial class MarketBesharatiContext : DbContext
//{
//    public MarketBesharatiContext()
//    {
//    }

//    public MarketBesharatiContext(DbContextOptions<MarketBesharatiContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<Address> Addresses { get; set; }

//    public virtual DbSet<Admin> Admins { get; set; }

//    public virtual DbSet<Attributes> Attributes { get; set; }

//    public virtual DbSet<Auction> Auctions { get; set; }

//    public virtual DbSet<Bid> Bids { get; set; }

//    public virtual DbSet<Booth> Booths { get; set; }

//    public virtual DbSet<BoothProduct> BoothProducts { get; set; }

//    public virtual DbSet<Category> Categories { get; set; }

//    public virtual DbSet<Comment> Comments { get; set; }

//    public virtual DbSet<Customer> Customers { get; set; }

//    public virtual DbSet<Medal> Medals { get; set; }

//    public virtual DbSet<Order> Orders { get; set; }

//    public virtual DbSet<OrderItem> OrderItems { get; set; }

//    public virtual DbSet<Picture> Pictures { get; set; }

//    public virtual DbSet<Product> Products { get; set; }

//    public virtual DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }

//    public virtual DbSet<Province> Provinces { get; set; }

//    public virtual DbSet<Seller> Sellers { get; set; }

//    public virtual DbSet<Wage> Wages { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.;Database=MarketBesharati;integrated security=sspi;TrustServerCertificate=True;MultipleActiveResultSets=true;");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Address>(entity =>
//        {
//            entity.Property(e => e.City).HasMaxLength(50);
//            entity.Property(e => e.FullAddress).HasMaxLength(255);
//            entity.Property(e => e.PostalCode)
//                .HasMaxLength(10)
//                .IsFixedLength();

//            entity.HasOne(d => d.Province).WithMany(p => p.Addresses)
//                .HasForeignKey(d => d.ProvinceId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Addresses_Provinces");
//        });

//        modelBuilder.Entity<Admin>(entity =>
//        {
//            entity.Property(e => e.Birthdate).HasColumnType("datetime");
//            entity.Property(e => e.Firstname).HasMaxLength(50);
//            entity.Property(e => e.Lastname).HasMaxLength(50);
//            entity.Property(e => e.ShabaNumber)
//                .HasMaxLength(25)
//                .IsFixedLength();

//            entity.HasOne(d => d.ProfilePic).WithMany(p => p.Admins)
//                .HasForeignKey(d => d.ProfilePicId)
//                .HasConstraintName("FK_Admins_Pictures");
//        });

//        modelBuilder.Entity<Attributes>(entity =>
//        {
//            entity.ToTable("Attribute");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.Name)
//                .HasMaxLength(50)
//                .IsUnicode(false);
//        });

//        modelBuilder.Entity<Auction>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK_Actions");

//            entity.Property(e => e.EndTime).HasColumnType("datetime");
//            entity.Property(e => e.StartTime).HasColumnType("datetime");

//            entity.HasOne(d => d.Booth).WithMany(p => p.Auctions)
//                .HasForeignKey(d => d.BoothId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Actions_Booths");

//            entity.HasOne(d => d.BoothNavigation).WithMany(p => p.Auctions)
//                .HasForeignKey(d => d.BoothId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Actions_Customers");

//            entity.HasOne(d => d.Product).WithMany(p => p.Auctions)
//                .HasForeignKey(d => d.ProductId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Actions_Products");
//        });

//        modelBuilder.Entity<Bid>(entity =>
//        {
//            entity.HasOne(d => d.Action).WithMany(p => p.Bids)
//                .HasForeignKey(d => d.ActionId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Bids_Actions");

//            entity.HasOne(d => d.Customer).WithMany(p => p.Bids)
//                .HasForeignKey(d => d.CustomerId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Bids_Customers");
//        });

//        modelBuilder.Entity<Booth>(entity =>
//        {
//            entity.Property(e => e.Description).HasMaxLength(300);
//            entity.Property(e => e.Name).HasMaxLength(50);

//            entity.HasOne(d => d.AvatarPicture).WithMany(p => p.Booths)
//                .HasForeignKey(d => d.AvatarPictureId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Booths_Pictures");

//            entity.HasOne(d => d.Medal).WithMany(p => p.Booths)
//                .HasForeignKey(d => d.MedalId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Booths_Medals");
//        });

//        modelBuilder.Entity<BoothProduct>(entity =>
//        {
//            entity.ToTable("BoothProduct");

//            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

//            entity.HasOne(d => d.Booth).WithMany(p => p.BoothProducts)
//                .HasForeignKey(d => d.BoothId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_BoothProduct_Booths");

//            entity.HasOne(d => d.Product).WithMany(p => p.BoothProducts)
//                .HasForeignKey(d => d.ProductId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_BoothProduct_Products");
//        });

//        modelBuilder.Entity<Category>(entity =>
//        {
//            entity.Property(e => e.Title).HasMaxLength(50);

//            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
//                .HasForeignKey(d => d.ParentId)
//                .HasConstraintName("FK_Categories_Categories");

//            entity.HasOne(d => d.Picture).WithMany(p => p.Categories)
//                .HasForeignKey(d => d.PictureId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Categories_Pictures");
//        });

//        modelBuilder.Entity<Comment>(entity =>
//        {
//            entity.Property(e => e.Text).HasMaxLength(600);

//            entity.HasOne(d => d.Customer).WithMany(p => p.Comments)
//                .HasForeignKey(d => d.CustomerId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Comments_Customers");

//            entity.HasOne(d => d.OrderItem).WithMany(p => p.Comments)
//                .HasForeignKey(d => d.OrderItemId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Comments_OrderItems");
//        });

//        modelBuilder.Entity<Customer>(entity =>
//        {
//            entity.Property(e => e.Birthdate).HasColumnType("datetime");
//            entity.Property(e => e.Firstname).HasMaxLength(50);
//            entity.Property(e => e.Lastname).HasMaxLength(50);

//            entity.HasOne(d => d.Address).WithMany(p => p.Customers)
//                .HasForeignKey(d => d.AddressId)
//                .HasConstraintName("FK_Customers_Addresses");

//            entity.HasOne(d => d.ProfilePic).WithMany(p => p.Customers)
//                .HasForeignKey(d => d.ProfilePicId)
//                .HasConstraintName("FK_Customers_Pictures");
//        });

//        modelBuilder.Entity<Medal>(entity =>
//        {
//            entity.Property(e => e.Name).HasMaxLength(50);
//        });

//        modelBuilder.Entity<Order>(entity =>
//        {
//            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
//            entity.Property(e => e.PayedAt).HasColumnType("datetime");

//            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
//                .HasForeignKey(d => d.CustomerId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Orders_Customers");
//        });

//        modelBuilder.Entity<OrderItem>(entity =>
//        {
//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.Count).HasColumnName("count");

//            entity.HasOne(d => d.BoothProduct).WithMany(p => p.OrderItems)
//                .HasForeignKey(d => d.BoothProductid)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_OrderItems_BoothProduct");

//            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
//                .HasForeignKey(d => d.OrderId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_OrderItems_Orders");
//        });

//        modelBuilder.Entity<Picture>(entity =>
//        {
//            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
//        });

//        modelBuilder.Entity<Product>(entity =>
//        {
//            entity.Property(e => e.Brand).HasMaxLength(255);
//            entity.Property(e => e.Describtion).HasMaxLength(300);
//            entity.Property(e => e.Grantee).HasMaxLength(255);
//            entity.Property(e => e.Name).HasMaxLength(255);

//            entity.HasOne(d => d.Avatar).WithMany(p => p.Products)
//                .HasForeignKey(d => d.AvatarId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Products_Pictures");
//        });

//        modelBuilder.Entity<ProductAttributeValue>(entity =>
//        {
//            entity.ToTable("ProductAttributeValue");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//            entity.Property(e => e.Value).HasMaxLength(100);

//            entity.HasOne(d => d.Attribute).WithMany(p => p.ProductAttributeValues)
//                .HasForeignKey(d => d.AttributeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_ProductAttributeValue_Attribute");

//            entity.HasOne(d => d.Product).WithMany(p => p.ProductAttributeValues)
//                .HasForeignKey(d => d.ProductId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_ProductAttributeValue_Products");
//        });



//        modelBuilder.Entity<Province>(entity =>
//        {
//            entity.Property(e => e.Name)
//                .HasMaxLength(50);
//        });

//        modelBuilder.Entity<Seller>(entity =>
//        {
//            entity.Property(e => e.Birthdate).HasColumnType("datetime");
//            entity.Property(e => e.Firstname).HasMaxLength(50);
//            entity.Property(e => e.Lastname).HasMaxLength(50);
//            entity.Property(e => e.ShabaNumber)
//                .HasMaxLength(25)
//                .IsFixedLength();

//            entity.HasOne(d => d.Address).WithMany(p => p.Sellers)
//                .HasForeignKey(d => d.AddressId)
//                .HasConstraintName("FK_Sellers_Addresses");

//            entity.HasOne(d => d.Booth).WithMany(p => p.Sellers)
//                .HasForeignKey(d => d.BoothId)
//                .HasConstraintName("FK_Sellers_Booths");

//            entity.HasOne(d => d.ProfilePic).WithMany(p => p.Sellers)
//                .HasForeignKey(d => d.ProfilePicId)
//                .HasConstraintName("FK_Sellers_Pictures");
//        });

//        modelBuilder.Entity<Wage>(entity =>
//        {
//            entity.Property(e => e.Id).ValueGeneratedNever();

//            entity.HasOne(d => d.Orderitem).WithMany(p => p.Wages)
//                .HasForeignKey(d => d.OrderitemId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Wages_OrderItems");
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
