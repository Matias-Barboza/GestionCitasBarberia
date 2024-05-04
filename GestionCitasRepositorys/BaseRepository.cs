﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCitasRepositorys
{
    public abstract class BaseRepository
    {
        private string connectionString;

        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public BaseRepository()
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings["barberia_db"].ConnectionString;
        }

        ///<summary>
        ///Si el valor retornado es 1, la conexión pudo ser establecida.
        ///</summary>
        public int TestConnection()
        {
            int result = 0;

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    NpgsqlCommand test = new NpgsqlCommand("SELECT 1", connection);
                    result = (int) test.ExecuteScalar();
                }
                catch (Exception e)
                {
                    connection.Close();
                    throw e;
                }
            }

            return result;
        }
    }
}
