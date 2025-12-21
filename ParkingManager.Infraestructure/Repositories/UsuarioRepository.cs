// UsuarioRepository.cs - VERSIÓN COMPLETA CON DAPPER
using Microsoft.EntityFrameworkCore;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Core.QueryFilters;
using ParkingManager.Core.CustomEntities;
using ParkingManager.Infrastructure.Data;
using ParkingManager.Infrastructure.Queries;

namespace ParkingManager.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly IDapperContext _dapperContext;

        public UsuarioRepository(ParkingContext context, IDapperContext dapperContext)
            : base(context)
        {
            _dapperContext = dapperContext;
        }

        // GET con Dapper y paginación
        public async Task<IEnumerable<Usuario>> GetUsuariosAsync(UsuarioQueryFilter filters)
        {
            var sql = @"
                SELECT Id, Nombre, Apellido, Email, Username, Telefono, Rol, FechaRegistro, Activo
                FROM Usuarios
                WHERE (@Nombre IS NULL OR Nombre LIKE '%' + @Nombre + '%')
                  AND (@Email IS NULL OR Email LIKE '%' + @Email + '%')
                  AND (@Rol IS NULL OR Rol = @Rol)
                  AND (@Activo IS NULL OR Activo = @Activo)
                ORDER BY Nombre
                OFFSET @Offset ROWS
                FETCH NEXT @PageSize ROWS ONLY";

            var offset = (filters.PageNumber - 1) * filters.PageSize;

            var usuarios = await _dapperContext.QueryAsync<Usuario>(sql, new
            {
                Nombre = filters.Nombre,
                Email = filters.Email,
                Rol = filters.Rol,
                Activo = filters.Activo,
                Offset = offset,
                PageSize = filters.PageSize
            });

            return usuarios;
        }

        // GET por ID con Dapper
        public async Task<Usuario?> GetUsuarioByIdAsync(int id)
        {
            var sql = @"
                SELECT Id, Nombre, Apellido, Email, Username, Telefono, Rol, 
                       Password, FechaRegistro, Activo
                FROM Usuarios
                WHERE Id = @Id";

            return await _dapperContext.QueryFirstOrDefaultAsync<Usuario>(sql, new { Id = id });
        }

        // GET por Username con Dapper
        public async Task<Usuario?> GetByUsernameAsync(string username)
        {
            var sql = @"
                SELECT Id, Nombre, Apellido, Email, Username, Telefono, Rol, 
                       Password, FechaRegistro, Activo
                FROM Usuarios
                WHERE Username = @Username";

            return await _dapperContext.QueryFirstOrDefaultAsync<Usuario>(sql,
                new { Username = username });
        }

        // Verificar si existe email
        public async Task<bool> ExistsByEmailAsync(string email)
        {
            var sql = "SELECT COUNT(1) FROM Usuarios WHERE Email = @Email";
            var count = await _dapperContext.ExecuteScalarAsync<int>(sql, new { Email = email });
            return count > 0;
        }

        // INSERT con EF Core (transaccional)
        public async Task InsertUsuarioAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        // UPDATE con EF Core
        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        // DELETE con EF Core
        public async Task DeleteUsuarioAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            var sql = @"
        SELECT Id, Nombre, Apellido, Email, Username, Telefono, Rol, 
               Password, FechaRegistro, Activo
        FROM Usuarios
        WHERE Email = @Email";

            return await _dapperContext.QueryFirstOrDefaultAsync<Usuario>(
                sql, new { Email = email });
        }

        public async Task<bool> ExistsByUsernameAsync(string username)
        {
            var sql = "SELECT COUNT(1) FROM Usuarios WHERE Username = @Username";
            var count = await _dapperContext.ExecuteScalarAsync<int>(
                sql, new { Username = username });
            return count > 0;
        }

    }
}