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
        public List<Persona> ObtenerPersonasCapitulo(int idTipoPersona)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dataBase"].ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandTimeout = 60;
                    command.CommandText = "TRAER_PERSONAS_CAPITULO";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@IdTipoPersona", System.Data.SqlDbType.Int).Value = idTipoPersona;

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(command);

                    connection.Open();

                    da.Fill(dt);

                    connection.Close();
                    da.Dispose();

                    List<Persona> personasCapitulo = new List<Persona>();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Persona persona = new Persona();

                        persona.IdPersona = int.Parse(dt.Rows[i]["id_persona"].ToString());
                        persona.IdPersonaTipo = idTipoPersona;
                        persona.IdPrograma = int.Parse(dt.Rows[i]["id_programa"].ToString());
                        persona.IdProgramaCapitulo = int.Parse(dt.Rows[i]["id_programa_capitulo"].ToString());
                        persona.IdProgramaTemporada = 0;
                        persona.Nombre = dt.Rows[i]["Nombre"].ToString();
                        persona.Apellido = dt.Rows[i]["Apellido"].ToString();
                        persona.NombreAbreviado = dt.Rows[i]["NombreAbreviado"].ToString();
                        persona.Orden = int.Parse(dt.Rows[i]["orden"].ToString());

                        personasCapitulo.Add(persona);
                    }

                    return personasCapitulo;
                }
                catch (Exception ex)
                {
                    throw ex;
                }




            }




            
        }

        public List<Persona> ObtenerPersonasTemporada(int idTipoPersona)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dataBase"].ConnectionString);

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandTimeout = 60;
                command.CommandText = "TRAER_PERSONAS_TEMPORADA";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@IdTipoPersona", System.Data.SqlDbType.Int).Value = idTipoPersona;

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(command);

                connection.Open();

                da.Fill(dt);

                connection.Close();
                da.Dispose();

                List<Persona> personasTemporada = new List<Persona>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Persona persona = new Persona();

                    persona.IdPersona = int.Parse(dt.Rows[i]["id_persona"].ToString());
                    persona.IdPersonaTipo = idTipoPersona;
                    persona.IdPrograma = int.Parse(dt.Rows[i]["id_programa"].ToString());
                    persona.IdProgramaCapitulo = 0;
                    persona.IdProgramaTemporada = int.Parse(dt.Rows[i]["id_programa_temporada"].ToString());
                    persona.Nombre = dt.Rows[i]["Nombre"].ToString();
                    persona.Apellido = dt.Rows[i]["Apellido"].ToString();
                    persona.NombreAbreviado = dt.Rows[i]["NombreAbreviado"].ToString();
                    persona.Orden = int.Parse(dt.Rows[i]["orden"].ToString());

                    personasTemporada.Add(persona);
                }

                return personasTemporada;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
