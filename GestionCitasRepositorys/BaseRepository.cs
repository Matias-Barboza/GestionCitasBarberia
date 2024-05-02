using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCitasRepositorys
{
    public abstract class BaseRepository
    {
        private string connectionString;

        public string ConnectionString { get => connectionString; set => connectionString = value; }
    }
}
