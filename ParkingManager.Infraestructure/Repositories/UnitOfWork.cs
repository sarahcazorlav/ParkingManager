using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ParkingManager.Core.Interfaces;
using ParkingManager.Infrastructure.Data;
using System.Data;

namespace ParkingManager.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ParkingContext _context;
        private readonly IDapperContext _dapper;
        private IDbContextTransaction? _efTransaction;

        // Repositorios lazy
        private IDisponibilidadRepository? _disponibilidadRepository;
        private IRegistroRepository? _registroRepository;
        private ITarifaRepository? _tarifaRepository;
        private IUsuarioRepository? _usuarioRepository;
        private IVehiculoRepository? _vehiculoRepository;
        private ISecurityRepository? _securityRepository;

        public UnitOfWork(ParkingContext context, IDapperContext dapper)
        {
            _context = context;
            _dapper = dapper;
        }

        public IDisponibilidadRepository Disponibilidades =>
            _disponibilidadRepository ??= new DisponibilidadRepository(_context, _dapper);

        public IRegistroRepository Registros =>
            _registroRepository ??= new RegistroRepository(_context, _dapper);

        public ITarifaRepository Tarifas =>
            _tarifaRepository ??= new TarifaRepository(_context, _dapper);

        public IUsuarioRepository Usuarios =>
            _usuarioRepository ??= new UsuarioRepository(_context, _dapper);

        public IVehiculoRepository Vehiculos =>
            _vehiculoRepository ??= new VehiculoRepository(_context, _dapper);

        public ISecurityRepository Security =>
            _securityRepository ??= new SecurityRepository(_context, _dapper);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            if (_efTransaction == null)
            {
                _efTransaction = await _context.Database.BeginTransactionAsync();
                var conn = _context.Database.GetDbConnection();
                var tx = _efTransaction.GetDbTransaction();
                _dapper.SetAmbientConnection(conn, tx);
            }
        }

        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                if (_efTransaction != null)
                {
                    await _efTransaction.CommitAsync();
                    _efTransaction.Dispose();
                    _efTransaction = null;
                }
            }
            finally
            {
                _dapper.ClearAmbientConnection();
            }
        }

        public async Task RollbackAsync()
        {
            if (_efTransaction != null)
            {
                await _efTransaction.RollbackAsync();
                _efTransaction.Dispose();
                _efTransaction = null;
            }
            _dapper.ClearAmbientConnection();
        }

        public IDbConnection? GetDbConnection()
        {
            return _context.Database.GetDbConnection();
        }

        public IDbTransaction? GetDbTransaction()
        {
            return _efTransaction?.GetDbTransaction();
        }

        public void Dispose()
        {
            _efTransaction?.Dispose();
            _context?.Dispose();
        }
    }
}