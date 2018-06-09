using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public int IdProveedor { get; set; }
        public int IdUnidadMedida { get; set; }
        public int IdImpuesto { get; set; }
        public int IdExoneraciones { get; set; }
        public string Nombre { get; set; }
        public string Detalle { get; set; }
        public int CantidadDisponible { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal CostoUnitario { get; set; }
        public string Codigo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool Gravado { get; set; }
        public bool Activo { get; set; }

    }
}
