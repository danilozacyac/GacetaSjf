using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Documents.Fixed.FormatProviders;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf;
using Telerik.Windows.Documents.Fixed.Model;

namespace GacetaSjf.Controles
{
    /// <summary>
    /// Interaction logic for Presentacion.xaml
    /// </summary>
    public partial class Presentacion : UserControl
    {

        readonly string filePath;

        public Presentacion(string filePath)
        {
            InitializeComponent();
            this.filePath = filePath;

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           MemoryStream stream = new MemoryStream();

            using (Stream input = File.OpenRead(filePath))
            {
                input.CopyTo(stream);
            }

            FormatProviderSettings settings = new FormatProviderSettings(ReadingMode.OnDemand);
            PdfFormatProvider provider = new PdfFormatProvider(stream, settings);
            RadFixedDocument doc = provider.Import();
            this.pdfViewer.Document = doc;

            
        }

        private void TbCurrentPageKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (e.Key == System.Windows.Input.Key.Enter)
                {
                    textBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
            }
        }
    }
}
