   M S B A M L   `   `   `  ����G  CScrum_o_wall, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Scrum_o_wall.ViewsScrum_o_wall.Views  5   	   &     Scrum_o_wall.Views.BurndownChart   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5	   	   @d2http://schemas.microsoft.com/expression/blend/2008     5
   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Scrum_o_wall.Views     5   	     � Title$  Scrum'o'Wall��5   	   $	��450��6   $	��800��6+    � WindowState$ 	Maximized=�67    � WindowStyle$
 None=�6O    � WindowStartupLocation$ CenterScreen=�6b   $��16(�6�    � 
ResizeMode$ NoResize=�6�    � ContextMenu 5      �� 5   
   .@�5      �� m� 5      -   5        $
��Quit��5   '   $��Retour��6   63   5      .��5      � .+�5   
   �� -   5         ��Name$ lnIdeal��5      	 �� X1$	 120��6    	 �� Y1$ 70��6)   $��2��61   		 �� X2$		 730��6E   	
 �� Y2$	
 330��6N   
���  ��6f   � 5   
   -   5         �Name$ 	lnCurrent��5       � Points �    '�, �� ��$��2��6>   
���   �5      �� 5   
   -   5         ��Name$ brdrGraphic��5      
�������$��2,0,0,2q�69   $��120,70,70,120q�6S   �� 5   
   $��Complexité��6   $��Center=�6%   6B   �� 5   
   $
��Jour��6   $��Bottom=�6   $��Center=�6:   $��383,0,377,91q�6W    J� RenderTransformOrigin$ 0.575,-1.226&�6m   6�   �� 5   
   -   5        $��lblDayBegin��5   @   $��Bottom=�6   $��120,0,0,100q�6+   .��6S   DD.MM6Z   �� 5   
   -   5        $��	lblDayEnd��5   [   $��Bottom=�6   $��
0,0,70,100q�6+   $��Right=�6?   .��6l   DD.MM6s   �� 5!   
   -   5        $��lblComplexityMax��5!   Z   $	��Top=�6   $��	90,60,0,0q�6+   $
��Left=�6?   .��6r   XX6v   �� 5"   
   -   5        $��lblComplexityZero��5"   ^   $��Bottom=�6   $��100,0,0,120q�6+   $
��Left=�6C   .��6w   06z   �� 5$   
   -	   5         ��Name$ 	btnCancel��5$      $	��←��6L   $	��Top=�6X   $��Center=�6w   $��10q�6�   $��75��6�   $��75��6�   $��45(�6�   $��Bottom=�6�    � 	Resources 5%       �� 
TargetType �� Property �� Value��%_   '��       �� 5&      " ��6   .�5'      ��  �@��CornerRadius$ 50��65   5(      5)      5*      5+      5,      