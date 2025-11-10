using Microsoft.EntityFrameworkCore;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Core.QueryFilters;
using ParkingManager.Infrastructure.Data;

namespace ParkingManager.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ParkingContext _context;

        public UsuarioRepository(ParkingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosAsync(UsuarioQueryFilter filters)
        {
            var query = _context.Usuarios.AsQueryable();

            if (filters.Id != null)
                query = query.Where(u => u.Id == filters.Id);

            if (!string.IsNullOrEmpty(filters.Nombre))
                query = query.Where(u => u.Nombre.Contains(filters.Nombre));
            return await query.ToListAsync();
        }

        public async Task<Usuario?> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task InsertUsuarioAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
