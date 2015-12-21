using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
