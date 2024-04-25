using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionCitas
{
    public partial class BookAppointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadServices();
        }

        private void LoadServices()
        {
            //Solo para probar la carga de DropDownList

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
    }
}