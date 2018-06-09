using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Models
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        public int IdTipoIdentificacion { get; set; }
        public int IdUbicacion { get; set; }
        public int IdTipoEntidad { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string NombreComercial { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Tel_CodigoPais { get; set; }
        public string Tel_Numero { get; set; }
        public string Fax_CodigoPais { get; set; }
        public string Fax_Numero { get; set; }
        public string DireccionOtrasSennas { get; set; }
        public bool EsCorreoValido { get; set; }
        public bool Activo { get; set; }


    }
}
