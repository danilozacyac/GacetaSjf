using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GacetaSjf.Controllers;
using GacetaSjf.Dao;
using Telerik.Windows.Controls;

namespace GacetaSjf
{
    /// <summary>
    /// Interaction logic for DetalleDoctos.xaml
    /// </summary>
    public partial class DetalleDoctos : Window
    {
        Votos documento;
        string textoCompleto = String.Empty;



        private DocumentoController controller;
        public IEnumerable<Documento> ListaDocumentos;
        public int PosActual;
        private Documento documentoMostrado;
        public List<Documento> DocsMostrar;

        public DetalleDoctos()
        {
            InitializeComponent();
        }


        public DetalleDoctos(IEnumerable<Documento> listaDocumentos, int posActual)
        {
            InitializeComponent();
            this.PosActual = posActual;
            this.ListaDocumentos = listaDocumentos;
            DocsMostrar = ListaDocumentos.ToList();
            controller = new DocumentoController(this, DocsMostrar[PosActual]);
        }


        public DetalleDoctos(Documento documentoMostrado)
        {
            InitializeComponent();
            this.documentoMostrado = documentoMostrado;
            controller = new DocumentoController(this, documentoMostrado);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            
        }

        Anexos selectedAnexo;
       

        private void LstAnexos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //selectedAnexo = LstAnexos.SelectedItem as Anexos;

            //int position = TxtDetalle.Text.IndexOf(selectedAnexo.Frase);
        }


        private void RibbonButton_Click(object sender, RoutedEventArgs e)
        {
            RadRibbonButton ribbon = sender as RadRibbonButton;

            switch (ribbon.Name)
            {
                case "RbtnInicio":
                    controller.DocumentoStart();
                    break;
                case "RbtnPrevious":
                    controller.DocumentoPrevious();
                    break;
                case "RbtnNext":
                    controller.DocumentoNext();
                    break;
                case "RbtnFin":
                    controller.DocumentoEnd();
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
    }
}
