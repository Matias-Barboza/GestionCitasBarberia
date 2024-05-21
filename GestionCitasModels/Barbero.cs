namespace GestionCitasModels
{
    public class Barbero
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _nombreCompleto;
        private string _email;
        private string _urlImagenRostro;

        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string NombreCompleto { get => _nombreCompleto ; set => _nombreCompleto = value; }
        public string Email { get => _email; set => _email = value; }
        public string UrlImagenRostro { get => _urlImagenRostro; set => _urlImagenRostro = value; }
    }
}
