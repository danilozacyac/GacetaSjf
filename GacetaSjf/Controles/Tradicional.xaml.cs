using GacetaSjf.Dao;
using GacetaSjf.Model;
using MantesisVerIusCommonObjects.Dto;
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
    /// Interaction logic for Tradicional.xaml
    /// </summary>
    public partial class Tradicional : UserControl
    {
        public ObservableCollection<TesisDto> listaTesis;
        private Tomos selectedTomo;
        private bool vaciarListado = true;

        public Tradicional()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            listaTesis = new TesisSjfModel().GetTesis();

            GTesis.DataContext = listaTesis;
            CbxVolumen.DataContext = new Tomos().GetTomos();
        }

        private void CbxVolumen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTomo = CbxVolumen.SelectedItem as Tomos;

            GTesis.DataContext = (from n in listaTesis
                                  where n.VolumenInt == selectedTomo.Volumen
                                  select n);
        }

        private void BtnIncorpora_Click(object sender, RoutedEventArgs e)
        {
            if (vaciarListado)
            {
                listaTesis = new ObservableCollection<TesisDto>();
                GTesis.DataContext = listaTesis;
                vaciarListado = false;
            }

            int ius = Convert.ToInt32(TxtIus.Text);

            TesisDto tesis = new TesisSjfModel().GetTesis(ius);

            if (tesis == null)
            {
                MessageBox.Show("El número de tesis que ingresaste no existe, favor de verificar", "Atención:", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (listaTesis.Contains(tesis))
            {
                MessageBox.Show("La tesis solicitada ya se encuentra dentro del listado", "Atención:", MessageBoxButton.OK, MessageBoxImage.Information);
                TxtIus.Text = String.Empty;
                return;
            }
            else
            {
                listaTesis.Add(tesis);
                TxtIus.Text = String.Empty;
            }

            
        }

        private void BtnSecuencial_Click(object sender, RoutedEventArgs e)
        {
            listaTesis = new TesisSjfModel().GetTesis();

            GTesis.DataContext = listaTesis;
            vaciarListado = true;
        }
    }
}
