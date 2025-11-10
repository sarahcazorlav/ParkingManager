using FluentValidation;
using ParkingManager.Infrastructure.DTOs;

namespace ParkingManager.Infrastructure.Validators
{
    public class RegistroValidator : AbstractValidator<RegistroDto>
    {
        public RegistroValidator()
        {
            RuleFor(r => r.VehiculoId).GreaterThan(0);
            RuleFor(r => r.FechaEntrada).NotEmpty();
        }
    }
}
