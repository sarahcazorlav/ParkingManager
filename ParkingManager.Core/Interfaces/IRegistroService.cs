using ParkingManager.Core.CustomEntities;
using ParkingManager.Core.Entities;
using ParkingManager.Core.QueryFilters;

namespace ParkingManager.Core.Interfaces
{
    public interface IRegistroService
    {
        Task<Registro> RegistrarEntradaAsync(Registro registro);
        Task<Registro> RegistrarSalidaAsync(int registroId);
        Task<Registro?> GetRegistroByIdAsync(int id);
    }
}