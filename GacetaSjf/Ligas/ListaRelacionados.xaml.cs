using GacetaSjf.Dao;
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
using System.Windows.Shapes;

namespace GacetaSjf.Ligas
{
    /// <summary>
    /// Interaction logic for ListaRelacionados.xaml
    /// </summary>
    public partial class ListaRelacionados : Window
    {
        ObservableCollection<Articulos> listaArticulos;
        Articulos selectedArticulo;

        public ListaRelacionados(ObservableCollection<Articulos> listaArticulos)
        {
            InitializeComponent();
            this.listaArticulos = listaArticulos;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TxtTitulo.Text = listaArticulos[0].TituloLey;
            GArticulos.DataContext = listaArticulos;
        }

        private void GArticulos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DetalleArticulo detalle = new DetalleArticulo(selectedArticulo);
            detalle.Owner = this;
            detalle.ShowDialog();
        }

        private void GArticulos_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            selectedArticulo = GArticulos.SelectedItem as Articulos;
        }
    }
}
