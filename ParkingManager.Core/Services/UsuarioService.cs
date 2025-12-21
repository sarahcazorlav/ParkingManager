using ParkingManager.Core.CustomEntities;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Core.QueryFilters;

namespace ParkingManager.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedList<Usuario>> GetUsuariosAsync(UsuarioQueryFilter filters)
        {
            var usuarios = await _unitOfWork.Usuarios.GetUsuariosAsync(filters);

            // Aquí deberías obtener el total count, por ahora lo simulamos
            var pagedList = PagedList<Usuario>.Create(
                usuarios,
                filters.PageNumber,
                filters.PageSize
            );

            return pagedList;
        }

        public async Task<Usuario?> GetUsuarioByIdAsync(int id)
        {
            return await _unitOfWork.Usuarios.GetUsuarioByIdAsync(id);
        }

        public async Task InsertUsuarioAsync(Usuario usuario)
        {
            // Validaciones
            if (await _unitOfWork.Usuarios.ExistsByEmailAsync(usuario.Email))
            {
                throw new Exception("El correo ya está registrado");
            }

            if (await _unitOfWork.Usuarios.ExistsByUsernameAsync(usuario.Username))
            {
                throw new Exception("El nombre de usuario ya está registrado");
            }

            await _unitOfWork.Usuarios.InsertUsuarioAsync(usuario);
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            await _unitOfWork.Usuarios.UpdateUsuarioAsync(usuario);
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            await _unitOfWork.Usuarios.DeleteUsuarioAsync(id);
        }
    }
}