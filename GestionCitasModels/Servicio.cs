namespace GestionCitasModels
{
    public class Servicio
    {
        private int id;
        private string descripcion;
        private int tiempoEstimado;
        private decimal precio;

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int TiempoEstimado { get => tiempoEstimado; set => tiempoEstimado = value; }
        public decimal Precio { get => precio; set => precio = value; }
    }
}
