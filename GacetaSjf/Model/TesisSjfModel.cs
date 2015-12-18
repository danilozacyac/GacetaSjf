using MantesisVerIusCommonObjects.Dto;
using ScjnUtilities;
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
    public class TesisSjfModel
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["SJF"].ConnectionString;
        public ObservableCollection<TesisDto> GetTesis()
        {
            ObservableCollection<TesisDto> listaTesis = new ObservableCollection<TesisDto>();

            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM Tesis Where parte <> 99  ORDER BY ConsecIndx";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TesisDto tesis = new TesisDto();
                        tesis.Ius = Convert.ToInt32(reader["Ius"]);
                        tesis.Tesis = reader["Tesis"].ToString();
                        tesis.Rubro = reader["Rubro"].ToString();
                        tesis.TaTj = Convert.ToInt32(reader["ta/tj"]);
                        tesis.Sala = Convert.ToInt32(reader["Sala"]);
                        tesis.LocAbr = reader["LocAbr"].ToString();
                        tesis.VolumenInt = Convert.ToInt32(reader["Volumen"]);

                        listaTesis.Add(tesis);
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TesisSjfModel", "Gaceta");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TesisSjfModel", "Gaceta");
            }
            finally
            {
                connection.Close();
            }

            return listaTesis;
        }


        public TesisDto GetTesis(int ius)
        {
            TesisDto tesis = null;

            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM Tesis Where IUS = @IUS AND parte <> 99  ORDER BY ConsecIndx";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@IUS", ius);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tesis = new TesisDto();
                        tesis.Ius = Convert.ToInt32(reader["Ius"]);
                        tesis.Tesis = reader["Tesis"].ToString();
                        tesis.Rubro = reader["Rubro"].ToString();
                        tesis.TaTj = Convert.ToInt32(reader["ta/tj"]);
                        tesis.Sala = Convert.ToInt32(reader["Sala"]);
                        tesis.LocAbr = reader["LocAbr"].ToString();
                        tesis.VolumenInt = Convert.ToInt32(reader["Volumen"]);

                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TesisSjfModel", "Gaceta");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TesisSjfModel", "Gaceta");
            }
            finally
            {
                connection.Close();
            }

            return tesis;
        }

    }
}
