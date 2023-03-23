using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebInventarios.Models.ViewModels;

namespace WebInventarios.Models
{
    public partial class ConexionContext : DbContext
    {

        public ConexionContext() 
        { 
        }
        public ConexionContext(DbContextOptions<ConexionContext> options)
            : base(options) 
        {
        }

        public virtual DbSet<Inventarios> Inventarios { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<ProductosAlmacen> ProductosAlmacen { get;set; } = null!;
        public virtual DbSet<Almacenes> Almacenes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventarios>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Inventario");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                //entity.HasNoKey();

                entity.HasKey(e => e.ProductoId);
                entity.Property(e => e.ProductoDesc)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            });
            modelBuilder.Entity<Almacenes>(entity =>
            {
                entity.Property(a => a.IDAlmacen).HasColumnName("IDAlmacen");

                entity.Property(a => a.DescripcionAlmacen);
                entity.HasKey(a => a.IDAlmacen);

            });

            modelBuilder.Entity<ProductosAlmacen>(entity =>
                entity.Property(p=> p.Id)
                

                );

            modelBuilder.Entity<ProductosAlmacen>()
                .HasOne(pa => pa.Almacenes)
                .WithOne(a => a.ProductosAlmacen1)
                .HasForeignKey<ProductosAlmacen>(pa => pa.IDAlmacen);

            modelBuilder.Entity<ProductosAlmacen>()
                .HasOne(pa => pa.Producto)
                .WithOne(p => p.ProductosAlmacen1)
                .HasForeignKey<ProductosAlmacen>(pa => pa.ProductoId);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
