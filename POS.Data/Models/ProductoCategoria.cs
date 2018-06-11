using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Models
{
    public class ProductoCategoria
    {
        public ProductoCategoria()
        {
            Producto = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }
        public bool? Activo { get; set; }

        public ICollection<Producto> Producto { get; set; }
    }
}
