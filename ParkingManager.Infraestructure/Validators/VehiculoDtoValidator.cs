using FluentValidation;
using ParkingManager.Infrastructure.DTOs;

namespace ParkingManager.Infrastructure.Validators
{
    public class VehiculoDtoValidator : AbstractValidator<VehiculoDto>
    {
        public VehiculoDtoValidator()
        {
            RuleFor(v => v.Placa)
                .NotEmpty().WithMessage("Debe ingresar la placa del vehículo");

            RuleFor(v => v.Marca)
                .NotEmpty().WithMessage("Debe ingresar la marca del vehículo");

            RuleFor(v => v.UsuarioId)
                .GreaterThan(0).WithMessage("Debe asignar un usuario al vehículo");
        }
    }
}
