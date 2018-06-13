using POS.Data.DataAccess;
using POS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLogic.Mantenimiento
{
    public class MantenimientoPersona
    {
        IGenericRepository<Persona> persona;
        IGenericRepository<Ubicacion> ubicacion;
        IGenericRepository<TipoFigura> tipoFigura;
        IGenericRepository<LogErrores> logErrores;

        public MantenimientoPersona(IGenericRepository<Persona> _persona, IGenericRepository<Ubicacion> _ubicacion, 
                IGenericRepository<TipoFigura> _tipoFigura, IGenericRepository<LogErrores> _logErrores)
        {
            persona = _persona;
            ubicacion = _ubicacion;
            tipoFigura = _tipoFigura;
            logErrores = _logErrores;
        }

        public Persona BuscarPersonaPorCedula(string _cedula)
        {
            Persona Result;           
            try
            {
               // Result = (Persona)persona.FindBy(x => x.Identificacion == _cedula);
                return null;
            }
            catch (Exception _ex)
            {
                return null;
            }

        }

        public Ubicacion BuscarUbicacionPorCodigo(string _codigo)
        {
            Ubicacion Result;
            //var servicios = new ServiceCollection();
            //servicios.AgregarColeccionServicio();

            //var provedor = servicios.BuildServiceProvider();
            try
            {
               // Result = (Ubicacion)ubicacion.FindBy(x => x.Codigo == _codigo);
                return null;
            }
            catch (Exception _ex)
            {
                return null;
            }

        }

        public TipoFigura BuscarFipoFigura(int _id)
        {
            TipoFigura Result;
            //var servicios = new ServiceCollection();
            //servicios.AgregarColeccionServicio();

            //var provedor = servicios.BuildServiceProvider();
            try
            {
                //Result = (TipoFigura)tipoFigura.FindBy(x => x.Id == _id);
                return null;
            }
            catch (Exception _ex)
            {
                return null;
            }

        }


    }
}
