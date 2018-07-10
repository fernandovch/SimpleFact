using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POS.BLogic.Interfaces;
using POS.BLogic.Mantenimiento;
using POS.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace POS.WEB.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        IMantemientoProducto mantenimiento;

        public ProductController(IMantemientoProducto _mantenimiento)
        {
            mantenimiento = _mantenimiento;
        }

        [HttpGet("[action]")]
        [Route("api/Product/Index")]
        public Array Index()
        {
            Producto producto = new Producto { Id = 1, Nombre = "A", Activo = true, CantidadDisponible = 1,Codigo="1",CostoUnitario=1,Detalle="Prueba",
            PrecioUnitario=1, FechaCreacion =DateTime.Now,FechaModificacion= DateTime.Now, Gravado="0", IdCategoria=1,IdExoneracion= 1,
            IdImpuesto=1,IdProveedor=1,IdUnidadMedida=1, DetalleFactura=null, IdCategoriaNavigation= new ProductoCategoria(),IdExoneracionNavigation= new TipoExoneraciones(),IdImpuestoNavigation=new TipoImpuestos(),
                IdProveedorNavigation = new Persona(),IdUnidadMedidaNavigation=new TipoUnidadesMedida()
            };

            List<Producto> x = new List<Producto>();
            x.Add(producto);
            x.Add(producto);
            //return mantenimiento.ObtenerTodos().ToArray();
            return x.ToArray();
        }

        // GET api/<controller>/5
        //[HttpGet("{id}")]
        //[Route("api/Producto/Details/{id}")]
        //public IEnumerable<Producto> Get(int id)
        //{
        //    return mantenimiento.BuscarProductoPorId(id);
        //}

        //// POST api/<controller>
        //[HttpPost]
        //[Route("api/Producto/Create")]
        //public Producto Create([FromBody] Producto producto)
        //{
        //    return mantenimiento.AgregarProducto(producto);
        //}

        //// PUT api/<controller>/5
        //[HttpPut]
        //[Route("api/Producto/Edit")]
        //public Producto Edit([FromBody]Producto producto)
        //{
        //    return mantenimiento.ModificarProducto(producto);
        //}
       /* [HttpDelete]
        [Route("api/Producto/Delete/{id}")]
        public int Delete(int id)
        {
            return null;
        }*/
    }
}
