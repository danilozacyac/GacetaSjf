using System;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Linq;
using GacetaSjf.Dao;
using ScjnUtilities;
using System.Configuration;
using System.Collections.Generic;

namespace GacetaSjf.Model
{
    public class EjecutoriaModel
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["SJF"].ConnectionString;

        public ObservableCollection<Ejecutoria> GetEjecutoria()
        {
            ObservableCollection<Ejecutoria> listaEjecutoria = new ObservableCollection<Ejecutoria>();


            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM Ejecutoria Where ParteT <> 99 ORDER BY ConsecIndx";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Ejecutoria ejecutoria = new Ejecutoria();
                        ejecutoria.Ius = Convert.ToInt32(reader["Id"]);
                        ejecutoria.Sala = Convert.ToInt32(reader["Sala"]);
                        ejecutoria.Epoca = Convert.ToInt32(reader["Epoca"]);
                        ejecutoria.Volumen = Convert.ToInt32(reader["Volumen"]);
                        ejecutoria.Fuente = Convert.ToInt32(reader["Fuente"]);
                        ejecutoria.Pagina = Convert.ToInt32(reader["Pagina"]);
                        ejecutoria.Rubro = reader["Rubro"].ToString();
                        ejecutoria.Asunto = reader["TpoAsunto"].ToString();
                        ejecutoria.Promovente = reader["Promovente"].ToString();

                        listaEjecutoria.Add(ejecutoria);
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,EjecutoriaModel", "Gaceta");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,EjecutoriaModel", "Gaceta");
            }
            finally
            {
                connection.Close();
            }

            return listaEjecutoria;
        }



        public List<string> GetEjecutoriaPartes(int iusEjecutoria)
        {
            List<string> partes = new List<string>();


            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM ParteEjecutoria Where Id = @Id ORDER BY Parte";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@Id", iusEjecutoria);
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
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,EjecutoriaModel", "Gaceta");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,EjecutoriaModel", "Gaceta");
            }
            finally
            {
                connection.Close();
            }

            return partes;
        }





        public List<Anexos> GetAnexos(int iusEjecutoria)
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
                cmd.Parameters.AddWithValue("@Id", iusEjecutoria);
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
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,EjecutoriaModel", "Gaceta");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,EjecutoriaModel", "Gaceta");
            }
            finally
            {
                connection.Close();
            }

            return listaAnexos;
        }

    }
}
