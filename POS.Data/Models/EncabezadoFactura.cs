using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Models
{
    public class EncabezadoFactura
    {
        [Key]
        public int Id { get; set; }
        public string ClaveNumerica { get; set; }
        public string NumeroConsecutivo { get; set; }
        public DateTime FechaEmision { get; set; }
        public Persona Emisor { get; set; }
        public Persona Receptor { get; set; }
        public TipoPago TipoPago { get; set; }
        public TipoCondicionVenta CondicionVenta { get; set; }
        public int IdUsuario { get; set; }
        public string EstadoFactura { get; set; }

    }
}
