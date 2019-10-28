using AutoMapper;
using Euroval.Domain.Domain;
using Euroval.Entity.Entity;

namespace Euroval.Domain.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<DeporteViewModel, Deporte>();
            CreateMap<Deporte, DeporteViewModel>();

            CreateMap<PistaViewModel, Pista>();
            CreateMap<Pista, PistaViewModel>();

            CreateMap<ReservaViewModel, Reserva>()
                .ForMember(dest => dest.FechaInicio, opts => opts.MapFrom(src => src.FechaReserva))
                .ForMember(dest => dest.FechaFin, opts => opts.MapFrom(src => src.FechaReserva.AddHours(src.Duracion)));
            CreateMap<Reserva, ReservaViewModel>()
                .ForMember(dest => dest.FechaReserva, opts => opts.MapFrom(src => src.FechaInicio))
                .ForMember(dest => dest.Duracion, opts => opts.MapFrom(src => src.FechaFin.Hour - src.FechaInicio.Hour));

            CreateMap<SocioViewModel, Socio>();
            CreateMap<Socio, SocioViewModel>();

            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<Usuario, UsuarioViewModel>();
        }


    }
}
