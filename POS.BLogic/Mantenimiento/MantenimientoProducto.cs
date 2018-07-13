using POS.BLogic.Interfaces;
using POS.BLogic.Utilidades;
using POS.Data.DataAccess;
using POS.Data.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace POS.BLogic.Mantenimiento
{
    public class MantenimientoProducto : IMantemientoProducto
    {

        #region PrivateGlobals

        private IGenericRepository<Persona> sujeto;
        private IGenericRepository<Producto> producto;
        private IGenericRepository<ProductoCategoria> productoCategoria;
        private IGenericRepository<MovimientosInventario> movimiento;
        private IGenericRepository<RazonMovimientoInventario> razones;
        private IGenericRepository<TipoImpuestos> impuestos;
        private IGenericRepository<TipoExoneraciones> exoneraciones;
        private ManejoErrores log;

        #endregion

        #region PublicGlobals

        public MovimientosInventario globalVar_MovInventario;
        public Producto globalVar_Producto;

        #endregion

        public MantenimientoProducto() {

            Inicializador.Init();

            sujeto = DependencyInjector.Retrieve<GenericRepository<Persona>>();
            producto = DependencyInjector.Retrieve<GenericRepository<Producto>>();
            productoCategoria = DependencyInjector.Retrieve<GenericRepository<ProductoCategoria>>();
            movimiento = DependencyInjector.Retrieve<GenericRepository<MovimientosInventario>>();
            razones = DependencyInjector.Retrieve<GenericRepository<RazonMovimientoInventario>>();
            impuestos = DependencyInjector.Retrieve<GenericRepository<TipoImpuestos>>();
            exoneraciones = DependencyInjector.Retrieve<GenericRepository<TipoExoneraciones>>();
            globalVar_MovInventario = new MovimientosInventario();

        }

        public MovimientosInventario AgregarMovimientosInventario(MovimientosInventario _movimiento)
        {
            try { 
            return movimiento.Add(_movimiento);
            }
            catch (Exception _ex)
            {
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.InnerException.Message);
                return null;
            }
        }

        public Producto AgregarProducto(Producto _producto)
        {
            try { 
            return producto.Add(_producto);
            }
            catch (Exception _ex)
            {              
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.InnerException.Message);
                return null;
            }
        }

        public List<Producto> BuscarProducto(string parametro, string valor)
        {

            List<Producto> productResult;
            PropertyInfo property = typeof(Producto).GetProperty(parametro);
            string ColumnName = property.Name;
            try
            {
                productResult = producto.FindBy(x => x.Codigo == "1");
                return productResult;
            }
            catch (Exception _ex)
            {            
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.InnerException.Message);
                return null;
            }
        }

        public List<Producto> SeleccionarTodos()
        {            
            try
            {
                return producto.FindBy(x => x.Activo == true);
            }
            catch (Exception _ex)
            {
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.InnerException.Message);
                return null;
            }
        }

        public List<Producto> BuscarProductoPorCodigo(string _codigo)
        {

            List<Producto> productResult;

            try
            {
                return productResult = producto.FindBy(x => x.Codigo == _codigo);
            }
            catch (Exception _ex)
            {
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.InnerException.Message);
                return null;
            }
        }

        public List<Producto> BuscarProductoPorId(int _id)
        {

            List<Producto> productResult;

            try
            {
                return productResult = producto.FindBy(x => x.Id == _id);
                //return productResult = producto.Get(_id);
            }
            catch (Exception _ex)
            {
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.InnerException.Message);
                return null;
            }
        }

        public Producto ModificarProducto(Producto _producto)
        {
            try
            {
                return producto.Update(_producto, _producto.Id);
            }
            catch (Exception _ex)
            {
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return null;
            }
        }

        public List<ProductoCategoria> SeleccionarCategoriasProducto()
        {
            List<ProductoCategoria> ListProdCategoria;
            try
            {
                ListProdCategoria = productoCategoria.FindBy(x => x.Activo == true);
                return ListProdCategoria;
            }
            catch (Exception _ex)
            {
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return null;
            }
        }

        public List<Persona> SeleccionarProveedores()
        {
            try {
                return sujeto.FindBy(x => x.Activo == true);
            }
            catch (Exception _ex)
            {
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return null;
            }
        }

        public List<RazonMovimientoInventario> SeleccionarRazonesMovimientoInventario()
        {

            List<RazonMovimientoInventario> razonesMovimiento;
            try
            {
                razonesMovimiento = razones.FindBy(x => x.Activo == true);
                return razonesMovimiento;
            }
            catch (Exception _ex)
            {
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.InnerException.Message);
                return null;
            }
        }

        public List<TipoExoneraciones> SeleccionarTipoExoneraciones()
        {
            List<TipoExoneraciones> ListTipoExoneraciones;

            try
            {
                ListTipoExoneraciones = exoneraciones.FindBy(x => x.Activo == true);
                return ListTipoExoneraciones;
            }
            catch (Exception _ex)
            {
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return null;
            }
        }

        public List<TipoImpuestos> SeleccionarTiposImpuestos()
        {
            List<TipoImpuestos> ListTipoImp;

            try
            {
                ListTipoImp = impuestos.FindBy(x => x.Excepcion == false);
                return ListTipoImp;
            }
            catch (Exception _ex)
            {
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return null;
            }
        }
    }
}
