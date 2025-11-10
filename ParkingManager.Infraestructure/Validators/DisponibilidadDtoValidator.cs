using FluentValidation;
using ParkingManager.Infrastructure.DTOs;

namespace ParkingManager.Infrastructure.Validators
{
    public class DisponibilidadDtoValidator : AbstractValidator<DisponibilidadDto>
    {
        public DisponibilidadDtoValidator()
        {
            RuleFor(d => d.Zona)
                .NotEmpty().WithMessage("Debe indicar la zona.");

            RuleFor(d => d.EspaciosLibres)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Los espacios libres no pueden ser negativos.");

            RuleFor(d => d.EspaciosTotales)
                .GreaterThan(0)
                .WithMessage("Los espacios totales deben ser mayores a 0.");
        }
    }
}
