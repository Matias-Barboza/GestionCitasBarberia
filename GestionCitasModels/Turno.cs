using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCitasModels
{
    public class Turno
    {
        private int idTurno;
        private int idBarbero;
        private int idServicio;
        private DateTime fechaYHora;
        private string nombreApellidoCliente;
        private string telefonoCliente;
        private string emailCliente;

        public int IdTurno { get => idTurno; set => idTurno = value; }
        public int IdBarbero { get => idBarbero; set => idBarbero = value; }
        public int IdServicio { get => idServicio; set => idServicio = value; }
        public DateTime FechaYHora { get => fechaYHora; set => fechaYHora = value; }
        public string NombreApellidoCliente { get => nombreApellidoCliente; set => nombreApellidoCliente = value; }
        public string TelefonoCliente { get => telefonoCliente; set => telefonoCliente = value; }
        public string EmailCliente { get => emailCliente; set => emailCliente = value; }
    }
}
