using FluentValidation;

namespace GestionCitasModels
{
    public class ServicioValidator : AbstractValidator<Servicio>
    {
        public ServicioValidator() 
        {
            RuleFor(Servicio => Servicio.Id)
                .NotEmpty().WithMessage("El ID del servicio no puede estar vacío.")
                .GreaterThan(0).WithMessage("El ID no puede ser menor a 1.");

            RuleFor(Servicio => Servicio.Descripcion)
                .NotEmpty().WithMessage("La descripción del servicio no puede estar vacía.")
                .Matches("^[a-zA-Z]+(?:\\s+[a-zA-Z]+)*$").WithMessage("La descripción solo puede contener letras.");

            RuleFor(Servicio => Servicio.TiempoEstimado)
                .NotEmpty().WithMessage("El tiempo estimado no puede estar vacío.")
                .GreaterThan(0).WithMessage("El tiempo estimado del servicio no puede ser menor a 1.")
                .LessThan(60).WithMessage("El tiempo estimado del servicio no puede ser mayor a 60.");

            RuleFor(Servicio => Servicio.Precio)
                .NotEmpty().WithMessage("El precio del servicio no puede estar vacío")
                .GreaterThan(0).WithMessage("El precio no puede ser menor a 0");
        }
    }
}
