   M S B A M L   `   `   `  ����D  @GacetaSjf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:GacetaSjf.ConvertersGacetaSjf.Converters  5   	   U QICP.Controls.Document.Find, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullaGclr-namespace:ICP.Controls.Document;assembly=ICP.Controls.Document.FindICP.Controls.Document 5   	       GacetaSjf.DetalleDoctos   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   8	converter"clr-namespace:GacetaSjf.Converters     5   	   WicpGclr-namespace:ICP.Controls.Document;assembly=ICP.Controls.Document.Find     5   	   k gTelerik.Windows.Documents.Core, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p	 lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7|
 xTelerik.Windows.Controls.FixedDocumentViewersUI, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GanttView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7l hTelerik.Windows.Scheduling.Core, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7z vTelerik.Windows.Controls.FixedDocumentViewers, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Utelerik1http://schemas.telerik.com/2008/xaml/presentation    	 
        5   	   -   5          � Title$  UnaTesis��5   	   $
��1200��5   	   $	��900��5	   	    � Icon$ Resources/GACETA-2.ico��5
   	    � 	Resources 5      )   #GacetaSjf.Converters.EpocaConverter   	epocaConv+   %GacetaSjf.Converters.VolumenConverter  	volumConv-  'GacetaSjf.Converters.Instanciaconverter  
instanConv*  $GacetaSjf.Converters.FuenteConverter  
fuenteConv��%t   &	        &	      &	 &     &	 9       5   
   6#     5   
   6%     5   
   6'     5   
   6$   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��35 �6   .+�5   
   , 	 &Telerik.Windows.Controls.RadRibbonView  $��0��6    "   ApplicationButtonVisibility$ 	Collapsed=�5          ApplicationName$  ��5          WindowIconVisibility$ Visible=�5       .@�5      + 	 %Telerik.Windows.Controls.RadRibbonTab  .@�5      - 	 'Telerik.Windows.Controls.RadRibbonGroup  -   5        $��Navega��5   )   $��Navegar��67   .@�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5       . 	 (Telerik.Windows.Controls.RadRibbonButton  -   5        $��
RbtnInicio��5    2   $��Inicio��5"   2      
LargeImage$ Resources/first.png��5#   2   	   Size$	 Large=�5$   2     5%      -   5        $��RbtnPrevious��5%   2   $��Anterior��5'   2   $ Resources/back.png��5(   2   $	 Large=�5)   2     5*      -   5        $��RbtnNext��5*   2   $��	Siguiente��5,   2   $ Resources/next.png��5-   2   $	 Large=�5.   2     5/      -   5        $��RbtnFin��5/   2   $��Final��51   2   $ Resources/last.png��52   2   $	 Large=�53   2   �� 54      $ Vertical=�6%   .+�55      �� $��      Registro:   ��6$   $��14(�56   $   $
��Bold"�57   $   �� 58      -   5        
 ��Name$
 LblContador��58   $   $��      Registro:   ��59   $   $��14(�5:   $   $
��Bold"�5;   $   5<      5=      5?        5@      -   5        $��DocsRel��5@   )   $��Documentos Relacionados��68   .@�5A        -	   5        $��RBtnEjecutoria��5A   .   $��Ver Ejecutoria��5B   .   $ Resources/ejecutoria.png��5C   .   $	 Large=�5D   .     5E      -
   5        $��	RBtnVotos��5E   .   $��Ver Voto(s)��5F   .   $ Resources/ejecutoria.png��5G   .   $	 Large=�5H   .   5I        5J      $��Exportar��6)   .@�5K      �� $ 
Horizontal=�6!   .+�5L        -   5        $��RbtnClipboard��5L   2   $��Portapapeles��5M   2   $ Resources/clipboard.png��5N   2   $	 Large=�5O   2     5P      -   5        $��RBtnPdf��5P   2   $	��PDF��5Q   2   $ Resources/pdf_256.png��5R   2   $	 Large=�5S   2      
SmallImage$ Resources/pdf_128.png��5T   2     5U      -   5        $��RBtnWord��5U   2   $
��Word��5V   2   $ Resources/word_256.png��5W   2   $	 Large=�5X   2   $ Resources/word_128.png��5Y   2   5Z      5[      5\      5]      � 5_   
   $��1��6    � ColumnDefinitions 5`      �� 5a      $	��300 �6#   �� 5b      $��3* �6#   .+�5e      � $��0��6   .+�5f      �� $��Stretch=�6   $��Stretch=�6;   .@�5g      �� $��Datos Generales��6   .��5h      � ���	#FFE5E5E5.+�5i      �� $��	10,10,0,0q�6$   $
