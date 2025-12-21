using AutoMapper;
using ParkingManager.Core.Entities;
using ParkingManager.Infrastructure.DTOs;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ParkingManager.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapeos bidireccionales DTO ↔ Entidades
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Vehiculo, VehiculoDto>().ReverseMap();
            CreateMap<Registro, RegistroDto>().ReverseMap();
            CreateMap<Tarifa, TarifaDto>().ReverseMap();
            CreateMap<Disponibilidad, DisponibilidadDto>().ReverseMap();

            //para el historial de disponibilidades
            // NUEVO MAPEO
            CreateMap<Disponibilidad, DisponibilidadRangoDto>()
                .ForMember(dest => dest.Fecha,
                    opt => opt.MapFrom(src => src.FechaActualizacion.Date))
                .ForMember(dest => dest.Dia,
                    opt => opt.MapFrom(src =>
                        CultureInfo.GetCultureInfo("es-ES")
                            .DateTimeFormat.GetDayName(src.FechaActualizacion.DayOfWeek)))
                .ForMember(dest => dest.Hora,
                    opt => opt.MapFrom(src => src.FechaActualizacion.TimeOfDay))
                .ForMember(dest => dest.NumeroEspacio,
                    opt => opt.MapFrom(src => src.NumeroEspacio))
                .ForMember(dest => dest.Zona,
                    opt => opt.MapFrom(src => src.Zona))
                .ForMember(dest => dest.Estado,
                    opt => opt.MapFrom(src => src.Ocupado ? "Ocupado" : "Libre"));
        }
    }
}
