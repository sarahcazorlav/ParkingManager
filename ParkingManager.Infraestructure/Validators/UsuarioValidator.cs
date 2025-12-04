using FluentValidation;
using ParkingManager.Core.Entities;

namespace ParkingManager.Infrastructure.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MaximumLength(100);

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio")
                .MaximumLength(100);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email es obligatorio")
                .EmailAddress().WithMessage("Debe ser un correo válido")
                .MaximumLength(100);

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("El username es obligatorio")
                .MinimumLength(4).WithMessage("Mínimo 4 caracteres")
                .MaximumLength(50);

            RuleFor(x => x.Telefono)
                .MaximumLength(15)
                .When(x => !string.IsNullOrEmpty(x.Telefono));

            RuleFor(x => x.Rol)
                .NotEmpty().WithMessage("El rol es obligatorio");
        }
    }
}