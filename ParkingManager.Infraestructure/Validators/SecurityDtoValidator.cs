using FluentValidation;
using ParkingManager.Infrastructure.DTOs;

namespace ParkingManager.Infrastructure.Validators
{
    public class SecurityDtoValidator : AbstractValidator<SecurityDto>
    {
        public SecurityDtoValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("El login es obligatorio")
                .MinimumLength(4).WithMessage("El login debe tener al menos 4 caracteres")
                .MaximumLength(50).WithMessage("El login no puede exceder 50 caracteres");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es obligatoria")
                .MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres")
                .MaximumLength(100).WithMessage("La contraseña no puede exceder 100 caracteres");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MaximumLength(100).WithMessage("El nombre no puede exceder 100 caracteres");

            RuleFor(x => x.Role)
                .IsInEnum().WithMessage("El rol no es válido");
        }
    }
}