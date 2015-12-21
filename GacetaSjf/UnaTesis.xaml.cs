using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GacetaSjf.Controllers;
using MantesisVerIusCommonObjects.Dto;
using Telerik.Windows.Controls;

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

        public UnaTesis()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
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


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
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