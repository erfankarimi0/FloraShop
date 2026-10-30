using System;
using System.Collections.Generic;
using FloraShop.Infra.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FloraShop.Infra.Data.Context;

public partial class FloraContext : DbContext
{
    public FloraContext()
    {
    }

    public FloraContext(DbContextOptions<FloraContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MidshoppingCartProduct> MidshoppingCartProducts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MidshoppingCartProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MIDOrderProduct");

            entity.ToTable("MIDShoppingCartProduct");

            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.MidshoppingCartProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MIDOrderProduct_Product");

            entity.HasOne(d => d.ShoppingCart).WithMany(p => p.MidshoppingCartProducts)
                .HasForeignKey(d => d.ShoppingCartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MIDOrderProduct_ShoppingCart");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.InsertDate)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdateDate).HasPrecision(0);

            entity.HasOne(d => d.ShoppingCart).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShoppingCartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_ShoppingCart");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.InsertDate)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Available");
            entity.Property(e => e.UpdateDate).HasPrecision(0);
        });

        modelBuilder.Entity<ShoppingCart>(entity =>
        {
            entity.ToTable("ShoppingCart");

            entity.Property(e => e.InsertDate).HasPrecision(0);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.UpdateDate).HasPrecision(0);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
