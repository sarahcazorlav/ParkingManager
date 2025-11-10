using FluentValidation;
using ParkingManager.Infrastructure.DTOs;

namespace ParkingManager.Infrastructure.Validators
{
    public class DisponibilidadValidator : AbstractValidator<DisponibilidadDto>
    {
        public DisponibilidadValidator()
        {
            RuleFor(d => d.Zona)
                .NotEmpty().WithMessage("Debe indicar la zona.");

            RuleFor(d => d.EspaciosLibres)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Los espacios libres no pueden ser negativos.");
        }
    }
}
