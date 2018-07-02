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
    public class UnitTest_mantenimientoFacturacion
    {
        [TestMethod]
        public void SeleccionarFacturaElectronica()
        {
            SimpleFactContext context = new SimpleFactContext();
            SimpleFactContext context2 = new SimpleFactContext();
            IGenericRepository<ServicioFacturaElectronica> Interface_facturaElectronica = new GenericRepository<ServicioFacturaElectronica>(context);
            IGenericRepository<LogErrores> Interface_logErrores = new GenericRepository<LogErrores>(context2);
            MantenimientoFacturaElectronica mantePersona = new MantenimientoFacturaElectronica(Interface_facturaElectronica, Interface_logErrores);
            //var ListaP = mantePersona.BuscarPersonaPorCedula("1234");
            //Assert.AreEqual(ListaP[0].Identificacion, "1234");
        }
    }
}
