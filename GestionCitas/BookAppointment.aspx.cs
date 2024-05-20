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
        private TurnoController _turnoController;
        private BarberoController _barberoController;
        private ServicioController _servicioController;

        protected void Page_Load(object sender, EventArgs e)
        {
            _turnoController = new TurnoController();
            _barberoController = new BarberoController();
            _servicioController = new ServicioController();

            if (!IsPostBack)
            {
                Calendar.SelectedDate = DateTime.Today;
                //LoadBarbers();
                //LoadHoursFor(Calendar.SelectedDate, BarbersDropDownList.SelectedValue);
                LoadServices();
            }

            // Prueba de Repeater
            Barbero barbero = new Barbero();
            Barbero barbero1 = new Barbero();

            barbero.Id = 0;
            barbero1.Id = 1;
            barbero.Nombre = "Matias";
            barbero1.Nombre = "Alexis";

            List<Barbero> barberos = new List<Barbero>();

            barberos.Add(barbero);
            barberos.Add(barbero1);

            barbersRepeater.DataSource = barberos;
            barbersRepeater.DataBind();
        }

        //------------------------------------------------------- MÉTODOS ---------------------------------------------------------------

        private void LoadHoursFor(DateTime fecha, string nombreBarbero)
        {
            if (HoursDropDownList.Items.Count != 0)
            {
                HoursDropDownList.Items.Clear();
            }

            if (fecha.DayOfWeek == DayOfWeek.Sunday || fecha.DayOfWeek == DayOfWeek.Monday)
            {
                HoursDropDownList.Items.Add("Horarios no disponibles para la fecha seleccionada...");
                return;
            }

            List<string> hoursAvailables = GetAllHoursAvailables(fecha, nombreBarbero);

            HoursDropDownList.Items.Add("Seleccione un horario...");
            HoursDropDownList.SelectedIndex = 0;

            // Ahora hoursAvailables debería contener unicamente los horarios disponibles
            foreach (string hourAvailable in hoursAvailables)
            {
                HoursDropDownList.Items.Add(new ListItem(hourAvailable));
            }
        }

        //private void LoadBarbers()
        //{
        //    List<string> barbersFullNames = _barberoController.GetAllBarberosFullNames();

        //    BarbersDropDownList.Items.Add(new ListItem("Seleccione una opción..."));

        //    foreach (string fullName in barbersFullNames)
        //    {
        //        BarbersDropDownList.Items.Add(fullName);
        //    }
        //}

        private void LoadServices()
        {
            List<string> services = _servicioController.GetAllServiciosDescription();

            ServicesDropDownList.Items.Add(new ListItem("Seleccione una opción..."));

            foreach (string service in services)
            {
                ServicesDropDownList.Items.Add(new ListItem(service));
            }
        }

        private Dictionary<string, TimeSpan> GetAllHours(bool isSaturday)
        {
            // Si es Sábado, el primer horario es 10:00 AM, si no debe ser 9:00 AM
            int firstHourOfDay = isSaturday ? 10 : 9;
            Dictionary<string, TimeSpan> allHours = new Dictionary<string, TimeSpan>();

            for (int i = firstHourOfDay; i <= 21; i++)
            {
                string abreviattion = (i <= 12) ? "AM" : "PM";

                allHours.Add($"{i}:00 {abreviattion}", new TimeSpan(i, 0, 0));
            }

            return allHours;
        }

        public List<string> GetAllHoursAvailables(DateTime fecha, string nombreBarbero)
        {
            Dictionary<string, TimeSpan> allHours = GetAllHours(fecha.DayOfWeek == DayOfWeek.Saturday);
            List<TimeSpan> hoursNotAvailables = _turnoController.GetAllHoursNotAvailablesOf(fecha, nombreBarbero);
            List<string> hoursAvailables = null;

            // Encuentro los horarios no disponibles, y los elimino de todos los horarios, quedando unicamente los disponibles
            foreach (TimeSpan hourNotAvailable in hoursNotAvailables)
            {
                if (allHours.ContainsValue(hourNotAvailable))
                {
                    KeyValuePair<string, TimeSpan> keyValuePair = allHours.First(x => x.Value == hourNotAvailable);

                    allHours.Remove(keyValuePair.Key);
                }
            }

            hoursAvailables = allHours.Keys.ToList();

            return hoursAvailables;
        }

        public TimeSpan GetHourFor(string keyHour, bool isSaturday)
        {
            Dictionary<string, TimeSpan> allHours = GetAllHours(isSaturday);

            return allHours.First(x => x.Key == keyHour).Value;
        }

        //------------------------------------------------------- EVENTOS ---------------------------------------------------------------

        protected void BookBtn_Click(object sender, EventArgs e)
        {
            Turno nuevoTurno = new Turno();

            // Informacion básica del turno (Barbero elegido y servicio seleccionado)
            //nuevoTurno.Barbero.Id = BarbersDropDownList.SelectedIndex;
            nuevoTurno.Servicio.Id = ServicesDropDownList.SelectedIndex;

            // Mapeo fecha y hora en base al calendario (Calendar) y a los horarios disponibles (HoursDropDownList)
            bool isSaturday = Calendar.SelectedDate.DayOfWeek == DayOfWeek.Saturday;

            // Obtengo el horario en TimeSpan para el horario en string pasado como argumento que viene del HoursDropDownList
            TimeSpan hourSelected = GetHourFor(HoursDropDownList.SelectedValue, isSaturday);

            nuevoTurno.FechaYHora = new DateTime(
                                                 Calendar.SelectedDate.Year,
                                                 Calendar.SelectedDate.Month,
                                                 Calendar.SelectedDate.Day,
                                                 hourSelected.Hours,
                                                 hourSelected.Minutes,
                                                 hourSelected.Seconds
                                                 );

            // Informacion del cliente
            nuevoTurno.NombreCliente = NameTextBox.Text;
            nuevoTurno.ApellidoCliente = SurnameTextBox.Text;
            nuevoTurno.TelefonoCliente = TelTextBox.Text;
            nuevoTurno.EmailCliente = EmailTextBox.Text;

            bool created = _turnoController.CreateTurno(nuevoTurno);

            if (created)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            //LoadHoursFor(Calendar.SelectedDate, BarbersDropDownList.SelectedValue);
        }

        protected void BarbersDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadHoursFor(Calendar.SelectedDate, BarbersDropDownList.SelectedValue);
        }

        protected void ServicesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ServicesDropDownList.SelectedIndex == 0)
            {
                return;
            }

            EstimatedTimeTextBox.Text = _servicioController.GetTiempoEstimadoServicioById(ServicesDropDownList.SelectedIndex).ToString() + " min";
            AmountTextBox.Text = _servicioController.GetPrecioServicioById(ServicesDropDownList.SelectedIndex).ToString() + " $";
        }

        protected void barbersRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                RadioButton rbt = (RadioButton)e.Item.FindControl("BarberRadioButton");
                string setUniqueRadioButton = "SetUniqueRadioButton('barbersRepeater.*BarberChoice', this);";
                rbt.Attributes.Add("onclick", setUniqueRadioButton);
            }
        }
    }
}