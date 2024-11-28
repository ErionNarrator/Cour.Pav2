using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace Cour.Pav.Model;

public partial class AucitonContext : DbContext
{
    public AucitonContext()
    {
    }

    public AucitonContext(DbContextOptions<AucitonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auction> Auctions { get; set; }

    public virtual DbSet<Buyer> Buyers { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=..\\..\\..\\DB\\Auciton.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auction>(entity =>
        {
            entity.Property(e => e.AuctionId).HasColumnName("auction_id");
            entity.Property(e => e.AuctionName).HasColumnName("auction_name");
            entity.Property(e => e.Date)
                .HasColumnType("DATE")
                .HasColumnName("date");
            entity.Property(e => e.Location).HasColumnName("location");
            entity.Property(e => e.Specifications).HasColumnName("specifications");
        });

        modelBuilder.Entity<Buyer>(entity =>
        {
            entity.Property(e => e.BuyerId).HasColumnName("buyer_id");
            entity.Property(e => e.BuyerName).HasColumnName("buyer_name");
            entity.Property(e => e.LoginBuyer).HasColumnName("login_buyer");
            entity.Property(e => e.PasswordBuyer).HasColumnName("password_buyer");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.AuctionId).HasColumnName("auction_id");
            entity.Property(e => e.BuyerId).HasColumnName("buyer_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.LotNumber).HasColumnName("lot_number");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.SellerId).HasColumnName("seller_id");

            entity.HasOne(d => d.Auction).WithMany(p => p.Items).HasForeignKey(d => d.AuctionId);

            entity.HasOne(d => d.Buyer).WithMany(p => p.Items).HasForeignKey(d => d.BuyerId);

            entity.HasOne(d => d.Seller).WithMany(p => p.Items).HasForeignKey(d => d.SellerId);
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.Property(e => e.SellerId).HasColumnName("seller_id");
            entity.Property(e => e.LoginSeller).HasColumnName("login_seller");
            entity.Property(e => e.PasswordSeller).HasColumnName("password_seller");
            entity.Property(e => e.SellerName).HasColumnName("seller_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
