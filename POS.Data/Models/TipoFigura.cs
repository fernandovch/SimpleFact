using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Models
{
    public class TipoFigura
    {
        public TipoFigura()
        {
            Persona = new HashSet<Persona>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Activo { get; set; }

        public ICollection<Persona> Persona { get; set; }
    }
}
