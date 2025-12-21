using FluentValidation;
using ParkingManager.Infrastructure.DTOs;

namespace ParkingManager.Infrastructure.Validators
{
    public class DisponibilidadRangoRequestDtoValidator : AbstractValidator<DisponibilidadRangoRequestDto>
    {
        public DisponibilidadRangoRequestDtoValidator()
        {
            RuleFor(x => x.FechaInicio)
                .NotEmpty().WithMessage("La fecha de inicio es requerida")
                .LessThanOrEqualTo(x => x.FechaFin)
                .WithMessage("La fecha de inicio debe ser menor o igual a la fecha de fin");

            RuleFor(x => x.FechaFin)
                .NotEmpty().WithMessage("La fecha de fin es requerida");

            RuleFor(x => x)
                .Must(x => (x.FechaFin - x.FechaInicio).TotalDays <= 31)
                .WithMessage("El rango de fechas no puede ser mayor a 31 días");
        }
    }
}