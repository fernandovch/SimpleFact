using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using POS.BLogic.Mantenimiento;
using POS.Data.DataAccess;
using POS.Data.Models;
using System;

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

      /*  IGenericRepository<Producto> repos;
        [TestInitialize]
        public void Setup()
        {
            var x = new Mock<IGenericRepository<Producto>>();
            MantenimientoProducto mante = new MantenimientoProducto(repos);

            Producto producto = mante.BuscarProductoPorCodigo("1");

            Assert.AreEqual(producto.Codigo, "1");
        }
        */


        [TestMethod]
        public void TestMethod1()
        {
            SimpleFactContext context = new SimpleFactContext();
          /*  IGenericRepository<Producto> producto = new GenericRepository<Producto>(context);
            MantenimientoProducto mantepro = new MantenimientoProducto(producto);
            string par = "Codigo";
            string val = "1";
            var algo = mantepro.BuscarProducto(par, val);*/
            
            
        }
    }
}

