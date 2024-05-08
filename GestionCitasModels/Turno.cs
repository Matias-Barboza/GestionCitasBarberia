﻿using System;
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
        private string nombreCliente;
        private string apellidoCliente;
        private string telefonoCliente;
        private string emailCliente;
        private Servicio servicio;
        private Barbero barbero;

        public int IdTurno { get => idTurno; set => idTurno = value; }
        public int IdBarbero { get => idBarbero; set => idBarbero = value; }
        public int IdServicio { get => idServicio; set => idServicio = value; }
        public DateTime FechaYHora { get => fechaYHora; set => fechaYHora = value; }
        public string NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public string ApellidoCliente { get => apellidoCliente; set => apellidoCliente = value; }
        public string NombreCompletoCliente { get => $"{NombreCliente} {ApellidoCliente}"; set => NombreCompletoCliente = value; }
        public string TelefonoCliente { get => telefonoCliente; set => telefonoCliente = value; }
        public string EmailCliente { get => emailCliente; set => emailCliente = value; }
        public Servicio Servicio { get => servicio; set => servicio = value; }
        public Barbero Barbero { get => barbero; set => barbero = value; }

        public Turno() 
        {
            Servicio = new Servicio();
            Barbero = new Barbero();
        }
    }
}
