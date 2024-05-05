using GestionCitasModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionCitas
{
    public partial class CancelAppointement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) 
            {
                if ((bool) Session["turnoEncontrado"]) 
                {
                    Turno turno = (Turno) Session["turno"];

                    TextBoxDate.Text = turno.FechaYHora.Date.ToShortDateString();
                    TextBoxHour.Text = turno.FechaYHora.Hour > 12 ? turno.FechaYHora.Hour.ToString() + ":00 AM" : turno.FechaYHora.Hour.ToString() + ":00 PM";
                    TextBoxService.Text = turno.Servicio.Descripcion;
                    TextBoxClientFullName.Text = turno.NombreCliente + " " + turno.ApellidoCliente;
                }
            }
        }
    }
}