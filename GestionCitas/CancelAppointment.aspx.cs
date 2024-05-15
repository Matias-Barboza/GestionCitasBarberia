using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GestionCitasControllers;
using GestionCitasModels;

namespace GestionCitas
{
    public partial class CancelAppointement : System.Web.UI.Page
    {
        TurnoController _turnoController;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) 
            {
                if (Request.QueryString["id"] != null) 
                {
                    _turnoController = new TurnoController();

                    Turno turno = _turnoController.GetTurnoById(Convert.ToInt32(Request.QueryString["id"].ToString()));

                    TextBoxDate.Text = turno.FechaYHora.Date.ToShortDateString();
                    TextBoxHour.Text = turno.FechaYHora.Hour > 12 ? turno.FechaYHora.Hour.ToString() + ":00 AM" : turno.FechaYHora.Hour.ToString() + ":00 PM";
                    TextBoxService.Text = turno.Servicio.Descripcion;
                    TextBoxClientFullName.Text = turno.NombreCliente + " " + turno.ApellidoCliente;
                }
            }
        }

        protected void btnCancelAppointment_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                _turnoController = new TurnoController();

                Turno turno = _turnoController.GetTurnoById(Convert.ToInt32(Request.QueryString["id"].ToString()));

                bool eliminated = _turnoController.DeleteTurno(turno.IdTurno);

                if (eliminated)
                {
                    Response.Redirect("~/Default.aspx");
                }
                //Si no debe informarse al usuario
            }
        }
    }
}