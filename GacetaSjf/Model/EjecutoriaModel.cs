using System;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Linq;
using GacetaSjf.Dao;
using ScjnUtilities;
using System.Configuration;

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

    }
}
