   M S B A M L   `   `   `  ����D  @GacetaSjf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:GacetaSjf.ConvertersGacetaSjf.Converters  5      9!clr-namespace:GacetaSjf.ControlesGacetaSjf.Controles  5      )    #GacetaSjf.Controles.VotoTradicional   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      8	Converter"clr-namespace:GacetaSjf.Converters     5      :CustomColumn!clr-namespace:GacetaSjf.Controles     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      k gTelerik.Windows.Documents.Core, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7|	 xTelerik.Windows.Controls.FixedDocumentViewersUI, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o
 kTelerik.Windows.Controls.GanttView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7l hTelerik.Windows.Scheduling.Core, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7z vTelerik.Windows.Controls.FixedDocumentViewers, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Utelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
       5      -   5        
�������  � 	Resources  5         CustomCellStyle �� 
TargetType4  .Telerik.Windows.Controls.GridView.GridViewCell �� Property �� Value,   &GacetaSjf.Converters.TipoVotoConverter  	votosConv��%p   &	        &	 I     �� 5   
   "  6(   .�5      ��  � ��$	 Top=�69   5        5   
   6&   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ BtnSecuencial��5      $	��180��5      $��	10,30,0,0q�5      $
��Left=�5      $	��Top=�5       $��Lectura Secuencial��5"      '  !Telerik.Windows.Controls.GroupBox  5$   
   $	��140��6   $��
10,90,10,0q�5%      $��Stretch=�5&      $	��Top=�5'      $��Búsqueda por registro��5(      .��5)      � .+�5*      �� $��	10,18,0,0q�6   $
��Left=�5+      $	��Top=�5,      $��Registro digital:��5-      �� 5.      -   5         ��Name$ TxtIus��5.      $	��140��5/      $��23��50      $��	10,45,0,0q�51      $
��Left=�52      $	��Top=�53      �� 54      -   5        $ BtnIncorpora��54      $��75��55      $��	75,73,0,0q�56      $
��Left=�57      $	��Top=�58      $��
Incorporar��5:      5<      5=      *  $Telerik.Windows.Controls.RadGridView  5@   
   -   5          Name$ GVotos��5@      $��1��5A      $��0,60,0,0q�5B      $��Stretch=�5C      $��Stretch=�5D      ;  5Telerik.Windows.Controls.GridView.GridViewDataControl   AutoGenerateColumns .  	   CanUserDeleteRows	 .  
   CanUserInsertRows
 .     RowIndicatorVisibility$ 	Collapsed=�5J         ShowGroupPanel .  *  $Telerik.Windows.Controls.DataControl   ItemsSource 5H      ��    Columns 5M      (   "GacetaSjf.Controles.MyColumnNumber  5N      -  'Telerik.Windows.Controls.GridViewColumn   Width?	  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$ 30	 6.     ColumnaNumerica   	CellStyle# [ 5O   .      Header$ #��5P   .   1
  +Telerik.Windows.Controls.GridViewDataColumn
  5Q      $	 230	 6-   # [  5R   -   6  0Telerik.Windows.Controls.GridViewBoundColumnBase   Header$ Asunto��5T   -      IsFilterable .     
IsReadOnly .    TextWrapping$
 Wrap=�5W   -      DataMemberBinding 5S   -   �� *Asunto+5W   -   
  5X      $ *	 6-   # [  5Y   -   $ Rubro / Tema��5[   -    .   . $
 Wrap=�5^   -    5Z   -   �� *Rubro+5^   -   
  5_      $	 .2*	 6-   # [  5`   -   $ Localización��5b   -    .   . $
 Wrap=�5e   -    5a   -   �� *LocAbr+5e   -   
  5f      $
 Auto	 6-   # [  5g   -   $ Registro digital��5i   -    .   .  5h   -   �� *Ius+5k   -   
  5l      $	 .2*	 6-   # [  5m   -   $ Emisor��5o   -    .  . $
 Wrap=�5r   -    5n   -   �� *Emisor+5r   -   
  5s      $	 .2*	 6-   # [  5t   -   $ Tipo de Voto��5w   -    .  . $
 Wrap=�5z   -    5u   -   �� *
TipoVoto+ �� 	Converter# [ 5z   -      RowStyle 5}      �� 5~      3  -Telerik.Windows.Controls.GridView.GridViewRow"  6   .�5      ��  � ��$ 50��6/   -   5        5�      5�      �� 5�   
   -   5         ��Name$ BtnPrint��5�      $��1��5�      $��45��5�      $��43��5�      $��	0,10,15,0q�5�      $��Right=�5�      $	��Top=�5�       � Cursor$
 Hand��5�      $2��,/GacetaSjf;component/Resources/printSave.png��5�      5�      5�      