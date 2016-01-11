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

namespace GacetaSjf.Controles
{
    /// <summary>
    /// Interaction logic for AcuerdoTradicional.xaml
    /// </summary>
    public partial class AcuerdoTradicional : UserControl
    {
        ObservableCollection<Documento> listaAcuerdos;
        Votos selectedVoto;

        public AcuerdoTradicional()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            listaAcuerdos = new AcuerdoModel().GetAcuerdos();
            GAcuerdos.DataContext = listaAcuerdos;
        }

        private void GAcuerdos_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            selectedVoto = GAcuerdos.SelectedItem as Votos;
        }

        private void GAcuerdos_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int index = listaAcuerdos.IndexOf(selectedVoto);

            DetalleDoctos doctos = new DetalleDoctos(listaAcuerdos.Cast<Votos>(), index);
            doctos.ShowDialog();
        }

        
    }
}
