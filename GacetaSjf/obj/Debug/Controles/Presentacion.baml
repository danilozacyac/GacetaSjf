   M S B A M L   `   `   `  ����z  vTelerik.Windows.Controls.FixedDocumentViewers, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7�iclr-namespace:Telerik.Windows.Documents.Converters;assembly=Telerik.Windows.Controls.FixedDocumentViewers$Telerik.Windows.Documents.Converters  5      | xTelerik.Windows.Controls.FixedDocumentViewersUI, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7�vclr-namespace:Telerik.Windows.Controls.FixedDocumentViewersUI;assembly=Telerik.Windows.Controls.FixedDocumentViewersUI/Telerik.Windows.Controls.FixedDocumentViewersUI 5      ��clr-namespace:Telerik.Windows.Controls.FixedDocumentViewersUI.Converters;assembly=Telerik.Windows.Controls.FixedDocumentViewersUI:Telerik.Windows.Controls.FixedDocumentViewersUI.Converters 5       	GacetaSjf&    GacetaSjf.Controles.Presentacion   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      �
convertersiclr-namespace:Telerik.Windows.Documents.Converters;assembly=Telerik.Windows.Controls.FixedDocumentViewers     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      �fixedViewersUIvclr-namespace:Telerik.Windows.Controls.FixedDocumentViewersUI;assembly=Telerik.Windows.Controls.FixedDocumentViewersUI     5      �fixedViewersUIConverters�clr-namespace:Telerik.Windows.Controls.FixedDocumentViewersUI.Converters;assembly=Telerik.Windows.Controls.FixedDocumentViewersUI     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      k gTelerik.Windows.Documents.Core, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e	 aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p
 lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GanttView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7l hTelerik.Windows.Scheduling.Core, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Utelerik1http://schemas.telerik.com/2008/xaml/presentation   	 
          5	      -   5        
�������  � 	Resources  5      * 	 $Telerik.Windows.Controls.IconSources   	IconPaths   LightBasePath   ModernBasePathK   ETelerik.Windows.Documents.Converters.FixedDocumentViewerModeConverter  ModeConverterD   >Telerik.Windows.Documents.Converters.BoolToVisibilityConverter  BoolToVisibilityConverter=   7Telerik.Windows.Documents.Converters.ScaleModeConverter  ScaleModeConverter7 	 1Telerik.Windows.Controls.InvertedBooleanConverter  InvertedBooleanConverter��%3  &	        &	 �     &	 �     &	 �     &	 �       5   
   $F @/Telerik.Windows.Controls.FixedDocumentViewers;component/Images/��5      $M G/Telerik.Windows.Controls.FixedDocumentViewers;component/Images/Modern/��5        5   
   66     5   
   6/     5   
   6(     5   
   6+   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5    
   )  #Telerik.Windows.Controls.RadToolBar  $��Stretch=�6    � DataContext 6;   ��  �� ElementName$ 	pdfViewer�� �� Path$ CommandDescriptors�.@�5!      ( 	 "Telerik.Windows.Controls.RadButton  $��2q�6    $
��Left=�5"       $��Stretch=�5#       $��Center=�5$       $��Center=�5%          IsBackgroundVisible .  $��0q�5(       $y�	Collapsed=�5)       ��5&       �� *OpenCommandDescriptor.Command+ ^� ToolTip 5*      �� 5+      $
��Open��6    .��5-      �� $
��None=�6z   ��6   4 	 .Telerik.Windows.Controls.IconResourceExtension  	   IconRelativePath$	 open.png��
   IconSources#
 [  6z   5.        50      $��2q�6    $
��Left=�51       $��Stretch=�52       $��Center=�53       $��Center=�54        .  $��0q�57       ��55       �� * PrintCommandDescriptor.Command+y�58       �� *" PrintCommandDescriptor.IsEnabled+ �� 	Converter# [  5:      �� 5;      $��Imprimir��6    .��5=      �� $
��None=�6}   ��6     $	 printer.png��#
 [  6}   5>      2	  ,Telerik.Windows.Controls.RadToolBarSeparator	  5@        5B      -   5          Name$ counterClockwiseButton��5B       $��2q�5C       $
��Left=�5D       $��Stretch=�5E        .  $��0q�5H       ��5F       �� *1/RotateCounterClockwiseCommandDescriptor.Command+ 5I      �� 5J      $��Rotar a la izquierda��6    .��5L      �� $
��None=�6�   ��6     $!	 rotate-counterclockwise.png��#
 [  6�   5M        5O      -   5        $ clockwiseButton��5O       $��2q�5P       $
��Left=�5Q       $��Stretch=�5R        .  $��0q�5U       ��5S       �� **(RotateClockwiseCommandDescriptor.Command+ 5V      �� 5W      $��Rotar a la derecha��6    .��5Y      �� $
��None=�6�   ��6     $	 rotate-clockwise.png��#
 [  6�   5Z      	  5\        5^      $��2q�6    $
��Left=�5_       $��Stretch=�5`       $��Center=�5a       $��Center=�5b        .  $��0q�5e       ��5c       �� *!PageUpCommandDescriptor.Command+y�5f       �� *#!PageUpCommandDescriptor.IsEnabled+# [  5h      �� 5i      $��Página anterior��6    .��5k      �� $
��None=�6~   ��6     $	 previous.png��#
 [  6~   5l        5n      $��2q�6    $
��Left=�5o       $��Stretch=�5p       $��Center=�5q       $��Center=�5r        .  $��0q�5u       ��5s       �� *#!PageDownCommandDescriptor.Command+y�5v       �� *%#PageDownCommandDescriptor.IsEnabled+# [  5x      �� 5y      $��Página siguiente��6    .��5{      �� $
��None=�6z   ��6     $	 next.png��#
 [  6z   5|      �� 5~      -   5         ��Name$ tbCurrentPage��5~      $��45��5      $��2q�5�      $��Center=�5�      ��5�      �� *'%FixedDocumentViewer.CurrentPageNumber+ �� Mode$ TwoWay=��� 5�      $��2q�6   $��Center=�5�      $��/��5�      �� 5�      $��2q�6   $��Center=�5�      ��5�      �� $ 	pdfViewer��$ Document.Pages.Count�	  5�        5�      $��2q�6    $
��Left=�5�       $��Stretch=�5�       $��Center=�5�       $��Center=�5�        .  $��0q�5�       ��5�       �� *!ZoomInCommandDescriptor.Command+y�5�       �� *#!ZoomInCommandDescriptor.IsEnabled+# [  5�      �� 5�      $��Acercar��6    .��5�      �� $
��None=�6}   ��6     $	 zoom-in.png��#
 [  6}   5�        5�      -   5        $ PART_btnZoomOut��5�       $��2q�5�       $
��Left=�5�       $��Stretch=�5�       $��Center=�5�       $��Center=�5�        .  $��0q�5�       ��5�       �� *" ZoomOutCommandDescriptor.Command+y�5�       �� *$"ZoomOutCommandDescriptor.IsEnabled+# [  5�      �� 5�      $��Alejar��6    .��5�      �� $
��None=�6~   ��6     $	 zoom-out.png��#
 [  6~   5�      	  5�      .
 	 (Telerik.Windows.Controls.RadToggleButton
  5�      -   5         
 Name$ fitToWidthButton��5�   &   $��2q�5�   &   $
��Left=�5�   &   $��Stretch=�5�   &    
  IsBackgroundVisible .  $��0q�5�   &   ��5�   &   �� *@>FitToWidthFixedDocumentPagesPresenterCommandDescriptor.Command+ d� 	IsChecked 5�   &   �� *B@FitToWidthFixedDocumentPagesPresenterCommandDescriptor.IsEnabled+$ TwoWay=�{�5�   &   �� *B@FitToWidthFixedDocumentPagesPresenterCommandDescriptor.IsEnabled+# [ $ TwoWay=� 5�      �� 5�      $V��PAjustar al ancho de la ventana y habilitar la navegación continua del documento��6    .��5�      �� $
��None=�6�   ��6     $	 document-fit-width.png��#
 [  6�   5�      
  5�      -   5        $ fitToPageButton��5�   &   $��2q�5�   &   $
��Left=�5�   &   $��Stretch=�5�   &    .  $��0q�5�   &   ��5�   &   �� *HFFitToPageFixedDocumentSinglePageViewPresenterCommandDescriptor.Command+ 5�   &   �� *JHFitToPageFixedDocumentSinglePageViewPresenterCommandDescriptor.IsEnabled+$ TwoWay=�{�5�   &   �� *JHFitToPageFixedDocumentSinglePageViewPresenterCommandDescriptor.IsEnabled+# [ $ TwoWay=� 5�      �� 5�      $.��(Ajustar página al tamaño de la ventana��6    .��5�      �� $
��None=�6�   ��6     $	 document-fit-page.png��#
 [  6�   5�      	  5�      
  5�      $��2q�6&   $
��Left=�5�   &   $��Stretch=�5�   &    .  $��0q�5�   &    5�   &   �� *FixedDocumentViewer.Mode+$ TwoWay=�# [  �� ConverterParameter$	 Pan�� 5�      �� 5�      $6��0Navegue por el documento con la herramienta mano��6    .��5�      �� $
��None=�6   ��6     $	 hand-free.png��#
 [  6   5�      
  5�      $��2q�6&   $
��Left=�5�   &   $��Stretch=�5�   &    .  $��0q�5   &    5�   &   �� *FixedDocumentViewer.Mode+$ TwoWay=�# [ $ TextSelection�� 5     �� 5     $"��Seleccione textos e imagenes��6    .��5     �� $
��None=�6�   ��6     $	 text-selection.png��#
 [  6�   5     5     +   %Telerik.Windows.Controls.RadPdfViewer  5  
   -   5          Name$ 	pdfViewer��5     $��1��5	      5
     �� $ 	pdfViewer��$ CommandDescriptors�5     5     