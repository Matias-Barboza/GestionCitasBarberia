namespace GestionCitasModels
{
    public class Servicio
    {
        private int _id;
        private string _descripcion;
        private int _tiempoEstimado;
        private decimal _precio;

        public int Id { get => _id; set => _id = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public int TiempoEstimado { get => _tiempoEstimado; set => _tiempoEstimado = value; }
        public decimal Precio { get => _precio; set => _precio = value; }
    }
}
