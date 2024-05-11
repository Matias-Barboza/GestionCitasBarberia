using System;
using System.Collections.Generic;
using System.Configuration;
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
            turnoController = new TurnoController();

            if (!IsPostBack) 
            {
                Calendar.SelectedDate = DateTime.Today;
                LoadHoursFor(Calendar.SelectedDate);
                LoadBarbers();
                LoadServices();
            }
            else 
            {
                HoursDropDownList.Items.Clear();
            }
        }

        //------------------------------------------------------- MÉTODOS DE PRUEBA -----------------------------------------------------------

        private void LoadHoursFor(DateTime fecha)
        {
            Dictionary<string, TimeSpan> allHours = GetAllHours(fecha.DayOfWeek == DayOfWeek.Saturday);
            List<TimeSpan> hoursNotAvailables = turnoController.GetAllHoursNotAvailablesOf(fecha);


            // Encuentro los horarios no disponibles, y los elimino de todos los horarios
            foreach(TimeSpan hourNotAvailable in hoursNotAvailables) 
            {
                if (allHours.ContainsValue(hourNotAvailable)) 
                {
                    KeyValuePair<string, TimeSpan> keyValuePair = allHours.First(x => x.Value == hourNotAvailable);

                    allHours.Remove(keyValuePair.Key);
                }
            }

            // Ahora allHours debería contener unicamente los horarios disponibles
            foreach(string hourAvailable in allHours.Keys) 
            {
                HoursDropDownList.Items.Add(hourAvailable.ToString());
            }
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
            Turno nuevoTurno = new Turno();

            nuevoTurno.Barbero.Id = BarbersDropDownList.SelectedIndex;
            nuevoTurno.Servicio.Id = ServicesDropDownList.SelectedIndex;
            nuevoTurno.FechaYHora = Calendar.SelectedDate;
            nuevoTurno.NombreCliente = NameTextBox.Text;
            nuevoTurno.ApellidoCliente = SurnameTextBox.Text;
            nuevoTurno.TelefonoCliente = TelTextBox.Text;
            nuevoTurno.EmailCliente = EmailTextBox.Text;

            bool created = turnoController.CreateTurno(nuevoTurno);

            if (created)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            LoadHoursFor(Calendar.SelectedDate);
        }

        private Dictionary<string, TimeSpan> GetAllHours(bool isSaturday) 
        {
            // Si es Sábado, el primer horario es 10:00 AM, si no debe ser 9:00 AM
            int firstHourOfDay = isSaturday ? 10 : 9;
            Dictionary<string, TimeSpan> allHours = new Dictionary<string, TimeSpan>();

            for(int i = firstHourOfDay; i <= 21; i++) 
            {
                string abreviattion = (i <= 12) ? "AM" : "PM";

                allHours.Add($"{i}:00 {abreviattion}", new TimeSpan(i, 0, 0));
            }

            return allHours;
        }
    }
}