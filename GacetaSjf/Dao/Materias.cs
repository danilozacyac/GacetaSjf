using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using ScjnUtilities;

namespace GacetaSjf.Dao
{
    public class Materias
    {
        private int idMateria;
        private string materia;

        public int IdMateria
        {
            get
            {
                return this.idMateria;
            }
            set
            {
                this.idMateria = value;
            }
        }

        public string Materia
        {
            get
            {
                return this.materia;
            }
            set
            {
                this.materia = value;
            }
        }


        private readonly string connectionString = ConfigurationManager.ConnectionStrings["SJF"].ConnectionString;
        public ObservableCollection<Materias> GetMaterias()
        {
            ObservableCollection<Materias> listaTesis = new ObservableCollection<Materias>();

            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM cMats Where idMat <= 6 ";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Materias tesis = new Materias();
                        tesis.IdMateria = Convert.ToInt32(reader["IdMat"]);
                        tesis.Materia = reader["DescMat"].ToString();

                        listaTesis.Add(tesis);
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,Materias", "Gaceta");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,Materias", "Gaceta");
            }
            finally
            {
                connection.Close();
            }

            return listaTesis;
        }
    }
}
