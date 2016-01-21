using System;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using GacetaSjf.Dao;
using GacetaSjf.Model;
using Telerik.Windows.Controls;
using System.Configuration;
using System.IO;
using Telerik.Windows.Documents.Fixed.FormatProviders;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf;
using Telerik.Windows.Documents.Fixed.Model;
using GacetaSjf.Controles;

namespace GacetaSjf.Controllers
{
    public class DocumentoController
    {

        private readonly DetalleDoctos unDocumento;


        private Documento documentoMostrada = null;

        string textoCompleto = String.Empty;




        public DocumentoController(DetalleDoctos unDocumento, Documento documentoMostrada)
        {
            this.unDocumento = unDocumento;
            this.documentoMostrada = documentoMostrada;
            LoadDocumentoWindow(documentoMostrada);
        }

        public void LoadDocumentoWindow(Documento documento)
        {

            //LoadComboBoxes();
            LoadDocumento(documento);
            //LoadNoBindingValues();


        }


        public void LoadDocumento(Documento documentoAMostrar)
        {
            unDocumento.flowDoc.Blocks.Clear();
            textoCompleto = String.Empty;

            if (documentoAMostrar is Ejecutoria)
            {
                if (documentoAMostrar.Rubro == null)
                    documentoAMostrar = new EjecutoriaModel().GetEjecutoria(documentoAMostrar as Ejecutoria);

                documentoAMostrar.Partes = new EjecutoriaModel().GetEjecutoriaPartes(documentoAMostrar.Ius);
                documentoAMostrar.Anexos = new EjecutoriaModel().GetAnexos(documentoAMostrar.Ius);
            }
            else if (documentoAMostrar is Votos)
            {
                documentoAMostrar.Partes = new VotosModel().GetVotosPartes(documentoAMostrar.Ius);
                documentoAMostrar.Anexos = new VotosModel().GetAnexos(documentoAMostrar.Ius);
            }
            else if (documentoAMostrar is Documento)
            {
                if (documentoAMostrar.Rubro == null)
                    documentoAMostrar = new AcuerdoModel().GetAcuerdos(documentoAMostrar);

                documentoAMostrar.Partes = new AcuerdoModel().GetAcuerdosPartes(documentoAMostrar.Ius);
                documentoAMostrar.Anexos = new AcuerdoModel().GetAnexos(documentoAMostrar.Ius);
            }

            textoCompleto += documentoAMostrar.Rubro + "\r\n";
            foreach (string parte in documentoAMostrar.Partes)
            {
                textoCompleto += parte;
            }

            //TxtDetalle.Text = textoCompleto;

            string[] parrafos = textoCompleto.Replace('\n', ' ').Split('\r');

            if (documentoAMostrar.Anexos.Count == 0)
            {
                foreach (string par in parrafos)
                {
                    if (String.IsNullOrWhiteSpace(par)) { }
                    else
                    {
                        Paragraph paraHeader = new Paragraph();
                        paraHeader.FontSize = 12;
                        paraHeader.FontWeight = FontWeights.Normal;
                        paraHeader.Inlines.Add(new Run(par));
                        unDocumento.flowDoc.Blocks.Add(paraHeader);
                    }
                }
                unDocumento.LblAnexos.Visibility = Visibility.Collapsed;
                unDocumento.LstAnexos.Visibility = Visibility.Collapsed;
            }
            else
            {
                foreach (string par in parrafos)
                {
                    if (String.IsNullOrWhiteSpace(par)) { }
                    else
                    {
                        bool esAnexo = false;
                        BlockUIContainer elemento = null;

                        foreach (Anexos anexo in documentoAMostrar.Anexos)
                        {
                            if (par.Contains(anexo.Frase))
                            {
                                esAnexo = true;

                                if (par.Contains("Ver votación"))
                                {
                                    string tempString = par.Replace(anexo.Frase, "");

                                    elemento = new BlockUIContainer(new VerVotacion());

                                    Paragraph paraHeader = new Paragraph();
                                    paraHeader.FontSize = 12;
                                    paraHeader.FontWeight = FontWeights.Normal;
                                    paraHeader.Inlines.Add(new Run(tempString));
                                    paraHeader.Inlines.Add(new VerVotacion());
                                    unDocumento.flowDoc.Blocks.Add(paraHeader);
                                }
                                else if (anexo.Archivo.EndsWith(".PDF"))
                                {
                                    RadPdfViewer viewer = new RadPdfViewer();

                                    MemoryStream stream = new MemoryStream();

                                    using (Stream input = File.OpenRead(ConfigurationManager.AppSettings["Datos"].ToString() + @"Anexos\" + anexo.Archivo))
                                    {
                                        input.CopyTo(stream);
                                    }

                                    FormatProviderSettings settings = new FormatProviderSettings(ReadingMode.OnDemand);
                                    PdfFormatProvider provider = new PdfFormatProvider(stream, settings);
                                    RadFixedDocument doc = provider.Import();
                                    viewer.Document = doc;
                                    elemento = new BlockUIContainer(viewer);

                                    unDocumento.flowDoc.Blocks.Add(elemento);
                                }

                                break;
                            }

                        }

                        if (!esAnexo)
                        {
                            Paragraph paraHeader = new Paragraph();
                            paraHeader.FontSize = 12;
                            paraHeader.FontWeight = FontWeights.Normal;
                            paraHeader.Inlines.Add(new Run(par));
                            unDocumento.flowDoc.Blocks.Add(paraHeader);
                        }
                    }
                }


                unDocumento.LblAnexos.Visibility = Visibility.Collapsed;
                unDocumento.LstAnexos.Visibility = Visibility.Visible;
                unDocumento.LstAnexos.DataContext = documentoAMostrar.Anexos;
            }

            

            unDocumento.DataContext = documentoAMostrar;

            if (unDocumento.DocsMostrar != null && unDocumento.DocsMostrar.Count > 1)
                unDocumento.LblContador.Content = "     " + (unDocumento.PosActual + 1) + " / " + unDocumento.DocsMostrar.Count;
            else
            {
                unDocumento.LblContador.Content = "    1 / 1";
                unDocumento.Navega.IsEnabled = false;
            }



        }


        #region RibbonButtons

        public void DocumentoStart()
        {
            documentoMostrada = null;
            unDocumento.PosActual = 0;
            Documento documento = unDocumento.DocsMostrar[unDocumento.PosActual];
            this.LoadDocumentoWindow(documento);

            unDocumento.LblContador.Content = "     " + (unDocumento.PosActual + 1) + " / " + unDocumento.DocsMostrar.Count;
        }

        public void DocumentoPrevious()
        {
            documentoMostrada = null;
            if (unDocumento.PosActual > 0)
            {
                unDocumento.PosActual--;
                Documento documento = unDocumento.DocsMostrar[unDocumento.PosActual];
                this.LoadDocumentoWindow(documento);

                unDocumento.LblContador.Content = "     " + (unDocumento.PosActual + 1) + " / " + unDocumento.DocsMostrar.Count;
            }
        }

        public void DocumentoNext()
        {
            documentoMostrada = null;
            if (unDocumento.PosActual < unDocumento.DocsMostrar.Count - 1)
            {
                unDocumento.PosActual++;
                Documento documento = unDocumento.DocsMostrar[unDocumento.PosActual];

                //unaTesisModel.DbConnectionOpen();
                this.LoadDocumentoWindow(documento);
                //unaTesisModel.DbConnectionClose();

                unDocumento.LblContador.Content = "     " + (unDocumento.PosActual + 1) + " / " + unDocumento.DocsMostrar.Count;
            }
        }

        public void DocumentoEnd()
        {
            documentoMostrada = null;

            unDocumento.PosActual = unDocumento.DocsMostrar.Count - 1;
            Documento documento = unDocumento.DocsMostrar[unDocumento.PosActual];

            //unaTesisModel.DbConnectionOpen();
            this.LoadDocumentoWindow(documento);
            //unaTesisModel.DbConnectionClose();
            unDocumento.LblContador.Content = "     " + (unDocumento.PosActual + 1) + " / " + unDocumento.DocsMostrar.Count;
        }

        public void TesisToClipboard(int queMando)
        {
            //switch (queMando)
            //{
            //    case 1: // Toda la tesis
            //        Clipboard.SetText(
            //                          unaTesis.TxtEpoca.Text + "\r\n" + "Registro: " + tesisMostrada.Ius + "\r\n" +
            //                          "Instancia: " + unaTesis.TxtInstancia.Text + "\r\n" +
            //                          ((unaTesis.RbtJurisp.IsChecked == true) ? "Jurisprudencia" : "Tesis Aislada") + "\r\n" +
            //                          "Fuente: " + unaTesis.CbxFuente.Text + "\r\n" +
            //                          unaTesis.TxtVolumen.Text + "\r\n" +
            //                          "Materia(s): " + unaTesis.TxtMat1.Text + ((!unaTesis.TxtMat2.Text.Equals("<sin materia>"))
            //                                                                    ? (", " + unaTesis.TxtMat2.Text + ((!unaTesis.TxtMat3.Text.Equals("<sin materia>")) ? ", " + unaTesis.TxtMat3.Text : "")) : "") + "\r\n" +
            //                          "Tesis: " + unaTesis.TxtTesis.Text + "\r\n" + "Página: " + unaTesis.TxtPag.Text + "\r\n" +
            //                          "\r\n" +
            //                          ((!unaTesis.TxtGenealogia.Text.Equals(String.Empty)) ? "Genealogía: " + unaTesis.TxtGenealogia.Text + "\r\n" : String.Empty) +
            //                          tesisMostrada.Rubro + "\r\n" + tesisMostrada.Texto + "\r\n" +
            //                          tesisMostrada.Precedentes + "\r\n" + "\r\n" + "\r\n" +
            //                          ((!unaTesis.TxtObservaciones.Text.Equals(String.Empty)) ? "Notas: " + "\r\n" + unaTesis.TxtObservaciones.Text + "\r\n" + "\r\n" : "") +
            //                          ((!unaTesis.TxtConcordancia.Text.Equals(String.Empty)) ? "Notas: " + "\r\n" + unaTesis.TxtConcordancia.Text + "\r\n" + "\r\n" : "") +
            //                          "Nota de publicación:" + "\r\n" + unaTesis.TxtNotaPublica.Text);
            //        MessageBox.Show("Tesis enviada al portapapeles");
            //        break;
            //    case 2: // NumIus
            //        Clipboard.SetText(tesisMostrada.Ius.ToString());
            //        break;
            //    case 3: // Rubro
            //        Clipboard.SetText(tesisMostrada.Rubro);
            //        break;
            //    case 4: // Texto
            //        Clipboard.SetText(tesisMostrada.Texto);
            //        break;
            //    case 5: // Precedentes
            //        Clipboard.SetText(tesisMostrada.Precedentes);
            //        break;
            //    case 6: // Nota Rubro
            //        Clipboard.SetText(tesisMostrada.NotasRubro);
            //        break;
            //    case 7: // Nota Texto
            //        Clipboard.SetText(tesisMostrada.NotasTexto);
            //        break;
            //    case 8: // Nota Precedentes
            //        Clipboard.SetText(tesisMostrada.NotasPrecedentes);
            //        break;
            //}
        }




        #endregion

    }
}
