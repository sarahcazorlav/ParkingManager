using ParkingManager.Core.Entities;
using ParkingManager.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingManager.Core.Interfaces
{
    public interface IRegistroService
    {
        Task<IEnumerable<Registro>> GetRegistrosAsync(RegistroQueryFilter filters);
        Task<Registro?> GetRegistroAsync(int id);
        Task InsertRegistroAsync(Registro registro);
        Task<bool> UpdateRegistroAsync(Registro registro);
        Task<bool> DeleteRegistroAsync(int id);
    }
}
