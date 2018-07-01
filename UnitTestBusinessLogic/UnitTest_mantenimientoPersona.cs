using Microsoft.VisualStudio.TestTools.UnitTesting;
using POS.BLogic.Mantenimiento;
using POS.Data.DataAccess;
using POS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestBusinessLogic
{
    [TestClass]
    public class UnitTest_mantenimientoPersona
    {

        [TestMethod]
        public void BuscarPersonaPorCedula_CedulaValida()
        {
            SimpleFactContext context = new SimpleFactContext();
            SimpleFactContext context2 = new SimpleFactContext();
            IGenericRepository<Ubicacion> Interface_ubicacion = new GenericRepository<Ubicacion>(context);
            IGenericRepository<Persona> Interface_persona = new GenericRepository<Persona>(context);
            IGenericRepository<TipoFigura> Interface_tipoFigura = new GenericRepository<TipoFigura>(context);
            IGenericRepository<TipoCedula> Interface_tipoCedula = new GenericRepository<TipoCedula>(context);
            IGenericRepository<LogErrores> Interface_logErrores = new GenericRepository<LogErrores>(context2);
            MantenimientoPersona mantePersona = new MantenimientoPersona(Interface_persona, Interface_ubicacion, Interface_tipoFigura, Interface_logErrores, Interface_tipoCedula);
            var ListaP = mantePersona.BuscarPersonaPorCedula("1234");
            Assert.AreEqual(ListaP[0].Identificacion, "1234");
        }

        [TestMethod]
        public void SeleccionarTipoFigura_CuandoExistenDatosActivos()
        {
            SimpleFactContext context = new SimpleFactContext();
            SimpleFactContext context2 = new SimpleFactContext();
            IGenericRepository<Ubicacion> Interface_ubicacion = new GenericRepository<Ubicacion>(context);
            IGenericRepository<Persona> Interface_persona = new GenericRepository<Persona>(context);
            IGenericRepository<TipoFigura> Interface_tipoFigura = new GenericRepository<TipoFigura>(context);
            IGenericRepository<TipoCedula> Interface_tipoCedula = new GenericRepository<TipoCedula>(context);
            IGenericRepository<LogErrores> Interface_logErrores = new GenericRepository<LogErrores>(context2);
            MantenimientoPersona mantePersona = new MantenimientoPersona(Interface_persona, Interface_ubicacion, Interface_tipoFigura, Interface_logErrores, Interface_tipoCedula);
            var ListaP = mantePersona.SeleccionarTipoFigura();
            Assert.IsNotNull(ListaP);
        }

        [TestMethod]
        public void InsertarPersona_ConInformacionValida()
        {
            SimpleFactContext context = new SimpleFactContext();
            SimpleFactContext context2 = new SimpleFactContext();
            IGenericRepository<Ubicacion> Interface_ubicacion = new GenericRepository<Ubicacion>(context);
            IGenericRepository<Persona> Interface_persona = new GenericRepository<Persona>(context);
            IGenericRepository<TipoFigura> Interface_tipoFigura = new GenericRepository<TipoFigura>(context);
            IGenericRepository<TipoCedula> Interface_tipoCedula = new GenericRepository<TipoCedula>(context);
            IGenericRepository<LogErrores> Interface_logErrores = new GenericRepository<LogErrores>(context2);
            MantenimientoPersona mantePersona = new MantenimientoPersona(Interface_persona, Interface_ubicacion, Interface_tipoFigura, Interface_logErrores, Interface_tipoCedula);
            var res = mantePersona.AgregarPersona(1, 1, 1, "112410464", "Persona Test" + DateTime.Now.Day, "", "persona1@gmail.com", new DateTime(1985, 5, 12), "506", "87122797", null, null, "Otras sennas", true, true);
            Assert.AreEqual(res.Identificacion, "112410464");
        }

        [TestMethod]
        public void InsertarPersona_ConInformacionNoValida()
        {
            SimpleFactContext context = new SimpleFactContext();
            SimpleFactContext context2 = new SimpleFactContext();
            IGenericRepository<Ubicacion> Interface_ubicacion = new GenericRepository<Ubicacion>(context);
            IGenericRepository<Persona> Interface_persona = new GenericRepository<Persona>(context);
            IGenericRepository<TipoFigura> Interface_tipoFigura = new GenericRepository<TipoFigura>(context);
            IGenericRepository<TipoCedula> Interface_tipoCedula = new GenericRepository<TipoCedula>(context);
            IGenericRepository<LogErrores> Interface_logErrores = new GenericRepository<LogErrores>(context2);
            MantenimientoPersona mantePersona = new MantenimientoPersona(Interface_persona, Interface_ubicacion, Interface_tipoFigura, Interface_logErrores, Interface_tipoCedula);
            var res = mantePersona.AgregarPersona(15, 1, 1, "112410464", "Persona Test" + DateTime.Now.Day, "", "persona1@gmail.com", new DateTime(1985, 5, 12), "506", "87122797", null, null, "Otras sennas", true, true);
            Assert.IsNull(res);
        }

        [TestMethod]
        public void ModificarPersona_ConInformacionValida()
        {
            //SimpleFactContext context = new SimpleFactContext();
            //SimpleFactContext context2 = new SimpleFactContext();
            //IGenericRepository<Ubicacion> Interface_ubicacion = new GenericRepository<Ubicacion>(context);
            //IGenericRepository<Persona> Interface_persona = new GenericRepository<Persona>(context);
            //IGenericRepository<TipoFigura> Interface_tipoFigura = new GenericRepository<TipoFigura>(context);
            //IGenericRepository<TipoCedula> Interface_tipoCedula = new GenericRepository<TipoCedula>(context);
            //IGenericRepository<LogErrores> Interface_logErrores = new GenericRepository<LogErrores>(context2);
            //MantenimientoPersona mantePersona = new MantenimientoPersona();
            //var res = mantePersona.ModificarPersona(1, 1, 1, "112410464", "Persona Test" + DateTime.Now.Day, "", "persona12@gmail.com", new DateTime(1985, 5, 12), "506", "87122797", null, null, "Otras sennas", true, true,1002);
            //Assert.AreEqual(res.CorreoElectronico, "persona12@gmail.com");
        }

        [TestMethod]
        public void ModificarPersona_ConInformacionNoValida()
        {
            //SimpleFactContext context = new SimpleFactContext();
            //SimpleFactContext context2 = new SimpleFactContext();
            //IGenericRepository<Ubicacion> Interface_ubicacion = new GenericRepository<Ubicacion>(context);
            //IGenericRepository<Persona> Interface_persona = new GenericRepository<Persona>(context);
            //IGenericRepository<TipoFigura> Interface_tipoFigura = new GenericRepository<TipoFigura>(context);
            //IGenericRepository<TipoCedula> Interface_tipoCedula = new GenericRepository<TipoCedula>(context);
            //IGenericRepository<LogErrores> Interface_logErrores = new GenericRepository<LogErrores>(context2);
            //MantenimientoPersona mantePersona = new MantenimientoPersona(Interface_persona, Interface_ubicacion, Interface_tipoFigura, Interface_logErrores, Interface_tipoCedula);
            //var res = mantePersona.ModificarPersona(1, 1, 18, "112410464", "Persona Test" + DateTime.Now.Day, "", "persona12@gmail.com", new DateTime(1985, 5, 12), "506", "87122797", null, null, "Otras sennas", true, true, 1002);
            //Assert.IsNull(res);
        }

        [TestMethod]
        public void SeleccionarTipoCedula_CuandoExistenDatosActivos()
        {
            //SimpleFactContext context = new SimpleFactContext();
            //SimpleFactContext context2 = new SimpleFactContext();
            //IGenericRepository<Ubicacion> Interface_ubicacion = new GenericRepository<Ubicacion>(context);
            //IGenericRepository<Persona> Interface_persona = new GenericRepository<Persona>(context);
            //IGenericRepository<TipoFigura> Interface_tipoFigura = new GenericRepository<TipoFigura>(context);
            //IGenericRepository<TipoCedula> Interface_tipoCedula = new GenericRepository<TipoCedula>(context);
            //IGenericRepository<LogErrores> Interface_logErrores = new GenericRepository<LogErrores>(context2);
            //MantenimientoPersona mantePersona = new MantenimientoPersona(Interface_persona, Interface_ubicacion, Interface_tipoFigura, Interface_logErrores, Interface_tipoCedula);
            //var ListaP = mantePersona.SeleccionarTipoCedula();
            //Assert.AreEqual(ListaP.Count, 4);
        }

    }
}
