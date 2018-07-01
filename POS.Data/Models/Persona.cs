using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Models
{
    public class Persona
    {
        public Persona()
        {
            EncabezadoFacturaIdEmisorNavigation = new HashSet<EncabezadoFactura>();
            EncabezadoFacturaIdReceptorNavigation = new HashSet<EncabezadoFactura>();
            Producto = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public int? IdIdentificacion { get; set; }
        public int? IdUbicacion { get; set; }
        public int IdTipoFigura { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string NombreComercial { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Tel_CodigoPais { get; set; }
        public string Tel_Numero { get; set; }
        public string Fax_CodigoPais { get; set; }
        public string Fax_Numero { get; set; }
        public string Direccion_OtrasSenas { get; set; }
        public bool? EsCorreoValido { get; set; }
        public bool? Activo { get; set; }

        public TipoCedula IdIdentificacionNavigation { get; set; }
        public TipoFigura IdTipoFiguraNavigation { get; set; }
        public Ubicacion IdUbicacionNavigation { get; set; }
        public ICollection<EncabezadoFactura> EncabezadoFacturaIdEmisorNavigation { get; set; }
        public ICollection<EncabezadoFactura> EncabezadoFacturaIdReceptorNavigation { get; set; }
        public ICollection<Producto> Producto { get; set; }
    }
}
