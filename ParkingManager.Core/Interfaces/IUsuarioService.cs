using ParkingManager.Core.CustomEntities;
using ParkingManager.Core.Entities;
using ParkingManager.Core.QueryFilters;

namespace ParkingManager.Core.Interfaces
{
    public interface IUsuarioService
    {
        Task<PagedList<Usuario>> GetUsuariosAsync(UsuarioQueryFilter filters);
        Task<Usuario?> GetUsuarioByIdAsync(int id);
        Task InsertUsuarioAsync(Usuario usuario);
        Task UpdateUsuarioAsync(Usuario usuario);
        Task DeleteUsuarioAsync(int id);
    }
}