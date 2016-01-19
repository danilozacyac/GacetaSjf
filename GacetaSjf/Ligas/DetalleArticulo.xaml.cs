using System;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using GacetaSjf.Dao;
using GacetaSjf.Model;

namespace GacetaSjf.Ligas
{
    /// <summary>
    /// Interaction logic for DetalleArticulo.xaml
    /// </summary>
    public partial class DetalleArticulo : Window
    {
        Articulos articulotoshow;

        public DetalleArticulo(Articulos articulotoshow)
        {
            InitializeComponent();
            this.articulotoshow = articulotoshow;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            new ArticuloModel().GetPartesArticulo(articulotoshow);

            Paragraph paraHeader = new Paragraph();
            paraHeader.FontSize = 14;
            paraHeader.FontWeight = FontWeights.Bold;
            paraHeader.TextAlignment = TextAlignment.Center;
            paraHeader.Inlines.Add(new Run(articulotoshow.TituloLey));
            flowDoc.Blocks.Add(paraHeader);
            
            string textoCompleto = String.Empty;




            foreach (string parte in articulotoshow.PartesArticulo)
            {
                textoCompleto += parte;
            }

            textoCompleto = textoCompleto.Replace("\n", "");

            string[] parrafos = textoCompleto.Split('\r');

            foreach (string par in parrafos)
            {
                if (String.IsNullOrWhiteSpace(par)) { }
                else
                {
                    Paragraph paragraph = new Paragraph();
                    paragraph.FontSize = 12;
                    paragraph.FontWeight = FontWeights.Normal;
                    paragraph.TextAlignment = TextAlignment.Justify;
                    paragraph.Inlines.Add(new Run(par));
                    flowDoc.Blocks.Add(paragraph);
                }
            }
        }
    }
}
