using ParkingManager.Core.CustomEntities;
using ParkingManager.Core.Entities;
using ParkingManager.Core.QueryFilters;
using System; // <-- Agregado para DateTime
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingManager.Core.Interfaces
{
    public interface IDisponibilidadService
    {
        Task<PagedList<Disponibilidad>> GetDisponibilidadesAsync(DisponibilidadQueryFilter filters);
        Task<Disponibilidad?> GetDisponibilidadByIdAsync(int id);
        Task InsertDisponibilidadAsync(Disponibilidad disponibilidad);
        Task UpdateDisponibilidadAsync(Disponibilidad disponibilidad);
        Task DeleteDisponibilidadAsync(int id);

        // Devuelve la lista de disponibilidades por zona
        Task<IEnumerable<Disponibilidad>> GetDisponiblesPorZonaAsync(string zona);

        //para el historial de disponibilidades
        Task<IEnumerable<Disponibilidad>> GetDisponibilidadesPorRangoFechasAsync(DateTime fechaInicio, DateTime fechaFin);
    }
}