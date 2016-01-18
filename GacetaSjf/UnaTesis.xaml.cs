using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GacetaSjf.Controllers;
using MantesisVerIusCommonObjects.Dto;
using Telerik.Windows.Controls;
using System.Collections.Generic;

namespace GacetaSjf
{
    /// <summary>
    /// Interaction logic for UnaTesis.xaml
    /// </summary>
    public partial class UnaTesis : Window
    {
        private UnaTesisController controller;
        public ObservableCollection<TesisDto> ListaTesis;
        public int PosActual;
        private TesisDto tesisMostrada;
        public List<int> tesisAbiertas;
        public int ColorFondo;

        public UnaTesis()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Muestra el detalle de tesis con la posibilidad de navegar a traves de un listado
        /// </summary>
        /// <param name="listaTesis">Lista de Tesis mostrada en la ventana principal</param>
        /// <param name="posActual">Posición de la tesis seleccionada dentro del listado mostrado</param>
        public UnaTesis( ObservableCollection<TesisDto> listaTesis, int posActual)
        {
            InitializeComponent();
            this.PosActual = posActual;
            this.ListaTesis = listaTesis;
            controller = new UnaTesisController(this,listaTesis[posActual]);
        }

        /// <summary>
        /// Muestra el detalle de una sola tesis, no se puede navegar a través de un listado
        /// </summary>
        /// <param name="tesisMostrada">Tesis de la cual se visualiza el detalle</param>
        /// <param name="tesisAbiertas">Lista de tesis que se han abierto por ligas entre ellas</param>
        /// <param name="colorFondo">Color de fondo de la tesis que se muestra</param>
        public UnaTesis(TesisDto tesisMostrada, List<int> tesisAbiertas,int colorFondo)
        {
            InitializeComponent();
            this.tesisMostrada = tesisMostrada;
            this.tesisAbiertas = tesisAbiertas;
            this.ColorFondo = colorFondo;
            controller = new UnaTesisController(this, tesisMostrada);
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (ListaTesis == null)
                controller.LoadTesisWindow(tesisMostrada);
            else
                controller.LoadTesisWindow(ListaTesis[PosActual]);
        }

        private void RibbonButton_Click(object sender, RoutedEventArgs e)
        {
            RadRibbonButton ribbon = sender as RadRibbonButton;

            switch (ribbon.Name)
            {
                case "RbtnInicio":
                    controller.TesisStart();
                    break;
                case "RbtnPrevious":
                    controller.TesisPrevious();
                    break;
                case "RbtnNext":
                    controller.TesisNext();
                    break;
                case "RbtnFin":
                    controller.TesisEnd();
                    break;
                case "RbtnClipboard":
                    controller.TesisToClipboard(1);
                    break;
                case "BtnCIus":
                    controller.TesisToClipboard(2);
                    break;
                case "BtnCRubro":
                    controller.TesisToClipboard(3);
                    break;
                case "BtnCTexto":
                    controller.TesisToClipboard(4);
                    break;
                case "BtnCPrec":
                    controller.TesisToClipboard(5);
                    break;
            }
        }

        private void ExportarGroupClick(object sender, RoutedEventArgs e)
        {
            RadRibbonButton action = sender as RadRibbonButton;
            controller.ExportarOptions(action.Name);
        }
    }
}