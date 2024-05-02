using FluentValidation;
using FluentValidation.Results;

using GestionCitasModels;
using GestionCitasRepositorys;

namespace GestionCitasControllers
{
    public class TurnoController
    {
        private TurnoRepository turnoRepository;

        public TurnoController() 
        {
            this.TurnoRepository = new TurnoRepository();
        }

        public TurnoRepository TurnoRepository { get => turnoRepository; set => turnoRepository = value; }

        public bool IsValidAppointment(Turno entidad)
        {
            bool valid = false;

            try
            {
                TurnoValidator validator = new TurnoValidator();
                
                ValidationResult result = validator.Validate(entidad);

                valid = result.IsValid;
            }
            catch(ValidationException e) 
            {
                throw e;
            }

            return valid;
        }
    }
}
