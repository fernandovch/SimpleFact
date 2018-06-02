using Microsoft.EntityFrameworkCore;
using POS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace POS.Data.DataAccess
{
    public class SimpleFactContext:DbContext
    {
        public SimpleFactContext(DbContextOptions<SimpleFactContext> options):base(options) { }

        public DbSet<DetalleFactura> DetalleFactura { get; set; }
        public DbSet<EncabezadoFactura> EncabezadoFactura { get; set; }
        public DbSet<LogErrores> LogErrores { get; set; }
        public DbSet<ModulosSistema> ModulosSistema { get; set; }
        public DbSet<MovimientosInventario> MovimientosInventario { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<ProductoCategoria> ProductoCategoria { get; set; }
        public DbSet<RazonMovimientoInventario> RazonMovimientoInventario { get; set; }
        public DbSet<ServicioFacturaElectronica> ServicioFacturaElectronica { get; set; }
        public DbSet<TipoCedula> TipoCedula { get; set; }
        public DbSet<TipoCondicionVenta> TipoCondicionVenta { get; set; }
        public DbSet<TipoExoneraciones> TipoExoneraciones { get; set; }
        public DbSet<TipoFigura> TipoFigura { get; set; }
        public DbSet<TipoImpuestos> TipoImpuestos { get; set; }
        public DbSet<TipoPago> TipoPago { get; set; }
        public DbSet<TipoUnidadesMedida> TipoUnidadesMedida { get; set; }
        public DbSet<Ubicacion> Ubicacion { get; set; }

    }
}