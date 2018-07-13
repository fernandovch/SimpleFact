using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POS.BLogic.Interfaces;
using POS.BLogic.Mantenimiento;
using POS.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace POS.WEB.Controllers
{
    //[Route("[controller]")]
    public class ProductoController : Controller
    {
        IMantemientoProducto mantenimiento;

        public ProductoController(IMantemientoProducto _mantenimiento)
        {
            mantenimiento = _mantenimiento;
        }

        [HttpGet]
        // [Route("api/Producto/Index")]        
        public Array Index()
        {
            return mantenimiento.SeleccionarTodos().ToArray();          
        }

        //get <controller>/5
        [HttpGet("{id}")]
       // [Route("api/Producto/Detalle/{id}")]
        public Array Get(int id)
        {
            return mantenimiento.BuscarProductoPorId(id).ToArray();
        }

        // post api/<controller>
        [HttpPost]
       // [Route("api/Producto/Crear")]
        public Producto Create([FromBody]Producto producto)
        {
            return mantenimiento.AgregarProducto(producto);
        }

        // put api/<controller>/5
        [HttpGet]
      //  [Route("api/Producto/Detalle")]
        public Producto Details(int id)
        {
            return mantenimiento.BuscarProductoPorId(id).ToArray()[0];
        }

        [HttpPut]
       // [Route("api/Producto/Editar")]
        public int Edit([FromBody]Producto producto)
        {
            return mantenimiento.ModificarProducto(producto).Id;
        }

        /* [HttpDelete]
         [Route("api/Producto/Delete/{id}")]
         public int Delete(int id)
         {
             return null;
         }*/
    }
}
