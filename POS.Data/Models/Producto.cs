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
        public ProductoCategoria Categoria { get; set; }
        public Persona Proveedor { get; set; }
        public TipoUnidadesMedida UnidadMedida { get; set; }
        public TipoImpuestos Impuesto { get; set; }
        public TipoExoneraciones Exoneraciones { get; set; }
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
