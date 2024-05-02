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
    public partial class BookAppointment : System.Web.UI.Page
    {
        private TurnoController turnoController;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                LoadHours();
                LoadBarbers();
                LoadServices();
            }
        }

        //------------------------------------------------------- MÉTODOS DE PRUEBA -----------------------------------------------------------

        private void LoadHours()
        {
            HoursDropDownList.Items.Add(new ListItem("Seleccione una opción..."));
            HoursDropDownList.Items.Add(new ListItem("9:00 AM"));
            HoursDropDownList.Items.Add(new ListItem("10:00 AM"));
            HoursDropDownList.Items.Add(new ListItem("11:00 AM"));
            HoursDropDownList.Items.Add(new ListItem("12:00 AM"));
            HoursDropDownList.Items.Add(new ListItem("14:00 AM"));
            HoursDropDownList.Items.Add(new ListItem("15:00 AM"));
            HoursDropDownList.Items.Add(new ListItem("16:00 AM"));
            HoursDropDownList.Items.Add(new ListItem("17:00 AM"));
            HoursDropDownList.Items.Add(new ListItem("18:00 AM"));
            HoursDropDownList.Items.Add(new ListItem("19:00 AM"));
            HoursDropDownList.Items.Add(new ListItem("20:00 AM"));
            HoursDropDownList.Items.Add(new ListItem("21:00 AM"));
        }

        private void LoadBarbers()
        {
            BarbersDropDownList.Items.Add(new ListItem("Seleccione una opción..."));
            BarbersDropDownList.Items.Add(new ListItem("Matias Aquino"));
            BarbersDropDownList.Items.Add(new ListItem("Alexis Reyes"));
        }

        private void LoadServices()
        {
            //Solo para probar la carga de DropDownList
            ServicesDropDownList.Items.Add(new ListItem("Seleccione una opción..."));
            ServicesDropDownList.Items.Add(new ListItem("Barba"));
            ServicesDropDownList.Items.Add(new ListItem("Barba y perfilado de cejas"));
            ServicesDropDownList.Items.Add(new ListItem("Corte"));
            ServicesDropDownList.Items.Add(new ListItem("Corte y barba"));
            ServicesDropDownList.Items.Add(new ListItem("Corte y perfilado de barba"));
            ServicesDropDownList.Items.Add(new ListItem("Corte y perfilado de cejas"));
            ServicesDropDownList.Items.Add(new ListItem("Corte, barba y perfilado de cejas"));
            ServicesDropDownList.Items.Add(new ListItem("Corte, perfilado de barba y perfilado de cejas"));
            ServicesDropDownList.Items.Add(new ListItem("Perfilado de barba"));
            ServicesDropDownList.Items.Add(new ListItem("Perfilado de barba y perfilado de cejas"));
            ServicesDropDownList.Items.Add(new ListItem("Perfilado de cejas"));
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        protected void BookBtn_Click(object sender, EventArgs e)
        {
            
        }
    }
}