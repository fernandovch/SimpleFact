using POS.BLogic.Interfaces;
using POS.BLogic.Utilidades;
using POS.Data.DataAccess;
using POS.Data.Models;
using System;
using System.Collections.Generic;

namespace POS.BLogic.Mantenimiento
{
    public class MantenimientoPersona : IMantemientoPersona
    {
        #region PrivateGlobals

        private IGenericRepository<Persona> sujeto;
        private ManejoErrores log;

        #endregion

        #region PublicGlobals

        public Persona globalVar_Persona;

        #endregion


        public MantenimientoPersona()
        {
            Inicializador.Init();
            sujeto = DependencyInjector.Retrieve<GenericRepository<Persona>>();
            log = new ManejoErrores();
            globalVar_Persona = new Persona();

        }

        public Persona AgregarPersona(Persona _persona)
        {
            IGenericRepository<Persona> persona = DependencyInjector.Retrieve<GenericRepository<Persona>>();
            try
            {
                return persona.Add(_persona);
            }
            catch (Exception _ex)
            {              
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return null;
            }
        }

        public List<Persona> BuscarPersonaPorCedula(string _cedula)
        {
            List<Persona> Result;
            try
            {
                IGenericRepository<Persona> persona = DependencyInjector.Retrieve<GenericRepository<Persona>>();

                Result = persona.FindBy(x => x.Identificacion == _cedula);
                return Result;
            }
            catch (Exception _ex)
            {
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return null;
            }
        }

        public Persona ModificarPersona(Persona _persona)
        {
            IGenericRepository<Persona> persona = DependencyInjector.Retrieve<GenericRepository<Persona>>();
            try {
                return persona.Update(_persona, _persona.Id);
            }
            catch (Exception _ex)
            {
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return null;
            }
        }

        public List<TipoCedula> SeleccionarTipoCedula()
        {
            List<TipoCedula> tiposCedula;
            try
            {
                IGenericRepository<TipoCedula> tipoCedula = DependencyInjector.Retrieve<GenericRepository<TipoCedula>>();
                tiposCedula = tipoCedula.FindBy(x => x.Activo == true);
                return tiposCedula;
            }
            catch (Exception _ex)
            {
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return null;
            }
        }

        public List<TipoFigura> SeleccionarTipoFigura()
        {
            List<TipoFigura> ListTipoFigura;
            try
            {
                IGenericRepository<TipoFigura> tipoFigura = DependencyInjector.Retrieve<GenericRepository<TipoFigura>>();

                ListTipoFigura = tipoFigura.FindBy(x => x.Activo == true);
                return ListTipoFigura;
            }
            catch (Exception _ex)
            {
                log.RegistrarErrorLog((int)ModuloSistema.MantenimientoProducto, _ex.Message, _ex.Source + " : " + _ex.StackTrace);
                return null;
            }
        }
    }
}
