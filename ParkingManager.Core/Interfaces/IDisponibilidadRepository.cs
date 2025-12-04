using ParkingManager.Core.Entities;
using ParkingManager.Core.QueryFilters;

namespace ParkingManager.Core.Interfaces
{
    public interface IDisponibilidadRepository : IBaseRepository<Disponibilidad>
    {
        Task<IEnumerable<Disponibilidad>> GetAllAsync();
        Task<IEnumerable<Disponibilidad>> GetDisponiblesPorZonaAsync(string zona);
        Task<Disponibilidad?> GetByIdAsync(int id);
        Task AddAsync(Disponibilidad disp);
        Task UpdateAsync(Disponibilidad disp);
        Task DeleteAsync(int id);
        Task<IEnumerable<Disponibilidad>> GetDisponibilidadesAsync(DisponibilidadQueryFilter filters);
        Task<Disponibilidad?> GetDisponibilidadByIdAsync(int id);
        Task InsertDisponibilidadAsync(Disponibilidad disponibilidad);
        Task UpdateDisponibilidadAsync(Disponibilidad disponibilidad);
        Task DeleteDisponibilidadAsync(int id);
    }
}
