﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using GacetaSjf.Dao;
using GacetaSjf.Model;
using MantesisVerIusCommonObjects.Dto;
using System.Windows.Media;
using System.Collections.Generic;
using GacetaSjf.Ligas;
using GacetaSjf.Singletons;

namespace GacetaSjf.Controllers
{
    public class UnaTesisController
    {
        private readonly UnaTesis unaTesis;


        private TesisDto tesisMostrada = null;
        private Ejecutoria ejecutoriaRelacionada;
        private ObservableCollection<Votos> votosRelacionados;

       

        public UnaTesisController(UnaTesis unaTesis,TesisDto tesisMostrada)
        {
            this.unaTesis = unaTesis;
            this.tesisMostrada = tesisMostrada;
            //LoadTesisWindow(tesisMostrada);
        }

        public void LoadTesisWindow(TesisDto tesisMostrada)
        {
            if (unaTesis.tesisAbiertas == null)
                unaTesis.tesisAbiertas = new List<int>();
            else
                unaTesis.tesisAbiertas.Clear();

            unaTesis.tesisAbiertas.Add(tesisMostrada.Ius);

            LoadTesis(tesisMostrada);
            LoadNoBindingValues();

            if (unaTesis.ListaTesis == null || unaTesis.ListaTesis.Count == 1)
                unaTesis.Navega.Visibility = Visibility.Collapsed;

        }

        /// <summary>
        /// Carga la información de la tesis en cada uno de los campos del formulario
        /// </summary>
        public void LoadTesis(TesisDto tesisAMostrar)
        {
            TesisSjfModel model = new TesisSjfModel();

            unaTesis.flowDoc.Blocks.Clear();

            this.FlowdocBackgroundColor();

            tesisMostrada = model.GetTesis(tesisAMostrar.Ius);

            ejecutoriaRelacionada = model.GetTesisEjecutoria(tesisAMostrar.Ius);

            unaTesis.RBtnEjecutoria.Visibility = (ejecutoriaRelacionada == null) ? Visibility.Collapsed : Visibility.Visible;

            votosRelacionados = model.GetTesisVotos(tesisAMostrar.Ius);

            unaTesis.RBtnVerVoto.Visibility = (votosRelacionados.Count == 0) ? Visibility.Collapsed : Visibility.Visible;


            ObservableCollection<Liga> ligasTesis = new LigasModel().GetLigas(tesisMostrada.Ius);

            tesisMostrada.IsReadOnly = true;

            unaTesis.DataContext = tesisMostrada;

            if (unaTesis.ListaTesis != null && unaTesis.ListaTesis.Count > 1)
                unaTesis.LblContador.Content = "     " + (unaTesis.PosActual + 1) + " / " + unaTesis.ListaTesis.Count;
            else
            {
                unaTesis.LblContador.Content = "    1 / 1";
                unaTesis.Navega.IsEnabled = false;
            }

            //Agregamos el rubro
            this.LoadParteTesis(tesisMostrada.Rubro, ligasTesis, 1);

            //Agregamos el texto
            this.LoadParteTesis(tesisMostrada.Texto, ligasTesis, 2);

            //Agregamos precedentes
            this.LoadParteTesis(tesisMostrada.Precedentes, ligasTesis, 4);

            //Agregamos tribunal
            //this.LoadParteTesis(tesisMostrada, ligasTesis, 4);

            //Agregamos Nota Publica
            this.LoadParteTesis(tesisMostrada.NotaPublica, ligasTesis, 1000);

            unaTesis.TxtSemanario.Text = "Semanario Judicial de la Federación, " + this.GetTextoPublicaSemanario(tesisMostrada.Precedentes);
            unaTesis.TxtGaceta.Text = this.GetTextoPublicaGaceta();
        }

