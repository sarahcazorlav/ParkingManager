using Microsoft.EntityFrameworkCore;
using ParkingManager.Core.Entities;
using ParkingManager.Core.Interfaces;
using ParkingManager.Core.QueryFilters;
using ParkingManager.Infrastructure.Data;

namespace ParkingManager.Infrastructure.Repositories
{
    public class DisponibilidadRepository
    : BaseRepository<Disponibilidad>, IDisponibilidadRepository
    {
        public DisponibilidadRepository(ParkingContext context, IDapperContext dapper)
            : base(context) { }

        public async Task<IEnumerable<Disponibilidad>> GetDisponiblesPorZonaAsync(string zona)
        {
            return await _context.Disponibilidades
                .Where(d => d.Zona == zona && !d.Ocupado)
                .ToListAsync();
        }
        public async Task DeleteDisponibilidadAsync(int id)
        {
            var entity = await _context.Disponibilidades.FindAsync(id);
            if (entity != null)
            {
                _context.Disponibilidades.Remove(entity);
            }
        }

        public async Task<Disponibilidad?> GetDisponibilidadByIdAsync(int id)
        {
            return await _context.Disponibilidades.FindAsync(id);
        }

        public async Task<IEnumerable<Disponibilidad>> GetDisponibilidadesAsync(DisponibilidadQueryFilter filters)
        {
            var query = _context.Disponibilidades.AsQueryable();

            if (!string.IsNullOrEmpty(filters.Zona))
                query = query.Where(d => d.Zona == filters.Zona);

            if (!string.IsNullOrEmpty(filters.Estado))
                query = query.Where(d => d.Estado == filters.Estado);

            if (filters.Piso.HasValue)
                query = query.Where(d => d.Piso == filters.Piso.Value);

            if (filters.Ocupado.HasValue)
                query = query.Where(d => d.Ocupado == filters.Ocupado.Value);

            return await query.ToListAsync();
        }

        public async Task InsertDisponibilidadAsync(Disponibilidad disponibilidad)
        {
            await _context.Disponibilidades.AddAsync(disponibilidad);
        }

        public async Task UpdateDisponibilidadAsync(Disponibilidad disponibilidad)
        {
            _context.Disponibilidades.Update(disponibilidad);
        }
    }
}
