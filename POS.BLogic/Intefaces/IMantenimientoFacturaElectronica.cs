using POS.Data.Models;
using System.Collections.Generic;

namespace POS.BLogic.Intefaces
{
    public interface IMantenimientoFacturaElectronica
    {
        ServicioFacturaElectronica ActualizarEstadoFacturaElectronica(int _idFactura, bool _enviada);
        List<ServicioFacturaElectronica> SeleccionarFacturaElectronica(int _idFactura);
        List<ServicioFacturaElectronica> SeleccionarFacturaElectronicaSinEnviar();
    }
}
