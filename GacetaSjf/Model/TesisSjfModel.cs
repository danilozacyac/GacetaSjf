using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using GacetaSjf.Dao;
using MantesisVerIusCommonObjects.Dto;
using ScjnUtilities;

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
                        tesis.LocAbr = reader["LocAbr"].ToString().Replace("\r\n","");
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

        /// <summary>
        /// Obtiene todos los datos de una tesis
        /// </summary>
        /// <param name="ius">Número de la tesis de la cual se requieren su información</param>
        /// <returns></returns>
        public TesisDto GetTesis(int ius)
        {
            TesisDto tesis = null;

            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM Tesis Where IUS = @IUS   ORDER BY ConsecIndx";

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
                        tesis.Texto = reader["Texto"].ToString();
                        tesis.Precedentes = reader["Precedentes"].ToString();
                        tesis.EpocaInt = Convert.ToInt32(reader["Epoca"]);
                        tesis.TaTj = Convert.ToInt32(reader["ta/tj"]);
                        tesis.Sala = Convert.ToInt32(reader["Sala"]);
                        tesis.LocAbr = reader["LocAbr"].ToString().Replace("\r\n", "");
                        tesis.VolumenInt = Convert.ToInt32(reader["Volumen"]);
                        tesis.Fuente = Convert.ToInt32(reader["Fuente"]);
                        tesis.Pagina = reader["Pagina"].ToString();
                        tesis.Materia1 = Convert.ToInt32(reader["Materia1"]);
                        tesis.Materia2 = Convert.ToInt32(reader["Materia2"]);
                        tesis.Materia3 = Convert.ToInt32(reader["Materia3"]);
                        tesis.ConsecIndx = Convert.ToInt32(reader["ConsecIndx"]);

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

        /// <summary>
        /// Obtiene todas las tesis que estan relacionadas a un tema u ordenamiento legal
        /// </summary>
        /// <param name="tema">Tema u ordenamiento legal seleccionado</param>
        /// <returns></returns>
        public ObservableCollection<TesisDto> GetTesis(Temas tema)
        {
            ObservableCollection<TesisDto> listaTesis = new ObservableCollection<TesisDto>();


            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT Z.*, T.LocAbr " +
                            " FROM Tesis T INNER JOIN zzzzzTematicoIUS Z ON T.IUS = Z.IUS Where IdTema = @IdTema ORDER BY Z.Rubro";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@IdTema", tema.IdTema);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TesisDto tesis = new TesisDto();
                        tesis.Ius = Convert.ToInt32(reader["Ius"]);
                        tesis.Tesis = reader["CveTesis"].ToString();
                        tesis.Rubro = reader["Rubro"].ToString();
                        tesis.LocAbr = reader["LocAbr"].ToString().Replace("\r\n","");

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

        /// <summary>
        /// Obtiene el listado de tesis publicadas por el organismo seleccionado
        /// </summary>
        /// <param name="idSala"></param>
        /// <param name="idInstancia"></param>
        /// <returns></returns>
        public ObservableCollection<TesisDto> GetTesis(int idSala, int idInstancia)
        {
            ObservableCollection<TesisDto> listaTesis = new ObservableCollection<TesisDto>();

            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena;

            try
            {
                connection.Open();

                if (idSala < 7)
                {
                    sqlCadena = "SELECT * FROM Tesis Where Sala = @Sala AND Parte <> 99  ORDER BY ConsecIndx";
                    cmd = new OleDbCommand(sqlCadena, connection);
                    cmd.Parameters.AddWithValue("@Sala", idSala);
                    reader = cmd.ExecuteReader();
                }
                else
                {
                    sqlCadena = "SELECT * FROM Tesis Where Instancia = @Instancia AND Parte <> 99  ORDER BY ConsecIndx";
                    cmd = new OleDbCommand(sqlCadena, connection);
                    cmd.Parameters.AddWithValue("@Instancia", idInstancia);
                    reader = cmd.ExecuteReader();
                }

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
                        tesis.LocAbr = reader["LocAbr"].ToString().Replace("\r\n", "");
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


        public ObservableCollection<TesisDto> GetTesisIndices()
        {
            ObservableCollection<TesisDto> listaTesis = new ObservableCollection<TesisDto>();

            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM xSem_Tesis ORDER BY PosGral";

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
                        tesis.Rubro = reader["xRubro"].ToString();
                        //tesis.TaTj = Convert.ToInt32(reader["ta/tj"]);
                        tesis.Sala = Convert.ToInt32(reader["xInst"]);
                        tesis.Pagina = reader["Pag"].ToString();
                        //tesis.VolumenInt = Convert.ToInt32(reader["Volumen"]);
                        tesis.Volumen = DateTimeUtilities.ToMonthName( Convert.ToInt32(reader["xMes"]));
                        tesis.Materia1 = Convert.ToInt16(reader["Mat1"]);
                        tesis.Materia2 = Convert.ToInt16(reader["Mat2"]);
                        tesis.Materia3 = Convert.ToInt16(reader["Mat3"]);
                        
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

        /// <summary>
        /// Devuelve la Ejecutoria relacionada al número de registro digital de la tesis solicitada
        /// </summary>
        /// <param name="registroDigital">Identificador de la tesis</param>
        /// <returns></returns>
        public Ejecutoria GetTesisEjecutoria(int registroDigital)
        {
            Ejecutoria ejecutoria = null;

            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena;

            try
            {
                connection.Open();


                sqlCadena = "SELECT E.* FROM RelPartes R INNER JOIN Ejecutoria E ON E.Id = R.IdPte Where IUS = @IUS AND Cve = 2";
                    cmd = new OleDbCommand(sqlCadena, connection);
                    cmd.Parameters.AddWithValue("@IUS", registroDigital);
                    reader = cmd.ExecuteReader();
                

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ejecutoria = new Ejecutoria();
                        ejecutoria.Ius = Convert.ToInt32(reader["Id"]);
                        ejecutoria.Sala = Convert.ToInt32(reader["Sala"]);
                        ejecutoria.Epoca = Convert.ToInt32(reader["Epoca"]);
                        ejecutoria.Volumen = Convert.ToInt32(reader["Volumen"]);
                        ejecutoria.Fuente = Convert.ToInt32(reader["Fuente"]);
                        ejecutoria.Pagina = Convert.ToInt32(reader["Pagina"]);
                        ejecutoria.Rubro = reader["Rubro"].ToString();
                        ejecutoria.Asunto = reader["TpoAsunto"].ToString();
                        ejecutoria.Promovente = reader["Promovente"].ToString();
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

            return ejecutoria;
        }


        public ObservableCollection<Votos> GetTesisVotos(int registroDigital)
        {
            ObservableCollection<Votos> listaVotos = new ObservableCollection<Votos>();

            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena;

            try
            {
                connection.Open();


                sqlCadena = "SELECT V.* FROM RelPartes R INNER JOIN VotosParticulares V ON V.Id = R.IdPte Where IUS = @IUS AND Cve = 3";
                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@IUS", registroDigital);
                reader = cmd.ExecuteReader();
                

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Votos voto = new Votos();
                        voto.Ius = Convert.ToInt32(reader["Id"]);
                        voto.Sala = Convert.ToInt32(reader["Sala"]);
                        voto.Epoca = Convert.ToInt32(reader["Epoca"]);
                        voto.Volumen = Convert.ToInt32(reader["Volumen"]);
                        voto.Fuente = Convert.ToInt32(reader["Fuente"]);
                        voto.Pagina = Convert.ToInt32(reader["Pagina"]);
                        voto.Rubro = reader["Rubro"].ToString();
                        voto.Asunto = reader["TpoAsunto"].ToString();
                        voto.Promovente = reader["Promovente"].ToString();
                        voto.TipoVoto = Convert.ToInt32(reader["Clasificacion"]);
                        voto.Emisor = reader["Complemento"].ToString();

                        listaVotos.Add(voto);
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

            return listaVotos;
        }


    }
}
