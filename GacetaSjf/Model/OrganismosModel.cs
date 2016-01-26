using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using GacetaSjf.Dao;
using ScjnUtilities;

namespace GacetaSjf.Model
{
    public class OrganismosModel
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["SJF"].ConnectionString;

        public ObservableCollection<Organismos> GetOrganismos(Organismos parent)
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
                if(parent == null)
                cmd.Parameters.AddWithValue("@Padre", 10);
                else
                    cmd.Parameters.AddWithValue("@Padre", parent.IdOrganismo);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Organismos organismo = new Organismos();

                        organismo.IdOrganismo = Convert.ToInt32(reader["IdInd"]);
                        organismo.Organismo = reader["cDesc"].ToString();
                        organismo.Nivel = Convert.ToInt16(reader["nNivel"]);
                        organismo.Tag = reader["cTag"].ToString();
                        organismo.CKey = reader["cKey"].ToString();
                        organismo.IdPadre = Convert.ToInt32(reader["nIdPadre"]);
                        organismo.Parent = parent;

                        if (!organismo.CKey.StartsWith("S"))
                        {
                            if (organismo.Nivel < 3)
                                organismo.Children = this.GetOrganismos(organismo);
                            else
                                organismo.Children = this.GetOrganismos(organismo.IdOrganismo);
                        }
                        listaTesis.Add(organismo);
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,OrganismosModel", "ListadoDeTesis");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,OrganismosModel", "ListadoDeTesis");
            }
            finally
            {
                connection.Close();
            }

            return listaTesis;
        }


        public ObservableCollection<Organismos> GetOrganismos(int idInstancia)
        {
            ObservableCollection<Organismos> listaOrganismos = new ObservableCollection<Organismos>();

            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM TribCol WHERE Cto = @Cto ORDER BY Mat, Ord";

            int circuito = 0;

            if (idInstancia > 100 && idInstancia < 200)
                circuito = idInstancia - 100;


            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@Cto", circuito);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Organismos organismo = new Organismos();

                        organismo.IdOrganismo = Convert.ToInt32(reader["IdTCC"]);
                        organismo.Organismo = reader["DescTCC"].ToString();
                        //organismo.Children = this.GetOrganismosTree(organismo.IdOrganismo);

                        listaOrganismos.Add(organismo);
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,OrganismosModel", "ListadoDeTesis");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,OrganismosModel", "ListadoDeTesis");
            }
            finally
            {
                connection.Close();
            }

            return listaOrganismos;
        }


    }
}
