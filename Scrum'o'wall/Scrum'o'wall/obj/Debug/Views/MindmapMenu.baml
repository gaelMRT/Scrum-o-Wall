   M S B A M L   `   `   `  ����G  CScrum_o_wall, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Scrum_o_wall.ViewsScrum_o_wall.Views  5   	   $    Scrum_o_wall.Views.MindmapMenu   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5	   	   @d2http://schemas.microsoft.com/expression/blend/2008     5
   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Scrum_o_wall.Views     5   	     � Title$  Scrum'o'Wall��5   	   $	��450��6   $	��800��6+    � WindowState$ 	Maximized=�67    � WindowStyle$
 None=�6O    � WindowStartupLocation$ CenterScreen=�6b    � 
ResizeMode$ NoResize=�6�   $��16(�6�    � ContextMenu 5      �� 5   
   .@�5      m� -   5        $��
CreateNode��5   /   $��Créer un noeud��6   6A   m� 5      -   5        $��Modify��5   4   $��Modifier le mindmap��6   6B   �� 5      m� 5      -   5        $
��Quit��5   '   $��Retour��6   63   5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $	��100 �6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5    
   �� -   5         ��Name$ scrllVwr��5       $
��Auto=�6)   $
��Auto=�6L   $��2��6q   .��5!      � -   5        	 �Name$	 
grdMindMap��5!      5"      5#      �� 5$   
   -   5        
 ��Name$
 
btnAddNode��5$   I   $��1��6   $��1��6   $
��Left=�6.   $��+��6�   $	��Top=�6�   $��75��6�   $��75��6�   
���   �$��45(�6�   $��10q�6�    � 	Resources 5%       �� 
TargetType �� Property �� Value��%_   '��       �� 5&      " ��6   .�5'      ��  �@��CornerRadius$ 50��65   5(      5)      5*      �� 5+   
   -   5        $
 	btnReturn��5+   ;   $��1��6   $��Right=�6   $	��←��6v   $	��Top=�6�   
���   �$��45(�6�   $��75��6�   $��75��6�   $��10q�6�    5,      ��%_   '��       �� 5-      " ��6   .�5.      ��  �@��CornerRadius$ 50��65   5/      50      51      52      53      