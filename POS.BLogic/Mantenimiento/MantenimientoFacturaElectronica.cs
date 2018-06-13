using POS.Data.DataAccess;
using POS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLogic.Mantenimiento
{
    public class MantenimientoFacturaElectronica
    {
        private IGenericRepository<ServicioFacturaElectronica> Interface_facturaElectronica;

        public MantenimientoFacturaElectronica(IGenericRepository<ServicioFacturaElectronica> _facturaElectronica)
        {
            Interface_facturaElectronica = _facturaElectronica;
        }

        /// <summary>
        /// Buscar facturas por id
        /// </summary>
        /// <param name="_idFactura"></param>
        /// <returns></returns>
        public List<ServicioFacturaElectronica> SeleccionarFacturaElectronica(int _idFactura)
        {
            List<ServicioFacturaElectronica> listaFacturas;
            try
            {
                listaFacturas = Interface_facturaElectronica.FindBy(x => x.IdFactura == _idFactura);
                return listaFacturas;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Seleccionar facturas electrónicas sin enviar a hacienda.
        /// </summary>
        /// <returns></returns>
        public List<ServicioFacturaElectronica> SeleccionarFacturaElectronicaSinEnviar()
        {
            List<ServicioFacturaElectronica> listaFacturas;
            try
            {
                listaFacturas = Interface_facturaElectronica.FindBy(x => x.Procesada == false);
                return listaFacturas;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Actualizar el estado de la factura electronica.
        /// </summary>
        /// <param name="_idFactura"></param>
        /// <returns></returns>
        public ServicioFacturaElectronica ActualizarEstadoFacturaElectronica(int _idFactura, bool _enviada)
        {
            ServicioFacturaElectronica factura;
            try
            {
                factura = Interface_facturaElectronica.Get(_idFactura);
                factura.Procesada = _enviada;
                return Interface_facturaElectronica.Update(factura, _idFactura);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
