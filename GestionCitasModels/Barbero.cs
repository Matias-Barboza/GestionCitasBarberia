namespace GestionCitasModels
{
    public class Barbero
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _email;

        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string NombreCompleto { get => $"{Nombre} {Apellido}"; set => NombreCompleto = value; }
        public string Email { get => _email; set => _email = value; }
    }
}
