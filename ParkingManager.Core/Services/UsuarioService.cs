using ParkingManager.Core.Entities;
using ParkingManager.Core.QueryFilters;
using ParkingManager.Core.CustomEntities;
using ParkingManager.Core.Interfaces;

namespace ParkingManager.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<PagedList<Usuario>> GetUsuariosAsync(UsuarioQueryFilter filters)
        {
            var usuarios = await _usuarioRepository.GetUsuariosAsync(filters);

            int pageNumber = filters.PageNumber == 0 ? 1 : filters.PageNumber;
            int pageSize = filters.PageSize == 0 ? 10 : filters.PageSize;

            // Crear lista paginada
            return PagedList<Usuario>.Create(usuarios, pageNumber, pageSize);
        }

        public async Task<Usuario?> GetUsuarioByIdAsync(int id) =>
            await _usuarioRepository.GetUsuarioByIdAsync(id);

        public async Task InsertUsuarioAsync(Usuario usuario) =>
            await _usuarioRepository.InsertUsuarioAsync(usuario);

        public async Task UpdateUsuarioAsync(Usuario usuario) =>
            await _usuarioRepository.UpdateUsuarioAsync(usuario);

        public async Task DeleteUsuarioAsync(int id) =>
            await _usuarioRepository.DeleteUsuarioAsync(id);
    }
}
