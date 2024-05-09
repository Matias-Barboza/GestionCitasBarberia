using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace GestionCitasModels
{
    public class BarberoValidator : AbstractValidator<Barbero>
    {
        public BarberoValidator() 
        {
            RuleFor(Barbero => Barbero.Nombre)
                .NotEmpty().WithMessage("El nombre del barbero no puede estar vacío.")
                .Matches("^[a-zA-Z]+(?:\\s+[a-zA-Z]+)*$").WithMessage("El nombre solo puede contener letras.");

            RuleFor(Barbero => Barbero.Apellido)
                .NotEmpty().WithMessage("El apellido del barbero no puede estar vacío.")
                .Matches("^[a-zA-Z]+(?:\\s+[a-zA-Z]+)*$").WithMessage("El apellido solo puede contener letras.");

            RuleFor(Barbero => Barbero.Email)
                .NotEmpty().WithMessage("La información 'Email' es obligatoria, no puede estar vacía.")
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).WithMessage("La dirección proporcionada debe respetar una estructura de mail.");
        }
    }
}
