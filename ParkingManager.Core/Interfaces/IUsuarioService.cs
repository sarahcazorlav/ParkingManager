using ParkingManager.Core.Entities;
using ParkingManager.Core.QueryFilters;
using ParkingManager.Core.CustomEntities; // si tienes ResponseData o paginación

namespace ParkingManager.Core.Services
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
