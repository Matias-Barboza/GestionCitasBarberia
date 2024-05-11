using FluentValidation.Results;
using GestionCitasModels;
using GestionCitasRepositorys;
using System;
using System.Collections.Generic;

namespace GestionCitasControllers
{
    public class ServicioController
    {
        private ServicioRepository servicioRepository;

        public ServicioRepository ServicioRepository { get => servicioRepository; set => servicioRepository = value; }

        public ServicioController()
        {
            this.ServicioRepository = new ServicioRepository();
        }

        public bool IsValidService(Servicio servicio)
        {
            bool valid = false;

            try
            {
                ServicioValidator validator = new ServicioValidator();

                ValidationResult result = validator.Validate(servicio);

                valid = result.IsValid;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return valid;
        }

        public bool CreateServicio(Servicio servicio)
        {
            bool created = false;


            if (!IsValidService(servicio))
            {
                return created;
            }

            created = servicioRepository.CreateService(servicio);

            return created;
        }

        public bool UpdateServicio(Servicio servicio)
        {
            bool updated = false;

            if (!IsValidService(servicio))
            {
                return updated;
            }

            updated = servicioRepository.UpdateServicio(servicio);

            return updated;
        }

        public bool DeleteServicio(int idServicio)
        {
            bool deleted = false;

            if (idServicio <= 0)
            {
                return deleted;
            }

            deleted = servicioRepository.DeleteServicio(idServicio);

            return deleted;
        }

        public Servicio GetServicioById(int idServicio)
        {
            if (idServicio <= 0)
            {
                return null;
            }

            return servicioRepository.GetServicioById(idServicio);
        }

        public List<Servicio> GetAllServicios()
        {
            return servicioRepository.GetAllServicios();
        }

        public List<string> GetAllServiciosDescription()
        {
            return servicioRepository.GetAllServiciosDescription();
        }
    }
}
