using POS.BLogic.Intefaces;
using POS.BLogic.Utilidades;
using POS.Data.DataAccess;
using POS.Data.Models;
using System;
using System.Collections.Generic;

namespace POS.BLogic.Facturacion
{
    public class AdministrarFacturacion : IAdministracionFactura
    {
        private IGenericRepository<EncabezadoFactura> encabezadoFactura;
        private IGenericRepository<DetalleFactura> detalleFactura;
        private IGenericRepository<Persona> sujeto;
        private IGenericRepository<TipoPago> tipoPago;
        private IGenericRepository<TipoCondicionVenta> tipoCondicionVenta;
        private IGenericRepository<Producto> producto;
        private IGenericRepository<TipoImpuestos> impuestos;
        private IGenericRepository<TipoExoneraciones> exoneracion;
        private IGenericRepository<ServicioFacturaElectronica> facturaElectronica;

        private IGenericRepository<LogErrores> logErrores;
        private ManejoErrores log;

        public AdministrarFacturacion()
        {
            Inicializador.Init();
            encabezadoFactura = DependencyInjector.Retrieve<GenericRepository<EncabezadoFactura>>();
            detalleFactura = DependencyInjector.Retrieve<GenericRepository<DetalleFactura>>();
            sujeto = DependencyInjector.Retrieve<GenericRepository<Persona>>();
            tipoPago = DependencyInjector.Retrieve<GenericRepository<TipoPago>>();
            tipoCondicionVenta = DependencyInjector.Retrieve<GenericRepository<TipoCondicionVenta>>();
            producto = DependencyInjector.Retrieve<GenericRepository<Producto>>();
            impuestos = DependencyInjector.Retrieve<GenericRepository<TipoImpuestos>>();
            exoneracion = DependencyInjector.Retrieve<GenericRepository<TipoExoneraciones>>();
            facturaElectronica = DependencyInjector.Retrieve<GenericRepository<ServicioFacturaElectronica>>();
            logErrores = DependencyInjector.Retrieve<GenericRepository<LogErrores>>();

        }

        /// <summary>
        /// Crea el encabezado de la factura y su # para poder relacionar con el detalle factura.
        /// </summary>
       
        /// <returns></returns>
        public EncabezadoFactura CrearEncabezadoFactura(EncabezadoFactura _encabezado)
        {
            try
            {
                return encabezadoFactura.Add(_encabezado);
            }
            catch (Exception _ex)
            {
                log = new ManejoErrores(logErrores);
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Crea detalle de factura por cada producto, creando la relacion entre el encabezado y el detalle.
        /// </summary>
       
        /// <returns></returns>
        public DetalleFactura CrearDetalleFactura(DetalleFactura _detalle)
        {
            try
            {
                return detalleFactura.Add(_detalle);
            }
            catch (Exception _ex)
            {
                log = new ManejoErrores(logErrores);
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Busca proveedores que hagan match con el numero de cedula.
        /// </summary>
        /// <param name="_cedula"></param>
        /// <returns></returns>
        public List<Persona> BuscarReceptor(string _cedula)
        {
            List<Persona> persona;
            try
            {
                persona = sujeto.FindBy(x => x.Identificacion == _cedula);
                return persona;
            }
            catch (Exception _ex)
            {
                log = new ManejoErrores(logErrores);
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Selecciona todos los tipos de pago que se encuentren activos.
        /// </summary>
        /// <returns></returns>
        public List<TipoPago> BuscarTipoPago()
        {
            List<TipoPago> pago;
            try
            {
                pago = tipoPago.FindBy(x => x.Activo == true);
                return pago;
            }
            catch (Exception _ex)
            {
                log = new ManejoErrores(logErrores);
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Selecciona todos los tipos de condicion de venta que estén activos.
        /// </summary>
        /// <returns></returns>
        public List<TipoCondicionVenta> BuscanCondicionVenta()
        {
            List<TipoCondicionVenta> condicionV;
            try
            {
                condicionV = tipoCondicionVenta.FindBy(x => x.Activo == true);
                return condicionV;
            }
            catch (Exception _ex)
            {
                log = new ManejoErrores(logErrores);
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Obtiene el numero maximo consecutivo ingresado en una factura, para poder continuar la numeración.
        /// </summary>
        /// <returns></returns>
        public int ObtenerConsecutivo()
        {
            int consecutivo;
            try
            {
                consecutivo = encabezadoFactura.GetMaxValue(x => int.Parse(x.NumeroConsecutivo));
                return consecutivo;
            }
            catch (Exception _ex)
            {
                log = new ManejoErrores(logErrores);
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.StackTrace);

                return -1;
            }
        }


               
    }

}
