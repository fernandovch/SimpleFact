using POS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLogic.Interfaces
{
    public interface IMantemientoProducto
    {
        List<Producto> BuscarProductoPorCodigo(string _codigo);

        List<Persona> SeleccionarProveedores();

        List<ProductoCategoria> SeleccionarCategoriasProducto();

        List<TipoImpuestos> SeleccionarTiposImpuestos();

        List<TipoExoneraciones> SeleccionarTipoExoneraciones();

        Producto ModificarProducto(Producto _producto);

        Producto AgregarProducto(Producto _producto);

        MovimientosInventario AgregarMovimientosInventario(MovimientosInventario _movimiento);

        List<RazonMovimientoInventario> SeleccionarRazonesMovimientoInventario();

        List<Producto> BuscarProducto(string parametro, string valor);

        List<Producto> ObtenerTodos();
    }
}
