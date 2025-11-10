namespace ParkingManager.Infrastructure.Queries
{
    public static class VehiculoQuery
    {
        // Consulta general
        public const string GetAllVehiculos = @"
            SELECT v.Id, v.Placa, v.Marca, v.Modelo, v.Color, v.UsuarioId, u.Nombre AS Propietario
            FROM Vehiculos v
            INNER JOIN Usuarios u ON u.Id = v.UsuarioId;
        ";

        // Buscar vehículo por placa
        public const string GetVehiculoByPlaca = @"
            SELECT * FROM Vehiculos WHERE Placa = @Placa;
        ";

        // Listar vehículos por usuario
        public const string GetVehiculosByUsuario = @"
            SELECT v.*
            FROM Vehiculos v
            INNER JOIN Usuarios u ON u.Id = v.UsuarioId
            WHERE v.UsuarioId = @UsuarioId;
        ";

        // Estadísticas o conteo
        public const string CountVehiculosPorUsuario = @"
            SELECT UsuarioId, COUNT(*) AS TotalVehiculos
            FROM Vehiculos
            GROUP BY UsuarioId;
        ";
    }
}
