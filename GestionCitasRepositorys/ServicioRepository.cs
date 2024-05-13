using GestionCitasModels;
using Npgsql;
using System;
using System.Collections.Generic;

namespace GestionCitasRepositorys
{
    public class ServicioRepository : BaseRepository
    {

        public bool CreateService(Servicio servicio) 
        {
            bool created = false;
            int rowsBeforeOperation = -1;
            int rowsAfterOperation = -1;

            using(NpgsqlConnection  connection = new NpgsqlConnection(ConnectionString)) 
            {
                try
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(*) FROM obtener_todos_los_servicios()", connection))
                    {
                        rowsBeforeOperation = (int)(long) command.ExecuteScalar();
                    }
                    using(NpgsqlCommand command = new NpgsqlCommand("CALL sp_crear_servicio(@descripcion_servicio_nuevo, @tiempo_estimado_servicio_nuevo, @precio_servicio_nuevo)", connection)) 
                    {

                        command.Parameters.AddWithValue("descripcion_servicio_nuevo", servicio.Descripcion);
                        command.Parameters.AddWithValue("tiempo_estimado_servicio_nuevo", servicio.TiempoEstimado);
                        command.Parameters.AddWithValue("precio_servicio_nuevo", servicio.Precio);

                        command.ExecuteNonQuery();
                    }
                    using (NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(*) FROM obtener_todos_los_servicios()", connection))
                    {
                        rowsBeforeOperation = (int)(long)command.ExecuteScalar();
                    }

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

        public bool UpdateServicio(Servicio servicio) 
        {
            int updated = -1;

            using(NpgsqlConnection connection = new NpgsqlConnection(ConnectionString)) 
            {
                try
                {
                    using(NpgsqlCommand command = new NpgsqlCommand("CALL sp_editar_servicio(@id_servicio_editar, @descripcion_nueva, @tiempo_estimado_nuevo, @precio_nuevo)", connection))
                    {

                        command.Parameters.AddWithValue("id_servicio_editar", servicio.Id);
                        command.Parameters.AddWithValue("descripcion_nueva", servicio.Descripcion);
                        command.Parameters.AddWithValue("tiempo_estimado_nuevo", servicio.TiempoEstimado);
                        command.Parameters.AddWithValue("precio_nuevo", servicio.Precio);

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

        public bool DeleteServicio(int idServicio) 
        {
            int deleted = -1;

            using(NpgsqlConnection connection = new NpgsqlConnection(ConnectionString)) 
            {
                try
                {
                    using (NpgsqlCommand command = new NpgsqlCommand("CALL sp_eliminar_servicio(@id_servicio_eliminar", connection))
                    {

                        command.Parameters.AddWithValue("id_servicio_eliminar", idServicio);

                        command.ExecuteNonQuery();
                    }
                    using(NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(*) FROM obtener_servicio_por_id(@id_servicio_buscado)")) 
                    {

                        command.Parameters.AddWithValue("id_servicio_buscado", idServicio);

                        deleted = (int)(long) command.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw ex;
                }
            }

            return deleted == 0;
        }

        public Servicio GetServicioById(int idServicio)
        {
            Servicio servicioBuscado = null;

            using(NpgsqlConnection connection = new NpgsqlConnection(ConnectionString)) 
            {
                try
                {
                    connection.Open();

                    using(NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM obtener_servicio_por_id(@id_servicio_buscado)", connection)) 
                    {

                        command.Parameters.AddWithValue("id_servicio_buscado", idServicio);

                        using(NpgsqlDataReader  reader = command.ExecuteReader()) 
                        {
                            if (reader.Read()) 
                            {
                                servicioBuscado = new Servicio();

                                servicioBuscado.Id = (int)reader[0];
                                servicioBuscado.Descripcion = (string) reader[1];    
                                servicioBuscado.TiempoEstimado = (int) reader[2];    
                                servicioBuscado.Precio = (decimal) reader[3];    
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

            return servicioBuscado;
        }

        public int GetTiempoEstimadoServicioById(int idServicio) 
        {
            int tiempoEstimado = 0;

            using(NpgsqlConnection connection = new NpgsqlConnection(ConnectionString)) 
            {
                try
                {
                    connection.Open();

                    using(NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM obtener_tiempo_estimado_servicio_por_id(@id_servicio)", connection)) 
                    {

                        command.Parameters.AddWithValue("id_servicio", idServicio);

                        tiempoEstimado = (int) command.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw ex;
                }
            }

            return tiempoEstimado;
        }

        public decimal GetPrecioServicioById(int idServicio)
        {
            decimal precio = 0;

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM obtener_precio_servicio_por_id(@id_servicio)", connection))
                    {

                        command.Parameters.AddWithValue("id_servicio", idServicio);

                        precio = (decimal) command.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw ex;
                }
            }

            return precio;
        }

        public List<Servicio> GetAllServicios() 
        {
            List<Servicio> servicios = new List<Servicio>();

            using(NpgsqlConnection connection = new NpgsqlConnection(ConnectionString)) 
            {
                try
                {
                    connection.Open();

                    using(NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM obtener_todos_los_servicios()", connection)) 
                    {
                        
                        using(NpgsqlDataReader reader = command.ExecuteReader()) 
                        {
                            
                            while(reader.Read()) 
                            {
                                Servicio servicio = new Servicio();

                                servicio.Id = (int) reader[0];
                                servicio.Descripcion = (string) reader[1];
                                servicio.TiempoEstimado = (int) reader[2];
                                servicio.Precio = (decimal) reader[3];

                                servicios.Add(servicio);
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

            return servicios;
        }

        public List<string> GetAllServiciosDescription()
        {
            List<string> descripcionServicios = new List<string>();

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM obtener_descripcion_todos_los_servicios()", connection))
                    {

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                descripcionServicios.Add((string)reader[0]);
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

            return descripcionServicios;
        }
    }
}
