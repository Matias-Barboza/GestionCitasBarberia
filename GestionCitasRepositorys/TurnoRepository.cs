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
                    NpgsqlCommand command = new NpgsqlCommand(@"CALL sp_reservar_turno(@id_barbero_reserva, @id_servicio_reserva,
                                                                                   @fecha_hora_turno_reserva,
                                                                                   @nombre_cliente_reserva, @apellido_cliente_reserva
                                                                                   @telefono_cliente_reserva, @email_cliente_reserva)", connection);
                    command.Parameters.Add(new NpgsqlParameter()
                    {
                        ParameterName = "id_barbero_reserva",
                        NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer,
                        Value = turno.IdBarbero
                    });
                    command.Parameters.Add(new NpgsqlParameter()
                    {
                        ParameterName = "id_servicio_reserva",
                        NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer,
                        Value = turno.IdServicio
                    });
                    command.Parameters.Add(new NpgsqlParameter()
                    {
                        ParameterName = "fecha_hora_turno_reserva",
                        NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Timestamp,
                        Value = turno.FechaYHora
                    });
                    command.Parameters.Add(new NpgsqlParameter()
                    {
                        ParameterName = "nombre_cliente_reserva",
                        NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar,
                        Value = turno.NombreCliente
                    });
                    command.Parameters.Add(new NpgsqlParameter()
                    {
                        ParameterName = "apellido_cliente_reserva",
                        NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar,
                        Value = turno.ApellidoCliente
                    });
                    command.Parameters.Add(new NpgsqlParameter()
                    {
                        ParameterName = "telefono_cliente_reserva",
                        NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar,
                        Value = turno.TelefonoCliente
                    });
                    command.Parameters.Add(new NpgsqlParameter()
                    {
                        ParameterName = "email_cliente_reserva",
                        NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar,
                        Value = turno.EmailCliente
                    });

                    created = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw ex;
                }
            }

            return created == 1;
        }

        public bool UpdateTurno(Turno turno)
        {
            return true;
        }

        public bool DeleteTurno(Turno turno)
        {
            return true;
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

                                turnoBuscado.IdTurno = (int) reader[0];
                                turnoBuscado.Servicio.Descripcion = (string) reader[1];
                                turnoBuscado.FechaYHora = (DateTime) reader[2];
                                turnoBuscado.NombreCliente = (string) reader[3];
                                turnoBuscado.ApellidoCliente = (string) reader[4];
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
