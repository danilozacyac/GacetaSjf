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
        private long ius;
        private readonly byte accion;
        public ObservableCollection<TesisDto> ListaTesis;
        public int PosActual;
        public readonly bool IsTesisUpdatable;
        private readonly bool isVerIusAccess;
        private TesisDto tesisMostrada;

        public UnaTesis()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ius">Número de registro IUS de la tesis a mostrar</param>
        /// <param name="accion">Como se abrira el registro.   1  Visualiza  ----  2  Actualiza  ---- 3 Nueva tesis</param>
        /// <param name="listaTesis">Lista de Tesis mostrada en la ventana principal</param>
        /// <param name="posActual">Posición de la tesis dentro del listado mostrado</param>
        /// <param name="isTesisUpdatable"></param>
        public UnaTesis(long ius, byte accion, ObservableCollection<TesisDto> listaTesis, int posActual, bool isTesisUpdatable)
        {
            InitializeComponent();
            this.ius = ius;
            this.accion = accion;
            this.PosActual = posActual;
            this.ListaTesis = listaTesis;
            this.IsTesisUpdatable = isTesisUpdatable;
            this.isVerIusAccess = false;
            controller = new UnaTesisController(this);
        }

        /// <summary>
        /// Constructor que utiliza la funcionalidad de Ver IUS para lanzar la una nueva ventana con la tesis buscada
        /// </summary>
        /// <param name="tesisMostrada"></param>
        /// <param name="isTesisUpdatable"></param>
        public UnaTesis(TesisDto tesisMostrada, bool isTesisUpdatable) : this()
        {
            this.tesisMostrada = tesisMostrada;
            this.ius = tesisMostrada.Ius;
            this.IsTesisUpdatable = isTesisUpdatable;
            isVerIusAccess = true;
            controller = new UnaTesisController(this, tesisMostrada);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            controller.LoadTesisWindow(this.ius);
            this.Title = (IsTesisUpdatable) ? "Actualizar Tesis" : "Visualizar Tesis";
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