using ParkingManager.Core.Entities;

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
    }
}
