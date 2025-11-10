using FluentValidation;
using ParkingManager.Infrastructure.DTOs;

namespace ParkingManager.Infrastructure.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioDto>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MaximumLength(50);

            RuleFor(x => x.Correo)
                .NotEmpty().EmailAddress().WithMessage("Debe ser un correo válido");

            RuleFor(x => x.Password)
                .NotEmpty().MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres");
        }
    }
}
