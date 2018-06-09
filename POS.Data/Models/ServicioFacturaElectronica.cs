using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml;

namespace POS.Data.Models
{
    public class ServicioFacturaElectronica
    {
        [Key]
        public int Id { get; set; }
        public int IdFactura { get; set; }
        public DateTime TiempoEnvio { get; set; }
        public XmlDocument XMLFacturaElectronica { get; set; }
        public DateTime TiempoRecibido { get; set; }
        public XmlDocument XMLRecibido { get; set; }
        public string EmailEnviado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Enviada { get; set; }

    }
}
