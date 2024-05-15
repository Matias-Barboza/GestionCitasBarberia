using FluentValidation;
using FluentValidation.Results;
using GestionCitasModels;
using GestionCitasRepositorys;
using System;
using System.Collections.Generic;

namespace GestionCitasControllers
{
    public class TurnoController
    {
        private TurnoRepository _turnoRepository;

        public TurnoRepository TurnoRepository { get => _turnoRepository; set => _turnoRepository = value; }

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
            catch(ValidationException ex) 
            {
                throw ex;
            }

            return valid;
        }

        public bool CreateTurno(Turno turno) 
        {
            bool created = false;

            if (!IsValidAppointment(turno))
            {
                return created;
            }

            created = _turnoRepository.CreateTurno(turno);

            return created;
        }

        public bool UpdateTurno(Turno turno) 
        {
            bool updated = false;

            if (!IsValidAppointment(turno)) 
            {
                return updated;
            }

            updated = _turnoRepository.UpdateTurno(turno);

            return updated;
        }

        public bool DeleteTurno(int idTurno) 
        {
            bool eliminated = false;

            if(idTurno < 1000)
            {
                return false;
            }

            eliminated = _turnoRepository.DeleteTurno(idTurno);

            return eliminated;
        }

        public Turno GetTurnoById(int idTurno) 
        {
            if(idTurno < 1000) 
            {
                return null;
            }

            return _turnoRepository.GetTurnoById(idTurno);
        }

        public List<Turno> GetAllTurnos() 
        {
            return _turnoRepository.GetAllTurnos();
        }

        public List<TimeSpan> GetAllHoursNotAvailablesOf(DateTime fecha, string nombreBarbero) 
        {
            return _turnoRepository.GetHourNotAvailablesOf(fecha, nombreBarbero);
        }

        public bool SuccessConnection() 
        {
            int result = _turnoRepository.TestConnection();

            return result == 1;
        }
    }
}
