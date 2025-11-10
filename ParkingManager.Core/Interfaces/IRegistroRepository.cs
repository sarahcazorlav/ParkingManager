using ParkingManager.Core.Entities;

namespace ParkingManager.Core.Interfaces
{
    public interface IRegistroRepository
    {
        Task<IEnumerable<Registro>> GetAllAsync();
        Task<Registro?> GetByIdAsync(int id);
        Task AddAsync(Registro registro);
        Task UpdateAsync(Registro registro);
        Task DeleteAsync(int id);
        Task RegistrarEntradaAsync(Registro registro);
        Task RegistrarSalidaAsync(int id);
    }
}
