using FluentValidation;
using ParkingManager.Infrastructure.DTOs;

namespace ParkingManager.Infrastructure.Validators
{
    public class UsuarioDtoValidator : AbstractValidator<UsuarioDto>
    {
        public UsuarioDtoValidator()
        {
            RuleFor(u => u.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio");

            RuleFor(u => u.Correo)
                .EmailAddress().WithMessage("Debe proporcionar un correo válido");

            RuleFor(u => u.Rol)
                .NotEmpty().WithMessage("Debe especificar el rol del usuario");
        }
    }
}
