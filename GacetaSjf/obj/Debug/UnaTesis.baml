   M S B A M L   `   `   `  ����D  @GacetaSjf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:GacetaSjf.ConvertersGacetaSjf.Converters  5   	   U QICP.Controls.Document.Find, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullaGclr-namespace:ICP.Controls.Document;assembly=ICP.Controls.Document.FindICP.Controls.Document 5   	       GacetaSjf.UnaTesis   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   8	converter"clr-namespace:GacetaSjf.Converters     5   	   WicpGclr-namespace:ICP.Controls.Document;assembly=ICP.Controls.Document.Find     5   	   k gTelerik.Windows.Documents.Core, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p	 lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7|
 xTelerik.Windows.Controls.FixedDocumentViewersUI, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GanttView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7l hTelerik.Windows.Scheduling.Core, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7z vTelerik.Windows.Controls.FixedDocumentViewers, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Utelerik1http://schemas.telerik.com/2008/xaml/presentation    	 
        5   	   -   5          � Title$  UnaTesis��5   	   $
��1200��5   	   $	��900��5	   	    � Icon$ Resources/GACETA-2.ico��5
   	    � 	Resources 5      )   #GacetaSjf.Converters.EpocaConverter   	epocaConv+   %GacetaSjf.Converters.VolumenConverter  	volumConv+   %GacetaSjf.Converters.MateriaConverter  materiaConv-  'GacetaSjf.Converters.Instanciaconverter  
instanConv*  $GacetaSjf.Converters.FuenteConverter  
fuenteConv��%�   &	        &	      &	 &     &	 9     &	 L       5   
   6#     5   
   6%     5   
   6%     5   
   6'     5   
   6$   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��35 �6   .+�5   
   , 	 &Telerik.Windows.Controls.RadRibbonView  -   5          Name$ 
MainRibbon��5       $��0��5       "   ApplicationButtonVisibility$ 	Collapsed=�5          ApplicationName$  ��5          WindowIconVisibility$ Visible=�5       .@�5      + 	 %Telerik.Windows.Controls.RadRibbonTab  .@�5       - 	 'Telerik.Windows.Controls.RadRibbonGroup  -   5        $��Navega��5    )   $��Navegar��67   .@�5!      ��  �� Orientation$ 
Horizontal=�6!   .+�5"      .	 	 (Telerik.Windows.Controls.RadRibbonButton	  -   5        $��
RbtnInicio��5"   2   $��Inicio��5$   2   	 	  
LargeImage$	 Resources/first.png��5%   2   
 	  Size$
 Large=�5&   2   	  5'      -   5        $��RbtnPrevious��5'   2   $��Anterior��5)   2   $	 Resources/back.png��5*   2   $
 Large=�5+   2   	  5,      -   5        $��RbtnNext��5,   2   $��	Siguiente��5.   2   $	 Resources/next.png��5/   2   $
 Large=�50   2   	  51      -   5        $��RbtnFin��51   2   $��Final��53   2   $	 Resources/last.png��54   2   $
 Large=�55   2   �� 56      $ Vertical=�6%   .+�57      �� $��      Registro:   ��6$   $��14(�58   $   $
��Bold"�59   $   �� 5:      -   5         ��Name$ LblContador��5:   $   $��      Registro:   ��5;   $   $��14(�5<   $   $
��Bold"�5=   $   5>      5?      5A        5B      -	   5        $��DocsRel��5B   )   $��Documentos Relacionados��68   .@�5C      	  -
   5        $��RBtnEjecutoria��5C   .   $��Ver Ejecutoria��5E   .   $	 Resources/ejecutoria.png��5F   .   $
 Large=�5G   .   	  5H      -   5        $��RBtnVerVoto��5H   .   $��Ver Voto(s)��5I   .   $	 Resources/juez.png��5J   .   $
 Large=�5K   .   	  5L      -   5        $��RBtnPdf��5L   .   $��Ver PDF��5N   .   $	 Resources/pdf_256.png��5O   .   $
 Large=�5P   .    	  
SmallImage$ Resources/pdf_128.png��5Q   .   5R        5S      $��Exportar��6)   .@�5T      �� $ 
Horizontal=�6!   .+�5U      	  -   5        $��RbtnClipboard��5U   2   $��Portapapeles��5W   2   $	 Resources/clipboard.png��5X   2   $
 Large=�5Y   2   	  5[      -   5        $��RBtnWord��5[   2   $
��Word��5]   2   $	 Resources/word_256.png��5^   2   $
 Large=�5_   2   $ Resources/word_128.png��5`   2   5a      5b      5c      5d      � 5f   
   $��1��6    � ColumnDefinitions 5g      �� 5h      $	��300 �6#   �� 5i      $��3* �6#   .+�5l      � $��0��6   .+�5m      �� $��Stretch=�6   $��Stretch=�6;   .@�5n      �� $��Datos Generales��6   .��5o      � ���	#FFE5E5E5.+�5p      �� $��	10,10,0,0q�6$   $
