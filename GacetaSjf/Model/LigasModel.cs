using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using GacetaSjf.Dao;
using ScjnUtilities;

namespace GacetaSjf.Model
{
    public class LigasModel
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Ligas"].ConnectionString;

        public ObservableCollection<Liga> GetLigas(int registroDigital)
        {
            ObservableCollection<Liga> listaRelaciones = new ObservableCollection<Liga>();


            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM Relaciones WHERE IUS = @IUS ORDER BY Seccion,Posicion";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@IUS", registroDigital);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Liga relacion = new Liga();
                        relacion.Ius = Convert.ToInt32(reader["IUS"]);
                        relacion.IdRelacion = Convert.ToInt32(reader["IdRel"]);
                        relacion.Frase = reader["MiDescriptor"].ToString();
                        relacion.Seccion = Convert.ToInt32(reader["Seccion"]);
                        relacion.Posicion = Convert.ToInt32(reader["Posicion"]);
                        relacion.Tipo = Convert.ToInt32(reader["Tipo"]);

                        listaRelaciones.Add(relacion);
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,LigasModel", "Gaceta");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,LigasModel", "Gaceta");
            }
            finally
            {
                connection.Close();
            }

            return listaRelaciones;
        }

        /// <summary>
        /// Obtiene el número de registro del documento que debe ser lanzado después de el click
        /// sobre el vínculo
        /// </summary>
        /// <param name="registroDigital">Número de registro de la tesis que tiene el vínculo</param>
        /// <param name="idRelacion">Identificador del destino</param>
        /// <returns></returns>
        public Liga GetNumiusLiga(int registroDigital, int idRelacion)
        {
            Liga relacion = null;


            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM RelFraseTesis WHERE IUS = @IUS AND IdRel = @IdRel";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@IUS", registroDigital);
                cmd.Parameters.AddWithValue("@IdRel", idRelacion);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        relacion = new Liga();
                        relacion.Ius = Convert.ToInt32(reader["IdLink"]);
                        relacion.IdRelacion = Convert.ToInt32(reader["IdRel"]);
                        relacion.Tipo = Convert.ToInt32(reader["Tipo"]);

                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,LigasModel", "Gaceta");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,LigasModel", "Gaceta");
            }
            finally
            {
                connection.Close();
            }

            return relacion;
        }

    }
}
