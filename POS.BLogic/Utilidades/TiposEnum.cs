using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLogic.Utilidades
{
        public enum EstadoFactura
        {
            Activa = 'A',
            Cancelada = 'C',
            Pendiente = 'P'
        }

        public enum ModuloSistema
        {
            Facturacion = 1,
            MantenimientoProducto = 2,
            MantenimientoPersona = 3,
            MantenimientoFacturaElectronica = 4
        }

        public enum TipoMovimiento
        {
            Ingreso = 'I'
        }

        public enum TipoDocumento
        {
            FacturaElectronica = 1,
            NotaDebito = 2,
            NotaCredito = 3,
            TiqueteElectronico = 4,
            NotaDespacho = 5,
            Contrato = 6,
            Procedimiento = 7,
            ComprobanteEmitidoContingencia = 8,
            Otros = 9
        }

        public enum SituacionComprobante
        {
            Normal = 1,
            Contingencia = 2,
            SinInternet = 3
        }

}
