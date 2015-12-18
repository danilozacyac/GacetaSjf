using ScjnUtilities;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;

namespace GacetaSjf.Dao
{
    public class Tomos
    {
        private int mes;
        private string tomo;
        private string pdfFile;
        private int volumen;

        public int Mes
        {
            get
            {
                return this.mes;
            }
            set
            {
                this.mes = value;
            }
        }

        public string Tomo
        {
            get
            {
                return this.tomo;
            }
            set
            {
                this.tomo = value;
            }
        }

        public string PdfFile
        {
            get
            {
                return this.pdfFile;
            }
            set
            {
                this.pdfFile = value;
            }
        }

        public int Volumen
        {
            get
            {
                return this.volumen;
            }
            set
            {
                this.volumen = value;
            }
        }



        private readonly string connectionString = ConfigurationManager.ConnectionStrings["SJF"].ConnectionString;
        public ObservableCollection<Tomos> GetTomos()
        {
            ObservableCollection<Tomos> listaTesis = new ObservableCollection<Tomos>();

            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM TomosSjf Where Habilitado = 1 ORDER BY Mes";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Tomos tesis = new Tomos();
                        tesis.Mes = Convert.ToInt32(reader["mes"]);
                        tesis.Tomo = reader["Tomo"].ToString();
                        tesis.PdfFile = reader["PDF"].ToString();
                        tesis.Volumen = Convert.ToInt32(reader["Volumen"]);

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

    }
}
