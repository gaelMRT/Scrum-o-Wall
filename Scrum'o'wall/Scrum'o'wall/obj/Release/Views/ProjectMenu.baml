   M S B A M L   `   `   `  ���� G  CScrum_o_wall, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Scrum_o_wall.ViewsScrum_o_wall.Views  $    Scrum_o_wall.Views.ProjectMenu   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:Scrum_o_wall.Views       � Title$  Scrum'o'Wall��$	��450��$	��800�� � WindowState$ 	Maximized=� � WindowStyle$
 None=�$��16(� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � ContextMenu �� .@�m� -   $
��Edit��$��Editer le projet���� m� -   $
��Quit��$��Retour��.���� -    ��Name$ cnvsBacklog��.+��� -   $��lblProjectName��$��Nom du projet��$��30(�$��60���� -   $��
lblBacklog��
 �� Top$ 65��$��30��.��Product Backlog�� -    ��Name$ gbxUserStories��$	��260��$	��280��$	 100��	 �� Left$	 10��$��User stories��.���� -   $��scrlUserStories��$��0,0,0,0q�.���� -   $ cnvsUserStories���� -	   $ 
gbxSprints��$	��260��$	��220��$	 100��
 �� Right$
 10��$		 295��$��Sprints��.���� -
   $��scrlSprints��$��0,0,0,0q�.���� -   $ cnvsSprints���� -   $ 
gbxMindMap��$	��260��$	��270��$	 100��$
 10��$		 520��$��MindMaps��.���� -   $��scrlMindMaps��$��0,0,0,0q�.���� -   $ cnvsMindMaps���� -    ��Name$ 	btnReturn��$	��←��$	��Top=� �� Bottom$ 10��$��75��$��75��
���   �$��45(�$	 365��$		 363�� � 	Resources  �� 
TargetType �� Property �� Value��%:   '��       �� " ��.���  �@��CornerRadius$ 50���� -   $ btnAddUserStory��$��+��$	��Top=�$ 10��$��40��$��40��
���   �$��23(�$	 320��$		 193�� ��%:   '��       �� " ��.���  �@��CornerRadius$ 50���� -   $ btnAddSprint��$��+��$	��Top=�$ 10��$��40��$��40��
���   �$��23(�$	 320��$		 380�� ��%:   '��       �� " ��.���  �@��CornerRadius$ 50���� -   $ btnAddMindMap��$��+��$	��Top=�$ 10��$��40��$��40��
���   �$��23(�$	 333��$		 656�� ��%:   '��       �� " ��.���  �@��CornerRadius$ 50��