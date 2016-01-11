﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using GacetaSjf.Dao;
using GacetaSjf.Model;

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
            LoadTesis(documento);
            //LoadNoBindingValues();


        }


        public void LoadTesis(Documento documentoAMostrar)
        {

            if (documentoAMostrar is Ejecutoria)
            {
                documentoAMostrar.Partes = new EjecutoriaModel().GetEjecutoriaPartes(documentoAMostrar.Ius);
                documentoAMostrar.Anexos = new EjecutoriaModel().GetAnexos(documentoAMostrar.Ius);
            }
            else if (documentoAMostrar is Votos)
            {
                documentoAMostrar.Partes = new VotosModel().GetVotosPartes(documentoAMostrar.Ius);
                documentoAMostrar.Anexos = new VotosModel().GetAnexos(documentoAMostrar.Ius);
            }

            textoCompleto += documentoAMostrar.Rubro + "\r\n";
            foreach (string parte in documentoAMostrar.Partes)
            {
                textoCompleto += parte;
            }

            //TxtDetalle.Text = textoCompleto;

            string[] parrafos = textoCompleto.Replace('\n', ' ').Split('\r');

            foreach (string par in parrafos)
            {
                Paragraph paraHeader = new Paragraph();
                paraHeader.FontSize = 12;
                paraHeader.FontWeight = FontWeights.Bold;
                paraHeader.Inlines.Add(new Run(par));
                unDocumento.flowDoc.Blocks.Add(paraHeader);
            }

            if (documentoAMostrar.Anexos.Count == 0)
            {
                unDocumento.LblAnexos.Visibility = Visibility.Collapsed;
                unDocumento.LstAnexos.Visibility = Visibility.Collapsed;
            }
            else
            {
                unDocumento.LblAnexos.Visibility = Visibility.Collapsed;
                unDocumento.LstAnexos.Visibility = Visibility.Visible;
                unDocumento.LstAnexos.DataContext = documentoAMostrar.Anexos;
            }

            unDocumento.DataContext = documentoAMostrar;

            if (unDocumento.ListaDocumentos != null && unDocumento.ListaDocumentos.Count > 1)
                unDocumento.LblContador.Content = "     " + (unDocumento.PosActual + 1) + " / " + unDocumento.ListaDocumentos.Count;
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
            Documento documento = unDocumento.ListaDocumentos[unDocumento.PosActual];
            this.LoadDocumentoWindow(documento);

            unDocumento.LblContador.Content = "     " + (unDocumento.PosActual + 1) + " / " + unDocumento.ListaDocumentos.Count;
        }

        public void DocumentoPrevious()
        {
            documentoMostrada = null;
            if (unDocumento.PosActual > 0)
            {
                unDocumento.PosActual--;
                Documento documento = unDocumento.ListaDocumentos[unDocumento.PosActual];
                this.LoadDocumentoWindow(documento);

                unDocumento.LblContador.Content = "     " + (unDocumento.PosActual + 1) + " / " + unDocumento.ListaDocumentos.Count;
            }
        }

        public void DocumentoNext()
        {
            documentoMostrada = null;
            if (unDocumento.PosActual < unDocumento.ListaDocumentos.Count - 1)
            {
                unDocumento.PosActual++;
                Documento documento = unDocumento.ListaDocumentos[unDocumento.PosActual];

                //unaTesisModel.DbConnectionOpen();
                this.LoadDocumentoWindow(documento);
                //unaTesisModel.DbConnectionClose();

                unDocumento.LblContador.Content = "     " + (unDocumento.PosActual + 1) + " / " + unDocumento.ListaDocumentos.Count;
            }
        }

        public void DocumentoEnd()
        {
            documentoMostrada = null;

            unDocumento.PosActual = unDocumento.ListaDocumentos.Count - 1;
            Documento documento = unDocumento.ListaDocumentos[unDocumento.PosActual];

            //unaTesisModel.DbConnectionOpen();
            this.LoadDocumentoWindow(documento);
            //unaTesisModel.DbConnectionClose();
            unDocumento.LblContador.Content = "     " + (unDocumento.PosActual + 1) + " / " + unDocumento.ListaDocumentos.Count;
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
