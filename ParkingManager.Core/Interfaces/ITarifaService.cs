using ParkingManager.Core.CustomEntities;
using ParkingManager.Core.Entities;
using ParkingManager.Core.QueryFilters;

namespace ParkingManager.Core.Interfaces
{
    public interface ITarifaService
    {
        Task<PagedList<Tarifa>> GetTarifasAsync(TarifaQueryFilter filters);
        Task<Tarifa?> GetTarifaByIdAsync(int id);
        Task InsertTarifaAsync(Tarifa tarifa);
        Task UpdateTarifaAsync(Tarifa tarifa);
        Task DeleteTarifaAsync(int id);
    }
}

