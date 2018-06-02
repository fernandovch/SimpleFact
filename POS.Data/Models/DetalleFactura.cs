using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Models
{
    public class DetalleFactura
    {
        [Key]
        public int Id { get; set; }
        public EncabezadoFactura Factura { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public string Exoneracion_NombreInstitucion { get; set; }
        public DateTime Exoneracion_FechaEmision { get; set; }
        public decimal Exoneracion_MontoImpuesto { get; set; }
        public int Exoneracion_PorcentajeCompra { get; set; }
        public decimal Impuesto_Tarifa { get; set; }
        public decimal Impuestp_Monto { get; set; }
        public decimal MontoDescuento { get; set; }
        public string NaturalezaDescuento { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }



    }
}
