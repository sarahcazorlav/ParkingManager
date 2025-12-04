using ParkingManager.Core.Enum;

namespace ParkingManager.Core.Entities
{
    public class Security : BaseEntity
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // Hash
        public string Name { get; set; } = string.Empty;
        public RoleType Role { get; set; } = RoleType.User;
    }
}