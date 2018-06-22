using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using POS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace POS.Data.DataAccess
{
    public class SimpleFactContext : DbContext
    {
        //public SimpleFactContext(DbContextOptions<SimpleFactContext> options):base(options) { }

        //IConfiguration configuration;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer(configuration.GetConnectionString("SimpleFactConexion").ToString());
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-7KB7TBQ\SQLEXPRESS;Initial Catalog=SimpleFact;User ID=sa;Password=SqL1205$");
            optionsBuilder.EnableSensitiveDataLogging(true);

        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<DetalleFactura> DetalleFactura { get; set; }
        public virtual DbSet<EncabezadoFactura> EncabezadoFactura { get; set; }
        public virtual DbSet<LogErrores> LogErrores { get; set; }
        public virtual DbSet<ModulosSistema> ModulosSistema { get; set; }
        public virtual DbSet<MovimientosInventario> MovimientosInventario { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<ProductoCategoria> ProductoCategoria { get; set; }
        public virtual DbSet<RazonMovimientoInventario> RazonMovimientoInventario { get; set; }
        public virtual DbSet<ServicioFacturaElectronica> ServicioFacturaElectronica { get; set; }
        public virtual DbSet<TipoCedula> TipoCedula { get; set; }
        public virtual DbSet<TipoCondicionVenta> TipoCondicionVenta { get; set; }
        public virtual DbSet<TipoDocumentosReferencia> TipoDocumentosReferencia { get; set; }
        public virtual DbSet<TipoExoneraciones> TipoExoneraciones { get; set; }
        public virtual DbSet<TipoFigura> TipoFigura { get; set; }
        public virtual DbSet<TipoImpuestos> TipoImpuestos { get; set; }
        public virtual DbSet<TipoPago> TipoPago { get; set; }
        public virtual DbSet<TipoUnidadesMedida> TipoUnidadesMedida { get; set; }
        public virtual DbSet<Ubicacion> Ubicacion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });
            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.ToTable("DetalleFactura", "pos");

                entity.Property(e => e.ExoneracionFechaEmision)
                    .HasColumnName("Exoneracion_FechaEmision")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExoneracionMontoImpuesto)
                            .HasColumnName("Exoneracion_MontoImpuesto")
                            .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.ExoneracionNombreInstitucion)
                            .HasColumnName("Exoneracion_NombreInstitucion")
                            .HasMaxLength(200)
                            .IsUnicode(false);

                entity.Property(e => e.ExoneracionPorcentajeCompra).HasColumnName("Exoneracion_PorcentajeCompra");

                entity.Property(e => e.ImpuestoTarifa)
                            .HasColumnName("Impuesto_Tarifa")
                            .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.ImpuestoMonto)
                            .HasColumnName("Impuestp_Monto")
                            .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.MontoDescuento).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.MontoTotal).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.NaturalezaDescuento).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 5)");

                entity.HasOne(d => d.IdFacturaNavigation)
                            .WithMany(p => p.DetalleFactura)
                            .HasForeignKey(d => d.IdFactura)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_DetalleFactura_EncabezadoFactura");

                entity.HasOne(d => d.IdProductoNavigation)
                            .WithMany(p => p.DetalleFactura)
                            .HasForeignKey(d => d.IdProducto)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_DetalleFactura_Producto");
            });

            modelBuilder.Entity<EncabezadoFactura>(entity =>
            {
                entity.ToTable("EncabezadoFactura", "pos");

                entity.Property(e => e.ClaveNumerica)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoFactura)
                                .IsRequired()
                                .HasMaxLength(250)
                                .IsUnicode(false);

                entity.Property(e => e.FechaEmision).HasColumnType("datetime");

                entity.Property(e => e.IdUsuario)
                                .IsRequired()
                                .HasMaxLength(450);

                entity.Property(e => e.NumeroConsecutivo)
                                .IsRequired()
                                .HasMaxLength(20)
                                .IsUnicode(false);

                entity.Property(e => e.TotalComprobante).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TotalDescuentos).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TotalExento).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TotalGravado).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TotalImpuesto).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TotalMercanciaExenta).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TotalMercanciaGravada).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TotalServiciosExentos).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TotalServiciosGravados).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TotalVenta).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TotalVentaNeta).HasColumnType("decimal(18, 5)");

                entity.HasOne(d => d.IdEmisorNavigation)
                                .WithMany(p => p.EncabezadoFacturaIdEmisorNavigation)
                                .HasForeignKey(d => d.IdEmisor)
                                .OnDelete(DeleteBehavior.ClientSetNull)
                                .HasConstraintName("FK_EncabezadoFactura_Persona");

                entity.HasOne(d => d.IdReceptorNavigation)
                                .WithMany(p => p.EncabezadoFacturaIdReceptorNavigation)
                                .HasForeignKey(d => d.IdReceptor)
                                .OnDelete(DeleteBehavior.ClientSetNull)
                                .HasConstraintName("FK_EncabezadoFactura_Persona1");

                entity.HasOne(d => d.IdTipoCondicionVentaNavigation)
                                .WithMany(p => p.EncabezadoFactura)
                                .HasForeignKey(d => d.IdTipoCondicionVenta)
                                .OnDelete(DeleteBehavior.ClientSetNull)
                                .HasConstraintName("FK_EncabezadoFactura_TipoCondicionVenta");

                entity.HasOne(d => d.IdTipoPagoNavigation)
                                .WithMany(p => p.EncabezadoFactura)
                                .HasForeignKey(d => d.IdTipoPago)
                                .OnDelete(DeleteBehavior.ClientSetNull)
                                .HasConstraintName("FK_EncabezadoFactura_TipoPago");

                entity.HasOne(d => d.IdUsuarioNavigation)
                                .WithMany(p => p.EncabezadoFactura)
                                .HasForeignKey(d => d.IdUsuario)
                                .OnDelete(DeleteBehavior.ClientSetNull)
                                .HasConstraintName("FK_EncabezadoFactura_EncabezadoFactura");
            });

            modelBuilder.Entity<LogErrores>(entity =>
            {
                entity.ToTable("LogErrores", "pos");

                entity.Property(e => e.Fecha).HasColumnType("datetime");
            });

            modelBuilder.Entity<ModulosSistema>(entity =>
            {
                entity.ToTable("ModulosSistema", "pos");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion)
                                    .HasMaxLength(250)
                                    .IsUnicode(false);

                entity.Property(e => e.Modulo)
                                    .HasMaxLength(50)
                                    .IsUnicode(false);
            });

            modelBuilder.Entity<MovimientosInventario>(entity =>
            {
                entity.ToTable("MovimientosInventario", "pos");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdUsuario)
                                    .IsRequired()
                                    .HasMaxLength(450);

                entity.Property(e => e.TipoMovimiento)
                                    .IsRequired()
                                    .HasMaxLength(50)
                                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                                    .WithMany(p => p.MovimientosInventario)
                                    .HasForeignKey(d => d.IdUsuario)
                                    .OnDelete(DeleteBehavior.ClientSetNull)
                                    .HasConstraintName("FK_MovimientosInventario_MovimientosInventario");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Persona", "pos");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.CorreoElectronico)
                                    .IsRequired()
                                    .HasMaxLength(60)
                                    .IsUnicode(false);

                entity.Property(e => e.DireccionOtrasSenas)
                                    .HasColumnName("Direccion_OtrasSenas")
                                    .HasMaxLength(160)
                                    .IsUnicode(false);

                entity.Property(e => e.EsCorreoValido).HasDefaultValueSql("((1))");

                entity.Property(e => e.FaxCodigoPais)
                                    .HasColumnName("Fax_CodigoPais")
                                    .HasMaxLength(3)
                                    .IsUnicode(false);

                entity.Property(e => e.FaxNumero)
                                    .HasColumnName("Fax_Numero")
                                    .HasMaxLength(20)
                                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Identificacion)
                                    .IsRequired()
                                    .HasMaxLength(12)
                                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                                    .IsRequired()
                                    .HasMaxLength(250)
                                    .IsUnicode(false);

                entity.Property(e => e.NombreComercial)
                                    .HasMaxLength(250)
                                    .IsUnicode(false);

                entity.Property(e => e.TelCodigoPais)
                                    .HasColumnName("Tel_CodigoPais")
                                    .HasMaxLength(3)
                                    .IsUnicode(false);

                entity.Property(e => e.TelNumero)
                                    .HasColumnName("Tel_Numero")
                                    .HasMaxLength(20)
                                    .IsUnicode(false);

                entity.HasOne(d => d.IdIdentificacionNavigation)
                                    .WithMany(p => p.Persona)
                                    .HasForeignKey(d => d.IdIdentificacion)
                                    .HasConstraintName("FK_Persona_TipoCedula");

                entity.HasOne(d => d.IdTipoFiguraNavigation)
                                    .WithMany(p => p.Persona)
                                    .HasForeignKey(d => d.IdTipoFigura)
                                    .OnDelete(DeleteBehavior.ClientSetNull)
                                    .HasConstraintName("FK_Persona_TipoFigura");

                entity.HasOne(d => d.IdUbicacionNavigation)
                                    .WithMany(p => p.Persona)
                                    .HasForeignKey(d => d.IdUbicacion)
                                    .HasConstraintName("FK_Persona_Ubicacion");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto", "pos");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CostoUnitario).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Detalle)
                                    .IsRequired()
                                    .HasMaxLength(160)
                                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Gravado)
                                    .IsRequired()
                                    .HasColumnType("char(1)")
                                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.Nombre)
                                    .IsRequired()
                                    .HasMaxLength(160)
                                    .IsUnicode(false);

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 5)");

                entity.HasOne(d => d.IdCategoriaNavigation)
                                    .WithMany(p => p.Producto)
                                    .HasForeignKey(d => d.IdCategoria)
                                    .OnDelete(DeleteBehavior.ClientSetNull)
                                    .HasConstraintName("FK_Producto_ProductoCategoria");

                entity.HasOne(d => d.IdExoneracionNavigation)
                                    .WithMany(p => p.Producto)
                                    .HasForeignKey(d => d.IdExoneracion)
                                    .HasConstraintName("FK_Producto_TipoExoneraciones");

                entity.HasOne(d => d.IdImpuestoNavigation)
                                    .WithMany(p => p.Producto)
                                    .HasForeignKey(d => d.IdImpuesto)
                                    .HasConstraintName("FK_Producto_TipoImpuestos");

                entity.HasOne(d => d.IdProveedorNavigation)
                                    .WithMany(p => p.Producto)
                                    .HasForeignKey(d => d.IdProveedor)
                                    .OnDelete(DeleteBehavior.ClientSetNull)
                                    .HasConstraintName("FK_Producto_Persona");

                entity.HasOne(d => d.IdUnidadMedidaNavigation)
                                    .WithMany(p => p.Producto)
                                    .HasForeignKey(d => d.IdUnidadMedida)
                                    .OnDelete(DeleteBehavior.ClientSetNull)
                                    .HasConstraintName("FK_Producto_TipoUnidadesMedida");
            });

            modelBuilder.Entity<ProductoCategoria>(entity =>
            {
                entity.ToTable("ProductoCategoria", "pos");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion)
                                    .HasMaxLength(450)
                                    .IsUnicode(false);

                entity.Property(e => e.NombreCategoria)
                                    .IsRequired()
                                    .HasMaxLength(450)
                                    .IsUnicode(false);
            });

            modelBuilder.Entity<RazonMovimientoInventario>(entity =>
            {
                entity.ToTable("RazonMovimientoInventario", "pos");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion)
                                    .HasMaxLength(250)
                                    .IsUnicode(false);

                entity.Property(e => e.RazonMovimiento)
                                    .HasMaxLength(250)
                                    .IsUnicode(false);
            });

            modelBuilder.Entity<ServicioFacturaElectronica>(entity =>
            {
                entity.ToTable("ServicioFacturaElectronica", "pos");

                entity.Property(e => e.EmailEnviado).HasMaxLength(250);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.TiempoEnvio).HasColumnType("datetime");

                entity.Property(e => e.TiempoRecibido).HasColumnType("datetime");

                entity.Property(e => e.XmlFacturaElectronica).HasColumnType("xml");

                entity.HasOne(d => d.IdFacturaNavigation)
                                    .WithMany(p => p.ServicioFacturaElectronica)
                                    .HasForeignKey(d => d.IdFactura)
                                    .OnDelete(DeleteBehavior.ClientSetNull)
                                    .HasConstraintName("FK_ServicioFacturaElectronica_EncabezadoFactura");
            });

            modelBuilder.Entity<TipoCedula>(entity =>
            {
                entity.ToTable("TipoCedula", "pos");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Codigo)
                                    .HasMaxLength(2)
                                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                                    .IsRequired()
                                    .HasMaxLength(100)
                                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoCondicionVenta>(entity =>
            {
                entity.ToTable("TipoCondicionVenta", "pos");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Codigo)
                                    .HasMaxLength(2)
                                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                                    .HasMaxLength(50)
                                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoDocumentosReferencia>(entity =>
            {
                entity.ToTable("TipoDocumentosReferencia", "pos");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Codigo)
                                    .HasMaxLength(50)
                                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                                    .HasMaxLength(50)
                                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoExoneraciones>(entity =>
            {
                entity.ToTable("TipoExoneraciones", "pos");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Codigo)
                                    .HasMaxLength(2)
                                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                                    .HasMaxLength(200)
                                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoFigura>(entity =>
            {
                entity.ToTable("TipoFigura", "pos");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion)
                                    .IsRequired()
                                    .HasMaxLength(250)
                                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                                    .IsRequired()
                                    .HasMaxLength(250)
                                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoImpuestos>(entity =>
            {
                entity.ToTable("TipoImpuestos", "pos");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                                    .HasMaxLength(150)
                                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoPago>(entity =>
            {
                entity.ToTable("TipoPago", "pos");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Codigo)
                                    .HasMaxLength(2)
                                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                                    .HasMaxLength(50)
                                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUnidadesMedida>(entity =>
            {
                entity.ToTable("TipoUnidadesMedida", "pos");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Codigo)
                                    .HasMaxLength(50)
                                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                                    .HasMaxLength(200)
                                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ubicacion>(entity =>
            {
                entity.ToTable("Ubicacion", "pos");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                                    .HasMaxLength(50)
                                    .IsUnicode(false);
            });
        }

    }

}