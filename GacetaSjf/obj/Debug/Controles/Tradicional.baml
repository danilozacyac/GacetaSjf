   M S B A M L   `   `   `  ����D  @GacetaSjf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GacetaSjf.ControlesGacetaSjf.Controles  5      E AUIControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:UIControls;assembly=UIControls
UIControls 5      %    GacetaSjf.Controles.Tradicional   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :CustomColumn!clr-namespace:GacetaSjf.Controles     5      C
UIControls,clr-namespace:UIControls;assembly=UIControls     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      k gTelerik.Windows.Documents.Core, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p	 lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7|
 xTelerik.Windows.Controls.FixedDocumentViewersUI, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GanttView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7l hTelerik.Windows.Scheduling.Core, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7z vTelerik.Windows.Controls.FixedDocumentViewers, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Utelerik1http://schemas.telerik.com/2008/xaml/presentation    	 
        5      -   5        
�������.��5      �   � ColumnDefinitions  5   
   �� 5      $	��200 �6   �� 5      $��* �6   .+�5   
   '  !Telerik.Windows.Controls.GroupBox  $	��140��6   $��10,129,10,0q�5      $��Stretch=�5      $	��Top=�5      $��Búsqueda por registro��5      .��5      � .+�5      �� $��	10,18,0,0q�6   $
��Left=�5      $	��Top=�5      $��Registro digital:��5      �� 5      -   5         ��Name$ TxtIus��5      $	��140��5      $��23��5      $��	10,45,0,0q�5       $
��Left=�5!      $	��Top=�5"      �� 5#      -   5         ��Name$ BtnIncorpora��5#      $��75��5$      $��	75,73,0,0q�5%      $
��Left=�5&      $	��Top=�5'      $��
Incorporar��5)      5+      5,      �� 5-   
   -   5        $ BtnSecuencial��5-      $	��180��5.      $��	10,30,0,0q�5/      $
��Left=�50      $	��Top=�51      $��Lectura Secuencial��53      �� 54   
   -   5        $ BtnBusqueda��54      $	��180��55      $��	10,72,0,0q�56      $
��Left=�57      $	��Top=�58      $��Búsqueda por palabra��5:      � 5=   
   $��1��6    � RowDefinitions 5>      �� 5?      $	��100 �6    �� 5@      $��* �6    .+�5B      *  $Telerik.Windows.Controls.RadComboBox  -   5          Name$ 
CbxVolumen��5B   "   $	��198��5C   "   $��
130,30,0,0q�5D   "   $
��Left=�5E   "   $	��Top=�5F   "    �� DisplayMemberPath$
 Tomo��5G   "    �� SelectedValuePath$ Volumen��5I   "   ��5H   "   �� 5J   "   �� 5K      $��	10,10,0,0q�6   $
��Left=�5L      $	��Top=�5M      $��Filtrar por:��5N      $
��Bold"�5O      �� 5P      $��25��6   $��
10,30,0,45q�5Q      $
��Left=�5R      $��Mes de publicación:��5S      �� 5T      $��
398,30,0,0q�6   $
��Left=�5U      $	��Top=�5V      $��
Instancia:��5W        5X      -   5        $ CbxInstancia��5X   "   $	��210��5Y   "   $��
462,30,0,0q�5Z   "   $
��Left=�5[   "   $	��Top=�5\   "   $ Descripcion��5]   "   $ 
IdElemento��5_   "   ��5^   "   �� 5`   "   �� 5a      $��	10,64,0,0q�6   $
��Left=�5b      $	��Top=�5c      $��
Buscar en:��5d      $
��Bold"�5e        UIControls.SearchTextBox  5f      -   5        $	��327��5f   '   $��
130,64,0,0q�5g   '   $
��Left=�5h   '   $	��Top=�5i   '      	LabelText$3 -Rubro, texto, precedentes o clave de tesis...��5j   '   5k   '   �� 5l      -	   5         ��Name$ BtnPrint��5l      $��45��5m      $��43��5n      $��	0,0,15,10q�5o      $��Right=�5p      $��Bottom=�5q      	 � Cursor$
	 Hand��5r      $2��,/GacetaSjf;component/Resources/printSave.png��5t      *  $Telerik.Windows.Controls.RadGridView  5v      -
   5        
  Name$
 GTesis��5v   "   $��1��5w   "   $��Stretch=�5x   "   $��Stretch=�5y   "   ;  5Telerik.Windows.Controls.GridView.GridViewDataControl   AutoGenerateColumns .     CanUserDeleteRows .     CanUserInsertRows .     RowIndicatorVisibility$ 	Collapsed=�5~   "      ShowGroupPanel .  *  $Telerik.Windows.Controls.DataControl   ItemsSource 5}   "   ��    Columns 5�      (   "GacetaSjf.Controles.MyColumnNumber  5�      -  'Telerik.Windows.Controls.GridViewColumn   Width?	  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$ 30	 62      ColumnaNumerica   	CellStyle# [  5�   2      Header$ #��5�   2   1
  +Telerik.Windows.Controls.GridViewDataColumn
  5�      $	 100	 61   6  0Telerik.Windows.Controls.GridViewBoundColumnBase   Header$ Clave de Tesis��5�   1      IsFilterable .     
IsReadOnly .    TextWrapping$
 Wrap=�5�   1      DataMemberBinding 5�   1   �� *Tesis+5�   1   
  5�      $ *	 61   $  Rubro (Título/Subtítulo)��5�   1    .   . $
 Wrap=�5�   1    5�   1   �� *Rubro+5�   1   
  5�      $
 .25*	 61   $ Localización��5�   1    .   . $
 Wrap=�5�   1    5�   1   �� *LocAbr+5�   1   
  5�      $
 Auto	 61   $ Registro digital��5�   1    .   .  5�   1   �� *Ius+5�   1      RowStyle 5�      �� 5�       �� 
TargetType3  -Telerik.Windows.Controls.GridView.GridViewRow"  6   .�5�      -   5        5�      5�      5�      5�      5�      