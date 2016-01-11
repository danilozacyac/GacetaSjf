using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using GacetaSjf.Dao;
using ScjnUtilities;

namespace GacetaSjf.Model
{
    public class VotosModel
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["SJF"].ConnectionString;

        public ObservableCollection<Votos> GetVotos()
        {
            ObservableCollection<Votos> listaVotos = new ObservableCollection<Votos>();


            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM VotosParticulares Where ParteT <> 99 ORDER BY ConsecIndx";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Votos voto = new Votos();
                        voto.Ius = Convert.ToInt32(reader["Id"]);
                        voto.Sala = Convert.ToInt32(reader["Sala"]);
                        voto.Epoca = Convert.ToInt32(reader["Epoca"]);
                        voto.Volumen = Convert.ToInt32(reader["Volumen"]);
                        voto.Fuente = Convert.ToInt32(reader["Fuente"]);
                        voto.Pagina = Convert.ToInt32(reader["Pagina"]);
                        voto.Rubro = reader["Rubro"].ToString();
                        voto.Asunto = reader["TpoAsunto"].ToString();
                        voto.Promovente = reader["Promovente"].ToString();
                        voto.TipoVoto = Convert.ToInt32(reader["Clasificacion"]);
                        voto.Emisor = reader["Complemento"].ToString();

                        listaVotos.Add(voto);
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,VotosModel", "Gaceta");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,VotosModel", "Gaceta");
            }
            finally
            {
                connection.Close();
            }

            return listaVotos;
        }

        /// <summary>
        /// Devuelve el voto del registro que se esta buscando
        /// </summary>
        /// <param name="registroDigital">Número de registro del voto que se quiere obtener</param>
        /// <returns></returns>
        public Votos GetVotos(int registroDigital)
        {
            Votos voto = null;


            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM VotosParticulares Where Id = @Id AND ParteT <> 99 ORDER BY ConsecIndx";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@Id", registroDigital);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        voto = new Votos();
                        voto.Ius = Convert.ToInt32(reader["Id"]);
                        voto.Sala = Convert.ToInt32(reader["Sala"]);
                        voto.Epoca = Convert.ToInt32(reader["Epoca"]);
                        voto.Volumen = Convert.ToInt32(reader["Volumen"]);
                        voto.Fuente = Convert.ToInt32(reader["Fuente"]);
                        voto.Pagina = Convert.ToInt32(reader["Pagina"]);
                        voto.Rubro = reader["Rubro"].ToString();
                        voto.Asunto = reader["TpoAsunto"].ToString();
                        voto.Promovente = reader["Promovente"].ToString();
                        voto.TipoVoto = Convert.ToInt32(reader["Clasificacion"]);
                        voto.Emisor = reader["Complemento"].ToString();

                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,VotosModel", "Gaceta");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,VotosModel", "Gaceta");
            }
            finally
            {
                connection.Close();
            }

            return voto;
        }



        public List<string> GetVotosPartes(int registroDigital)
        {
            List<string> partes = new List<string>();


            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM ParteVotos Where Id = @Id ORDER BY Parte";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@Id", registroDigital);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        partes.Add(reader["txtParte"].ToString());
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,VotosModel", "Gaceta");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,VotosModel", "Gaceta");
            }
            finally
            {
                connection.Close();
            }

            return partes;
        }





        public List<Anexos> GetAnexos(int registroDigital)
        {
            List<Anexos> listaAnexos = new List<Anexos>();


            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM zTablasPartes Where Id = @Id ORDER BY Posicion";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@Id", registroDigital);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Anexos anexo = new Anexos();
                        anexo.Archivo = reader["Archivo"].ToString();
                        anexo.Frase = reader["Frase"].ToString();
                        anexo.Posicion = Convert.ToInt32(reader["Posicion"]);
                        anexo.Tamanio = Convert.ToInt32(reader["Tamanio"]);
                        anexo.Tipo = Convert.ToInt32(reader["IdTpo"]);

                        listaAnexos.Add(anexo);
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,VotosModel", "Gaceta");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,VotosModel", "Gaceta");
            }
            finally
            {
                connection.Close();
            }

            return listaAnexos;
        }
    }
}
