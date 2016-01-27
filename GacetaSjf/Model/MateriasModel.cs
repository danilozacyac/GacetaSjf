using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using GacetaSjf.Dao;
using ScjnUtilities;

namespace GacetaSjf.Model
{
    public class MateriasModel
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["SJF"].ConnectionString;

        public List<Materias> GetMaterias()
        {
            List<Materias> listaMaterias = new List<Materias>();

            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM cMats WHERE IdMat < 7 ORDER BY IdMat";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Materias datos = new Materias();
                        datos.IdMateria = Convert.ToInt32(reader["IdMat"]);
                        datos.Materia = reader["DescMat"].ToString();

                        listaMaterias.Add(datos);
                    }
                }
                cmd.Dispose();
                reader.Close();

                Materias dummy = new Materias();
                dummy.IdMateria = 99;
                dummy.Materia = "Todas";

                listaMaterias.Add(dummy);
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

            return listaMaterias;
        }

    }
}
