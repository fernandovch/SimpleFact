using Microsoft.Extensions.DependencyInjection;
using POS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.DataAccess
{
    public static class AgregarServicioInterno
    {
        public static IServiceCollection AgregarColeccionServicio(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<Producto>), typeof(GenericRepository<Producto>));
            services.AddTransient(typeof(IGenericRepository<Persona>), typeof(GenericRepository<Persona>));
            services.AddTransient(typeof(IGenericRepository<MovimientosInventario>), typeof(GenericRepository<MovimientosInventario>));
            services.AddTransient(typeof(IGenericRepository<RazonMovimientoInventario>), typeof(GenericRepository<RazonMovimientoInventario>));

            return services;
        }


    }
}