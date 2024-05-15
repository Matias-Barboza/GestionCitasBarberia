using GestionCitasControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GestionCitasModels;

namespace GestionCitas
{
    public partial class CancelAppointment : System.Web.UI.Page
    {
        TurnoController _turnoController;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            _turnoController = new TurnoController();

            bool converted = int.TryParse(TextBoxIdTurno.Text, out int id);

            if(converted) 
            {
                Turno turno = _turnoController.GetTurnoById(id);

                if(turno != null)
                {
                    Response.Redirect($"~/CancelAppointment.aspx?id={id}");
                }
            }
            // Si no pudo ser convertido, enviar msj al usuario de su error
        }
    }
}