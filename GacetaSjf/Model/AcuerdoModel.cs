using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using GacetaSjf.Dao;
using ScjnUtilities;

namespace GacetaSjf.Model
{
    public class AcuerdoModel
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["SJF"].ConnectionString;

        public ObservableCollection<Documento> GetAcuerdos()
        {
            ObservableCollection<Documento> listaAcuerdos = new ObservableCollection<Documento>();


            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT A.*, I.DescInstAbr FROM Acuerdo A INNER JOIN cInsts I ON A.Sala = I.IdInst  Where ParteT <> 99 ORDER BY ConsecIndx";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Documento documento = new Documento();
                        documento.Ius = Convert.ToInt32(reader["Id"]);
                        documento.Sala = Convert.ToInt32(reader["Sala"]);
                        documento.Epoca = Convert.ToInt32(reader["Epoca"]);
                        documento.Volumen = Convert.ToInt32(reader["Volumen"]);
                        documento.Fuente = Convert.ToInt32(reader["Fuente"]);
                        documento.Pagina = Convert.ToInt32(reader["Pagina"]);
                        documento.Rubro = reader["Rubro"].ToString();
                        documento.Asunto = reader["Tesis"].ToString();
                        documento.Promovente = reader["DescInstAbr"].ToString();

                        listaAcuerdos.Add(documento);
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AcuerdoModel", "Gaceta");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AcuerdoModel", "Gaceta");
            }
            finally
            {
                connection.Close();
            }

            return listaAcuerdos;
        }


        public Documento GetAcuerdos(int registroDigital)
        {
            Documento documento = null;


            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT A.*, I.DescInstAbr FROM Acuerdo A INNER JOIN cInsts I ON A.Sala = I.IdInst Where Id = @Id AND ParteT <> 99 ORDER BY ConsecIndx";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@Id", registroDigital);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        documento = new Documento();
                        documento.Ius = Convert.ToInt32(reader["Id"]);
                        documento.Sala = Convert.ToInt32(reader["Sala"]);
                        documento.Epoca = Convert.ToInt32(reader["Epoca"]);
                        documento.Volumen = Convert.ToInt32(reader["Volumen"]);
                        documento.Fuente = Convert.ToInt32(reader["Fuente"]);
                        documento.Pagina = Convert.ToInt32(reader["Pagina"]);
                        documento.Rubro = reader["Rubro"].ToString();
                        documento.Asunto = reader["Tesis"].ToString();
                        documento.Promovente = reader["DescInstAbr"].ToString();

                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AcuerdoModel", "Gaceta");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AcuerdoModel", "Gaceta");
            }
            finally
            {
                connection.Close();
            }

            return documento;
        }



        public List<string> GetAcuerdosPartes(int registroDigital)
        {
            List<string> partes = new List<string>();


            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM ParteAcuerdo Where Id = @Id ORDER BY Parte";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@Id", registroDigital);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        partes.Add(reader["txtParte"].ToString());
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AcuerdoModel", "Gaceta");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AcuerdoModel", "Gaceta");
            }
            finally
            {
                connection.Close();
            }

            return partes;
        }





        public List<Anexos> GetAnexos(int registroDigital)
        {
            List<Anexos> listaAnexos = new List<Anexos>();


            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM zTablasPartes Where Id = @Id ORDER BY Posicion";

            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@Id", registroDigital);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Anexos anexo = new Anexos();
                        anexo.Archivo = reader["Archivo"].ToString();
                        anexo.Frase = reader["Frase"].ToString();
                        anexo.Posicion = Convert.ToInt32(reader["Posicion"]);
                        anexo.Tamanio = Convert.ToInt32(reader["Tamanio"]);
                        anexo.Tipo = Convert.ToInt32(reader["IdTpo"]);

                        listaAnexos.Add(anexo);
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,VotosModel", "Gaceta");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,VotosModel", "Gaceta");
            }
            finally
            {
                connection.Close();
            }

            return listaAnexos;
        }

    }
}
