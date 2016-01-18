using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using GacetaSjf.Dao;
using GacetaSjf.Model;
using MantesisVerIusCommonObjects.Dto;

namespace GacetaSjf.Controllers
{
    public class UnaTesisController
    {
        private readonly UnaTesis unaTesis;


        private TesisDto tesisMostrada = null;
        


       

        public UnaTesisController(UnaTesis unaTesis,TesisDto tesisMostrada)
        {
            this.unaTesis = unaTesis;
            this.tesisMostrada = tesisMostrada;
            //LoadTesisWindow(tesisMostrada);
        }

        public void LoadTesisWindow(TesisDto tesisMostrada)
        {

            LoadTesis(tesisMostrada);
            LoadNoBindingValues();

            if (unaTesis.ListaTesis.Count == 1)
                unaTesis.Navega.Visibility = Visibility.Collapsed;

        }

        /// <summary>
        /// Carga la información de la tesis en cada uno de los campos del formulario
        /// </summary>
        public void LoadTesis(TesisDto tesisAMostrar)
        {
            unaTesis.flowDoc.Blocks.Clear();

            tesisMostrada = new TesisSjfModel().GetTesis(tesisAMostrar.Ius);

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

            if (clickedLiga.Tipo == 0) //Legislación federal
            {

            }
            else if (clickedLiga.Tipo == 10) // Ligas entre tesis, ejecutorias, votos y acuerdos
            {
                Liga infoToLaunch = new LigasModel().GetNumiusLiga(clickedLiga.Ius, clickedLiga.IdRelacion);

                if (infoToLaunch.Tipo == 1) //Lanza una tesis
                {
                    TesisDto tesisToLaunch = new TesisSjfModel().GetTesis(infoToLaunch.Ius);

                    UnaTesis newWindow = new UnaTesis(new ObservableCollection<TesisDto>() { tesisToLaunch }, 0);
                    newWindow.Title = tesisMostrada.Ius + " ---> " + tesisToLaunch.Ius;
                    newWindow.Owner = unaTesis;
                    newWindow.ShowDialog();
                }
                else if (infoToLaunch.Tipo == 2) //Lanza una ejecutoria
                {

                }

            }
            else if (clickedLiga.Tipo == 50) //Legislaciones estatales
            {

            }



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

        


        public void TesisToClipboard(int queMando)
        {
            switch (queMando)
            {
                case 1: // Toda la tesis
                    Clipboard.SetText(
                                      unaTesis.TxtEpoca.Text + "\r\n" + "Registro: " + tesisMostrada.Ius + "\r\n" +
                                      "Instancia: " + unaTesis.TxtInstancia.Text + "\r\n" +
                                      ((unaTesis.RbtJurisp.IsChecked == true) ? "Jurisprudencia" : "Tesis Aislada") + "\r\n" +
                                      "Fuente: " + unaTesis.CbxFuente.Text + "\r\n" +
                                      unaTesis.TxtVolumen.Text + "\r\n" +
                                      "Materia(s): " + unaTesis.TxtMat1.Text + ((!unaTesis.TxtMat2.Text.Equals("<sin materia>"))
                                                                                ? (", " + unaTesis.TxtMat2.Text + ((!unaTesis.TxtMat3.Text.Equals("<sin materia>")) ? ", " + unaTesis.TxtMat3.Text : "")) : "") + "\r\n" +
                                      "Tesis: " + unaTesis.TxtTesis.Text + "\r\n" + "Página: " + unaTesis.TxtPag.Text + "\r\n" +
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