��Left=�5q   $   $	��Top=�5r   $   $��Reg. Digital��5s   $   �� 5t      $��
10,105,0,0q�6$   $
��Left=�5u   $   $	��Top=�5v   $   $��Epoca de publicación:��5w   $   �� 5x      $��
10,144,0,0q�6$   $
��Left=�5y   $   $	��Top=�5z   $   $��Época de la tesis:��5{   $   �� 5|      $��	11,41,0,0q�6$   $
��Left=�5}   $   $	��Top=�5~   $   $)��#Clave o número de identificación:��5   $   �� 5�      $��50��6'   $��21,357,35,0q�5�   '   $��Stretch=�5�   '   $	��Top=�5�   '   $��Tipo de Tesis��5�   '   {�5�   '   �� *
IsEnable+ �� Mode$ TwoWay=�.��5�   "   � .+�5�   &   	� -   5         	�Name$ 	RbtJurisp��5�   2   $	��100��5�   2   $��28��5�   2   $��0,7,0,-7q�5�   2   $
��Left=�5�   2   $	��Top=�5�   2   $�� Jurisprudencia��5�   2   {�.  5�   2   	� 5�   &   -   5        $ 
RbtAislada��5�   2   $��80��5�   2   $��28��5�   2   $��
117,7,0,-7q�5�   2   $
��Left=�5�   2   $	��Top=�5�   2   $�� T. Aislada��5�   2   {�.  5�   2   5�   #   5�      �� 5�      $	��180��6'   $��10,423,35,0q�5�   '   $��Stretch=�5�   '   $	��Top=�5�   '   $��Materias��5�   '   .��5�   "   � .+�5�   &   �� -   5         ��Name$ TxtMat1��5�   .   $	��200��5�   .   $��25��5�   .   $��
15,25,15,0q�5�   .   $
��Left=�5�   .   $	��Top=�5�   .    �� 
IsReadOnly . ��5�   .   �� *
Materia1+ �� 	Converter# [ �� 5�   &   -   5        $ TxtMat2��5�   .   $	��200��5�   .   $��25��5�   .   $��
15,75,15,0q�5�   .   $
��Left=�5�   .   $	��Top=�5�   .    . ��5�   .   �� *
Materia2+# [ �� 5�   &   -   5        $ TxtMat3��5�   .   $	��200��5�   .   $��25��5�   .   $��15,125,15,0q�5�   .   $
��Left=�5�   .   $	��Top=�5�   .    . ��5�   .   �� *
Materia3+# [ 5�   #   5�      �� 5�      -   5        $ TxtIus��5�   &   $	��120��5�   &   $��23��5�   &   $��
148,13,0,0q�5�   &   $
��Left=�5�   &   $	��Top=�5�   &    .  �� TextWrapping$
 Wrap=�5�   &   ��5�   &   �� *Ius+5�   &   �� 5�      -   5        $ TxtEpoca��5�   &   $	��120��5�   &   $��23��5�   &   $��148,144,0,0q�5�   &   $
��Left=�5�   &   $	��Top=�5�   &    . $
 Wrap=�5�   &   ��5�   &   �� *
EpocaInt+# [  5�   &   �� 5�      -   5        $ TxtEpocaPublica��5�   &   $	��120��5�   &   $��23��5�   &   $��148,108,0,0q�5�   &   $
��Left=�5�   &   $	��Top=�5�   &    . $��Décima Época��5�   &   $ NoWrap=�5�   &   �� 5�      -   5        $ TxtTesis��5�   &   $	��120��5�   &   $��23��5�   &   $��
148,67,0,0q�5�   &   $
��Left=�5�   &   $	��Top=�5�   &    . $
 Wrap=�5�   &   ��5�   &   �� *Tesis+5�   &   �� 5�      -   5        $ TxtSemanario��5�   &   $	��257��5�   &   $��75��5�   &   $��
11,191,0,0q�5�   &   $
��Left=�5�   &   $	��Top=�5�   &   $
 Wrap=�5�   &   �� 5�      -   5        $ 	TxtGaceta��5�   &   $	��257��5�   &   $��75��5�   &   $��
11,275,0,0q�5�   &   $
��Left=�5�   &   $	��Top=�5�   &   $
 Wrap=�5�   &   5�      5�      �� 5�      $��Otros Textos��6   .��5�      � ���	#FFE5E5E5.+�5�      �� $��	10,10,0,0q�6$   $
��Left=�5�   $   $	��Top=�5�   $   $��Genealogía:��5�   $   �� 5�      -   5        $ TxtGenealogia��5�   &   $	��270��5�   &   $	��151��5�   &   $��	10,36,0,0q�5�   &   $
��Left=�5�   &   $	��Top=�5�   &    �� AcceptsReturn . $ WrapWithOverflow=�5  &   " �� VerticalScrollBarVisibility$
 Auto=�5  &    5   &   �� *
IsReadOnly+$ TwoWay=���5  &   �� *
Genealogia+$ TwoWay=�5  &   �� 5     $��
10,208,0,0q�6$   $
��Left=�5  $   $	��Top=�5  $   $��Observaciones:��5	  $   �� 5
     -   5        $ TxtObservaciones��5
  &   $	��270��5  &   $	��146��5  &   $��
10,234,0,0q�5  &   $
��Left=�5  &   $	��Top=�5  &    . $ WrapWithOverflow=�5  &   $
 Auto=�5  &    5  &   �� *
IsReadOnly+$ TwoWay=���5  &   �� *Observaciones+$ TwoWay=�5  &   �� 5     $��
10,403,0,0q�6$   $
��Left=�5  $   $	��Top=�5  $   $��Concordancia:��5  $   �� 5     -   5        $ TxtConcordancia��5  &   $	��270��5  &   $	��166��5  &   $��
10,428,0,0q�5  &   $
��Left=�5  &   $	��Top=�5   &    . $ WrapWithOverflow=�5&  &   $
 Auto=�5'  &    5"  &   �� *
IsReadOnly+$ TwoWay=���5$  &   �� *Concordancia+$ TwoWay=�5'  &   5(     5)     5+     5-     � 5/     $��1��6   .+�51     ,� -   5         ,�Name$ flowDocViewer��51  +   $��0,0,0,40q�52  +   ���	#FF414141 ,� Zoom$	 130Q�54  +   .��55     /� -   5         /�Name$ flowDoc��55  #    /� 
FontFamily$ Arial)�56  #    /� 
FontWeight$ Normal"�57  #    /� 
Foreground
 �   �58  #   59     '
  !ICP.Controls.Document.FindControl
  5;     $��0��6"   $	��350��5<  "   $��25��5=  "   $
��Left=�5>  "   $��Bottom=�5?  "    
  BackgroundText$ Buscar palabra...��5@  "    
  BackgroundTextBrush
 �����$��1q�5B  "     
  HighlightedParagraphBrush
 ��·� 
  HighlightedTextBrush
 �  ��)  
  "NextPreviousButtonsForegroundBrush
  ��  �! 
  TextBoxBackgroundBrush
! �����" 
  Document" 5C  "   �� # �� ElementName$# flowDocViewer��$ �� Path$$ Document�5H  "   5J     5N     �� 5O  
   $��2��6   5R     5T     