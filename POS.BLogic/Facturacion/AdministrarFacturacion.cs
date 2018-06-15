using POS.Data.DataAccess;
using POS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLogic.Facturacion
{
    public class AdministrarFacturacion
    {
        private IGenericRepository<EncabezadoFactura> Interface_encabezadoFactura;
        private IGenericRepository<DetalleFactura> Interface_detalleFactura;
        private IGenericRepository<Persona> Interface_persona;
        private IGenericRepository<TipoPago> Interface_tipoPago;
        private IGenericRepository<TipoCondicionVenta> Interface_tipoCondicionVenta;
        private IGenericRepository<Producto> Interface_producto;
        private IGenericRepository<TipoImpuestos> Interface_impuestos;
        private IGenericRepository<TipoExoneraciones> Interface_exoneracion;
        private IGenericRepository<ServicioFacturaElectronica> Interface_facturaElectronica;

        public AdministrarFacturacion(IGenericRepository<EncabezadoFactura> _encabezadoFactura,
         IGenericRepository<DetalleFactura> _detalleFactura,
         IGenericRepository<Persona> _persona,
         IGenericRepository<TipoPago> _tipoPago,
         IGenericRepository<TipoCondicionVenta> _tipoCondicionVenta,
         IGenericRepository<Producto> _producto,
         IGenericRepository<TipoImpuestos> _impuestos,
         IGenericRepository<TipoExoneraciones>_exoneracion,
         IGenericRepository<ServicioFacturaElectronica> _facturaElectronica)
        {
            Interface_encabezadoFactura = _encabezadoFactura;
            Interface_detalleFactura = _detalleFactura;
            Interface_persona = _persona;
            Interface_tipoPago = _tipoPago;
            Interface_tipoCondicionVenta = _tipoCondicionVenta;
            Interface_producto = _producto;
            Interface_impuestos = _impuestos;
            Interface_exoneracion = _exoneracion;
            Interface_facturaElectronica = _facturaElectronica;

        }

        /// <summary>
        /// Crea el encabezado de la factura y su # para poder relacionar con el detalle factura.
        /// </summary>
        /// <param name="_claveNumerica"></param>
        /// <param name="_numConsecutivo"></param>
        /// <param name="_fechaEmision"></param>
        /// <param name="_idEmisor"></param>
        /// <param name="_idReceptor"></param>
        /// <param name="_idTipoPago"></param>
        /// <param name="_idCondicionVenta"></param>
        /// <param name="_idUsuario"></param>
        /// <param name="_estadoFactura"></param>
        /// <param name="_totalServiciosGravados"></param>
        /// <param name="_totalServiciosExentos"></param>
        /// <param name="_totalMercanciaGravada"></param>
        /// <param name="_totalMercanciaExenta"></param>
        /// <param name="_totalGravado"></param>
        /// <param name="_totalExento"></param>
        /// <param name="_totalVenta"></param>
        /// <param name="_totalDescuento"></param>
        /// <param name="_totalVentaNeta"></param>
        /// <param name="_totalImpuesto"></param>
        /// <param name="_totalComprobante"></param>
        /// <returns></returns>
        public EncabezadoFactura CrearEncabezadoFactura(string _claveNumerica, string _numConsecutivo, DateTime _fechaEmision, int _idEmisor,
            int _idReceptor, int _idTipoPago, int _idCondicionVenta, string _idUsuario, string _estadoFactura, decimal _totalServiciosGravados,
            decimal _totalServiciosExentos, decimal _totalMercanciaGravada, decimal? _totalMercanciaExenta, decimal? _totalGravado, decimal _totalExento,
            decimal? _totalVenta, decimal? _totalDescuento, decimal? _totalVentaNeta, decimal? _totalImpuesto,decimal? _totalComprobante)
        {
            EncabezadoFactura encabezado;
            try
            {
                encabezado = new EncabezadoFactura();
                encabezado.ClaveNumerica = _claveNumerica;
                encabezado.NumeroConsecutivo = _numConsecutivo;
                encabezado.FechaEmision = _fechaEmision;
                encabezado.IdEmisor = _idEmisor;
                encabezado.IdReceptor = _idReceptor;
                encabezado.IdTipoPago = _idTipoPago;
                encabezado.IdTipoCondicionVenta = _idCondicionVenta;
                encabezado.IdUsuario = _idUsuario;
                encabezado.EstadoFactura = _estadoFactura;
                encabezado.TotalServiciosGravados = _totalServiciosGravados;
                encabezado.TotalServiciosExentos = _totalServiciosExentos;
                encabezado.TotalMercanciaGravada = _totalMercanciaGravada;
                encabezado.TotalMercanciaExenta = _totalMercanciaExenta;
                encabezado.TotalGravado = _totalGravado;
                encabezado.TotalExento = _totalExento;
                encabezado.TotalVenta = _totalVenta;
                encabezado.TotalDescuentos = _totalDescuento;
                encabezado.TotalVentaNeta = _totalVentaNeta;
                encabezado.TotalImpuesto = _totalImpuesto;
                encabezado.TotalComprobante = _totalComprobante;
                return Interface_encabezadoFactura.Add(encabezado);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Crea detalle de factura por cada producto, creando la relacion entre el encabezado y el detalle.
        /// </summary>
        /// <param name="_idFactura"></param>
        /// <param name="_idProducto"></param>
        /// <param name="_cantidad"></param>
        /// <param name="_exoneracionNombreInstitucion"></param>
        /// <param name="_exoneracionFechaEmision"></param>
        /// <param name="_exoneracionMontoImpuesto"></param>
        /// <param name="_exoneracionPorcentajeCompra"></param>
        /// <param name="_impuestoTarifa"></param>
        /// <param name="_impuestoMonto"></param>
        /// <param name="_montoDescuento"></param>
        /// <param name="_naturalezaDescuento"></param>
        /// <param name="_subTotal"></param>
        /// <param name="_montoTotal"></param>
        /// <returns></returns>
        public DetalleFactura CrearDetalleFactura(int _idFactura, int _idProducto, int _cantidad, string _exoneracionNombreInstitucion, 
            DateTime? _exoneracionFechaEmision, decimal? _exoneracionMontoImpuesto, int? _exoneracionPorcentajeCompra, decimal? _impuestoTarifa,
            decimal? _impuestoMonto, decimal? _montoDescuento, decimal? _naturalezaDescuento, decimal? _subTotal, decimal? _montoTotal)
        {
            DetalleFactura detalle;
            try
            {
                detalle = new DetalleFactura();
                detalle.IdFactura = _idFactura;
                detalle.IdProducto = _idProducto;
                detalle.Cantidad = _cantidad;
                detalle.ExoneracionNombreInstitucion = _exoneracionNombreInstitucion;
                detalle.ExoneracionFechaEmision = _exoneracionFechaEmision;
                detalle.ExoneracionMontoImpuesto = _exoneracionMontoImpuesto;
                detalle.ExoneracionPorcentajeCompra = _exoneracionPorcentajeCompra;
                detalle.ImpuestoTarifa = _impuestoTarifa;
                detalle.ImpuestoMonto = _impuestoMonto;
                detalle.MontoDescuento = _montoDescuento;
                detalle.NaturalezaDescuento = _naturalezaDescuento;
                detalle.SubTotal = _subTotal;
                detalle.MontoTotal = _montoTotal;
                return Interface_detalleFactura.Add(detalle);
            }
            catch (Exception ex)
            {
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
            List<Persona> p;
            try
            {
                p = Interface_persona.FindBy(x => x.Identificacion == _cedula);
                return p;
            }
            catch (Exception ex)
            {
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
                pago = Interface_tipoPago.FindBy(x => x.Activo == true);
                return pago;
            }
            catch (Exception ex)
            {
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
                condicionV = Interface_tipoCondicionVenta.FindBy(x => x.Activo == true);
                return condicionV;
            }
            catch (Exception ex)
            {
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
                consecutivo = Interface_encabezadoFactura.GetMaxValue(x => int.Parse(x.NumeroConsecutivo));
                return consecutivo;
            }
            catch(Exception _ex)
            {
                return 0;
            }
        }


               
    }

}
