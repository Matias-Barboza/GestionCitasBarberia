using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Npgsql;
using GestionCitasModels;

namespace GestionCitasRepositorys
{
    public class TurnoRepository : BaseRepository
    {

        public bool CreateTurno(Turno turno)
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
                    using (NpgsqlCommand command =  new NpgsqlCommand("SELECT COUNT(*) FROM turno", connection)) 
                    {
                        rowsBeforeOperation = (int)(long) command.ExecuteScalar();
                    }
                    using (NpgsqlCommand command = new NpgsqlCommand(@"CALL sp_reservar_turno(@id_barbero_reserva, @id_servicio_reserva,
                                                                                              @fecha_hora_turno_reserva, @nombre_cliente_reserva,
                                                                                              @apellido_cliente_reserva, @telefono_cliente_reserva,
                                                                                              @email_cliente_reserva)", connection))
                    {

                        command.Parameters.AddWithValue("id_barbero_reserva", turno.Barbero.Id);
                        command.Parameters.AddWithValue("id_servicio_reserva", turno.Servicio.Id);
                        command.Parameters.AddWithValue("fecha_hora_turno_reserva", turno.FechaYHora);
                        command.Parameters.AddWithValue("nombre_cliente_reserva", turno.NombreCliente);
                        command.Parameters.AddWithValue("apellido_cliente_reserva", turno.ApellidoCliente);
                        command.Parameters.AddWithValue("telefono_cliente_reserva", turno.TelefonoCliente);
                        command.Parameters.AddWithValue("email_cliente_reserva", turno.EmailCliente);
                        
                        command.ExecuteNonQuery();
                    }
                    // Comprueba numero de filas dentro de tabla turno despues de la operacion
                    using (NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(*) FROM turno", connection))
                    {
                        rowsAfterOperation = (int)(long) command.ExecuteScalar();
                    }

                    // Si el numero de filas de antes + 1, es igual al numero de filas despues, asigno TRUE (creado) si no FALSE
                    created = (rowsBeforeOperation + 1) == rowsAfterOperation ? true : false;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw ex;
                }
            }

            return created;
        }

        public bool UpdateTurno(Turno turno)
        {
            int updated = -1;

            using(NpgsqlConnection connection = new NpgsqlConnection(ConnectionString)) 
            {
                try
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand(@"CALL sp_editar_turno(@id_turno, @id_barbero, @id_servicio,
                                                                                           @fecha_hora_turno, @nombre_cliente, @apellido_cliente,
                                                                                           @telefono_cliente, @email_cliente)", connection))
                    {

                        command.Parameters.AddWithValue("id_turno", turno.IdTurno);
                        command.Parameters.AddWithValue("id_barbero", turno.Barbero.Id);
                        command.Parameters.AddWithValue("id_servicio", turno.Servicio.Id);
                        command.Parameters.AddWithValue("fecha_hora_turno", turno.FechaYHora);
                        command.Parameters.AddWithValue("nombre_cliente", turno.NombreCliente);
                        command.Parameters.AddWithValue("apellido_cliente", turno.ApellidoCliente);
                        command.Parameters.AddWithValue("telefono_cliente", turno.TelefonoCliente);
                        command.Parameters.AddWithValue("email_cliente", turno.EmailCliente);

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

        public bool DeleteTurno(int idTurno)
        {
            int eliminated = -1;

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand("CALL sp_eliminar_turno(@id_turno)", connection))
                    {
                        command.Parameters.AddWithValue("id_turno", idTurno);

                        command.ExecuteNonQuery();
                    }
                    using (NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(*) FROM obtener_turno_por_id(@id_turno)", connection))
                    {
                        command.Parameters.AddWithValue("id_turno", idTurno);

                        eliminated = (int)(long) command.ExecuteScalar();
                    }
                }
                catch (Exception e)
                {
                    connection.Close();
                    throw e;
                }
            }

            return eliminated == 0;
        }

        public Turno GetTurnoById(int idTurno)
        {
            Turno turnoBuscado = null;

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM obtener_turno_por_id(@id_turno)", connection))
                    {
                        command.Parameters.AddWithValue("id_turno", idTurno);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                turnoBuscado = new Turno();

                                turnoBuscado.IdTurno = (int)reader[0];
                                turnoBuscado.Servicio.Descripcion = (string)reader[1];
                                turnoBuscado.FechaYHora = (DateTime)reader[2];
                                turnoBuscado.NombreCliente = (string)reader[3];
                                turnoBuscado.ApellidoCliente = (string)reader[4];
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    connection.Close();
                    throw e;
                }
            }

            return turnoBuscado;
        }

        public List<Turno> GetAllTurnos()
        {
            List<Turno> turnos = new List<Turno>();

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM obtener_todos_los_turnos()", connection))
                    {

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Turno turno = new Turno();

                                turno.IdTurno = (int)reader[0];
                                turno.Barbero.NombreCompleto = (string)reader[1];
                                turno.Servicio.Descripcion = (string)reader[2];
                                turno.FechaYHora = (DateTime)reader[3];
                                turno.NombreCompletoCliente = (string)reader[4];

                                turnos.Add(turno);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    connection.Close();
                    throw e;
                }
            }

            return turnos;
        }
    }
}
