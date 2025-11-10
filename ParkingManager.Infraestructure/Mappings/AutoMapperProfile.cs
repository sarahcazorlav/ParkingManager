using AutoMapper;
using ParkingManager.Core.Entities;
using ParkingManager.Infrastructure.DTOs;
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
        }
    }
}
