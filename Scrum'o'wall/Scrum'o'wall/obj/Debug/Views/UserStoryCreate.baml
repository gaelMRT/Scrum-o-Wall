   M S B A M L   `   `   `  ����G  CScrum_o_wall, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Scrum_o_wall.ViewsScrum_o_wall.Views  5   	   (    "Scrum_o_wall.Views.UserStoryCreate   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5	   	   @d2http://schemas.microsoft.com/expression/blend/2008     5
   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Scrum_o_wall.Views     5   	     � Title$   Création d'une User Story��5   	   $	��491��6+   $��508.713��68    � WindowStartupLocation$ CenterScreen=�6H   $��16(�6m   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��163* �6   �� 5      $
��226* �6    � RowDefinitions 5   
   �� 5      $	��56* �6   �� 5      $
��148* �6   �� 5      $	��44* �6   �� 5      $	��42* �6   �� 5      $	��42* �6   �� 5      $	��42* �6   �� 5      $	��45* �6   .+�5   
   �� $��2��6   $��Center=�6$   $��Center=�6A   $��36(�6\   $��58��6j   $��
44,-2,44,0q�6v   $	��336��6�   .��6�   Créer une User Story6�   �� 5   
   $��1��6   $��Right=�6   $	��Top=�69   .��6R   Description de la User Story:6q   �� 5    
   -   5        $��tbxDesc��5    E   $��1��6    �� TextWrapping$
 Wrap=�6    �� 	MaxLength$ 65535��63   $��1��6T   $��10q�6d    �� IsPressAndHoldEnabled .  6p   �� 5"   
   $��2��6   $��Right=�6   $��Center=�69   .��6U   Date limite:6c   (  "System.Windows.Controls.DatePicker  5#   
   -   5          Name$ dtpckrDateLimit��5#      $��1��6.   $��10q�6>   $��2��6J    .  6W   �� 5%   
   $��3��6   $��Right=�6   $��Center=�69   .��6T   Estimation de complexité :6p   �� 5&   
   -   5        $��tbxComplexity��5&      $��3��6   $ 5��64   $��1��6B   $��10q�6r    .  6~   �� 5(   
   $��4��6   $��Right=�6   $��Center=�69   .��6T   	Priorité6^   �� 5)   
   -   5        $��cbxPriority��5)      $��4��6&   $��10q�63   $��10��6?    .  6w   �� 5+   
   $��5��6   $��Right=�6   $��Center=�69   .��6T   Type6Z   �� 5,   
   -   5        $��cbxType��5,      $��5��6"   $��10q�6/   $��10��6;    .  6s   �� 5.   
   -   5         ��Name$ 
btnConfirm��5.   ,   $��6��6Y   $��1��6f   $��10q�6v   .��6�   	Confirmer6�   �� 5/   
   -   5        $ 	btnCancel��5/   +   $��6��6V   $��10q�6c   .��6o   	Annuler6x   50      51      