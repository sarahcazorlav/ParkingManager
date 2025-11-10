using FluentValidation;
using ParkingManager.Infrastructure.DTOs;

namespace ParkingManager.Infrastructure.Validators
{
    public class TarifaDtoValidator : AbstractValidator<TarifaDto>
    {
        public TarifaDtoValidator()
        {
            RuleFor(t => t.TipoVehiculo)
                .NotEmpty().WithMessage("Debe indicar el tipo de vehículo");

            RuleFor(t => t.PrecioPorHora)
                .GreaterThan(0).WithMessage("El precio por hora debe ser mayor a 0");
        }
    }
}
