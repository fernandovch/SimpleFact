using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml;

namespace POS.Data.Models
{
    public class ServicioFacturaElectronica
    {
        public int Id { get; set; }
        public int IdFactura { get; set; }
        public DateTime? TiempoEnvio { get; set; }
        public string XmlFacturaElectronica { get; set; }
        public DateTime? TiempoRecibido { get; set; }
        public string XmlRecibido { get; set; }
        public string EmailEnviado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool Procesada { get; set; }

        public EncabezadoFactura IdFacturaNavigation { get; set; }

    }
}
