using POS.BLogic.Intefaces;
using POS.BLogic.Utilidades;
using POS.Data.DataAccess;
using POS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLogic.Mantenimiento
{
    public class MantenimientoFacturaElectronica: IMantenimientoFacturaElectronica
    {
        #region PrivateGlobals

        private IGenericRepository<ServicioFacturaElectronica> facturaElectronica;
        private ManejoErrores log;

        #endregion
 

        public MantenimientoFacturaElectronica()
        {
            Inicializador.Init();
            facturaElectronica = DependencyInjector.Retrieve<GenericRepository<ServicioFacturaElectronica>>();
            log = new ManejoErrores();

        }

        public ServicioFacturaElectronica ActualizarEstadoFacturaElectronica(int _idFactura, bool _enviada)
        {
            ServicioFacturaElectronica factura;
            try
            {
                factura = facturaElectronica.Get(_idFactura);
                factura.Procesada = _enviada;
                return facturaElectronica.Update(factura, _idFactura);
            }
            catch (Exception _ex)
            {                
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return null;
            }

        }

        public List<ServicioFacturaElectronica> SeleccionarFacturaElectronica(int _idFactura)
        {
            List<ServicioFacturaElectronica> listaFacturas;
            try
            {
                listaFacturas = facturaElectronica.FindBy(x => x.IdFactura == _idFactura);
                return listaFacturas;
            }
            catch (Exception _ex)
            {
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return null;
            }
        }

        public List<ServicioFacturaElectronica> SeleccionarFacturaElectronicaSinEnviar()
        {
            List<ServicioFacturaElectronica> listaFacturas;
            try
            {
                listaFacturas = facturaElectronica.FindBy(x => x.Procesada == false);
                return listaFacturas;
            }
            catch (Exception _ex)
            {
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return null;
            }
        }
    }
}
