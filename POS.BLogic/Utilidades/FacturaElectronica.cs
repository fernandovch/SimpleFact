using POS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace POS.BLogic.Utilidades
{
    public class FacturaElectronica
    {
        public EncabezadoFactura EncabezadoFacturaElectronica { get; set; }
        public DetalleFactura DetalleFacturaElectronica { get; set; }
        public XmlDocument ComprobanteXml { get; set; }
    }
}
