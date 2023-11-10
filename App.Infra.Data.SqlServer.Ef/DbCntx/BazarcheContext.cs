using System;
using System.Collections.Generic;
using System.Data;
using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Common.Entities;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._User.Entities;
using App.Infra.Data.SqlServer.Ef.EntitiesConfigs;
using App.Infra.Data.SqlServer.Ef.EntitiesConfigs.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.SqlServer.Ef.DbCntx;

public class BazarcheContext : IdentityDbContext<AppUser, AppRole, int>
{
    public BazarcheContext(DbContextOptions<BazarcheContext> options) : base(options)
    {
    }
    #region DbSets
    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Attributes> Attributes { get; set; }

    public virtual DbSet<Auction> Auctions { get; set; }

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

    public virtual DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    public virtual DbSet<Wage> Wages { get; set; }
    #endregion
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Note to Myself : relations Methods start with .Has() therfor relation FluentApi should wirretn
        //                   in config files of entiy that has an id of other entity

        modelBuilder.ApplyConfiguration(new PictureConfig());
        modelBuilder.ApplyConfiguration(new BoothConfig());
        modelBuilder.ApplyConfiguration(new ProvinceConfig());
        modelBuilder.ApplyConfiguration(new AddressConfig());

        modelBuilder.ApplyConfiguration(new RoleSeedData());
        modelBuilder.ApplyConfiguration(new UserSeedData());
        modelBuilder.ApplyConfiguration(new UsertoRoleSeedData());

        modelBuilder.ApplyConfiguration(new AdminConfig());
        modelBuilder.ApplyConfiguration(new AuctionConfig());
        modelBuilder.ApplyConfiguration(new BidConfig());
        modelBuilder.ApplyConfiguration(new BoothProductConfig());
        modelBuilder.ApplyConfiguration(new CategoryConfig());
        modelBuilder.ApplyConfiguration(new CommentConfig());
        modelBuilder.ApplyConfiguration(new CustomerConfig());
        modelBuilder.ApplyConfiguration(new MedalConfig());
        modelBuilder.ApplyConfiguration(new OrderConfig());
        modelBuilder.ApplyConfiguration(new OrderItemConfig());
        modelBuilder.ApplyConfiguration(new ProductConfig());
        modelBuilder.ApplyConfiguration(new SellerConfig());
        modelBuilder.ApplyConfiguration(new WageConfig());

        modelBuilder.ApplyConfiguration(new ProductAttributeValueConfig());
        modelBuilder.ApplyConfiguration(new AttributesConfig());

        base.OnModelCreating(modelBuilder);
    }

}

