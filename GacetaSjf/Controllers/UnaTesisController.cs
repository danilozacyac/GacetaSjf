using GacetaSjf.Singletons;
using MantesisVerIusCommonObjects.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GacetaSjf.Controllers
{
    public class UnaTesisController
    {
        private readonly UnaTesis unaTesis;

        private UnaTesisModel unaTesisModel;

        private TesisDto tesisMostrada = null;



        public UnaTesisController(UnaTesis unaTesis)
        {
            this.unaTesis = unaTesis;
        }

        public UnaTesisController(UnaTesis unaTesis, TesisDto tesisMostrada)
        {
            this.unaTesis = unaTesis;
            this.tesisMostrada = tesisMostrada;
        }

        public void LoadTesisWindow(long ius)
        {

            LoadComboBoxes();
            LoadTesis(ius);
            LoadNoBindingValues();


        }

        /// <summary>
        /// Carga la información de la tesis en cada uno de los campos del formulario
        /// </summary>
        public void LoadTesis(long ius)
        {
            unaTesisModel = new UnaTesisModel();

            if (tesisMostrada == null)
            {
                tesisMostrada = unaTesisModel.CargaDatosTesisMantesisSql(ius);
            }
            else
            {
                ius = tesisMostrada.Ius;
            }

            tesisMostrada.IsEnable = unaTesis.IsTesisUpdatable;
            tesisMostrada.IsReadOnly = !unaTesis.IsTesisUpdatable;

            unaTesis.DataContext = tesisMostrada;

            if (unaTesis.ListaTesis != null && unaTesis.ListaTesis.Count > 1)
                unaTesis.LblContador.Content = "     " + (unaTesis.PosActual + 1) + " / " + unaTesis.ListaTesis.Count;
            else
            {
                unaTesis.LblContador.Content = "    1 / 1";
                unaTesis.Navega.IsEnabled = false;
            }



        }

        public void LoadComboBoxes()
        {
            unaTesis.CbxInstancia.ItemsSource = DatosCompartidosSingleton.Instancias;
            unaTesis.CbxFuente.ItemsSource = DatosCompartidosSingleton.Fuentes;

            unaTesis.CbxMat1.ItemsSource = MateriasSingleton.MateriasSin;
            unaTesis.CbxMat2.ItemsSource = MateriasSingleton.MateriasSin;
            unaTesis.CbxMat3.ItemsSource = MateriasSingleton.MateriasSin;
            unaTesis.CbxMat4.ItemsSource = MateriasSingleton.MateriasSin;
            unaTesis.CbxMat5.ItemsSource = MateriasSingleton.MateriasSin;


        }

        public void LoadNoBindingValues()
        {
            unaTesis.RbtAislada.FontWeight = System.Windows.FontWeights.Normal;
            unaTesis.RbtJurisp.FontWeight = System.Windows.FontWeights.Normal;

            unaTesis.CbxInstancia.SelectedValue = tesisMostrada.Sala;
            unaTesis.CbxFuente.SelectedValue = tesisMostrada.Fuente;

            unaTesis.CbxMat1.SelectedValue = tesisMostrada.Materia1;
            unaTesis.CbxMat2.SelectedValue = tesisMostrada.Materia2;
            unaTesis.CbxMat3.SelectedValue = tesisMostrada.Materia3;
            unaTesis.CbxMat4.SelectedValue = tesisMostrada.Materia4;
            unaTesis.CbxMat5.SelectedValue = tesisMostrada.Materia5;

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

            //binaryMotivos = NumericUtilities.ToBinaryInvert(tesisMostrada.MotivoModificar);
            //binaryArray = binaryMotivos.ToCharArray();
        }

        //private char[] binaryArray;
        //private string sCamposModif = "";





        #region RibbonButtons

        public void TesisStart()
        {
            tesisMostrada = null;
            unaTesis.PosActual = 0;
            TesisDto tesis = unaTesis.ListaTesis[unaTesis.PosActual];
            this.LoadTesisWindow(tesis.Ius);

            unaTesis.LblContador.Content = "     " + (unaTesis.PosActual + 1) + " / " + unaTesis.ListaTesis.Count;
        }

        public void TesisPrevious()
        {
            tesisMostrada = null;
            if (unaTesis.PosActual > 0)
            {
                unaTesis.PosActual--;
                TesisDto tesis = unaTesis.ListaTesis[unaTesis.PosActual];
                this.LoadTesisWindow(tesis.Ius);

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
                this.LoadTesisWindow(tesis.Ius);
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
            this.LoadTesisWindow(tesis.Ius);
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
                                      "Instancia: " + unaTesis.CbxInstancia.Text + "\r\n" +
                                      ((unaTesis.RbtJurisp.IsChecked == true) ? "Jurisprudencia" : "Tesis Aislada") + "\r\n" +
                                      "Fuente: " + unaTesis.CbxFuente.Text + "\r\n" +
                                      unaTesis.TxtVolumen.Text + "\r\n" +
                                      "Materia(s): " + unaTesis.CbxMat1.Text + ((!unaTesis.CbxMat2.Text.Equals("<sin materia>"))
                                                                                ? (", " + unaTesis.CbxMat2.Text + ((!unaTesis.CbxMat3.Text.Equals("<sin materia>")) ? ", " + unaTesis.CbxMat3.Text : "")) : "") + "\r\n" +
                                      "Tesis: " + unaTesis.TxtTesis.Text + "\r\n" + "Página: " + unaTesis.TxtPag.Text + "\r\n" +
                                      "\r\n" +
                                      ((!unaTesis.TxtGenealogia.Text.Equals(String.Empty)) ? "Genealogía: " + unaTesis.TxtGenealogia.Text + "\r\n" : String.Empty) +
                                      tesisMostrada.Rubro + "\r\n" + tesisMostrada.Texto + "\r\n" +
                                      tesisMostrada.Precedentes + "\r\n" + "\r\n" + "\r\n" +
                                      ((!unaTesis.TxtObservaciones.Text.Equals(String.Empty)) ? "Notas: " + "\r\n" + unaTesis.TxtObservaciones.Text + "\r\n" + "\r\n" : "") +
                                      ((!unaTesis.TxtConcordancia.Text.Equals(String.Empty)) ? "Notas: " + "\r\n" + unaTesis.TxtConcordancia.Text + "\r\n" + "\r\n" : "") +
                                      "Nota de publicación:" + "\r\n" + unaTesis.TxtNotaPublica.Text);
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