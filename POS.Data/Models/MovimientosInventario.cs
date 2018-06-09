using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Models
{
    public class MovimientosInventario
    {
        [Key]
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public string TipoMovimiento { get; set; }
        public int IdRazonMovimiento { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }

    }
}
