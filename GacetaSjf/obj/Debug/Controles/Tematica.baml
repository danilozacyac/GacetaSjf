   M S B A M L   `   `   `  ����D  @GacetaSjf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GacetaSjf.ControlesGacetaSjf.Controles  5      E AUIControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:UIControls;assembly=UIControls
UIControls 5      "    GacetaSjf.Controles.Tematica   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :CustomColumn!clr-namespace:GacetaSjf.Controles     5      C
UIControls,clr-namespace:UIControls;assembly=UIControls     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      k gTelerik.Windows.Documents.Core, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p	 lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7|
 xTelerik.Windows.Controls.FixedDocumentViewersUI, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GanttView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7l hTelerik.Windows.Scheduling.Core, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7z vTelerik.Windows.Controls.FixedDocumentViewers, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Utelerik1http://schemas.telerik.com/2008/xaml/presentation    	 
        5      -   5        
�������.��5      �   � ColumnDefinitions  5   
   �� 5      $	��.4* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   )  #Telerik.Windows.Controls.RadListBox  -   5          Name$ LstTematico��5      $��0,30,0,0q�5      $��Stretch=�5      $��Stretch=�5       �� DisplayMemberPath$
 Tema��5      >  8Telerik.Windows.Controls.Primitives.ItemsControlSelector   SelectedValuePath$ IdTema��5      ��5      �� 5        UIControls.SearchTextBox  5    
   -   5        $��	10,5,30,0q�5    #   $��Stretch=�5!   #   $	��Top=�5"   #      	LabelText$ Buscar Tema...��5#   #   5$   #   *  $Telerik.Windows.Controls.RadGridView  5%   
   -   5          Name$ GTesis��5%      $��1��5&      $��
10,30,10,0q�5'      $��Stretch=�5(      $��Stretch=�5)      ;  5Telerik.Windows.Controls.GridView.GridViewDataControl   AutoGenerateColumns .     CanUserDeleteRows .  	   CanUserInsertRows	 .  
   RowIndicatorVisibility$
 	Collapsed=�5.         ShowGroupPanel .  *  $Telerik.Windows.Controls.DataControl   ItemsSource 5-      ��    Columns 51      (   "GacetaSjf.Controles.MyColumnNumber  52      -  'Telerik.Windows.Controls.GridViewColumn   Width?	  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$ 30	 6.      ColumnaNumerica   	CellStyle# [  53   .      Header$ #��54   .   1
  +Telerik.Windows.Controls.GridViewDataColumn
  55      $	 100	 6-   6  0Telerik.Windows.Controls.GridViewBoundColumnBase   Header$ Clave de Tesis��57   -      IsFilterable .     
IsReadOnly .    TextWrapping$
 Wrap=�5:   -      DataMemberBinding 56   -   �� *Tesis+5:   -   
  5;      $ *	 6-   $ Rubro��5=   -    .   . $
 Wrap=�5@   -    5<   -   �� *Rubro+5@   -   
  5A      $	 .2*	 6-   $ Localización��5C   -    .   . $
 Wrap=�5F   -    5B   -   �� *LocAbr+5F   -   
  5G      $
 Auto	 6-   $ Registro digital��5I   -    .   .  5H   -   �� *Ius+5K   -      RowStyle 5M      �� 5N       �� 
TargetType3  -Telerik.Windows.Controls.GridView.GridViewRow"  6   .�5O      -   5        5P      5R        5S   
   -   5          Name$ SearchTesis��5S   #   $��1��5T   #   $	��250��5U   #   $��10,5,0,0q�5V   #   $
��Left=�5W   #   $	��Top=�5X   #   $* $Buscar por rubro o clave de tesis...��5Y   #   5Z   #   5[      5\      