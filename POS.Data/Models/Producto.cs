
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Models
{
    public class Producto
    {
        public Producto()
        {
            DetalleFactura = new HashSet<DetalleFactura>();
        }

        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public int IdProveedor { get; set; }
        public int IdUnidadMedida { get; set; }
        public int? IdImpuesto { get; set; }
        public int? IdExoneracion { get; set; }
        public string Nombre { get; set; }
        public string Detalle { get; set; }
        public int CantidadDisponible { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal CostoUnitario { get; set; }
        public string Codigo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string Gravado { get; set; }
        public bool? Activo { get; set; }

        public ProductoCategoria IdCategoriaNavigation { get; set; }
        public TipoExoneraciones IdExoneracionNavigation { get; set; }
        public TipoImpuestos IdImpuestoNavigation { get; set; }
        public Persona IdProveedorNavigation { get; set; }
        public TipoUnidadesMedida IdUnidadMedidaNavigation { get; set; }
        public ICollection<DetalleFactura> DetalleFactura { get; set; }

    }
}
