   M S B A M L   `   `   `  ����G  CScrum_o_wall, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Scrum_o_wall.ViewsScrum_o_wall.Views  5   	   $    Scrum_o_wall.Views.ProjectEdit   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5	   	   @d2http://schemas.microsoft.com/expression/blend/2008     5
   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Scrum_o_wall.Views     5   	     � Title$  Modification d'un projet��5   	   $	��500��6*   $	��600��67    � WindowStartupLocation$ CenterScreen=�6C   $��16(�6h   .��5      � $��0,0,2,-1q�6    � ColumnDefinitions 5   
   �� 5      $
��140* �6   �� 5      $
��249* �6    � RowDefinitions 5   
   �� 5      $	��84* �6   �� 5      $	��43* �6   �� 5      $
��184* �6   �� 5      $	��53* �6   �� 5      $	��56* �6   �� 5      $	��56* �6   .+�5   
   �� $��2��6   $��Center=�6$   $��Center=�6A   $��36(�6\   .��6l   Modification un projet6�   �� 5   
   $��1��6   $��Right=�6   $��Center=�69   .��6T   Nom du projet :6e   �� 5   
   -   5        $��tbxName��5      $��1��6   $��1��6.    �� 	MaxLength$ 50��6>   $��10q�6M   �� 5!   
   $��2��6   $��Right=�6   $	��Top=�69   .��6Q   Description du projet :6j   �� 5"   
   -   5        $��tbxDesc��5"      $��2��6   $��1��6.   $ 65535��6>    �� TextWrapping$ WrapWithOverflow=�6P   $��10q�6p    �� IsPressAndHoldEnabled .  6|   �� 5$   
   $��3��6   $��Right=�6   $��Center=�69   .��6T   Date de début :6e   (  "System.Windows.Controls.DatePicker  5%   
   -   5        $��dtpckrDateBegin��5%   "   $��3��6   $��1��69   $��10q�6I   $��Center=�6U    .  6p   � 5'   
   $��4��6   $��2��6    5(      �� 5)      6%   �� 5*      6%   .+�5,      �� -   5        $��	btnStates��5,   ;   $��10q�6/   .��6d   
Colonnes6n   �� 5-      -   5        $��btnUsers��5-   J   $��1��6.   $��10q�6>   .��6q   Utilisateurs assignés6�   5.      � 5/   
   $��5��6   $��2��6    50      �� 51      6%   �� 52      6%   �� 53      $��2* �6#   60   .+�55      �� -   5         ��Name$ 	btnCancel��55      $��10q�6)   .��6g   	Annuler6p   �� 56      -   5        $ 	btnDelete��56      $��1��6)   $��10q�69   .��6w   	Supprimer6�   �� 57      -   5        $ 
btnConfirm��57      $��2��6*   $��10q�6:   .��6z   	Confirmer6�   58      59      5:      