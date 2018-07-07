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
        #region PrivateGlobals
        private IGenericRepository<EncabezadoFactura> encabezadoFactura;
        private IGenericRepository<DetalleFactura> detalleFactura;
        private IGenericRepository<Persona> sujeto;
        private IGenericRepository<TipoPago> tipoPago;
        private IGenericRepository<TipoCondicionVenta> tipoCondicionVenta;
        private IGenericRepository<Producto> producto;
        private IGenericRepository<TipoImpuestos> impuestos;
        private IGenericRepository<TipoExoneraciones> exoneracion;
        private IGenericRepository<ServicioFacturaElectronica> facturaElectronica;
        private ManejoErrores log;
        private Settings setting = new Settings();

        #endregion

        #region PublicGlobals
        public EncabezadoFactura globalVar_EncabezadoFactura;
        public DetalleFactura globalVar_DetalleFactura;

        #endregion

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
            log = new ManejoErrores();
            globalVar_EncabezadoFactura = new EncabezadoFactura();
            globalVar_DetalleFactura = new DetalleFactura();

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
                log.RegistrarErrorLog((int)ModuloSistema.Facturacion, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
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
                log.RegistrarErrorLog((int)ModuloSistema.Facturacion, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
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
                log.RegistrarErrorLog((int)ModuloSistema.Facturacion, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
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
                log.RegistrarErrorLog((int)ModuloSistema.Facturacion, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
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
                log.RegistrarErrorLog((int)ModuloSistema.Facturacion, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
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
                return consecutivo+1;
            }
            catch (Exception _ex)
            {
                log.RegistrarErrorLog((int)ModuloSistema.Facturacion, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return -1;
            }
        }

        public string GenerarClaveNumerica(string _situacionComprobante)
        {
            ///Primeros 3 digitos
            string codPais = string.Empty;
            /// dia en que se genera la factura 2 digitos (4-5)
            string dia = string.Empty;
            // mes en que se genera la factura 2 digitos (6-7)
            string mes = string.Empty;
            // anno en que se genera la factura 2 digitos (8-9)
            string anno = string.Empty;
            // numero de cedula del contribuyente 10 digitos (10-21)
            string numCedula = string.Empty;
            // numero consecutivo del comprobante electronico 19 digitos (22-41)
            string numConsecutivo = string.Empty;
            // numero codigo de seguridad 7 digitos (43-50)
            string codSeguridad = string.Empty;
            // string clave numerica
            string claveNumerica = string.Empty;

            try
            {
                codPais = setting.Codigo_Pais;
                dia = DateTime.Now.ToString("dd");
                mes = DateTime.Now.ToString("MM");
                anno = DateTime.Now.ToString("yy");
                numCedula = setting.Numero_Cedula;
                numConsecutivo = ObtenerConsecutivo().ToString().PadLeft(19,'0');
                codSeguridad = numConsecutivo.PadLeft(7, '0');
                claveNumerica = codPais + dia + mes + anno + numCedula + numConsecutivo + _situacionComprobante + codSeguridad;
                return claveNumerica;
            }
            catch (Exception _ex)
            {
                log.RegistrarErrorLog((int)ModuloSistema.Facturacion, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return null;
            }
        }

    }

}
