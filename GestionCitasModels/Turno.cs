using System;

namespace GestionCitasModels
{
    public class Turno
    {
        private int _idTurno;
        private Servicio _servicio;
        private Barbero _barbero;
        private DateTime _fechaYHora;
        private string _nombreCliente;
        private string _apellidoCliente;
        private string _telefonoCliente;
        private string _emailCliente;

        public int IdTurno { get => _idTurno; set => _idTurno = value; }
        public Servicio Servicio { get => _servicio; set => _servicio = value; }
        public Barbero Barbero { get => _barbero; set => _barbero = value; }
        public DateTime FechaYHora { get => _fechaYHora; set => _fechaYHora = value; }
        public string NombreCliente { get => _nombreCliente; set => _nombreCliente = value; }
        public string ApellidoCliente { get => _apellidoCliente; set => _apellidoCliente = value; }
        public string NombreCompletoCliente { get => $"{NombreCliente} {ApellidoCliente}"; set => NombreCompletoCliente = value; }
        public string TelefonoCliente { get => _telefonoCliente; set => _telefonoCliente = value; }
        public string EmailCliente { get => _emailCliente; set => _emailCliente = value; }

        public Turno() 
        {
            Servicio = new Servicio();
            Barbero = new Barbero();
        }
    }
}
