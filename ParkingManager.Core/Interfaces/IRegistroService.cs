using ParkingManager.Core.CustomEntities;
using ParkingManager.Core.Entities;
using ParkingManager.Core.QueryFilters;

namespace ParkingManager.Core.Interfaces
{
    public interface IRegistroService
    {
        Task<PagedList<Registro>> GetRegistrosAsync(RegistroQueryFilter filters);
        Task<Registro?> GetRegistroByIdAsync(int id);
        Task InsertRegistroAsync(Registro registro);
        Task UpdateRegistroAsync(Registro registro);
        Task DeleteRegistroAsync(int id);
    }
}