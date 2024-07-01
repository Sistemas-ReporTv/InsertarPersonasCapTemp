using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertarPersonasCapTemp
{
    public class Datos
    {
        private SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dataBase"].ConnectionString);

        public List<Persona> ObtenerPersonasCapitulo(int idTipoPersona)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = _connection;
            command.CommandTimeout = 60;
            command.CommandText = "TRAER_PERSONAS_CAPITULO";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@IdTipoPersona", System.Data.SqlDbType.Int).Value = idTipoPersona;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);

            try
            {
                _connection.Open();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _connection.Close();
                da.Dispose();
            }

            List<Persona> personasCapitulo = new List<Persona>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Persona persona = new Persona();

                persona.IdPersona = int.Parse(dt.Rows[i]["id_persona"].ToString() ?? "");
                persona.IdPersonaTipo = idTipoPersona;
                persona.IdPrograma = int.Parse(dt.Rows[i]["id_programa"].ToString() ?? "");
                persona.IdProgramaCapitulo = int.Parse(dt.Rows[i]["id_programa_capitulo"].ToString() ?? "");
                persona.IdProgramaTemporada = 0;
                persona.Nombre = dt.Rows[i]["Nombre"].ToString() ?? "";
                persona.Apellido = dt.Rows[i]["Apellido"].ToString() ?? "";
                persona.NombreAbreviado = dt.Rows[i]["NombreAbreviado"].ToString() ?? "";
                persona.Orden = int.Parse(dt.Rows[i]["orden"].ToString() ?? "");

                personasCapitulo.Add(persona);
            }

            return personasCapitulo;
        }

        public List<Persona> ObtenerPersonasTemporada(int idTipoPersona)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = _connection;
            command.CommandTimeout = 60;
            command.CommandText = "TRAER_PERSONAS_TEMPORADA";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@IdTipoPersona", System.Data.SqlDbType.Int).Value = idTipoPersona;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);

            try
            {
                _connection.Open();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _connection.Close();
                da.Dispose();
            }

            List<Persona> personasTemporada = new List<Persona>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Persona persona = new Persona();

                persona.IdPersona = int.Parse(dt.Rows[i]["id_persona"].ToString() ?? "");
                persona.IdPersonaTipo = idTipoPersona;
                persona.IdPrograma = int.Parse(dt.Rows[i]["id_programa"].ToString() ?? "");
                persona.IdProgramaCapitulo = 0;
                persona.IdProgramaTemporada = int.Parse(dt.Rows[i]["id_programa_temporada"].ToString() ?? "");
                persona.Nombre = dt.Rows[i]["Nombre"].ToString() ?? "";
                persona.Apellido = dt.Rows[i]["Apellido"].ToString() ?? "";
                persona.NombreAbreviado = dt.Rows[i]["NombreAbreviado"].ToString() ?? "";
                persona.Orden = int.Parse(dt.Rows[i]["orden"].ToString() ?? "");

                personasTemporada.Add(persona);
            }

            return personasTemporada;
        }

        public void InsertarActoresCapitulo (int idProgamaCapitulo, string actores)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = _connection;
            command.CommandTimeout = 60;
            command.CommandText = "INSERT_ACTORES_CAPITULO";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@idProgramaCapitulo", System.Data.SqlDbType.Int).Value = idProgamaCapitulo;
            command.Parameters.Add("@actores", System.Data.SqlDbType.VarChar, -1).Value = actores;

            try
            {
                _connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
            finally
            {
                _connection.Close();
                command.Dispose();
            }
        }

        public void InsertarDirectoresCapitulo(int idProgamaCapitulo, string directores)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = _connection;
            command.CommandTimeout = 60;
            command.CommandText = "INSERT_DIRECTORES_CAPITULO";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@idProgramaCapitulo", System.Data.SqlDbType.Int).Value = idProgamaCapitulo;
            command.Parameters.Add("@directores", System.Data.SqlDbType.VarChar, -1).Value = directores;

            try
            {
                _connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _connection.Close();
                command.Dispose();
            }
        }

        public void InsertarActoresTemporada(int idProgamaTemporada, string actores)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = _connection;
            command.CommandTimeout = 60;
            command.CommandText = "INSERT_ACTORES_TEMPORADA";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@idProgramaTemporada", System.Data.SqlDbType.Int).Value = idProgamaTemporada;
            command.Parameters.Add("@actores", System.Data.SqlDbType.VarChar, -1).Value = actores;

            try
            {
                _connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _connection.Close();
                command.Dispose();
            }
        }

        public void InsertarDirectoresTemporada(int idProgamaTemporada, string directores)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = _connection;
            command.CommandTimeout = 60;
            command.CommandText = "INSERT_DIRECTORES_TEMPORADA";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@idProgramaTemporada", System.Data.SqlDbType.Int).Value = idProgamaTemporada;
            command.Parameters.Add("@directores", System.Data.SqlDbType.VarChar, -1).Value = directores;

            try
            {
                _connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _connection.Close();
                command.Dispose();
            }
        }

    }
}
