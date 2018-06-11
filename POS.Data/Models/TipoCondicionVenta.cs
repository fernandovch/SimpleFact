using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Models
{
    public class TipoCondicionVenta
    {
        public TipoCondicionVenta()
        {
            EncabezadoFactura = new HashSet<EncabezadoFactura>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public bool? Activo { get; set; }

        public ICollection<EncabezadoFactura> EncabezadoFactura { get; set; }
    }
}
