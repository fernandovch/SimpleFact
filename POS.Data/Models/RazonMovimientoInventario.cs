using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Models
{
    public class RazonMovimientoInventario
    {
        [Key]
        public int Id { get; set; }
        public string RazonMovimiento { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
