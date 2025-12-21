using ParkingManager.Core.Entities;
using ParkingManager.Core.QueryFilters;

namespace ParkingManager.Core.Interfaces
{
    public interface IDisponibilidadRepository : IBaseRepository<Disponibilidad>
    {
        Task DeleteDisponibilidadAsync(int id);
        Task<Disponibilidad?> GetDisponibilidadByIdAsync(int id);
        Task<IEnumerable<Disponibilidad>> GetDisponibilidadesAsync(DisponibilidadQueryFilter filters);
        Task<IEnumerable<Disponibilidad>> GetDisponiblesPorZonaAsync(string zona);
        Task InsertDisponibilidadAsync(Disponibilidad disponibilidad);
        Task UpdateDisponibilidadAsync(Disponibilidad disponibilidad);
    }
}
