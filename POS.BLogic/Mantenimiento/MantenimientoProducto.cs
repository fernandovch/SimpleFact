using Microsoft.Extensions.DependencyInjection;
using POS.BLogic.Utilidades;
using POS.Data.DataAccess;
using POS.Data.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace POS.BLogic.Mantenimiento
{
    public class MantenimientoProducto
    {

        private IGenericRepository<Producto> Interface_productos;
        private IGenericRepository<Persona> Interface_persona;
        private IGenericRepository<ProductoCategoria> Interface_categoriaProducto;
        private IGenericRepository<TipoUnidadesMedida> Interface_unidadMedida;
        private IGenericRepository<TipoImpuestos> Interface_impuestos;
        private IGenericRepository<TipoExoneraciones> Interface_exoneraciones;
        private IGenericRepository<MovimientosInventario> Interface_movimientoInventario;
        private IGenericRepository<RazonMovimientoInventario> Interface_razonesMovInventario;
        private IGenericRepository<LogErrores> Interface_logErrores;
        private ManejoErrores log;

        public MantenimientoProducto( IGenericRepository<Producto> produc,
        IGenericRepository<Persona> _persona,
        IGenericRepository<ProductoCategoria> _categoriaProducto,
        IGenericRepository<TipoUnidadesMedida> _unidadMedida,
        IGenericRepository<TipoImpuestos> _impuestos,
        IGenericRepository<TipoExoneraciones> _exoneraciones,
        IGenericRepository<MovimientosInventario> _movimientoInventario,
        IGenericRepository<RazonMovimientoInventario> _razonesMovInventario,
        IGenericRepository<LogErrores> _logErrores)
        {
            Interface_productos = produc;
            Interface_persona = _persona;
            Interface_categoriaProducto = _categoriaProducto;
            Interface_unidadMedida = _unidadMedida;
            Interface_impuestos = _impuestos;
            Interface_exoneraciones = _exoneraciones;
            Interface_movimientoInventario = _movimientoInventario;
            Interface_razonesMovInventario = _razonesMovInventario;
            Interface_logErrores = _logErrores;

        }

        /// <summary>
        /// Busqueda de producto por codigo de barras
        /// </summary>
        /// <param name="_codigo"></param>
        /// <returns></returns>
        public List<Producto> BuscarProductoPorCodigo(string _codigo)
        {
            List<Producto> productResult;
            
            try
            {
                return productResult = Interface_productos.FindBy(x => x.Codigo == _codigo);               
                //return null;
            }
            catch(Exception _ex)
            {
                log = new ManejoErrores(Interface_logErrores);
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.InnerException.Message);
                return null;
            }
            
        }

        /// <summary>
        /// Seleccionar todos los proveedores activos.
        /// </summary>
        /// <returns></returns>
        public List<Persona> SeleccionarProveedores()
        {
            List<Persona> ListProveedores;
            try
            {
                ListProveedores = Interface_persona.FindBy(x => x.Activo == true);
                return ListProveedores;
            }
            catch(Exception _ex)
            {
                log = new ManejoErrores(Interface_logErrores);
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Seleccionar todas las categorias de producto que estén activas.
        /// </summary>
        /// <returns></returns>
        public List<ProductoCategoria> SeleccionarCategoriasProducto()
        {
            List<ProductoCategoria> ListProdCategoria;
            try
            {
                ListProdCategoria = Interface_categoriaProducto.FindBy(x => x.Activo == true);
                return ListProdCategoria;
            }
            catch(Exception _ex)
            {
                log = new ManejoErrores(Interface_logErrores);
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Seleccionar todos los impuestos excluyendo las excepciones.
        /// </summary>
        /// <returns></returns>
        public List<TipoImpuestos> SeleccionarTiposImpuestos()
        {
            List<TipoImpuestos> ListTipoImp;

            try
            {
                ListTipoImp = Interface_impuestos.FindBy(x => x.Excepcion == false);
                return ListTipoImp;
            }
            catch(Exception _ex)
            {
                log = new ManejoErrores(Interface_logErrores);
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Seleccionar los tipos de exoneraciones excluyendo los tipos inactivos.
        /// </summary>
        /// <returns></returns>
        public List<TipoExoneraciones> SeleccionarTipoExoneraciones()
        {
            List<TipoExoneraciones> ListTipoExoneraciones;

            try
            {
                ListTipoExoneraciones = Interface_exoneraciones.FindBy(x => x.Activo == true);
                return ListTipoExoneraciones;
            }
            catch(Exception _ex)
            {
                log = new ManejoErrores(Interface_logErrores);
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return null;
            }
        }

        
        /// <summary>
        /// Actualizar atributos de producto.
        /// </summary>
        /// <param name="_producto"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Producto ModificarProducto(int _idCategoria, int _idProveedor, int? _idImpuesto, int? _idExoneracion, int _idUnidadMedida, string _nombre, string _detalle,
             int _cantDisponible, decimal _precioUnitario, decimal _costoUnitario, string _codigo, DateTime _fechaModificacion, string _gravado, bool _activo, int _id)
        {
            Producto prodActualizar;

            try
            {
                prodActualizar = new Producto();
               // prodActualizar.Id = _id;
                prodActualizar.IdCategoria = _idCategoria;
                prodActualizar.IdProveedor = _idProveedor;
                prodActualizar.IdImpuesto = _idImpuesto;
                prodActualizar.IdExoneracion = _idExoneracion;
                prodActualizar.IdUnidadMedida = _idUnidadMedida;
                prodActualizar.Nombre = _nombre;
                prodActualizar.Detalle = _detalle;
                prodActualizar.CantidadDisponible = _cantDisponible;
                prodActualizar.PrecioUnitario = _precioUnitario;
                prodActualizar.CostoUnitario = _costoUnitario;
                prodActualizar.Codigo = _codigo;
                prodActualizar.FechaModificacion = _fechaModificacion;
                prodActualizar.Gravado = _gravado;
                prodActualizar.Activo = _activo;
                return Interface_productos.Update(prodActualizar, _id);
                //productResult = repositorioProducto.Update(_producto, key);
                
            }
            catch(Exception _ex)
            {
                log = new ManejoErrores(Interface_logErrores);
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Ingresar un nuevo producto.
        /// </summary>
        /// <param name="_producto"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Producto IngresarProducto(int _idCategoria, int _idProveedor, int? _idImpuesto, int? _idExoneracion, int _idUnidadMedida, string _nombre, string _detalle,
             int _cantDisponible, decimal _precioUnitario, decimal _costoUnitario, string _codigo, DateTime _fechaModificacion, string _gravado, bool _activo)
        {
            Producto prodActualizar;

            try
            {
                prodActualizar = new Producto();
                prodActualizar.IdCategoria = _idCategoria;
                prodActualizar.IdProveedor = _idProveedor;
                prodActualizar.IdImpuesto = _idImpuesto;
                prodActualizar.IdExoneracion = _idExoneracion;
                prodActualizar.IdUnidadMedida = _idUnidadMedida;
                prodActualizar.Nombre = _nombre;
                prodActualizar.Detalle = _detalle;
                prodActualizar.CantidadDisponible = _cantDisponible;
                prodActualizar.PrecioUnitario = _precioUnitario;
                prodActualizar.CostoUnitario = _costoUnitario;
                prodActualizar.Codigo = _codigo;
                prodActualizar.FechaModificacion = _fechaModificacion;
                prodActualizar.FechaCreacion = DateTime.Now;
                prodActualizar.Gravado = _gravado;
                prodActualizar.Activo = _activo;
                return Interface_productos.Add(prodActualizar);
                //productResult = repositorioProducto.Update(_producto, key);

            }
            catch(Exception _ex)
            {
                log = new ManejoErrores(Interface_logErrores);
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.InnerException.Message);
                return null;
            }
        }

        /// <summary>
        /// Realizar ajuste de inventario.
        /// </summary>
        /// <param name="_idProducto"></param>
        /// <param name="_idRazon"></param>
        /// <param name="_cantActualizada"></param>
        /// <param name="_idUser"></param>
        /// <returns></returns>
        public MovimientosInventario InsertarMovimientosInventario(int _idProducto, int _idRazon, int _cantActualizada, string _idUser, string _tipoMovimiento)
        {
            MovimientosInventario movInventario;
            try
            {
                movInventario = new MovimientosInventario();
                movInventario.IdProducto = _idProducto;
                movInventario.IdRazonMovimiento = _idRazon;
                movInventario.TipoMovimiento = _tipoMovimiento;
                movInventario.IdUsuario = _idUser;
                movInventario.Cantidad = _cantActualizada;
                movInventario.Fecha = DateTime.Now;
                return Interface_movimientoInventario.Add(movInventario);

            }
            catch(Exception _ex)
            {
                log = new ManejoErrores(Interface_logErrores);
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.InnerException.Message);
                return null;
            }
        }

        /// <summary>
        /// Seleccionar razones de movimiento de inventario.
        /// </summary>
        /// <returns></returns>
        public List<RazonMovimientoInventario> SeleccionarRazonesMovimientoInventario()
        {
            List<RazonMovimientoInventario> razones;
            try
            {
                razones = Interface_razonesMovInventario.FindBy(x => x.Activo == true);
                return razones;
            }
            catch(Exception _ex)
            {
                log = new ManejoErrores(Interface_logErrores);
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
               //productResult = productos.FindBy(Producto => ColumnName == valor);               
                productResult = Interface_productos.FindBy(x => x.Codigo == "1");
                return productResult;
            }
            catch(Exception _ex)
            {
                log = new ManejoErrores(Interface_logErrores);
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.InnerException.Message);
                return null;
            }
        }
    }
}
