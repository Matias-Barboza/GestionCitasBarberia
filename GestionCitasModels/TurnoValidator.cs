using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCitasModels
{
    public class TurnoValidator: AbstractValidator<Turno>
    {
        public TurnoValidator() 
        {
            RuleFor(Turno => Turno.Barbero.Id)
                .NotEmpty().WithMessage("Es obligatorio seleccionar un barbero para la cita.")
                .GreaterThan(0).WithMessage("Debe elegir una opción válida.");

            RuleFor(Turno => Turno.Barbero.Id)
                .NotEmpty().WithMessage("Es obligatorio seleccionar un servicio para la cita.")
                .GreaterThan(0).WithMessage("Debe elegir una opción válida.");

            RuleFor(Turno => Turno.FechaYHora)
                .NotEmpty().WithMessage("Es obligatorio seleccionar una fecha para la cita.")
                .GreaterThan(DateTime.Today.AddDays(-1));

            RuleFor(Turno => Turno.NombreCliente)
                .NotEmpty().WithMessage("La información 'Nombre' es obligatoria.")
                .Matches("^[a-zA-Z]+(?:\\s+[a-zA-Z]+)*$");

            RuleFor(Turno => Turno.ApellidoCliente)
                .NotEmpty().WithMessage("La información 'Apellido' es obligatoria.")
                .Matches("^[a-zA-Z]+(?:\\s+[a-zA-Z]+)*$");

            RuleFor(Turno => Turno.TelefonoCliente)
                .NotEmpty().WithMessage("La información: Teléfono es obligatoria.")
                .Matches("^(?:\\+?54)?\\d{10}$");

            RuleFor(Turno => Turno.EmailCliente)
                .NotEmpty().WithMessage("La información: Email es obligatoria.")
                .Matches("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
        }
    }
}
