using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using POS.BLogic.Mantenimiento;
using POS.Data.DataAccess;
using POS.Data.Models;
using System;

namespace UnitTestBusinessLogic
{
    [TestClass]
    public class UnitTest1
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();
            return config;
        }

     
        [TestMethod]
        public void TestMethod1()
        {
            SimpleFactContext context = new SimpleFactContext();
            SimpleFactContext context2 = new SimpleFactContext();
            IGenericRepository<Producto> Interface_productos = new GenericRepository<Producto>(context);
            IGenericRepository<Persona> Interface_persona = new GenericRepository<Persona>(context);
            IGenericRepository<ProductoCategoria> Interface_categoriaProducto = new GenericRepository<ProductoCategoria>(context);
            IGenericRepository<TipoUnidadesMedida> Interface_unidadMedida = new GenericRepository<TipoUnidadesMedida>(context);
            IGenericRepository<TipoImpuestos> Interface_impuestos = new GenericRepository<TipoImpuestos>(context);
            IGenericRepository<TipoExoneraciones> Interface_exoneraciones = new GenericRepository<TipoExoneraciones>(context);
            IGenericRepository<MovimientosInventario> Interface_movimientoInventario = new GenericRepository<MovimientosInventario>(context);
            IGenericRepository<RazonMovimientoInventario> Interface_razonesMovInventario = new GenericRepository<RazonMovimientoInventario>(context);
            IGenericRepository<LogErrores> Interface_logErrores = new GenericRepository<LogErrores>(context2);
            IGenericRepository<Ubicacion> Interface_ubicacion = new GenericRepository<Ubicacion>(context);
            IGenericRepository<TipoCedula> Interface_tipoCedula = new GenericRepository<TipoCedula>(context);
            IGenericRepository<TipoFigura> Interface_tipofigura = new GenericRepository<TipoFigura>(context);
            IGenericRepository<ServicioFacturaElectronica> Interface_facturaElectronica = new GenericRepository<ServicioFacturaElectronica>(context);
            IGenericRepository<EncabezadoFactura> Interface_encabezadoF = new GenericRepository<EncabezadoFactura>(context);
            IGenericRepository<DetalleFactura> Interface_detalleF = new GenericRepository<DetalleFactura>(context);
            IGenericRepository<TipoPago> Interface_tipoPago = new GenericRepository<TipoPago>(context);
            IGenericRepository<TipoCondicionVenta> Interface_tipoCondVenta = new GenericRepository<TipoCondicionVenta>(context);

            // **************************************************** Pruebas mantenimiento producto ****************************************************

            MantenimientoProducto manteprod = new MantenimientoProducto(Interface_productos, Interface_persona, Interface_categoriaProducto, Interface_unidadMedida, Interface_impuestos, Interface_exoneraciones, Interface_movimientoInventario, Interface_razonesMovInventario, Interface_logErrores);

            /* Ingresar Producto */
            //Producto  res = manteprod.IngresarProducto(8, 1, 1,null,1, "Nombre Prod 2", "detalle prod 2", 2, 100, 50, "2", DateTime.Now, "1", true);
            
            /* Modificar Producto */ 
            Producto mod = manteprod.ModificarProducto(1, 1, 1, 1, 1, "Nombre Prod dos", "detalle prod 2", 2, 100, 50, "2", DateTime.Now, "1", true,4);
        }
    }
}

