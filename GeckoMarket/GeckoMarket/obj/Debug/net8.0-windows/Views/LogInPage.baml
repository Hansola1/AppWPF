   M S B A M L   `   `   `  ����F  BGeckoMarket, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:GeckoMarket.ViewsGeckoMarket.Views  5      !    GeckoMarket.Views.LogInPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:GeckoMarket.Views     5      c _MahApps.Metro.IconPacks.Core, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5        N� Title$  RegistrationPage��5
      $	��720��6    $
��1080��6-   $	��720��6:   $
��1080��6J    N� 
Background
 ���� .��5      ��  �� CornerRadius$ 10��6   
�������._�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   .+�5      � $��1��6   $��30 20 20 20q�6#   .+�5      �� $"��Войти в аккаунт��6   $��36(�63   $
��Bold"�6A   $
��Left=�6S   $��Center=�6n   $��315,-350,0,0q�6�   $��48��6�   �� 5      $��0,189,0,140q�6   $��Center=�62   $	��400��6O   .+�5      �� $��Логин:��6    $��Verdana)�6.   $��20(�6C   $��2,16,0,5q�6Q   �� 5      -   5         ��Name$ BorderLogin��5      $ 10��62   ���	#FFA7A7A7
������ $��1q�6u   ._�5      �� -   5         ��Name$ Login_TextBox��5   "   $	��399��69   $��45��6E   $��25(�6Q   
������ $��0q�6x   5      �� 5!      $��Пароль:��6    $��Verdana)�6/   $��20(�6D   $��2,16,0,5q�6R   �� 5"      $ 10��6   ���	#FFA7A7A7
������ $��1q�6`   ._�5#      G� -   5         G�Name$ PasswordBox��5#   &   $	��399��6;   $��45��6G   $��25(�6S   
������ $��0q�6z   5$      5%      �� 5(      $ 15��6   
���   �$	��400��6>   $��315,437,315,170q�6J   ._�5)      �� -   5         ��Name$ Login_Button��5)   N      
menuButton#��[  6   $	��NaN��6A   $��25(�6d   $
��Bold"�6r   
������ 
�������
������ $��
0,-11,0,-9q�6�   5*      �� 5+      $��
Войти��6   $��28(�6)   $
��Bold"�67   $��Center=�6I   $��0,455,0,184q�6f    �� TextAlignment$ Center=�6{   
�������$	��110��6�   �� 5,      $(��"У вас нет аккаунта?��6   $��20(�67   $
��Bold"�6E   $
��Left=�6W   $��318,520,0,124q�6r   $ Center=�6�   ���	#FF8F8F8F6�   �� 5-      -   5        #��[  5-      $��Создать��6=   $��18(�6O   $
��Bold"�6]   
������ 
���   �$��515,512,0,124q�6�   $
��Left=�6�   	 J� RenderTransformOrigin$	 0.5,0.5&�6�   $��84��6  ��6�   Z� 5.      50       � 51      -   5        
  �Name$
 	MainFrame��51        � NavigationUIVisibility$ Hidden=�6'   $��1��6G   52      53      54      