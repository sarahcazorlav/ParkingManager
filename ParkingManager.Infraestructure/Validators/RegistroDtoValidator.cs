using FluentValidation;
using ParkingManager.Infrastructure.DTOs;

namespace ParkingManager.Infrastructure.Validators
{
    public class RegistroDtoValidator : AbstractValidator<RegistroDto>
    {
        public RegistroDtoValidator()
        {
            RuleFor(r => r.VehiculoId)
                .GreaterThan(0).WithMessage("Debe especificar el vehículo.");

            RuleFor(r => r.TarifaId)
                .GreaterThan(0).WithMessage("Debe especificar una tarifa válida.");

            RuleFor(r => r.HoraEntrada)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("La hora de entrada no puede ser futura.");
        }
    }
}
