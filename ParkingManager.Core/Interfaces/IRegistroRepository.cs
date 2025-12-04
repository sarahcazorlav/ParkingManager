using ParkingManager.Core.Entities;
using ParkingManager.Core.QueryFilters;

namespace ParkingManager.Core.Interfaces
{
    public interface IRegistroRepository : IBaseRepository<Registro>
    {
        Task<IEnumerable<Registro>> GetRegistrosActivosAsync();
        Task<IEnumerable<Registro>> GetRegistrosPorUsuarioAsync(int usuarioId);
        Task<IEnumerable<Registro>> GetAllAsync();
        Task<Registro?> GetByIdAsync(int id);
        Task AddAsync(Registro registro);
        Task UpdateAsync(Registro registro);
        Task DeleteAsync(int id);
        Task RegistrarEntradaAsync(Registro registro);
        Task RegistrarSalidaAsync(int id);
        Task<IEnumerable<Registro>> GetRegistrosAsync(RegistroQueryFilter filters);
        Task<Registro?> GetRegistroByIdAsync(int id);
        Task InsertRegistroAsync(Registro registro);
        Task UpdateRegistroAsync(Registro registro);
        Task DeleteRegistroAsync(int id);
    }
}
