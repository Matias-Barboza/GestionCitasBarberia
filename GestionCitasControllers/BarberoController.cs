using FluentValidation.Results;
using GestionCitasModels;
using GestionCitasRepositorys;
using System;
using System.Collections.Generic;

namespace GestionCitasControllers
{
    public class BarberoController
    {
        private BarberoRepository _barberoRepository;

        public BarberoRepository BarberoRepository { get => _barberoRepository; set => _barberoRepository = value; }

        public BarberoController() 
        {
            this.BarberoRepository = new BarberoRepository();
        }

        public bool IsValidBarber(Barbero barbero) 
        {
            bool valid = false;

            try
            {
                BarberoValidator validator = new BarberoValidator();

                ValidationResult result = validator.Validate(barbero);

                valid = result.IsValid;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return valid;
        }

        public bool CreateBarber(Barbero barbero) 
        {
            bool created = false;

            if(!IsValidBarber(barbero)) 
            {
                return created;
            }

            created = _barberoRepository.CreateNewBarbero(barbero);

            return created;
        }

        public bool Update(Barbero barbero) 
        {
            bool updated = false;

            if (!IsValidBarber(barbero)) 
            {
                return updated;
            }

            updated = _barberoRepository.UpdateBarbero(barbero);

            return updated;
        }

        public bool Delete(int idBarbero) 
        {
            bool deleted = false;

            if (idBarbero <= 0) 
            {
                return deleted;
            }

            deleted = _barberoRepository.DeleteBarbero(idBarbero);

            return deleted;
        }

        public Barbero GetBarberoById(int idBarbero) 
        {
            if (idBarbero <= 0) 
            {
                return null;
            }

            return _barberoRepository.GetBarberoById(idBarbero);
        }

        public List<Barbero> GetAllBarberos() 
        {
            return _barberoRepository.GetAllBarberos();
        }

        public List<string> GetAllBarberosFullNames() 
        {
            return _barberoRepository.GetAllBarberosFullNames();
        }

        public List<Barbero> GetAllBarberosFullNamesAndImageUrl()
        {
            return _barberoRepository.GetAllBarberosFullNamesAndImageUrl();
        }
    }
}
