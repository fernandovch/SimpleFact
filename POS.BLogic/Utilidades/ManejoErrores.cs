using POS.Data.DataAccess;
using POS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLogic.Utilidades
{
    public class ManejoErrores
    {
        private IGenericRepository<LogErrores> interface_logErrores;

        public ManejoErrores()
        {
            Inicializador.Init();
            interface_logErrores = DependencyInjector.Retrieve<GenericRepository<LogErrores>>();
        }

        /// <summary>
        /// Ingresa el error en la tabla de logs.
        /// </summary>
        /// <param name="_modulo"></param>
        /// <param name="_mensajeError"></param>
        /// <param name="_detalleError"></param>
        /// <returns></returns>
        public LogErrores RegistrarErrorLog(int _modulo, string _mensajeError, string _detalleError)
        {
            LogErrores log;
            try
            {
                log = new LogErrores();
                log.Modulo = _modulo;
                log.MensajeError = _mensajeError;
                log.DetalleError = _detalleError;
                log.Fecha = DateTime.Now;
                return interface_logErrores.Add(log);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
