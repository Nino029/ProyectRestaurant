using AutoMapper;
using Restaurant.Domain.Entitites;
using Restaurant.Domain.Models.Cliente;
using Restaurant.Domain.Models.DetallePedido;
using Restaurant.Domain.Models.Empleado;
using Restaurant.Domain.Models.Factura;
using Restaurant.Infraestructure.Models.Cliente;
using Restaurant.Infraestructure.Models.DetallePedido;
using Restaurant.Infraestructure.Models.Empleado;
using Restaurant.Infraestructure.Models.Factura;

namespace Restaurant.Web.Api.DTOS
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            // Cliente mappings
            CreateMap<SaveClienteModel, Cliente>();
            CreateMap<Cliente, ViewClienteModel>()
               .ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.IdCliente));
            CreateMap<UpdateClienteModel, Cliente>();
            CreateMap<DeleteClienteModel, Cliente>()
               .ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.IdCliente));

            // Empleado mappings
            CreateMap<SaveEmpleadoModel, Empleado>();
            CreateMap<UpdateEmpleadoModel, Empleado>()
                .ReverseMap();
            CreateMap<Empleado, ViewEmpleadoModel>()
               .ForMember(dest => dest.IdEmpleado, opt => opt.MapFrom(src => src.IdEmpleado));

            // Factura mappings
            CreateMap<SaveFacturaModel, Factura>();
            CreateMap<Factura, ViewFacturaModel>()
               .ForMember(dest => dest.IdFactura, opt => opt.MapFrom(src => src.IdFactura));
            CreateMap<UpdateFacturaModel, Factura>();
            CreateMap<DeleteFacturaModel, Factura>()
               .ForMember(dest => dest.IdFactura, opt => opt.MapFrom(src => src.IdFactura));

            // DetallePedido mappings
            CreateMap<SaveDetallePedidoModel, DetallePedido>()
               .ForMember(dest => dest.IdDetallePedido, opt => opt.Ignore())
               .ForMember(dest => dest.IdPedidoNavigation, opt => opt.Ignore())
               .ForMember(dest => dest.IdPlatoNavigation, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<DetallePedido, ViewDetallePedidoModel>()
               .ForMember(dest => dest.IdDetallePedido, opt => opt.MapFrom(src => src.IdDetallePedido));
            CreateMap<UpdateDetallePedidoModel, DetallePedido>();
            CreateMap<DeleteDetallePedidoModel, DetallePedido>()
               .ForMember(dest => dest.IdDetallePedido, opt => opt.MapFrom(src => src.IdDetallePedido));

            // Add mappings for other models as needed
        }
    }
}
