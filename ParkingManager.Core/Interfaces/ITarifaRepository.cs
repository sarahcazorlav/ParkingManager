using ParkingManager.Core.Entities;
using ParkingManager.Core.QueryFilters;

namespace ParkingManager.Core.Interfaces
{
    public interface ITarifaRepository
    {
        Task<IEnumerable<Tarifa>> GetAllAsync();
        Task<Tarifa?> GetByIdAsync(int id);
        Task AddAsync(Tarifa tarifa);
        Task UpdateAsync(Tarifa tarifa);
        Task DeleteAsync(int id);
        Task<IEnumerable<Tarifa>> GetTarifasAsync(TarifaQueryFilter filters);
        Task<Tarifa?> GetTarifaByIdAsync(int id);
        Task InsertTarifaAsync(Tarifa tarifa);
        Task UpdateTarifaAsync(Tarifa tarifa);
        Task DeleteTarifaAsync(int id);
    }
}