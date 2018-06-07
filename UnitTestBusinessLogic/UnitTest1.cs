using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POS.BLogic.MantenimientoProducto;
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

        IGenericRepository<Producto> repos;
        [TestInitialize]
        public void Setup()
        {
           // this.repos = new Moq.Mock< IGenericRepository<Producto>>();
        }



        [TestMethod]
        public void TestMethod1()
        {
            //var repos = new Producto();
            //var mock = new GenericRepository
            //MantenimientoProducto mante = new MantenimientoProducto(repos);

            //Producto producto = mante.BuscarProductoPorCodigo("1");

            //Assert.AreEqual(producto.Codigo, "1");
            
            




        }
    }
}
