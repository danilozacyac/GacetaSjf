   M S B A M L   `   `   `  ����  	GacetaSjf    GacetaSjf.Busqueda   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   k gTelerik.Windows.Documents.Core, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7|	 xTelerik.Windows.Controls.FixedDocumentViewersUI, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o
 kTelerik.Windows.Controls.GanttView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7l hTelerik.Windows.Scheduling.Core, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7z vTelerik.Windows.Controls.FixedDocumentViewers, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Utelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
       5   	     � Title$  Búsqueda por palabra��5   	   $	��500��5   	   $	��400��5   	   .��5      �  � RowDefinitions 5	   
   �� 5
      $��80 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   �� $��	10,10,0,0q�6   $
��Left=�5      $	��Top=�5      $��Expresión de consulta:��5      $
��Bold"�5      �� 5   
   -   5         ��Name$ TxtConsulta��5      $��23��5      $��
10,41,20,0q�5      $��Stretch=�5      $	��Top=�5      �� 5   
   $��1��6   $	��318��5      $	��100��5      $��	10,10,0,0q�5      $
��Left=�5      $	��Top=�5      $��
Buscar en:��5      .��5       � .+�5!      �� -   5         ��Name$ ChkLocalizacion��5!      $��	20,10,0,0q�5"      $
��Left=�5#      $	��Top=�5$      $�� Localizacion��5%      �� 5&      -   5        $ ChkRubro��5&      $��
148,10,0,0q�5'      $
��Left=�5(      $	��Top=�5)      $ ��Rubro (Título/Subtítulo)��5*      �� 5+      -   5        $ ChkTexto��5+      $��	20,52,0,0q�5,      $
��Left=�5-      $	��Top=�5.      $�� Texto��5/      �� 50      -   5        $ ChkPrecedente��50      $��
148,52,0,0q�51      $
��Left=�52      $	��Top=�53      $�� Precedentes��54      56      57      �� 58   
   -   5         ��Name$ BtnConsulta��58      $��1��59      $	��122��5:      $��
350,10,0,0q�5;      $
��Left=�5<      $	��Top=�5=      $��Incorporar a consulta��5>      �� 5?   
   -   5        $ BtnAlmacenadas��5?      $��1��5@      $	��122��5A      $��
350,47,0,0q�5B      $
��Left=�5C      $	��Top=�5D      $��Ver consultas almacenadas��5E      �� 5F   
   -   5        $ BtnAlmacenar��5F      $��1��5G      $	��122��5H      $��
350,88,0,0q�5I      $
��Left=�5J      $	��Top=�5K      $��Almacenar consulta��5L      *  $Telerik.Windows.Controls.RadGridView  5M   
   $��2��6   $	��318��5N      $��10q�5O      $
��Left=�5P      $��Stretch=�5Q      ;  5Telerik.Windows.Controls.GridView.GridViewDataControl   ShowGroupPanel .  5R      �� 5S   
   -	   5        $ BtnEliminar��5S      $��2��5T      $	��113��5U      $��
359,34,0,0q�5V      $
��Left=�5W      $	��Top=�5X      $��Eliminar��5Y      �� 5Z   
   -
   5        $ 	BtnCopiar��5Z      $��2��5[      $	��113��5\      $��
359,70,0,0q�5]      $
��Left=�5^      $	��Top=�5_      $��Copiar��5`      �� 5a   
   -   5        $ BtnCancelar��5a      $��3��5b      $��75��5c      $��
397,18,0,0q�5d      $
��Left=�5e      $	��Top=�5f      $��Cancelar��5g      �� 5h   
   -   5        $ BtnRealizar��5h      $��3��5i      $	��110��5j      $��
282,18,0,0q�5k      $
��Left=�5l      $	��Top=�5m      $��Realizar consulta��5n      5o      5p      