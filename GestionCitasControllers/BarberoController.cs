using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using GestionCitasModels;
using GestionCitasRepositorys;

namespace GestionCitasControllers
{
    public class BarberoController
    {
        private BarberoRepository barberoRepository;

        public BarberoRepository BarberoRepository { get => barberoRepository; set => barberoRepository = value; }

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

            created = barberoRepository.CreateNewBarbero(barbero);

            return created;
        }

        public bool Update(Barbero barbero) 
        {
            bool updated = false;

            if (!IsValidBarber(barbero)) 
            {
                return updated;
            }

            updated = barberoRepository.UpdateBarbero(barbero);

            return updated;
        }

        public bool Delete(int idBarbero) 
        {
            bool deleted = false;

            deleted = barberoRepository.DeleteBarbero(idBarbero);

            return deleted;
        }

        public Barbero GetBarberoById(int idBarbero) 
        {
            barberoRepository
        }
    }
}
