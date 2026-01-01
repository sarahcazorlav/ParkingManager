using FluentValidation;
using ParkingManager.Infrastructure.DTOs;

namespace ParkingManager.Infrastructure.Validators
{
    public class DisponibilidadRangoRequestDtoValidator : AbstractValidator<DisponibilidadRangoRequestDto>
    {
        public DisponibilidadRangoRequestDtoValidator()
        {
            // Validaciones para fecha de inicio
            RuleFor(x => x.DiaInicio)
                .InclusiveBetween(1, 31)
                .WithMessage("El día de inicio debe estar entre 1 y 31");

            RuleFor(x => x.MesInicio)
                .InclusiveBetween(1, 12)
                .WithMessage("El mes de inicio debe estar entre 1 y 12");

            RuleFor(x => x.AnioInicio)
                .InclusiveBetween(2020, 2100)
                .WithMessage("El año de inicio debe estar entre 2020 y 2100");

            // Validaciones para fecha final
            RuleFor(x => x.DiaFinal)
                .InclusiveBetween(1, 31)
                .WithMessage("El día final debe estar entre 1 y 31");

            RuleFor(x => x.MesFinal)
                .InclusiveBetween(1, 12)
                .WithMessage("El mes final debe estar entre 1 y 12");

            RuleFor(x => x.AnioFinal)
                .InclusiveBetween(2020, 2100)
                .WithMessage("El año final debe estar entre 2020 y 2100");

            // Validación de fecha válida
            RuleFor(x => x)
                .Must(x => EsFechaValida(x.DiaInicio, x.MesInicio, x.AnioInicio))
                .WithMessage("La fecha de inicio no es válida")
                .Must(x => EsFechaValida(x.DiaFinal, x.MesFinal, x.AnioFinal))
                .WithMessage("La fecha final no es válida");

            // Validación de que fecha inicio <= fecha final
            RuleFor(x => x)
                .Must(x =>
                {
                    try
                    {
                        var fechaInicio = x.ObtenerFechaInicio();
                        var fechaFinal = x.ObtenerFechaFinal();
                        return fechaInicio <= fechaFinal;
                    }
                    catch
                    {
                        return false;
                    }
                })
                .WithMessage("La fecha de inicio debe ser menor o igual a la fecha final");

            // Validación de rango máximo de 31 días
            RuleFor(x => x)
                .Must(x =>
                {
                    try
                    {
                        var fechaInicio = x.ObtenerFechaInicio();
                        var fechaFinal = x.ObtenerFechaFinal();
                        return (fechaFinal - fechaInicio).TotalDays <= 31;
                    }
                    catch
                    {
                        return false;
                    }
                })
                .WithMessage("El rango de fechas no puede ser mayor a 31 días");
        }

        private bool EsFechaValida(int dia, int mes, int anio)
        {
            try
            {
                var fecha = new DateTime(anio, mes, dia);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}