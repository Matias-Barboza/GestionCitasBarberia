using FluentValidation.Results;
using GestionCitasModels;
using GestionCitasRepositorys;
using System;
using System.Collections.Generic;

namespace GestionCitasControllers
{
    public class ServicioController
    {
        private ServicioRepository _servicioRepository;

        public ServicioRepository ServicioRepository { get => _servicioRepository; set => _servicioRepository = value; }

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

            created = _servicioRepository.CreateService(servicio);

            return created;
        }

        public bool UpdateServicio(Servicio servicio)
        {
            bool updated = false;

            if (!IsValidService(servicio))
            {
                return updated;
            }

            updated = _servicioRepository.UpdateServicio(servicio);

            return updated;
        }

        public bool DeleteServicio(int idServicio)
        {
            bool deleted = false;

            if (idServicio <= 0)
            {
                return deleted;
            }

            deleted = _servicioRepository.DeleteServicio(idServicio);

            return deleted;
        }

        public Servicio GetServicioById(int idServicio)
        {
            if (idServicio <= 0)
            {
                return null;
            }

            return _servicioRepository.GetServicioById(idServicio);
        }

        public int GetTiempoEstimadoServicioById(int idServicio) 
        {
            return _servicioRepository.GetTiempoEstimadoServicioById(idServicio);
        }

        public decimal GetPrecioServicioById(int idServicio) 
        {
            return _servicioRepository.GetPrecioServicioById(idServicio);
        }

        public List<Servicio> GetAllServicios()
        {
            return _servicioRepository.GetAllServicios();
        }

        public List<string> GetAllServiciosDescription()
        {
            return _servicioRepository.GetAllServiciosDescription();
        }
    }
}
