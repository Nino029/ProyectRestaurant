using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Interfaces.IRepositories;
using Restaurant.Infraestructure.Repositories;


namespace Restaurant.Infraestructure.Extensions
{
    public static class Extensions
    {


         public static void ExtensionsRepository(this IServiceCollection services, IConfiguration configuration){

         services.AddTransient<IClienteRepository, ClienteRepository>();
         services.AddScoped<ClienteRepository>();
         services.AddTransient<IMesaRepository, MesaRepository>();
         services.AddTransient<IEmpleadoRepository, EmpleadoRepository>();
         services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
         services.AddTransient<IMenuRepository, MenuRepository>();
         services.AddTransient<IPedidoRepository, PedidoRepository>();
         services.AddTransient<IDetallePedidoRepository, DetallePedidoRepository>();
         services.AddScoped<IDetallePedidoRepository, DetallePedidoRepository>();
         services.AddTransient<IFacturaRepository, FacturaRepository>();
         services.AddScoped<IFacturaRepository, FacturaRepository>();
        }

    }
}


