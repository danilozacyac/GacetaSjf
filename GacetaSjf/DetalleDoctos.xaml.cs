using GacetaSjf.Dao;
using GacetaSjf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GacetaSjf
{
    /// <summary>
    /// Interaction logic for DetalleDoctos.xaml
    /// </summary>
    public partial class DetalleDoctos : Window
    {
        Documento documento;
        string textoCompleto = String.Empty;

        public DetalleDoctos()
        {
            InitializeComponent();
        }

        public DetalleDoctos(Ejecutoria ejecutoria)
        {
            InitializeComponent();
            this.documento = ejecutoria;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            if (documento is Ejecutoria)
            {
                documento.Partes = new EjecutoriaModel().GetEjecutoriaPartes(documento.Ius);
                documento.Anexos = new EjecutoriaModel().GetAnexos(documento.Ius);
            }

            textoCompleto += documento.Rubro + "\r\n";
            foreach (string parte in documento.Partes)
            {
                textoCompleto += parte;
            }

            //TxtDetalle.Text = textoCompleto;

            string[] parrafos = textoCompleto.Replace('\n',' ').Split('\r');

            foreach (string par in parrafos)
            {
                Paragraph paraHeader = new Paragraph();
                paraHeader.FontSize = 12;
                paraHeader.FontWeight = FontWeights.Bold;
                paraHeader.Inlines.Add(new Run(par));
                flowDoc.Blocks.Add(paraHeader);
            }

            if (documento.Anexos.Count == 0)
            {
                LblAnexos.Visibility = Visibility.Collapsed;
                LstAnexos.Visibility = Visibility.Collapsed;
            }
            else
            {
                LblAnexos.Visibility = Visibility.Collapsed;
                LstAnexos.Visibility = Visibility.Visible;
                LstAnexos.DataContext = documento.Anexos;
            }

        }

        Anexos selectedAnexo;
       

        private void LstAnexos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //selectedAnexo = LstAnexos.SelectedItem as Anexos;

            //int position = TxtDetalle.Text.IndexOf(selectedAnexo.Frase);
        }
    }
}
