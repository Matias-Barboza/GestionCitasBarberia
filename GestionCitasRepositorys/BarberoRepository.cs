using GestionCitasModels;
using Npgsql;
using System;
using System.Collections.Generic;

namespace GestionCitasRepositorys
{
    public class BarberoRepository : BaseRepository
    {

        public bool CreateNewBarbero(Barbero barbero)
        {
            bool created = false;
            int rowsBeforeOperation = -1;
            int rowsAfterOperation = -1;

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Comprueba numero de filas dentro de tabla turno antes de la operacion
                    using (NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(*) FROM barbero", connection))
                    {
                        rowsBeforeOperation = (int)(long)command.ExecuteScalar();
                    }
                    using (NpgsqlCommand command = new NpgsqlCommand(@"CALL sp_crear_barbero(@nombre_barbero_nuevo,
                                                                                            @apellido_barbero_nuevo,
                                                                                            @email_barbero_nuevo)", connection))
                    {

                        command.Parameters.AddWithValue("nombre_barbero_nuevo", barbero.Nombre);
                        command.Parameters.AddWithValue("apellido_barbero_nuevo", barbero.Apellido);
                        command.Parameters.AddWithValue("email_barbero_nuevo", barbero.Email);

                        command.ExecuteNonQuery();
                    }
                    // Comprueba numero de filas dentro de tabla turno despues de la operacion
                    using (NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(*) FROM barbero", connection))
                    {
                        rowsAfterOperation = (int)(long)command.ExecuteScalar();
                    }

                    // Si el numero de filas de antes + 1, es igual al numero de filas despues, asigno TRUE (creado) si no FALSE
                    created = (rowsBeforeOperation + 1) == rowsAfterOperation;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw ex;
                }
            }

            return created;
        }

        public bool UpdateBarbero(Barbero barbero)
        {
            int updated = -1;

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand(@"CALL sp_editar_barbero(@id_barbero_editar, @nombre_nuevo,
                                                                                             @apellido_nuevo, @email_nuevo)", connection))
                    {

                        command.Parameters.AddWithValue("id_barbero_editar", barbero.Id);
                        command.Parameters.AddWithValue("nombre_nuevo", barbero.Nombre);
                        command.Parameters.AddWithValue("apellido_nuevo", barbero.Apellido);
                        command.Parameters.AddWithValue("email_nuevo", barbero.Email);

                        updated = command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw ex;
                }
            }

            return updated == 1;
        }

        public bool DeleteBarbero(int idBarbero)
        {
            int eliminated = -1;


            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();

                    using (NpgsqlCommand command = new NpgsqlCommand(@"CALL sp_eliminar_barbero(@id_barbero)", connection))
                    {

                        command.Parameters.AddWithValue("id_barbero", idBarbero);

                        command.ExecuteNonQuery();
                    }
                    using (NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(*) FROM obtener_barbero_por_id(@id_barbero)", connection))
                    {

                        command.Parameters.AddWithValue("id_barbero", idBarbero);

                        eliminated = (int)(long)command.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw ex;
                }
            }

            return eliminated == 0;
        }

        public Barbero GetBarberoById(int idBarbero)
        {
            Barbero barberoBuscado = null;

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM obtener_barbero_por_id(@id_barbero)", connection))
                    {

                        command.Parameters.AddWithValue("id_barbero", idBarbero);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                barberoBuscado = new Barbero();

                                barberoBuscado.Id = (int)reader[0];
                                barberoBuscado.Nombre = (string)reader[1];
                                barberoBuscado.Apellido = (string)reader[2];
                                barberoBuscado.Email = (string)reader[3];
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw ex;
                }
            }

            return barberoBuscado;
        }

        public List<Barbero> GetAllBarberos()
        {
            List<Barbero> barberos = new List<Barbero>();

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM obtener_todos_los_barberos()", connection))
                    {

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                Barbero barbero = new Barbero();

                                barbero.Id = (int)reader[0];
                                barbero.Nombre = (string)reader[1];
                                barbero.Apellido = (string)reader[2];
                                barbero.Email = (string)reader[0];

                                barberos.Add(barbero);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw ex;
                }
            }

            return barberos;
        }

        public List<string> GetAllBarberosFullNames()
        {
            List<string> fullNames = null;

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                try
                {
                    using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM lista_nombre_completo_barberos()", connection))
                    {

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            fullNames = new List<string>();

                            while (reader.Read())
                            {
                                fullNames.Add((string)reader[0]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw ex;
                }
            }

            return fullNames;
        }

        public List<Barbero> GetAllBarberosFullNamesAndImageUrl()
        {
            List<Barbero> barbers = null;

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM lista_nombre_completo_e_imagen_barberos()", connection))
                    {

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {

                            barbers = new List<Barbero>();

                            while (reader.Read()) 
                            {
                                Barbero barber = new Barbero();

                                barber.Id = (int) reader[0];
                                barber.NombreCompleto = (string) reader[1];
                                barber.UrlImagenRostro = (string) reader[2];

                                barbers.Add(barber);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw ex;
                }
            }

            return barbers;
        }
    }
}
