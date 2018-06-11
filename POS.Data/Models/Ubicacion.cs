using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Models
{
    public class Ubicacion
    {
        public Ubicacion()
        {
            Persona = new HashSet<Persona>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Persona> Persona { get; set; }
    }
}
