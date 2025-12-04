using FluentValidation;
using ParkingManager.Infrastructure.DTOs;

namespace ParkingManager.Infrastructure.Validators
{
    public class UsuarioDtoValidator : AbstractValidator<UsuarioDto>
    {
        public UsuarioDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MaximumLength(100).WithMessage("El nombre no puede exceder 100 caracteres");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio")
                .MaximumLength(100).WithMessage("El apellido no puede exceder 100 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email es obligatorio")
                .EmailAddress().WithMessage("Debe ser un correo electrónico válido")
                .MaximumLength(100).WithMessage("El email no puede exceder 100 caracteres");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("El username es obligatorio")
                .MinimumLength(4).WithMessage("El username debe tener al menos 4 caracteres")
                .MaximumLength(50).WithMessage("El username no puede exceder 50 caracteres");

            RuleFor(x => x.Telefono)
                .MaximumLength(15).WithMessage("El teléfono no puede exceder 15 caracteres")
                .When(x => !string.IsNullOrEmpty(x.Telefono));

            RuleFor(x => x.Rol)
                .NotEmpty().WithMessage("El rol es obligatorio")
                .Must(rol => rol == "Admin" || rol == "Usuario")
                .WithMessage("El rol debe ser 'Admin' o 'Usuario'");
        }
    }
}