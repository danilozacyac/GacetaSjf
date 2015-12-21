using GacetaSjf.Controles;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace GacetaSjf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {




        }



        Tradicional tesisTradicional;
        private void BtnTradicional_Click(object sender, RoutedEventArgs e)
        {
            tesisTradicional = new Tradicional();
            this.AddPane(1, "Consulta tradicional (Tesis)", tesisTradicional);
        }

        Tematica consultaTematica;
        private void BtnTematica_Click(object sender, RoutedEventArgs e)
        {
            consultaTematica = new Tematica();
            this.AddPane(2, "Consulta temática", consultaTematica);
        }

        Ordenamientos consultaOrdenamientos;
        private void BtnOrdenamientos_Click(object sender, RoutedEventArgs e)
        {
            consultaOrdenamientos = new Ordenamientos();
            this.AddPane(3, "Consulta por ordenamientos", consultaOrdenamientos);
        }

        PorOrganismo consultaOrganismos;
        private void BtnOrganismo_Click(object sender, RoutedEventArgs e)
        {
            consultaOrganismos = new PorOrganismo();
            this.AddPane(4, "Consulta por órgano emisor", consultaOrganismos);
        }

        MesPdf consultaPdf;
        private void BtnConsultaPdf_Click(object sender, RoutedEventArgs e)
        {
            consultaPdf = new MesPdf();
            this.AddPane(5, "Consulta en PDF", consultaPdf);
        }

        private void AddPane(int tag, string tabTitle, object organoControl)
        {

            RadPane existingPane = this.GetExistingPane(tag);

            if (existingPane == null)
            {
                RadPane pane = new RadPane();
                pane.Tag = tag;
                pane.Header = tabTitle;
                pane.Content = organoControl;

                PanelCentral.Items.Add(pane);
                Docking.ActivePane = pane;
            }
            else
            {
                existingPane.IsHidden = false;
                Docking.ActivePane = existingPane;
            }
        }

        private RadPane GetExistingPane(int tag)
        {
            RadPane pane = null;

            foreach (RadPane panes in Docking.Panes)
            {
                if (Convert.ToInt32(panes.Tag) == tag)
                {
                    pane = panes;
                    break;
                }
            }
            return pane;
        }

        

        
    }
}
