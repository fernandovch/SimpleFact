using Microsoft.Extensions.DependencyInjection;
using POS.Data.DataAccess;
using POS.Data.Models;
using System;

namespace POS.BLogic.MantenimientoProducto
{
    public class MantenimientoProducto
    {

        IGenericRepository<Producto> productos;
        public MantenimientoProducto( IGenericRepository<Producto> produc)
        {
            productos = produc;

        }
        /// <summary>
        /// Busqueda de producto por codigo de barras
        /// </summary>
        /// <param name="_codigo"></param>
        /// <returns></returns>
        public Producto BuscarProductoPorCodigo(string _codigo)
        {
            Producto productResult;
            //var servicios = new ServiceCollection();
            //servicios.AgregarColeccionServicio();

            //var provedor = servicios.BuildServiceProvider();
            try
            {
                productResult = (Producto)productos.FindBy(x => x.Codigo == _codigo);
                return productResult;
            }
            catch(Exception _ex)
            {
                return null;
            }
            
        }
        /// <summary>
        /// Actualizar atributos de producto
        /// </summary>
        /// <param name="_producto"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        //public Producto ModificarProducto(Producto _producto, object key)
        //{
        //    Producto productResult;
        //    try
        //    {
        //        //productResult = repositorioProducto.Update(_producto, key);
        //        return productResult;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //public Producto IngresarProducto(Producto _producto)
        //{
        //    Producto productResult;
        //    try
        //    {
        //        productResult= repositorioProducto.Add(_producto);
        //        return productResult;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //public Producto BuscarProducto(string parametro, string valor)
        //{
        //    Producto productResult;
        //    //var entityType = typeof(Producto);
        //    // get the type of the value object
        //   // var valueType = valor.GetType();
        //   // var entityProperty = entityType.GetProperty(parametro);
           

        //    try
        //    {
        //        productResult = (Producto)repositorioProducto.FindBy(x => x.GetType().GetProperty(parametro).Name == valor);
        //        return productResult;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
    }
}
