   M S B A M L   `   `   `  ����G  CScrum_o_wall, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Scrum_o_wall.ViewsScrum_o_wall.Views  5   	   %    Scrum_o_wall.Views.SprintCreate   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5	   	   @d2http://schemas.microsoft.com/expression/blend/2008     5
   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Scrum_o_wall.Views     5   	     � Title$  Création d'un sprint��5   	   $��281.121��6&   $��462.967��67    � WindowStartupLocation$ CenterScreen=�6G   $��16(�6m   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��140* �6   �� 5      $
��249* �6    � RowDefinitions 5   
   �� 5      $	��84* �6   �� 5      $	��43* �6   �� 5      $	��43* �6   �� 5      $	��53* �6   .+�5   
   �� $��2��6   $��Center=�6$   $��Center=�6A   $��36(�6\   $��10q�6j   .��6v   Créer un sprint6�   �� 5   
   $��1��6   $��Right=�6   $��Center=�69   .��6U   Date de début :6f   �� 5   
   $��2��6   $��Right=�6   $��Center=�69   .��6U   Date de fin :6d   �� 5   
   -   5         ��Name$ 	btnCancel��5   +   $��3��6V   $��10q�6c   .��6o   	Annuler6x   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dtpckDateBegin��5   "   $��1��6   $��1��68   $��10q�6H    �� IsPressAndHoldEnabled .  6T     5    
   -   5        $��dtpckDateEnd��5    "   $��2��6   $��1��66   $��10q�6F    .  6R   �� 5!   
   -   5        $ btnAddProject��5!   /   $��3��6b   $��1��6o   $��10q�6   .��6�   	Confirmer6�   5"      5#      