using GacetaSjf.Dao;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GacetaSjf.Model
{
    public class OrganismosModel
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["SJF"].ConnectionString;

        public ObservableCollection<Organismos> GetOrganismosTree(int idPadre)
        {
            ObservableCollection<Organismos> listaTesis = new ObservableCollection<Organismos>();

            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM cIndices WHERE nIdPadre = @Padre ORDER BY IdInd";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@Padre", idPadre);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Organismos organismo = new Organismos();

                        organismo.IdOrganismo = Convert.ToInt32(reader["IdInd"]);
                        organismo.Organismo = reader["cDesc"].ToString();
                        organismo.Children = this.GetOrganismosTree(organismo.IdOrganismo);

                        listaTesis.Add(organismo);
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                //ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TesisModel", "ListadoDeTesis");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                //ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TesisModel", "ListadoDeTesis");
            }
            finally
            {
                connection.Close();
            }

            return listaTesis;
        }




    }
}
