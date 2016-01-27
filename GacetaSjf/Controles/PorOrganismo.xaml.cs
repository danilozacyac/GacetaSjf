using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GacetaSjf.Dao;
using GacetaSjf.Model;
using MantesisVerIusCommonObjects.Dto;

namespace GacetaSjf.Controles
{
    /// <summary>
    /// Interaction logic for PorOrganismo.xaml
    /// </summary>
    public partial class PorOrganismo : UserControl
    {
        private TesisDto selectedTesis;
        private Organismos selectedOrganismo;
        private ObservableCollection<TesisDto> listaTesis;

        public PorOrganismo()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TreeOrganismos.DataContext = new OrganismosModel().GetOrganismos(null);
        }

        private void TreeOrganismos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedOrganismo = TreeOrganismos.SelectedItem as Organismos;

            if (selectedOrganismo.CKey != null && selectedOrganismo.CKey.StartsWith("S"))
            {
                int queTraigo = (selectedOrganismo.CKey.EndsWith("6")) ? 6 : (selectedOrganismo.CKey.EndsWith("1")) ? 1 : 2;

                listaTesis = new TesisSjfModel().GetTesis(Convert.ToInt16(queTraigo), Convert.ToInt16(queTraigo));
            }else
                listaTesis = new TesisSjfModel().GetTesis(selectedOrganismo.IdOrganismo, selectedOrganismo.IdOrganismo);
            

            GTesis.DataContext = listaTesis;
        }

        private void GTesis_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            selectedTesis = GTesis.SelectedItem as TesisDto;
        }

        private void GTesis_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int posActual = listaTesis.IndexOf(selectedTesis);

            UnaTesis showTesis = new UnaTesis(listaTesis, posActual);
            showTesis.ShowDialog();
        }
    }
}
