using System;
using System.Linq;
using System.Windows;
using GacetaSjf.Controles;
using Telerik.Windows.Controls;
using GacetaSjf.Controles.Indices;

namespace GacetaSjf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Presentacion presentacion;

        public MainWindow()
        {
            StyleManager.ApplicationTheme = new Office_BlueTheme();
            //StyleManager.ApplicationTheme = new Windows8Theme();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //string filePath = ConfigurationManager.AppSettings["Datos"].ToString();

            //filePath += "presentacion.pdf";
            //presentacion = new Presentacion(filePath);
            //this.AddPane(100, "Presentación", presentacion);

        }


        Tradicional tesisTradicional;
        private void BtnTradicional_Click(object sender, RoutedEventArgs e)
        {
            tesisTradicional = new Tradicional();
            this.AddPane(1, "Consulta tradicional (Tesis)", tesisTradicional);

        }


        EjecTradicional ejecutoriaTradicional;
        private void BtnEjecutoria_Click(object sender, RoutedEventArgs e)
        {
            ejecutoriaTradicional = new EjecTradicional();
            this.AddPane(50, "Consulta tradicional (ejecutorias)", ejecutoriaTradicional);
        }

        VotoTradicional votoTradicional;
        private void BtnVotos_Click(object sender, RoutedEventArgs e)
        {
            votoTradicional = new VotoTradicional();
            this.AddPane(51, "Consulta tradicional (Votos)", votoTradicional);
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

        AcuerdoTradicional acuerdoTradicional = null;
        private void BtnAcuerdo_Click(object sender, RoutedEventArgs e)
        {
            acuerdoTradicional = new AcuerdoTradicional();
            this.AddPane(53, "Consulta tradicional (Acuerdos)", acuerdoTradicional);
        }


        IndiceTesis indiceTesis;
        private void BtnIndiceTesis_Click(object sender, RoutedEventArgs e)
        {
            indiceTesis = new IndiceTesis();
            this.AddPane(84, "Indice Anual de Tesis", indiceTesis);
        }

        IndiceDocumentos indiceEjecutorias;
        private void BtnIndiceEjecutoria_Click(object sender, RoutedEventArgs e)
        {
            indiceEjecutorias = new IndiceDocumentos(2);
            this.AddPane(85, "Indice Anual de Ejecutorias", indiceEjecutorias);
        }

        IndiceDocumentos indiceCorte;
        private void BtnIndiceScjn_Click(object sender, RoutedEventArgs e)
        {
            indiceCorte = new IndiceDocumentos(5);
            this.AddPane(86, "Indice Anual de Acuerdos de la SCJN", indiceCorte);
        }

        IndiceDocumentos indiceConsejo;
        private void BtnIndiceCjf_Click(object sender, RoutedEventArgs e)
        {
            indiceConsejo = new IndiceDocumentos(6);
            this.AddPane(87, "Indice Anual de Acuerdos del CJF", indiceConsejo);
        }

        IndiceDocumentos indiceConjunto;
        private void BtnIndiceConjunto_Click(object sender, RoutedEventArgs e)
        {
            indiceConjunto = new IndiceDocumentos(7);
            this.AddPane(88, "Indice Anual de Acuerdos Conjuntos", indiceConjunto);
        }

       

       

        

        
    }
}
