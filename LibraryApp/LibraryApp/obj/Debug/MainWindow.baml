   M S B A M L   `   `   `  ����E  ALibraryApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:LibraryApp
LibraryApp  5   	       LibraryApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:LibraryApp     5   	     � Title$  Библиотека��5   	   $	��700��6   $	��700��6)   $	��800��69   $	��800��6E   .��5	      � ���	#FFE4B89C$	��700��6"   $	��800��6/   $	��700��6;   $	��800��6K   .+�5   
   �� ���	#FFFFE4D3$	��630��6,   $	��750��69   $	��630��6E   $	��750��6U    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ 	#FFE6BDA6��6#      
BlurRadius$ 10Q�65      ShadowDepth$ 1Q�6E      	Direction$	 315Q�6U      RenderingBias$ Performance=�6e   5      �� 5   
   $F��@Добро пожаловать в мою библиотеку! ��6   $
��Left=�6>   $��	247,2,0,0q�6Y   $	��Top=�6l   $��Franklin Gothic Medium)�6�   $��20(�6�   
����������	#FFC78054}�. $	��376��6   J� RenderTransformOrigin$ 
0.61,0.524&�6  ��6�   Z�  5        5      $ 	#FFF3AC7F��6#   $ 10Q�65   $ 1Q�6E   5      �� 5   
   -   5         ��Name$ Information_ListView��5      $	��700��62   $	��500��6>   ��6K   �� 	 �� View	 5      �� 5      .P�5      �� $��
Номер��6%   
 �� Width$
 70��6\    �� DisplayMemberBinding 64   �� *Number+6\   �� 5      $��Название��6%   $	
 300��6^    67   �� *Title+6^   �� 5      $��
Автор��6%   $	
 140��6[    64   �� *Genre+6[   �� 5      $��Жанр��6%   $	
 200��6[    63   �� *Author+6[   5       5"      �� 5%   
   -   5         ��Name$ AddBook_Button��5%      $��Добавить��6)   $
��Left=�6<   $��
52,605,0,0q�6W   $	��Top=�6k   $��47��6�   $	��251��6�   $��20(�6�   
����������	#FFE8AF93$��Franklin Gothic Medium)�6�   ���	#FFFFBB996  �� 5&   
   -   5        $ DeletBook_Button��5&      $��Убрать��6+   $
��Left=�6<   $��499,605,0,48q�6W   $��47��6m   $	��251��6y   $��20(�6�   
����������	#FFE8AF93$��Franklin Gothic Medium)�6�   ���	#FFFFBB996�   �� 5)   
   -   5         ��Name$ SortBook_ComboBox��5)      $��25(�6.   
���   �$��Tekton Pro Cond)�6O   $��52,52,494,605q�6l   .@�5*      �� .��6   Фантастика6'   �� 5+      .��6   %#Научная фантастика6/   �� 5,      .��6   
Роман6"   �� 5-      .��6   Приключения6(   �� 5.      .��6   Все жанры6&   5/      �� 51   
   -   5         ��Name$ FindBook_TextBox��51      $��25(�6,   $
��Left=�6:    �� TextWrapping$
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $	��254��6�   $��43��6�   ���	#FFE1B396$��
496,52,0,0q�6�   6�   53      54      