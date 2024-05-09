using FluentValidation;
using System;

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
                .NotEmpty().WithMessage("La información 'Nombre' es obligatoria, no puede estar vacía.")
                .Matches("^[a-zA-Z]+(?:\\s+[a-zA-Z]+)*$").WithMessage("El nombre solo puede contener letras.");

            RuleFor(Turno => Turno.ApellidoCliente)
                .NotEmpty().WithMessage("La información 'Apellido' es obligatoria, no puede estar vacía.")
                .Matches("^[a-zA-Z]+(?:\\s+[a-zA-Z]+)*$").WithMessage("El apellido solo puede contener letras.");

            RuleFor(Turno => Turno.TelefonoCliente)
                .NotEmpty().WithMessage("La información 'Teléfono' es obligatoria, no puede estar vacía.")
                .Matches("^(?:\\+?54)?\\d{10}$").WithMessage("El teléfono solo puede contener números.");

            RuleFor(Turno => Turno.EmailCliente)
                .NotEmpty().WithMessage("La información 'Email' es obligatoria, no puede estar vacía.")
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).WithMessage("La dirección proporcionada debe respetar una estructura de email");
                //.Matches("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$").WithMessage("La dirección proporcionada debe respetar una estructura de email.");
        }
    }
}
