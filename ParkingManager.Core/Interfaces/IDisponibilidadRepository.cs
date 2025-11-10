using ParkingManager.Core.Entities;

namespace ParkingManager.Core.Interfaces
{
    public interface IDisponibilidadRepository
    {
        Task<IEnumerable<Disponibilidad>> GetAllAsync();
        Task<Disponibilidad?> GetByIdAsync(int id);
        Task AddAsync(Disponibilidad disp);
        Task UpdateAsync(Disponibilidad disp);
        Task DeleteAsync(int id);
    }
}
