using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GacetaSjf.Dao;
using GacetaSjf.Model;
using GacetaSjf.Reportes;

namespace GacetaSjf.Controles
{
    /// <summary>
    /// Interaction logic for AcuerdoTradicional.xaml
    /// </summary>
    public partial class AcuerdoTradicional : UserControl
    {
        ObservableCollection<Documento> listaAcuerdos;
        Documento selectedVoto;

        private bool vaciarListado = true;

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
            selectedVoto = GAcuerdos.SelectedItem as Documento;
        }

        private void GAcuerdos_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int index = listaAcuerdos.IndexOf(selectedVoto);

            DetalleDoctos doctos = new DetalleDoctos(listaAcuerdos.Cast<Documento>(), index);
            doctos.ShowDialog();
        }

        private void BtnSecuencial_Click(object sender, RoutedEventArgs e)
        {
            listaAcuerdos = new AcuerdoModel().GetAcuerdos();
            GAcuerdos.DataContext = listaAcuerdos;
            vaciarListado = true;
        }

        private void BtnIncorpora_Click(object sender, RoutedEventArgs e)
        {
            if (vaciarListado)
            {
                listaAcuerdos = new ObservableCollection<Documento>();
                GAcuerdos.DataContext = listaAcuerdos;
                vaciarListado = false;
            }

            int ius = Convert.ToInt32(TxtIus.Text);

            Documento acuerdo = new AcuerdoModel().GetAcuerdos(ius);

            if (acuerdo == null)
            {
                MessageBox.Show("El registro digital que ingresaste no existe, favor de verificar", "Atención:", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (listaAcuerdos.Contains(acuerdo))
            {
                MessageBox.Show("La ejecutoria solicitada ya se encuentra dentro del listado", "Atención:", MessageBoxButton.OK, MessageBoxImage.Information);
                TxtIus.Text = String.Empty;
                return;
            }
            else
            {
                listaAcuerdos.Add(acuerdo);
                TxtIus.Text = String.Empty;
            }
        }

        private void BtnPrint_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            WordReports word = new WordReports(listaAcuerdos);
            word.ListadoDeDocumentosTabla();
        }
        
    }
}
