   M S B A M L   `   `   `  ����G  CScrum_o_wall, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Scrum_o_wall.ViewsScrum_o_wall.Views  5   	   #    Scrum_o_wall.Views.FileCreate   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5	   	   @d2http://schemas.microsoft.com/expression/blend/2008     5
   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Scrum_o_wall.Views     5   	     � Title$  Ajouter un fichier��5   	   $	��500��6$   $	��600��61    � WindowStartupLocation$ CenterScreen=�6=   $��16(�6b   .��5      �  � RowDefinitions 5   
   �� 5      $	��78* �6   6+   �� 5      $	��56* �6   6+   �� 5      $
��227* �6   6,   �� 5      $	��56* �6   6+    � ColumnDefinitions 5   
   �� 5      $	��140 �6   6-   �� 5      .+�5   
   �� $��2��6   $��Center=�6(   $��10,26q�6C    �� TextAlignment$ Center=�6R   $��20(�6i   $��26��6w   Ajouter un fichier6�   �� 5   
   $��1��6   $��Center=�6!   $��10,14,10,22q�6<   $ Right=�6Q   $��20��6g   �� 6u   $�	Fichier :��6y   �� 6�   �� 6�   �� 6�   �� 6�   6�   �� 5   
   $��2��6   $	��Top=�6!   $��
10,10,10,0q�69   $ Right=�6M   $��21��6c   Description :6   �� 5   
   -   5         ��Name$ tbxFileName��5       �� 	MaxLength$ 65535��6'   {�.  $��1��6K   $��1��6X   $��10,10,100,10q�6h   6�   �� 5   
   -   5         ��Name$ btnFileSearch��5      $��1��6F   $��1��6S   $��
0,10,10,10q�6c   $��Right=�6�   $��87��6�   .��6�   +6�   �� 5   
   -   5        $��tbxDescription��5   D   $��10q�6   $ 65535��6    �� TextWrapping$
 Wrap=�60   $��2��6Z   $��1��6g   	 �� IsPressAndHoldEnabled	 .  .��6�   5       �� 5"   
   -   5        $ 	btnCancel��5"   +   $��4��6>   $��10q�6K   .��6o   	Annuler6x   �� 5#   
   -   5        $ 
btnConfirm��5#   ,   $��4��6@   $��1��6M   $��10q�6]   .��6�   	Confirmer6�   5$      5%      