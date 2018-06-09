using POS.Data.DataAccess;
using POS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLogic.Utilidades
{
    public class Utilidades
    {
        private IGenericRepository<LogErrores> logErrores;

        public Utilidades(IGenericRepository<LogErrores> _logErrores)
        {
            logErrores = _logErrores;
        }
    }
}
