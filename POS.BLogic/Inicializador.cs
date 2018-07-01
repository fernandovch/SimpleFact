using POS.Data.DataAccess;
using POS.Data.Models;


namespace POS.BLogic
{
    public class Inicializador
    {
        public static void Init()
        {
            
            DependencyInjector.Register<IGenericRepository<Persona>, GenericRepository<Persona>>();
            DependencyInjector.Register<IGenericRepository<EncabezadoFactura>, GenericRepository<EncabezadoFactura>>();
            DependencyInjector.Register<IGenericRepository<DetalleFactura>, GenericRepository<DetalleFactura>>();
            DependencyInjector.Register<IGenericRepository<Persona>, GenericRepository<Persona>>();
            DependencyInjector.Register<IGenericRepository<TipoPago>, GenericRepository<TipoPago>>();
            DependencyInjector.Register<IGenericRepository<TipoCondicionVenta>, GenericRepository<TipoCondicionVenta>>();
            DependencyInjector.Register<IGenericRepository<Producto>, GenericRepository<Producto>>();
            DependencyInjector.Register<IGenericRepository<TipoImpuestos>, GenericRepository<TipoImpuestos>>();
            DependencyInjector.Register<IGenericRepository<TipoExoneraciones>, GenericRepository<TipoExoneraciones>>();
            DependencyInjector.Register<IGenericRepository<ServicioFacturaElectronica>, GenericRepository<ServicioFacturaElectronica>>();
        }
    }
}