��Left=�5j   $   $	��Top=�5k   $   $��Reg. Digital��5l   $   �� 5m      $��	10,46,0,0q�6$   $
��Left=�5n   $   $	��Top=�5o   $   $��Epoca:��5p   $   �� 5q      $��	10,85,0,0q�6$   $
��Left=�5r   $   $	��Top=�5s   $   $��Volumen:��5t   $   �� 5u      $��
11,127,0,0q�6$   $
��Left=�5v   $   $	��Top=�5w   $   $��Página:��5x   $   �� 5y      $��
11,168,0,0q�6$   $
��Left=�5z   $   $	��Top=�5{   $   $��
Instancia:��5|   $   �� 5}      -   5         ��Name$ TxtInstancia��5}   &   $	��245��5~   &   $��
11,195,0,0q�5   &   $
��Left=�5�   &   $	��Top=�5�   &    �� 
IsReadOnly . ��5�   &   �� *Sala+ �� 	Converter# [ �� 5�      $��
11,221,0,0q�6$   $
��Left=�5�   $   $	��Top=�5�   $   $��Fuente:��5�   $   �� 5�      -   5        $ 	CbxFuente��5�   &   $	��245��5�   &   $��
11,249,0,0q�5�   &   $
��Left=�5�   &   $	��Top=�5�   &    .  ��5�   &   �� *Fuente+# [ �� 5�      -   5        $ TxtIus��5�   &   $	��120��5�   &   $��23��5�   &   $��	93,10,0,0q�5�   &   $
��Left=�5�   &   $	��Top=�5�   &    .  �� TextWrapping$
 Wrap=�5�   &   ��5�   &   �� *Ius+5�   &   �� 5�      -   5        $ TxtEpoca��5�   &   $	��120��5�   &   $��23��5�   &   $��	93,46,0,0q�5�   &   $
��Left=�5�   &   $	��Top=�5�   &    . $
 Wrap=�5�   &   ��5�   &   �� *Epoca+# [  5�   &   �� 5�      -   5        $ 
TxtVolumen��5�   &   $	��175��5�   &   $��23��5�   &   $��	93,88,0,0q�5�   &   $
��Left=�5�   &   $	��Top=�5�   &    . $ NoWrap=�5�   &   ��5�   &   �� *	Volumen+# [ 5�   &   �� 5�      -   5        $ TxtPag��5�   &   $��79��5�   &   $��23��5�   &   $��
93,127,0,0q�5�   &   $
��Left=�5�   &   $	��Top=�5�   &    . $
 Wrap=�5�   &   ��5�   &   �� *Pagina+5�   &   �� 5�      -   5        $
 	LblAnexos��5�   $   $��
11,300,0,0q�5�   $   $
��Left=�5�   $   $	��Top=�5�   $   $��Anexos:��5�   $   �� 5�      -   5         ��Name$ 	LstAnexos��5�   &   $	��245��5�   &   $	��325��5�   &   $��
11,326,0,0q�5�   &   $
��Left=�5�   &   $	��Top=�5�   &    �� DisplayMemberPath$ Frase��5�   &   ��5�   &   �� 5�   &   5�      5�      �� 5�      $��Otros Textos��6   .��5�      � ���	#FFE5E5E5.+�5�      �� $��	10,10,0,0q�6$   $
��Left=�5�   $   $	��Top=�5�   $   $��Genealogía:��5�   $   �� 5�      -   5        $ TxtGenealogia��5�   &   $	��270��5�   &   $	��151��5�   &   $��	10,36,0,0q�5�   &   $
��Left=�5�   &   $	��Top=�5�   &    �� AcceptsReturn . $ WrapWithOverflow=�5�   &   " �� VerticalScrollBarVisibility$
 Auto=�5�   &    5�   &   �� *
IsReadOnly+ �� Mode$ TwoWay=���5�   &   �� *
Genealogia+$ TwoWay=�5�   &   �� 5�      $��
10,208,0,0q�6$   $
��Left=�5�   $   $	��Top=�5�   $   $��Observaciones:��5�   $   �� 5�      -   5        $ TxtObservaciones��5�   &   $	��270��5�   &   $	��146��5�   &   $��
10,234,0,0q�5�   &   $
��Left=�5�   &   $	��Top=�5�   &    . $ WrapWithOverflow=�5�   &   $
 Auto=�5�   &    5�   &   �� *
IsReadOnly+$ TwoWay=���5�   &   �� *Observaciones+$ TwoWay=�5�   &   �� 5�      $��
10,403,0,0q�6$   $
��Left=�5�   $   $	��Top=�5�   $   $��Concordancia:��5�   $   �� 5�      -   5        $ TxtConcordancia��5�   &   $	��270��5�   &   $	��166��5�   &   $��
10,428,0,0q�5�   &   $
��Left=�5�   &   $	��Top=�5�   &    . $ WrapWithOverflow=�5�   &   $
 Auto=�5�   &    5�   &   �� *
IsReadOnly+$ TwoWay=���5�   &   �� *Concordancia+$ TwoWay=�5�   &   5�      5�      5      5     � 5     $��1��6   .+�5     ,� -   5         ,�Name$ flowDocViewer��5  +   $��0,0,0,40q�5  +   ���	#FF414141 ,� Zoom$	 130Q�5  +   .��5     /� -   5         /�Name$ flowDoc��5  #    /� 
FontFamily$ Arial)�5  #    /� 
FontWeight$ Normal"�5  #    /� 
Foreground
 �   �5  #   5     '	  !ICP.Controls.Document.FindControl	  5     $��0��6"   $	��350��5  "   $��25��5  "   $
��Left=�5  "   $��Bottom=�5  "    	  BackgroundText$ Buscar palabra...��5  "    	  BackgroundTextBrush
 �����$��1q�5   "     	  HighlightedParagraphBrush
 ��·� 	  HighlightedTextBrush
 �  ��)  	  "NextPreviousButtonsForegroundBrush
  ��  �! 	  TextBoxBackgroundBrush
! �����" 	  Document" 5!  "   �� # �� ElementName$# flowDocViewer��$ �� Path$$ Document�5&  "   5'     5+     �� 5,  
   $��2��6   5/     51     