using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

using GestionCitasModels;

namespace GestionCitasRepositorys
{
    public class TurnoRepository : BaseRepository
    {
        public bool CreateTurno(Turno turno)
        {
            int created = -1;

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Todavía sin funcionar
                    using (NpgsqlCommand command = new NpgsqlCommand(@"CALL sp_reservar_turno(@id_barbero_reserva, @id_servicio_reserva,
                                                                                              @fecha_hora_turno_reserva, @nombre_cliente_reserva,
                                                                                              @apellido_cliente_reserva, @telefono_cliente_reserva,
                                                                                              @email_cliente_reserva)", connection))
                    //using (NpgsqlCommand command = new NpgsqlCommand(@"INSERT INTO turno(id_barbero, id_servicio, fecha_hora_turno,
                    //                                                      nombre_cliente, apellido_cliente, telefono_cliente,
                    //                                                      email_cliente)
                    //                                                           VALUES(@id_barbero_reserva, @id_servicio_reserva, @fecha_hora_turno_reserva,
                    //                                                               @nombre_cliente_reserva, @apellido_cliente_reserva, @telefono_cliente_reserva,
                    //                                                               @email_cliente_reserva);", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("id_barbero_reserva", turno.IdBarbero);
                        command.Parameters.AddWithValue("id_servicio_reserva", turno.IdServicio);
                        command.Parameters.AddWithValue("fecha_hora_turno_reserva", turno.FechaYHora);
                        command.Parameters.AddWithValue("nombre_cliente_reserva", turno.NombreCliente);
                        command.Parameters.AddWithValue("apellido_cliente_reserva", turno.ApellidoCliente);
                        command.Parameters.AddWithValue("telefono_cliente_reserva", turno.TelefonoCliente);
                        command.Parameters.AddWithValue("email_cliente_reserva", turno.EmailCliente);

                        created = command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw ex;
                }
            }

            return created == 1;
        }

        public bool UpdateTurno(int idTurno)
        {
            return true;
        }

        public bool DeleteTurno(int idTurno)
        {
            int eliminated = -1;

            using(NpgsqlConnection connection = new NpgsqlConnection(ConnectionString)) 
            {
                try
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand("CALL sp_eliminar_turno(@id_turno)", connection)) 
                    {
                        command.Parameters.Add(new NpgsqlParameter()
                        {
                            ParameterName = "id_turno",
                            NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer,
                            Value = idTurno
                        });

                        command.ExecuteNonQuery();
                    }
                    using(NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(*) FROM obtener_turno_por_id(@id_turno)", connection)) 
                    {
                        command.Parameters.Add(new NpgsqlParameter()
                        {
                            ParameterName = "id_turno",
                            NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer,
                            Value = idTurno
                        });

                        eliminated =  (int)(long) command.ExecuteScalar();
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
                        command.Parameters.Add(new NpgsqlParameter()
                        {
                            ParameterName = "id_turno",
                            NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer,
                            Value = idTurno
                        });

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
            return new List<Turno>();
        }
    }
}
