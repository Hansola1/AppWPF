   M S B A M L   `   `   `  ����Q  MCosmosOdjectAPP_Matvey, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CosmosOdjectAPP_MatveyCosmosOdjectAPP_Matvey  5   	   '    !CosmosOdjectAPP_Matvey.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:CosmosOdjectAPP_Matvey     5   	     � Title$  Список звезд��5   
   $	��700��6   $	��700��6,   $	��800��6<   $	��800��6H   .��5	      � ���	#FFA59CE4$	��700��6"   $	��800��6/   $	��700��6;   $	��800��6K   .+�5   
   �� -   5         ��Name$ Information_ListView��5      $	��700��62   $��50,79,50,100q�6V   ��6>   ��  �� View 5      �� 5      .P�5      �� $��
Номер��6%    �� Width$ 50��6]    �� DisplayMemberBinding 64   �� *	NumStar+6]   �� 5      $��Название��6%   $	 320��6a    67   �� *
NameStar+6a   �� 5      $��Расстояние��6%   $	 100��6c    69   �� *
Distance+6c   �� 5      $��Тип звезды��6%   $	 210��6c    69   �� *
TypeStar+6c   5      5      �� 5   
   -   5         ��Name$ AddStar_Button��5      $��Добавить��6)   $
��Left=�6<   $��
52,605,0,0q�6W   $	��Top=�6k   $��47��6�   $	��325��6�   $��20(�6�   
����������	#FFE8AF93$��Franklin Gothic Medium)�6�   ���	#FF3940BC6  �� 5   
   -   5        $ DeletStar_Button��5      $��Убрать��6+   $
��Left=�6<   $��416,605,0,48q�6W   $��47��6m   $	��334��6y   $��20(�6�   
����������	#FF7B330F$��Franklin Gothic Medium)�6�   ���	#FF3940BC6�   �� 5   
   -   5         ��Name$ SortStar_ComboBox��5      $��25(�6.   
���   �$��Tekton Pro Cond)�6O   $��52,31,423,626q�6l   .@�5      �� .��6   Красный карлик6+   �� 5      .��6   Желтый карлик6*   �� 5      .��6   Суперземля6'   �� 5      .��6   !Оранжевый карлик6-   �� 5      .��6   Все типы звезд6+   5      �� 5!   
   -   5         ��Name$ FindStar_TextBox��5!      $��25(�6,   $
��Left=�6:    �� TextWrapping$
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $	��337��6�   $��43��6�   ���	#FFE1B396$��
416,31,0,0q�6�   6�   5#      5$      