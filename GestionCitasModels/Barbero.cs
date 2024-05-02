using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCitasModels
{
    public class Barbero
    {
        private int id;
        private string nombreApellido;
        private string email;

        public int Id { get => id; set => id = value; }
        public string NombreApellido { get => nombreApellido; set => nombreApellido = value; }
        public string Email { get => email; set => email = value; }
    }
}
