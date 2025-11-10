using ParkingManager.Infrastructure.DTOs;

using FluentValidation;
using ParkingManager.Infrastructure.DTOs;

namespace ParkingManager.Infrastructure.Validators
{
    public class TarifaValidator : AbstractValidator<TarifaDto>
    {
        public TarifaValidator()
        {
            RuleFor(t => t.TipoVehiculo)
                .NotEmpty().WithMessage("Debe indicar el tipo de vehículo.");

            RuleFor(t => t.MontoPorHora)
                .GreaterThan(0).WithMessage("La tarifa debe ser mayor a 0.");
        }
    }
}
