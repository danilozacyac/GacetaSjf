using GacetaSjf.Dao;
using GacetaSjf.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace GacetaSjf.Controles.Indices
{
    /// <summary>
    /// Interaction logic for IndiceDocumentos.xaml
    /// </summary>
    public partial class IndiceDocumentos : UserControl
    {
        ObservableCollection<Ejecutoria> listaEjecutorias;
        ObservableCollection<Documento> listaDocumentos;
        readonly int tipoDocumento;
        Documento selectedDocumento;

        public IndiceDocumentos(int tipoDocumento)
        {
            InitializeComponent();
            this.tipoDocumento = tipoDocumento;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (tipoDocumento == 2)
            {
                listaEjecutorias = new EjecutoriaModel().GetEjecutoriaIndices();
                GDocumentos.DataContext = listaEjecutorias;
            }
            else
            {
                listaDocumentos = new AcuerdoModel().GetAcuerdoIndices(tipoDocumento);
                GDocumentos.DataContext = listaDocumentos;
            }
        }

        private void GDocumentos_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            selectedDocumento = GDocumentos.SelectedItem as Documento;
        }

        private void GDocumentos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (tipoDocumento == 2)
            {
                int posActual = listaEjecutorias.IndexOf(selectedDocumento as Ejecutoria);

                DetalleDoctos doctos = new DetalleDoctos(listaEjecutorias.Cast<Documento>(), posActual);
                doctos.ShowDialog();
            }
            else
            {
                int posActual = listaDocumentos.IndexOf(selectedDocumento);

                DetalleDoctos doctos = new DetalleDoctos(listaDocumentos, posActual);
                doctos.ShowDialog();
            }
        }
    }
}
