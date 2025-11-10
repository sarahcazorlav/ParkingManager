using FluentValidation;
using ParkingManager.Infrastructure.DTOs;

namespace ParkingManager.Infrastructure.Validators
{
    public class VehiculoValidator : AbstractValidator<VehiculoDto>
    {
        public VehiculoValidator()
        {
            RuleFor(v => v.Placa)
                .NotEmpty().Length(5, 10)
                .WithMessage("La placa debe tener entre 5 y 10 caracteres");

            RuleFor(v => v.Tipo)
                .NotEmpty().WithMessage("Debe especificar el tipo de vehículo");
        }
    }
}
