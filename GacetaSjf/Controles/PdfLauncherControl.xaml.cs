using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace GacetaSjf.Controles
{
    /// <summary>
    /// Interaction logic for PdfLauncherControl.xaml
    /// </summary>
    public partial class PdfLauncherControl : UserControl
    {
        public PdfLauncherControl()
        {
            InitializeComponent();
        }

        private void LanzaPdf(object sender, MouseButtonEventArgs e)
        {
            string path = ConfigurationManager.AppSettings["Datos"].ToString();

            Process.Start(path + @"PDF\" + LblPdfFile.Content);
        }



        ///GacetaSjf;component/Resources/pdf_256.png


    }
}
