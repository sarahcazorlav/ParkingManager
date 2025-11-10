namespace ParkingManager.Infrastructure.Queries
{
    public static class UsuarioQuery
    {
        public const string GetAllUsuarios = @"
            SELECT IdUsuario, Nombre, Email, Rol
            FROM Usuarios;
        ";

        public const string GetUsuarioById = @"
            SELECT IdUsuario, Nombre, Email, Rol
            FROM Usuarios
            WHERE IdUsuario = @IdUsuario;
        ";

        public const string InsertUsuario = @"
            INSERT INTO Usuarios (Nombre, Email, Rol)
            VALUES (@Nombre, @Email, @Rol);
        ";

        public const string UpdateUsuario = @"
            UPDATE Usuarios
            SET Nombre = @Nombre, Email = @Email, Rol = @Rol
            WHERE IdUsuario = @IdUsuario;
        ";

        public const string DeleteUsuario = @"
            DELETE FROM Usuarios
            WHERE IdUsuario = @IdUsuario;
        ";
    }
}
