using POS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLogic.Intefaces
{
    public interface IAdministracionFactura
    {
        EncabezadoFactura CrearEncabezadoFactura(EncabezadoFactura _encabezado);
        DetalleFactura CrearDetalleFactura(DetalleFactura _detalle);
        List<Persona> BuscarReceptor(string _cedula);
        List<TipoPago> BuscarTipoPago();
        List<TipoCondicionVenta> BuscanCondicionVenta();
        int ObtenerConsecutivo();
    }
}
