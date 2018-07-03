using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using POS.BLogic.Facturacion;
using POS.BLogic.Mantenimiento;
using POS.BLogic.Utilidades;
using POS.Data.Models;
using System;
using System.Collections.Generic;

namespace UnitTestBusinessLogic
{
    [TestClass]
    public class UnitTest1
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();
            return config;
        }

            
      [TestMethod]
        public void TestMethod1()
        {
            Persona _sujeto = new Persona { 
                IdIdentificacion = 1,
                IdUbicacion = 1,
                IdTipoFigura = 1,
                Identificacion = "123456",
                Nombre = "Juan",
                NombreComercial = "",
                CorreoElectronico = "",
                FechaNacimiento = DateTime.Now.Date,
                Tel_CodigoPais = "",
                Tel_Numero = "",
                Fax_CodigoPais = "",
                Fax_Numero = "",
                Direccion_OtrasSenas = "",
                EsCorreoValido = true,
                Activo = true

            };

            MantenimientoPersona mantenimientoPersona = new MantenimientoPersona();



            /* Ingresar Producto */

            Persona resultado = mantenimientoPersona.AgregarPersona(_sujeto);
            Assert.AreEqual<Persona>(resultado, _sujeto );
        }

        [TestMethod]
        public void TestMethod2()
        {
            AdministrarServiciosHacienda service = new AdministrarServiciosHacienda();
             var result = service.ObtenerTokenIdP(true);
            var desconnect = service.DesconectarTokenIdP(true);
          /*  Settings valores = new Settings();
         var algo = valores.IdP_Uri;*/
        }

    }
}

