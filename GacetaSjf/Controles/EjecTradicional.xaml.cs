using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GacetaSjf.Dao;
using GacetaSjf.Model;

namespace GacetaSjf.Controles
{
    /// <summary>
    /// Interaction logic for EjecTradicional.xaml
    /// </summary>
    public partial class EjecTradicional : UserControl
    {

        ObservableCollection<Ejecutoria> listaEjecutorias;
        Ejecutoria selectedEjecutoria;

        public EjecTradicional()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            listaEjecutorias = new EjecutoriaModel().GetEjecutoria();
            GEjecutoria.DataContext = listaEjecutorias;
        }
    }
}
