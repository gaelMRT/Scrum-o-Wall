   M S B A M L   `   `   `  ����G  CScrum_o_wall, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Scrum_o_wallScrum_o_wall  5   	       Scrum_o_wall.MainMenu   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5	   	   @d2http://schemas.microsoft.com/expression/blend/2008     5
   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Scrum_o_wall     5   	     � Title$  Scrum'o'Wall��5   	    � 
ResizeMode$ NoResize=�6    � WindowState$ 	Maximized=�64    � WindowStartupLocation$ CenterScreen=�6L   $
��1000��6q   $
��1000��6~    � WindowStyle$
 None=�6�   $��16(�6�    � ContextMenu 5      �� 5   
   .@�5      m� -   5        $��
AddProject��5   2   $��Ajouter un projet��6   6D   �� 5      m� 5      -   5        $
��Quit��5   (   $��Quitter��6   64   5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $	��100 �6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   �� -   5         ��Name$ scrllVwr��5      $
��Auto=�6)   $��2��6L   .��5    
   �� -   5        	 ��Name$	 cnvsProject��5       $
��1000��6&   $��0,0,0,0q�63   $
��Left=�6D   $	��796��6_   5!      5"      �� 5#   
   -   5        
 ��Name$
 btnAddProject��5#   I   $��1��6   $��1��6   $
��Left=�6.   $��+��6�   $	��Top=�6�   $��75��6�   $��75��6�   
���   �$��45(�6�   $��10q�6�    � 	Resources 5$   
    �� 
TargetType �� Property �� Value��%_   '��       �� 5%      " ��6   .�5&      ��  �@��CornerRadius$ 50��61   5'      5(      5)      �� 5*   
   -   5        $
 	btnReturn��5*   ;   $��1��6   $��Right=�6   $	��←��6v   $	��Top=�6�   
���   �$��45(�6�   $��75��6�   $��75��6�   $��10q�6�    5+      ��%_   '��       �� 5,      " ��6   .�5-      ��  �@��CornerRadius$ 50��65   5.      5/      50      51      52      