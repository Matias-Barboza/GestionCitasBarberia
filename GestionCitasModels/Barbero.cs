namespace GestionCitasModels
{
    public class Barbero
    {
        private int id;
        private string nombre;
        private string apellido;
        private string email;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string NombreCompleto { get => $"{Nombre} {Apellido}"; set => NombreCompleto = value; }
        public string Email { get => email; set => email = value; }
    }
}
