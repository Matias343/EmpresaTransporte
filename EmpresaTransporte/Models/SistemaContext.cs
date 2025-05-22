using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace EmpresaTransporte.Models;

public partial class SistemaContext : DbContext
{
    public SistemaContext()
    {
    }

    public SistemaContext(DbContextOptions<SistemaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Camion> Camions { get; set; }

    public virtual DbSet<Mantencion> Mantencions { get; set; }

    public virtual DbSet<Viaje> Viajes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=190.44.59.20;user=integrador;password=invita_el_almuerzo;database=empresatransporte", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.42-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Camion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Camion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Anio).HasColumnName("anio");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Kilometraje).HasColumnName("kilometraje");
            entity.Property(e => e.Marca)
                .HasMaxLength(30)
                .HasColumnName("marca");
            entity.Property(e => e.Modelo)
                .HasMaxLength(30)
                .HasColumnName("modelo");
        });

        modelBuilder.Entity<Mantencion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Mantencion");

            entity.HasIndex(e => e.IdCamion, "id_camion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdCamion).HasColumnName("id_camion");
            entity.Property(e => e.Observacion)
                .HasMaxLength(255)
                .HasColumnName("observacion");

            entity.HasOne(d => d.IdCamionNavigation).WithMany(p => p.Mantencions)
                .HasForeignKey(d => d.IdCamion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Mantencion_ibfk_1");
        });

        modelBuilder.Entity<Viaje>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Viaje");

            entity.HasIndex(e => e.IdCamion, "id_camion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Destino)
                .HasMaxLength(255)
                .HasColumnName("destino");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdCamion).HasColumnName("id_camion");

            entity.HasOne(d => d.IdCamionNavigation).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.IdCamion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Viaje_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
