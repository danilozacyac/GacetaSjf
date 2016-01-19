using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using GacetaSjf.Dao;
using ScjnUtilities;

namespace GacetaSjf.Model
{
    public class ArticuloModel
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Ligas"].ConnectionString;

        public ObservableCollection<Articulos> GetLegislacionRelacionada(int registroDigital, int idRelacion)
        {
            ObservableCollection<Articulos> listaArticulos = new ObservableCollection<Articulos>();

            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena;

            try
            {
                connection.Open();

                sqlCadena = "SELECT * FROM RelFraseArts WHERE IUS = @IUS AND IdRel = @IdRel ORDER BY Consec";
                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@IUS", registroDigital);
                cmd.Parameters.AddWithValue("@IdRel", idRelacion);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Articulos articulo = new Articulos();
                        articulo.Ius = registroDigital;
                        articulo.IdRel = idRelacion;
                        articulo.Consec = Convert.ToInt32(reader["Consec"]);
                        articulo.IdLey = Convert.ToInt32(reader["IdLey"]);
                        articulo.IdReforma = Convert.ToInt32(reader["IdRef"]);
                        articulo.IdArticulo = Convert.ToInt32(reader["IdArt"]);
                        this.GetTituloLey(articulo);

                        if (articulo.PartesArticulo[0].Length < 255)
                            articulo.ArticuloShort = articulo.PartesArticulo[0] + "     <más información>";
                        else
                            articulo.ArticuloShort = articulo.PartesArticulo[0].Substring(0, 255) + "     <más información>";

                        listaArticulos.Add(articulo);
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

            return listaArticulos;
        }

        private void GetTituloLey(Articulos articulo)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena;

            try
            {
                connection.Open();

                sqlCadena = "SELECT Articulos.*, Leyes.DescLey" +
                            " FROM Leyes INNER JOIN Articulos ON Leyes.IdLey = Articulos.IdLey " +
                            " WHERE (((Articulos.[IdLey])= @IdLey) AND ((Articulos.[IdRef])= @IdRef) AND ((Articulos.[IdArt])= @IdArt))";
                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@IdLey", articulo.IdLey);
                cmd.Parameters.AddWithValue("@IdRef", articulo.IdReforma);
                cmd.Parameters.AddWithValue("@IdArt", articulo.IdArticulo);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        articulo.TituloLey = reader["DescLey"].ToString();
                        articulo.PartesArticulo.Add(reader["Info"].ToString());
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
        }


        public void GetPartesArticulo(Articulos articulo)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena;

            try
            {
                connection.Open();

                sqlCadena = "SELECT InfoT FROM ArticulosParte WHERE IdLey = @IdLey AND IdRef = @IdRef AND IdArt = @IdArt ORDER BY Parte";
                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@IdLey", articulo.IdLey);
                cmd.Parameters.AddWithValue("@IdRef", articulo.IdReforma);
                cmd.Parameters.AddWithValue("@IdArt", articulo.IdArticulo);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        articulo.PartesArticulo.Add(reader["InfoT"].ToString());
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
        }
    }
}