using Microsoft.EntityFrameworkCore;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Core.QueryFilters;
using ParkingManager.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingManager.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ParkingContext context) : base(context) { }

        public async Task<IEnumerable<Usuario>> GetUsuariosAsync(string? nombre = null)
        {
            var query = _context.Usuarios.AsQueryable();

            if (!string.IsNullOrEmpty(nombre))
                query = query.Where(u => u.Nombre.Contains(nombre) || u.Apellido.Contains(nombre));

            return await query
                .Include(u => u.Vehiculos)
                .OrderBy(u => u.Nombre)
                .ToListAsync();
        }

        public async Task<Usuario?> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios
                .Include(u => u.Vehiculos)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<IEnumerable<Usuario>> GetUsuariosAsync(UsuarioQueryFilter filters)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario?> GetByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task InsertUsuarioAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUsuarioAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUsuarioAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
