using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using MantesisVerIusCommonObjects.Dto;
using ScjnUtilities;
using GacetaSjf.Dao;

namespace GacetaSjf.Model
{
    public class TemasModel
    {


        private readonly string connectionString = ConfigurationManager.ConnectionStrings["SJF"].ConnectionString;


        /// <summary>
        /// Devuelve el listado temático o de ordenamientos legales
        /// </summary>
        /// <param name="esOrdenamiento">Indica que listado es el que se devuelve 1. Legales 0. Temático</param>
        /// <returns></returns>
        public ObservableCollection<Temas> GetTemas(int esOrdenamiento)
        {
            ObservableCollection<Temas> listaTemas = new ObservableCollection<Temas>();

            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM zzzzzTemas Where EsOrdenamientoLegal = @Ordenamiento ORDER BY DescTemaStr";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@Ordenamiento", esOrdenamiento);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Temas tema = new Temas();
                        tema.IdTema = Convert.ToInt32(reader["IdTema"]);
                        tema.Tema = reader["DescTema"].ToString();
                        tema.TemaStr = reader["DescTemaStr"].ToString();

                        listaTemas.Add(tema);
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TemasModel", "Gaceta");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TemasModel", "Gaceta");
            }
            finally
            {
                connection.Close();
            }

            return listaTemas;
        }



    }
}
