using GacetaSjf.Dao;
using ScjnUtilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GacetaSjf.Model
{
    public class DatosCompartidosModel
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["SJF"].ConnectionString;

        public List<DatosCompartidos> GetEpocas()
        {
            List<DatosCompartidos> listaEpocas = new List<DatosCompartidos>();

            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM cEpocas ORDER BY IdEpoca";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DatosCompartidos datos = new DatosCompartidos();
                        datos.IdElemento = Convert.ToInt32(reader["IdEpoca"]);
                        datos.Descripcion = reader["DescEpoca"].ToString();

                        listaEpocas.Add(datos);
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,DatosCompartidosModel", "Gaceta");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,DatosCompartidosModel", "Gaceta");
            }
            finally
            {
                connection.Close();
            }

            return listaEpocas;
        }

        public List<DatosCompartidos> GetVolumenes()
        {
            List<DatosCompartidos> listaVolumenes = new List<DatosCompartidos>();

            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM Volumen WHERE Volumen BETWEEN 8800 AND 9000 ORDER BY Volumen";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DatosCompartidos datos = new DatosCompartidos();
                        datos.IdElemento = Convert.ToInt32(reader["Volumen"]);
                        datos.Descripcion = reader["txtVolumen"].ToString();

                        listaVolumenes.Add(datos);
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,DatosCompartidosModel", "Gaceta");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,DatosCompartidosModel", "Gaceta");
            }
            finally
            {
                connection.Close();
            }

            return listaVolumenes;
        }


        public List<DatosCompartidos> GetInstancias()
        {
            List<DatosCompartidos> listaInstancias = new List<DatosCompartidos>();

            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM cInsts ORDER BY IdInst";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DatosCompartidos datos = new DatosCompartidos();
                        datos.IdElemento = Convert.ToInt32(reader["IdInst"]);
                        datos.Descripcion = reader["DescInst"].ToString();

                        listaInstancias.Add(datos);
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,DatosCompartidosModel", "Gaceta");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,DatosCompartidosModel", "Gaceta");
            }
            finally
            {
                connection.Close();
            }

            return listaInstancias;
        }


        public List<DatosCompartidos> GetFuentes()
        {
            List<DatosCompartidos> listaFuentes = new List<DatosCompartidos>();

            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM cFuentes ORDER BY IdFte";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DatosCompartidos datos = new DatosCompartidos();
                        datos.IdElemento = Convert.ToInt32(reader["IdFte"]);
                        datos.Descripcion = reader["DescFte"].ToString();

                        listaFuentes.Add(datos);
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,DatosCompartidosModel", "Gaceta");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,DatosCompartidosModel", "Gaceta");
            }
            finally
            {
                connection.Close();
            }

            return listaFuentes;
        }

    }
}
