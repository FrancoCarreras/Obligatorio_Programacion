using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Obligatorio_Programacion.Models;

public partial class ObligatorioProgramacionContext : DbContext
{
    public ObligatorioProgramacionContext()
    {
    }

    public ObligatorioProgramacionContext(DbContextOptions<ObligatorioProgramacionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Cotizacion> Cotizacions { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Imagen> Imagens { get; set; }

    public virtual DbSet<LineaFactura> LineaFacturas { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<PermisoRol> PermisoRols { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductoImagen> ProductoImagens { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=GWTN156-7\\INSTANCIAAGUSTIN;Initial Catalog=Obligatorio_Programacion;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Cedula).HasName("PK__Cliente__415B7BE43DECB5A1");

            entity.ToTable("Cliente");

            entity.Property(e => e.Cedula)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("cedula");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Cotizacion>(entity =>
        {
            entity.HasKey(e => e.IdCotizacion).HasName("PK__Cotizaci__D931C39BF073BAAB");

            entity.ToTable("Cotizacion");

            entity.Property(e => e.IdCotizacion).HasColumnName("idCotizacion");
            entity.Property(e => e.PrecioDolar).HasColumnName("precioDolar");
            entity.Property(e => e.PrecioPesos).HasColumnName("precioPesos");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PK__Factura__3CD5687E44299194");

            entity.ToTable("Factura");

            entity.Property(e => e.IdFactura).HasColumnName("idFactura");
            entity.Property(e => e.CedulaCliente)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("cedulaCliente");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.IdCotizacion).HasColumnName("idCotizacion");

            entity.HasOne(d => d.CedulaClienteNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.CedulaCliente)
                .HasConstraintName("FK_FacturaCliente");

            entity.HasOne(d => d.IdCotizacionNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdCotizacion)
                .HasConstraintName("FK_FacturaCotizacion");
        });

        modelBuilder.Entity<Imagen>(entity =>
        {
            entity.HasKey(e => e.IdImagen).HasName("PK__Imagen__EA9A713620E34EE7");

            entity.ToTable("Imagen");

            entity.Property(e => e.IdImagen).HasColumnName("idImagen");
            entity.Property(e => e.Url)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<LineaFactura>(entity =>
        {
            entity.HasKey(e => e.IdLineaFactura).HasName("PK__LineaFac__B2ACC97D5FD39C75");

            entity.Property(e => e.IdLineaFactura).HasColumnName("idLineaFactura");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdFactura).HasColumnName("idFactura");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");

            entity.HasOne(d => d.IdFacturaNavigation).WithMany(p => p.LineaFacturas)
                .HasForeignKey(d => d.IdFactura)
                .HasConstraintName("FK_LineaFacturaF");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.LineaFacturas)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK_LineaProducto");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso).HasName("PK__Permiso__06A58486A8999853");

            entity.ToTable("Permiso");

            entity.Property(e => e.IdPermiso).HasColumnName("idPermiso");
            entity.Property(e => e.NombrePermiso)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombrePermiso");
        });

        modelBuilder.Entity<PermisoRol>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PermisoRol");

            entity.Property(e => e.IdPermisoRol).HasColumnName("idPermisoRol");
            entity.Property(e => e.IdRolPermiso).HasColumnName("idRolPermiso");

            entity.HasOne(d => d.IdPermisoRolNavigation).WithMany()
                .HasForeignKey(d => d.IdPermisoRol)
                .HasConstraintName("FK_PermisoRol");

            entity.HasOne(d => d.IdRolPermisoNavigation).WithMany()
                .HasForeignKey(d => d.IdRolPermiso)
                .HasConstraintName("FK_RolPermiso");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__07F4A132824307BD");

            entity.ToTable("Producto");

            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });

        modelBuilder.Entity<ProductoImagen>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ProductoImagen");

            entity.Property(e => e.IdImagen).HasColumnName("idImagen");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");

            entity.HasOne(d => d.IdImagenNavigation).WithMany()
                .HasForeignKey(d => d.IdImagen)
                .HasConstraintName("FK_ImagenProducto");

            entity.HasOne(d => d.IdProductoNavigation).WithMany()
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK_ProductoImagen");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__3C872F76438A506E");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreRol");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A606FC95E0");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_UsuarioRol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
