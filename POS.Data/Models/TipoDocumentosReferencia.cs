using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.Models
{
    public class TipoDocumentosReferencia
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public bool? Activo { get; set; }
    }
}
