   M S B A M L   `   `   `  ����G  CScrum_o_wall, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Scrum_o_wall.ViewsScrum_o_wall.Views  5   	   #    Scrum_o_wall.Views.SprintMenu   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5	   	   @d2http://schemas.microsoft.com/expression/blend/2008     5
   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Scrum_o_wall.Views     5   	     � Title$  
SprintMenu��5   	   $	��450��6   $	��800��6)    � WindowState$ 	Maximized=�65    � WindowStyle$
 None=�6M    � WindowStartupLocation$ CenterScreen=�6`    � 
ResizeMode$ NoResize=�6�   $��16(�6�    � ContextMenu 5      �� 5   
   .@�5      m� -   5        $��	addColumn��5   4   $��Ajouter une colonne��6   6E   m� 5      -   5        $��btnBurndownChartMenu��5   9   $��Ouvrir le burndown chart��6   6U   m� 5      -   5        $��btnEditSprint��5   1   $��Editer le sprint��6   6F   �� 5      m� 5      -   5        $
��Quit��5   '   $��Retour��6   63   5      .��5      �� -   5         ��Name$ 
cnvsSprint��5      .+�5   
   �� -   5        $��lblProjectName��5      $��Nom du projet��6&   $��30(�6>   $��60��6L   �� 5   
   -   5        $��lblSprintName��5      $��Nom du sprint��6%   
 �� Top$ 65��6=   $��30��6M   �� 5   
   -   5         ��Name$ 	btnReturn��5   +   $	��←��6W   $	��Top=�6c   	 �� Bottom$	 10��6�   $��75��6�   $��75��6�   
���   �$��45(�6�   
 �� Left$
 80��6�    � 	Resources 5       �� 
TargetType �� Property �� Value��%_   '��       �� 5      " ��6   .�5      ��  �@��CornerRadius$ 50��65   5      5       5!      �� 5"   
   -	   5        $ btnBurndownChart��5"   2   $
��📅��6k   $	��Top=�6x   $	 10��6�   $��75��6�   $��75��6�   
���   �$��45(�6�    5#      ��%_   '��       �� 5$      " ��6   .�5%      ��  �@��CornerRadius$ 50��65   5&      5'      5(      5)      5*      