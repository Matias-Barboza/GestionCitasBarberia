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
        TurnoController turnoController;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            TurnoController turnoController = new TurnoController();

            bool converted = int.TryParse(TextBoxIdTurno.Text, out int id);

            if(converted) 
            {
                Turno turno = turnoController.GetById(id);

                if(turno != null)
                {
                    Session.Add("turnoEncontrado", true);
                    Session.Add("turno", turno);

                    Response.Redirect("~/CancelAppointment.aspx");
                }
            }
        }
    }
}