        public void LoadNoBindingValues()
        {
            unaTesis.RbtAislada.FontWeight = System.Windows.FontWeights.Normal;
            unaTesis.RbtJurisp.FontWeight = System.Windows.FontWeights.Normal;

            if (tesisMostrada.TaTj == 0)
            {
                unaTesis.RbtAislada.IsChecked = true;
                unaTesis.RbtAislada.FontWeight = System.Windows.FontWeights.Bold;
            }
            else
            {
                unaTesis.RbtJurisp.IsChecked = true;
                unaTesis.RbtJurisp.FontWeight = System.Windows.FontWeights.Bold;
            }

        }


        public void LoadParteTesis(string texto, ObservableCollection<Liga> ligasTesis,int seccion)
        {
            try
            {
                Paragraph paragraphTesis;

                var ligasTexto = (from n in ligasTesis
                                  where n.Seccion == seccion
                                  orderby n.Posicion
                                  select n).ToList();

                if (ligasTexto.Count > 0)
                {
                    string textoRecortable = texto;

                    paragraphTesis = new Paragraph();
                    paragraphTesis.FontSize = 12;
                    paragraphTesis.FontWeight = FontWeights.Normal;

                    foreach (Liga link in ligasTexto)
                    {
                        link.Frase = link.Frase.Replace("–", "-");
                        int index = textoRecortable.IndexOf(link.Frase);

                        Run textoPlano = new Run(textoRecortable.Substring(0, index));

                        Hyperlink hl = new Hyperlink(new Run(link.Frase));
                        hl.FontSize = 12;
                        hl.NavigateUri = new Uri("http://www.scjn.gob.mx/");
                        hl.Click += new RoutedEventHandler(LinkClick);
                        hl.Tag = link;

                        paragraphTesis.Inlines.Add(textoPlano);
                        paragraphTesis.Inlines.Add(hl);

                        textoRecortable = textoRecortable.Substring(index + link.Frase.Length);


                    }
                    Run textosobra = new Run(textoRecortable);
                    paragraphTesis.Inlines.Add(textosobra);
                    unaTesis.flowDoc.Blocks.Add(paragraphTesis);
                }
                else
                {
                    paragraphTesis = new Paragraph();
                    paragraphTesis.FontSize = 12;
                    paragraphTesis.FontWeight = FontWeights.Normal;
                    paragraphTesis.Inlines.Add(new Run(texto));
                    unaTesis.flowDoc.Blocks.Add(paragraphTesis);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(tesisMostrada.Ius.ToString());

                Paragraph paragraphTesis = new Paragraph();
                paragraphTesis.FontSize = 12;
                paragraphTesis.FontWeight = FontWeights.Normal;
                paragraphTesis.Inlines.Add(new Run(texto));
                unaTesis.flowDoc.Blocks.Add(paragraphTesis);
            }
        }

        public void LinkClick(object sender, RoutedEventArgs e)
        {
            Hyperlink link = sender as Hyperlink;
            Liga clickedLiga = link.Tag as Liga;

            if (clickedLiga.Tipo == 10) // Ligas entre tesis, ejecutorias, votos y acuerdos
            {
                Liga infoToLaunch = new LigasModel().GetNumiusLiga(clickedLiga.Ius, clickedLiga.IdRelacion);

                if (infoToLaunch.Tipo == 1) //Lanza una tesis
                {
                    TesisDto tesisToLaunch = new TesisSjfModel().GetTesis(infoToLaunch.Ius);


                    if (unaTesis.tesisAbiertas.Contains(tesisToLaunch.Ius))
                    {
                        MessageBox.Show("La tesis con registro digital " + tesisToLaunch.Ius + " ya se encuentra abierta");
                        return;
                    }
                    else
                    {
                        unaTesis.tesisAbiertas.Add(tesisToLaunch.Ius);
                        UnaTesis newWindow = new UnaTesis(tesisToLaunch, unaTesis.tesisAbiertas, 1);
                        newWindow.MainRibbon.ApplicationName = tesisMostrada.Ius + " ---> " + tesisToLaunch.Ius;
                        newWindow.Owner = unaTesis;
                        newWindow.ShowDialog();
                    }
                }
                else if (infoToLaunch.Tipo == 2) //Lanza una ejecutoria
                {

                }

            }
            else if (clickedLiga.Tipo == 50 || clickedLiga.Tipo == 0) //Legislaciones estatales
            {
                ObservableCollection<Articulos> listaArticulos = new ArticuloModel().GetLegislacionRelacionada(clickedLiga.Ius, clickedLiga.IdRelacion);

                if (listaArticulos.Count == 1)
                {
                    DetalleArticulo detalle = new DetalleArticulo(listaArticulos[0]);
                    detalle.Owner = unaTesis;
                    detalle.ShowDialog();
                }
                else
                {
                    ListaRelacionados lista = new ListaRelacionados(listaArticulos);
                    lista.Owner = unaTesis;
                    lista.ShowDialog();
                }
            }



        }


        public void FlowdocBackgroundColor()
        {
            if (unaTesis.ColorFondo == 0)
                unaTesis.flowDoc.Background = new SolidColorBrush(Colors.White);
            if (unaTesis.ColorFondo == 1)
                unaTesis.flowDoc.Background = new SolidColorBrush(Colors.LightPink);
            if (unaTesis.ColorFondo == 2)
                unaTesis.flowDoc.Background = new SolidColorBrush(Colors.LightGreen);
        }

        #region RibbonButtons

        public void TesisStart()
        {
            tesisMostrada = null;
            unaTesis.PosActual = 0;
            TesisDto tesis = unaTesis.ListaTesis[unaTesis.PosActual];
            this.LoadTesisWindow(tesis);

            unaTesis.LblContador.Content = "     " + (unaTesis.PosActual + 1) + " / " + unaTesis.ListaTesis.Count;
        }

        public void TesisPrevious()
        {
            tesisMostrada = null;
            if (unaTesis.PosActual > 0)
            {
                unaTesis.PosActual--;
                TesisDto tesis = unaTesis.ListaTesis[unaTesis.PosActual];
                this.LoadTesisWindow(tesis);

                unaTesis.LblContador.Content = "     " + (unaTesis.PosActual + 1) + " / " + unaTesis.ListaTesis.Count;
            }
        }

        public void TesisNext()
        {
            tesisMostrada = null;
            if (unaTesis.PosActual < unaTesis.ListaTesis.Count - 1)
            {
                unaTesis.PosActual++;
                TesisDto tesis = unaTesis.ListaTesis[unaTesis.PosActual];

                //unaTesisModel.DbConnectionOpen();
                this.LoadTesisWindow(tesis);
                //unaTesisModel.DbConnectionClose();

                unaTesis.LblContador.Content = "     " + (unaTesis.PosActual + 1) + " / " + unaTesis.ListaTesis.Count;
            }
        }

        public void TesisEnd()
        {
            tesisMostrada = null;

            unaTesis.PosActual = unaTesis.ListaTesis.Count - 1;
            TesisDto tesis = unaTesis.ListaTesis[unaTesis.PosActual];

            //unaTesisModel.DbConnectionOpen();
            this.LoadTesisWindow(tesis);
            //unaTesisModel.DbConnectionClose();
            unaTesis.LblContador.Content = "     " + (unaTesis.PosActual + 1) + " / " + unaTesis.ListaTesis.Count;
        }


        public void VerEjecutoria()
        {
            DetalleDoctos documento = new DetalleDoctos(ejecutoriaRelacionada);
            documento.Owner = unaTesis;
            documento.ShowDialog();
        }


        public void TesisToClipboard(int queMando)
        {
            switch (queMando)
            {
                case 1: // Toda la tesis
                    Clipboard.SetText(
                                      unaTesis.TxtEpoca.Text + "\r\n" + "Registro: " + tesisMostrada.Ius + "\r\n" +
                                      "Instancia: " + tesisMostrada.Sala + "\r\n" +
                                      ((unaTesis.RbtJurisp.IsChecked == true) ? "Jurisprudencia" : "Tesis Aislada") + "\r\n" +
                                      "Fuente: " + tesisMostrada.Fuente + "\r\n" +
                                      tesisMostrada.Volumen + "\r\n" +
                                      "Materia(s): " + unaTesis.TxtMat1.Text + ((!unaTesis.TxtMat2.Text.Equals("<sin materia>"))
                                                                                ? (", " + unaTesis.TxtMat2.Text + ((!unaTesis.TxtMat3.Text.Equals("<sin materia>")) ? ", " + unaTesis.TxtMat3.Text : "")) : "") + "\r\n" +
                                      "Tesis: " + unaTesis.TxtTesis.Text + "\r\n" + "Página: " + tesisMostrada.Pagina + "\r\n" +
                                      "\r\n" +
                                      ((!unaTesis.TxtGenealogia.Text.Equals(String.Empty)) ? "Genealogía: " + unaTesis.TxtGenealogia.Text + "\r\n" : String.Empty) +
                                      tesisMostrada.Rubro + "\r\n" + tesisMostrada.Texto + "\r\n" +
                                      tesisMostrada.Precedentes + "\r\n" + "\r\n" + "\r\n" +
                                      ((!unaTesis.TxtObservaciones.Text.Equals(String.Empty)) ? "Notas: " + "\r\n" + unaTesis.TxtObservaciones.Text + "\r\n" + "\r\n" : "") +
                                      ((!unaTesis.TxtConcordancia.Text.Equals(String.Empty)) ? "Notas: " + "\r\n" + unaTesis.TxtConcordancia.Text + "\r\n" + "\r\n" : "") +
                                      "Nota de publicación:" + "\r\n" + tesisMostrada.NotaPublica);
                    MessageBox.Show("Tesis enviada al portapapeles");
                    break;
                case 2: // NumIus
                    Clipboard.SetText(tesisMostrada.Ius.ToString());
                    break;
                case 3: // Rubro
                    Clipboard.SetText(tesisMostrada.Rubro);
                    break;
                case 4: // Texto
                    Clipboard.SetText(tesisMostrada.Texto);
                    break;
                case 5: // Precedentes
                    Clipboard.SetText(tesisMostrada.Precedentes);
                    break;
                case 6: // Nota Rubro
                    Clipboard.SetText(tesisMostrada.NotasRubro);
                    break;
                case 7: // Nota Texto
                    Clipboard.SetText(tesisMostrada.NotasTexto);
                    break;
                case 8: // Nota Precedentes
                    Clipboard.SetText(tesisMostrada.NotasPrecedentes);
                    break;
            }
        }


        private string GetTextoPublicaSemanario(string precedentes)
        {
            string [] cadenas =  precedentes.Replace("\n","").Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);

            string publica = cadenas[cadenas.Count() - 1];

            int posicion = publica.IndexOf("horas");

            string textoSemanario = publica.Substring(24, posicion - 24) + " horas";

            return textoSemanario;
        }

        private string GetTextoPublicaGaceta()
        {
            string fuente = (from n in CompartidosSingleton.Fuentes
                             where n.IdElemento == tesisMostrada.Fuente
                             select n.Descripcion).ToList()[0];

            string volumen = (from n in CompartidosSingleton.Volumenes
                              where n.IdElemento == tesisMostrada.VolumenInt
                              select n.Descripcion).ToList()[0];

            string subVolumen = (from n in CompartidosSingleton.SubVolumenes
                                 where n.IdElemento == tesisMostrada.IdSubVolumen
                                 select n.Descripcion).ToList()[0];

            return fuente + ", " + volumen + ", " + subVolumen + ", Página " + tesisMostrada.Pagina;
        }

        #endregion

        #region Exportar

        public void ExportarOptions(string name)
        {
            //switch (name)
            //{
            //    case "RBtnPdf":
            //        new ListaTesisPdf().GeneraPdfConDetalleTesis(tesisMostrada);
            //        break;
            //    case "RBtnWord":

            //        new ListaTesisWord().GeneraWordConDetalleTesis(tesisMostrada);
            //        break;
            //}
        }

        #endregion


    }
}