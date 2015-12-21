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
        private int habilitado;
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


        public int Habilitado
        {
            get
            {
                return this.habilitado;
            }
            set
            {
                this.habilitado = value;
            }
        }

        



        private readonly string connectionString = ConfigurationManager.ConnectionStrings["SJF"].ConnectionString;
        public ObservableCollection<Tomos> GetTomos()
        {
            ObservableCollection<Tomos> listaTomos = new ObservableCollection<Tomos>();

            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM TomosSjf ORDER BY Mes";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Tomos tomo = new Tomos();
                        tomo.Mes = Convert.ToInt32(reader["mes"]);
                        tomo.Tomo = reader["Tomo"].ToString();
                        tomo.PdfFile = reader["PDF"].ToString();
                        tomo.Volumen = Convert.ToInt32(reader["Volumen"]);
                        tomo.habilitado = Convert.ToInt32(reader["Habilitado"]);

                        listaTomos.Add(tomo);
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,Tomos", "Gaceta");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,Tomos", "Gaceta");
            }
            finally
            {
                connection.Close();
            }

            return listaTomos;
        }

    }
}
