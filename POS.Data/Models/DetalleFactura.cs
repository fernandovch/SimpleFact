using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Models
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public string ExoneracionNombreInstitucion { get; set; }
        public DateTime? ExoneracionFechaEmision { get; set; }
        public decimal? ExoneracionMontoImpuesto { get; set; }
        public int? ExoneracionPorcentajeCompra { get; set; }
        public decimal? ImpuestoTarifa { get; set; }
        public decimal? ImpuestpMonto { get; set; }
        public decimal? MontoDescuento { get; set; }
        public decimal? NaturalezaDescuento { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? MontoTotal { get; set; }

        public EncabezadoFactura IdFacturaNavigation { get; set; }
        public Producto IdProductoNavigation { get; set; }
    }
}
