using System;
using System.Collections.Generic;
using App.Domain.Core.Booths.Entities;
using App.Domain.Core.Common.Entities;
using App.Domain.Core.Products.Entities;
using App.Domain.Core.User.Entities;
using App.Infra.Data.SqlServer.Ef.EntitiesConfigs;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.SqlServer.Ef.DbCntx;

public class BazarcheContext : DbContext
{
    public BazarcheContext(DbContextOptions<BazarcheContext> options) : base(options)
    {
    }

    public virtual DbSet<Auction> ProductActions { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Bid> Bids { get; set; }

    public virtual DbSet<Booth> Booths { get; set; }

    public virtual DbSet<BoothProduct> BoothProducts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Medal> Medals { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AddressConfig());
        modelBuilder.ApplyConfiguration(new AdminConfig());
        modelBuilder.ApplyConfiguration(new BidConfig());
        modelBuilder.ApplyConfiguration(new BoothConfig());
        modelBuilder.ApplyConfiguration(new BoothProductConfig());
        modelBuilder.ApplyConfiguration(new CategoryConfig());
        modelBuilder.ApplyConfiguration(new CommentConfig());
        modelBuilder.ApplyConfiguration(new CustomerConfig());
        modelBuilder.ApplyConfiguration(new MedalConfig());
        modelBuilder.ApplyConfiguration(new OrderConfig());
        modelBuilder.ApplyConfiguration(new OrderItemConfig());
        modelBuilder.ApplyConfiguration(new PictureConfig());
        modelBuilder.ApplyConfiguration(new AuctionConfig());
        modelBuilder.ApplyConfiguration(new ProductConfig());
        modelBuilder.ApplyConfiguration(new SellerConfig());

        //modelBuilder.Entity<ProductImage>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToTable("ProductImage");

        //    entity.HasOne(d => d.Picture).WithMany()
        //        .HasForeignKey(d => d.PictureId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_ProductImage_Pictures");

        //    entity.HasOne(d => d.Product).WithMany()
        //        .HasForeignKey(d => d.ProductId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_ProductImage_Products");
        //});

        base.OnModelCreating(modelBuilder);
    }

}
