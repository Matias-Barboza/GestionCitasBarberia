using FluentValidation;
using FluentValidation.Results;

using GestionCitasModels;
using GestionCitasRepositorys;

namespace GestionCitasControllers
{
    public class TurnoController
    {
        private TurnoRepository turnoRepository;

        public TurnoRepository TurnoRepository { get => turnoRepository; set => turnoRepository = value; }

        public TurnoController() 
        {
            this.TurnoRepository = new TurnoRepository();
        }

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

        public bool CreateNewTurno(Turno turno) 
        {
            return true;
        }

        public bool TestConnection() 
        {
            int result = turnoRepository.CreateTurno();

            return result == 1;
        }
    }
}
