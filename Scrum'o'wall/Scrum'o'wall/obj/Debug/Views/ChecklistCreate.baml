   M S B A M L   `   `   `  ����G  CScrum_o_wall, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Scrum_o_wall.ViewsScrum_o_wall.Views  5   	   (    "Scrum_o_wall.Views.ChecklistCreate   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5	   	   @d2http://schemas.microsoft.com/expression/blend/2008     5
   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Scrum_o_wall.Views     5   	     � Title$  Créer une checklist��5   	    � WindowStartupLocation$ CenterScreen=�6%   $	��450��6J   $��447.5��6W   $��16(�6e   .��5      �  � RowDefinitions 5   
   �� 5      $	��70* �6   6+   �� 5      $	��40* �6   6+   �� 5      $
��259* �6   6,   �� 5      $	��50* �6   6+    � ColumnDefinitions 5   
   �� 5      $
��119* �6   6.   �� 5      $
��321* �6   6.   .+�5   
   �� $��2��6   $��Center=�6(   $��10,22q�6C    �� TextAlignment$ Center=�6R   $��20(�6i   $��26��6w   Créer une checklist6�   �� 5   
   $��1��6   $��Center=�6!   $��10q�6<   $ Right=�6H   $��20��6^   Nom :6r   �� 5   
   $��2��6   $	��Top=�6!   $��
10,10,10,0q�69   $ Right=�6M   $��21��6c   
Objets :6z   �� 5   
   -   5        $��tbxName��5   K   $��1��6    �� 	MaxLength$	 255��6   $��1��6/   $��10q�6?    �� IsPressAndHoldEnabled .  6�   � 5   
   $��2��6   $��1��6    5       �� 5!      $
��107* �6    60   �� 5"      $	��25* �6    6/   .+�5$      �� -   5         ��Name$ 	listItems��5$      $��10q�6*    .  5%      �� 5&      -   5         ��Name$ 
btnAddItem��5&      $��1��6)   $��10q�66   .��6v   Ajouter un objet6�   5'      �� 5)   
   -   5        $ 	btnCancel��5)      $��3��6$   $��10q�61   .��6o   	Annuler6x   �� 5*   
   -   5        $ 
btnConfirm��5*      $��3��6%   $��1��62   $��10q�6B   .��6�   	Confirmer6�   5+      5,      