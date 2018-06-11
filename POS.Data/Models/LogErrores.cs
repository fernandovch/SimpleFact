using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Models
{
    public class LogErrores
    {
        public int Id { get; set; }
        public int Modulo { get; set; }
        public string MensajeError { get; set; }
        public string DetalleError { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
