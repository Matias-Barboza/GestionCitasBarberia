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

        public Turno GetById(int idTurno) 
        {
            if(idTurno < 1000) 
            {
                return null;
            }

            return turnoRepository.GetTurnoById(idTurno);
        }

        public bool CreateNewTurno(Turno turno) 
        {
            bool result = false;

            if (!IsValidAppointment(turno))
            {
                return result;
            }

            result = turnoRepository.CreateTurno(turno);

            return result;
        }

        public bool DeleteTurno(int idTurno) 
        {
            bool eliminated = false;

            if(idTurno < 1000)
            {
                return false;
            }

            eliminated = turnoRepository.DeleteTurno(idTurno);

            return eliminated;
        }

        public bool SuccessConnection() 
        {
            int result = turnoRepository.TestConnection();

            return result == 1;
        }
    }
}
