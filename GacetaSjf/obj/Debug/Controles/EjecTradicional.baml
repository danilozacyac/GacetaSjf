   M S B A M L   `   `   `  ����D  @GacetaSjf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GacetaSjf.ControlesGacetaSjf.Controles  5      E AUIControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:UIControls;assembly=UIControls
UIControls 5      )    #GacetaSjf.Controles.EjecTradicional   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :CustomColumn!clr-namespace:GacetaSjf.Controles     5      C
UIControls,clr-namespace:UIControls;assembly=UIControls     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      k gTelerik.Windows.Documents.Core, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p	 lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7|
 xTelerik.Windows.Controls.FixedDocumentViewersUI, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GanttView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7l hTelerik.Windows.Scheduling.Core, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7z vTelerik.Windows.Controls.FixedDocumentViewers, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Utelerik1http://schemas.telerik.com/2008/xaml/presentation    	 
        5      -   5        
�������  � 	Resources  5         CustomCellStyle �� 
TargetType4  .Telerik.Windows.Controls.GridView.GridViewCell �� Property �� Value��%S   &	        �� 5   
   "  6(   .�5      ��  � ��$	 Top=�69   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ BtnSecuencial��5      $	��180��5      $��	10,30,0,0q�5      $
��Left=�5      $	��Top=�5      $��Lectura Secuencial��5      '  !Telerik.Windows.Controls.GroupBox  5!   
   $	��140��6   $��
10,90,10,0q�5"      $��Stretch=�5#      $	��Top=�5$      $��Búsqueda por registro��5%      .��5&      � .+�5'      �� $��	10,18,0,0q�6   $
��Left=�5(      $	��Top=�5)      $��Registro digital:��5*      �� 5+      -   5         ��Name$ TxtIus��5+      $	��140��5,      $��23��5-      $��	10,45,0,0q�5.      $
��Left=�5/      $	��Top=�50      �� 51      -   5        $ BtnIncorpora��51      $��75��52      $��	75,73,0,0q�53      $
��Left=�54      $	��Top=�55      $��
Incorporar��57      59      5:      *  $Telerik.Windows.Controls.RadGridView  5=   
   -   5          Name$ GEjecutoria��5=      $��1��5>      $��0,60,0,0q�5?      $��Stretch=�5@      $��Stretch=�5A      ;  5Telerik.Windows.Controls.GridView.GridViewDataControl   AutoGenerateColumns .  	   CanUserDeleteRows	 .  
   CanUserInsertRows
 .     	RowHeight$ 80Q�5F         RowIndicatorVisibility$ 	Collapsed=�5G         ShowGroupPanel .  *  $Telerik.Windows.Controls.DataControl   ItemsSource 5E      ��    Columns 5J      (   "GacetaSjf.Controles.MyColumnNumber  5K      -  'Telerik.Windows.Controls.GridViewColumn   Width?  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$ 30 6.     ColumnaNumerica   	CellStyle# [ 5L   .      Header$ #��5M   .   1	  +Telerik.Windows.Controls.GridViewDataColumn	  5N      $	 130 6-   # [  5O   -   6
  0Telerik.Windows.Controls.GridViewBoundColumnBase 
  Header$ Asunto��5Q   -      IsFilterable .     
IsReadOnly .    TextWrapping$
 Wrap=�5T   -    
  DataMemberBinding 5P   -   �� *Asunto+5T   -   	  5U      $ * 6-   # [  5V   -   $ Rubro / Tema��5X   -    .   . $
 Wrap=�5[   -    5W   -   �� *Rubro+5[   -   	  5\      $	 .2* 6-   # [  5]   -   $ Localización��5_   -    .   . $
 Wrap=�5b   -    5^   -   �� *LocAbr+5b   -   	  5c      $
 Auto 6-   # [  5d   -   $ Registro digital��5f   -    .   .  5e   -   �� *Ius+5h   -   	  5i      $	 .2* 6-   # [  5j   -   $ 
Promovente��5l   -    .   . $
 Wrap=�5o   -    5k   -   �� *
Promovente+5o   -      RowStyle 5q      �� 5r      3  -Telerik.Windows.Controls.GridView.GridViewRow"  6   .�5s      ��  � ��$ 50��6/   -   5        5u      5w      �� 5x   
   -   5         ��Name$ BtnPrint��5x      $��1��5y      $��45��5z      $��43��5{      $��	0,10,15,0q�5|      $��Right=�5}      $	��Top=�5~       � Cursor$
 Hand��5      $2��,/GacetaSjf;component/Resources/printSave.png��5�        UIControls.SearchTextBox  5�   
   -   5        $��1��5�   #   $	��300��5�   #   $��	10,14,0,0q�5�   #   $
��Left=�5�   #   $	��Top=�5�   #      	LabelText$4 .Buscar por rubro, tema, asunto o promovente...��5�   #   5�   #   5�      5�      