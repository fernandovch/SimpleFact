using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Models
{
    public class EncabezadoFactura
    {
        public EncabezadoFactura()
        {
            DetalleFactura = new HashSet<DetalleFactura>();
            ServicioFacturaElectronica = new HashSet<ServicioFacturaElectronica>();
        }

        public int Id { get; set; }
        public string ClaveNumerica { get; set; }
        public string NumeroConsecutivo { get; set; }
        public DateTime? FechaEmision { get; set; }
        public int IdEmisor { get; set; }
        public int IdReceptor { get; set; }
        public int IdTipoPago { get; set; }
        public int IdTipoCondicionVenta { get; set; }
        public string IdUsuario { get; set; }
        public string EstadoFactura { get; set; }
        public decimal? TotalServiciosGravados { get; set; }
        public decimal? TotalServiciosExentos { get; set; }
        public decimal? TotalMercanciaGravada { get; set; }
        public decimal? TotalMercanciaExenta { get; set; }
        public decimal? TotalGravado { get; set; }
        public decimal? TotalExento { get; set; }
        public decimal? TotalVenta { get; set; }
        public decimal? TotalDescuentos { get; set; }
        public decimal? TotalVentaNeta { get; set; }
        public decimal? TotalImpuesto { get; set; }
        public decimal? TotalComprobante { get; set; }

        public Persona IdEmisorNavigation { get; set; }
        public Persona IdReceptorNavigation { get; set; }
        public TipoCondicionVenta IdTipoCondicionVentaNavigation { get; set; }
        public TipoPago IdTipoPagoNavigation { get; set; }
        public AspNetUsers IdUsuarioNavigation { get; set; }
        public ICollection<DetalleFactura> DetalleFactura { get; set; }
        public ICollection<ServicioFacturaElectronica> ServicioFacturaElectronica { get; set; }

    }
}
