   M S B A M L   `   `   `  ����G  CScrum_o_wall, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Scrum_o_wall.ViewsScrum_o_wall.Views  5   	   &     Scrum_o_wall.Views.CommentCreate   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5	   	   @d2http://schemas.microsoft.com/expression/blend/2008     5
   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Scrum_o_wall.Views     5   	     � Title$  Création de commentaire��5   	   $��310.865��6)   $��445.866��6:    � WindowStartupLocation$ CenterScreen=�6J   $��16(�6o   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��25* �6   6-   �� 5      $	��48* �6   6-    � RowDefinitions 5   
   �� 5      $	��63* �6   6+   �� 5      $
��117* �6   6,   �� 5      $	��50* �6   6+   �� 5      $��50 �6   6*   .+�5   
   �� $��2��6    �� TextAlignment$ Center=�6(   $��20(�6?   $��Center=�6M   $��10q�6h   Poster un Commentaire6�   �� 5   
   $��1��6   $ Right=�6!   $��Center=�67   $��10,45,10,50q�6R   $��22��6g   	Contenu :6   �� 5   
   -   5         ��Name$ 
tbxContent��5       �� 	MaxLength$ 65535��6&   $��1��68   $��1��6E    �� TextWrapping$ WrapWithOverflow=�6U   $��10q�6u    �� IsPressAndHoldEnabled .  6�   �� 5   
   $��2��6   $ Right=�6!   $��Center=�67   $��10,12,10,18q�6R   $��20��6g   
Auteur :6~   �� 5   
   -   5        $��	cbxAuthor��5      $��2��6$   $��1��61   $��10q�6A    .  5      �� 5    
   -   5        	 ��Name$	 	btnCancel��5       $��3��6$   $��0��61   $��10q�6A   .��6   	Annuler6�   �� 5!   
   -   5        $	 
btnConfirm��5!      $��3��6%   $��1��62   $��10q�6B   .��6�   	Confirmer6�   5"      5#      