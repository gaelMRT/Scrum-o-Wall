   M S B A M L   `   `   `  ���� G  CScrum_o_wall, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Scrum_o_wall.ViewsScrum_o_wall.Views  $    Scrum_o_wall.Views.MindmapMenu   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:Scrum_o_wall.Views       � Title$  Scrum'o'Wall��$	��450��$	��800�� � WindowState$ 	Maximized=� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�$��16(� � ContextMenu �� .@�m� -   $��
CreateNode��$��Créer un noeud��m� -   $��Modify��$��Modifier le mindmap���� m� -   $
��Quit��$��Retour��.���  � RowDefinitions �� �� $	��100 � � ColumnDefinitions �� �� .+��� -    ��Name$ scrllVwr��$
��Auto=�$
��Auto=�$��2��.��� -   	 �Name$	 
grdMindMap���� -   
 ��Name$
 
btnAddNode��$��1��$��1��$
��Left=�$��+��$	��Top=�$��75��$��75��
���   �$��45(�$��10q� � 	Resources  �� 
TargetType �� Property �� Value��%:   '��       �� " ��.���  �@��CornerRadius$ 50���� -   $
 	btnReturn��$��1��$��Right=�$	��←��$	��Top=�
���   �$��45(�$��75��$��75��$��10q� ��%:   '��       �� " ��.���  �@��CornerRadius$ 50��