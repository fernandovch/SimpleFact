using Microsoft.VisualStudio.TestTools.UnitTesting;
using POS.BLogic.Mantenimiento;
using POS.Data.DataAccess;
using POS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestBusinessLogic
{
    [TestClass]
    public class UnitTest_mantenimientoProducto
    {
        [TestMethod]
        public void InsertarProducto_ConInformacionValida()
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
            MantenimientoProducto manteprod = new MantenimientoProducto(Interface_productos, Interface_persona, Interface_categoriaProducto, Interface_unidadMedida, Interface_impuestos, Interface_exoneraciones, Interface_movimientoInventario, Interface_razonesMovInventario, Interface_logErrores);
            Producto res = manteprod.IngresarProducto(1, 1, 1, null, 1, "Nombre Prod 3", "detalle prod 3", 2, 120, 60, "20", DateTime.Now, "1", true);
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void InsertarProducto_ConCategoriaQueNoExiste()
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
            MantenimientoProducto manteprod = new MantenimientoProducto(Interface_productos, Interface_persona, Interface_categoriaProducto, Interface_unidadMedida, Interface_impuestos, Interface_exoneraciones, Interface_movimientoInventario, Interface_razonesMovInventario, Interface_logErrores);
            Producto res = manteprod.IngresarProducto(1, 1, 1, null, 1, "Nombre Prod 3", "detalle prod 3", 2, 120, 60, "20", DateTime.Now, "1", true);
            Assert.IsNull(res.Id);
        }

        [TestMethod]
        public void BuscarProductoXCodigoExistente()
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
            MantenimientoProducto manteprod = new MantenimientoProducto(Interface_productos, Interface_persona, Interface_categoriaProducto, Interface_unidadMedida, Interface_impuestos, Interface_exoneraciones, Interface_movimientoInventario, Interface_razonesMovInventario, Interface_logErrores);
            var listaP = manteprod.BuscarProductoPorCodigo("1");
            if(listaP.Count>=1)
            { 
                Assert.AreEqual(listaP[0].Codigo, "1");
            }
        }
              

        [TestMethod]
        public void BuscarProductoXCodigoQueNoExiste()
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
            MantenimientoProducto manteprod = new MantenimientoProducto(Interface_productos, Interface_persona, Interface_categoriaProducto, Interface_unidadMedida, Interface_impuestos, Interface_exoneraciones, Interface_movimientoInventario, Interface_razonesMovInventario, Interface_logErrores);
            var listaP = manteprod.BuscarProductoPorCodigo("5");
            Assert.IsNull(listaP);
        }

        [TestMethod]
        public void BuscarProveedoresCuandoHayRegistrosActivos()
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
            MantenimientoProducto manteprod = new MantenimientoProducto(Interface_productos, Interface_persona, Interface_categoriaProducto, Interface_unidadMedida, Interface_impuestos, Interface_exoneraciones, Interface_movimientoInventario, Interface_razonesMovInventario, Interface_logErrores);
            var listaP = manteprod.SeleccionarProveedores();
            Assert.IsNotNull(listaP);
        }

        [TestMethod]
        public void BusquedaProveedoresCuandoNoHayRegistrosActivos()
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
            MantenimientoProducto manteprod = new MantenimientoProducto(Interface_productos, Interface_persona, Interface_categoriaProducto, Interface_unidadMedida, Interface_impuestos, Interface_exoneraciones, Interface_movimientoInventario, Interface_razonesMovInventario, Interface_logErrores);
            var listaP = manteprod.SeleccionarProveedores();
            Assert.IsNull(listaP);
        }

        [TestMethod]
        public void BusquedaCategoriaProductos_CuandoHayRegistrosActivos()
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
            MantenimientoProducto manteprod = new MantenimientoProducto(Interface_productos, Interface_persona, Interface_categoriaProducto, Interface_unidadMedida, Interface_impuestos, Interface_exoneraciones, Interface_movimientoInventario, Interface_razonesMovInventario, Interface_logErrores);
            var listaP = manteprod.SeleccionarProveedores();
            Assert.IsNull(listaP);
        }
    }
}
