   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	        WpfApplication1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	   Cee4http://schemas.microsoft.com/expression/2010/effects     5   	     � Title$  
MainWindow��5	   	   $	��670��6   $	��500��6)    � WindowStyle$
 None=�65    � WindowStartupLocation$ CenterScreen=�6H    � 
ResizeMode$ NoResize=�6m    � AllowsTransparency . ��6�   Z� ��6�   Z�  � 	Resources 5
         OnMouseEnter1 �� TargetProperty �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime	 �� Value  OnMouseEnter2  OnMouseLeave1  OnMouseLeftButtonDown1  OnMouseEnter3  mouseEntreCnxnBtn9  3System.Windows.Media.Animation.EasingDoubleKeyFrame
 O� KeyTime O� Value  OnMouseLeaveCnxnBtn 	 mehdi<  6System.Windows.Media.Animation.EasingThicknessKeyFrame p� KeyTime p� Value  listeUsersMouseEnter 	 listUsersMouseLeave��%g
  &	        &	 �     &	 �     &	 �    &	 �    &	     &	 1    &	     &	 9    &		 	    �� 5   
   .��5      �� $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�6+   $ border��6t   .g�5        $ 0��6&   $	 	#FF3B5998��62     5      $ 0:0:0.4��6&   $	 	#FF267391��68   5      5      �� 5   
   6   �� 5   
   .��5      �� $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�6+   $ border��6t   .g�5        $ 0��6&   $	 	#FF267391��62     5      $ 0:0:0.5��6&   $	 	#FF3B5998��68   5      5      �� 5   
   6   �� 5   
   6   �� 5   
   .��5      �� $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6+   $ connexionLabel��6x   .g�5        $ 0��6&   $	 White��62     5      $ 0:0:0.5��6&   $	 	#FF267391��68   5      U� 5      $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6,   $ connexionLabel��6�   .\�5         $
 0��6'   $ 0Q�63     5!      $
 0:0:0.3��6'   $ 10Q�69     5"      $
 0:0:0.4��6'   $ -8Q�69     5#      $
 0:0:0.5��6'   $ 0Q�69   5$      5%      �� 5&   
   .��5'      �� $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6+   $ connexionLabel��6x   .g�5(        $ 0��6&   $	 	#FF267300��62     5)      $ 0:0:0.6��6&   $	 White��68   5*      5+      �� 5,   
   .��5-      �� $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�6+   $ border��6t   .g�5.        $ 0��6&   $	 White��62     5/      $ 0:0:0.5��6&   $	 	#FF134D00��68   50      r� 51      $ (Border.BorderThickness)�6/   $ border��6d   .	�52        $ 0��6*   $ 2q�66     53      $ 0:0:0.5��6*   $ 1q�6<   54      �� 55      $0 *(Panel.Background).(SolidColorBrush.Color)�6+   $ passWord��6r   .g�56        $ 0��6&   $	 	#66FFFFFF��62     57      $ 0:0:1.1��6&   $	 	#00288BC3��68   58      �� 59      $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6+   $ passWord��6x   .g�5:        $ 0��6&   $	 White��62     5;      $ 0:0:1.1��6&   $	 	#FF1C3976��68   5<      5=      �� 5>   
   .��5?      �� $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�6+   $ border1��6t   .g�5@        $ 0��6&   $	 	#FF267391��62     5A      $ 0:0:0.7��6&   $	 	#FF267391��68   5B      5C      �� 5D   
   .��5E      �� $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�6+   $ border1��6t   .g�5F        $ 0��6&   $	 	#FF267391��62     5G      $ 0:0:0.7��6&   $	 	#FF267391��68   5H      5I      5J       � Triggers 5K      :� 5L   
    :� RoutedEvent$ UIElement.MouseEnter��6    :� 
SourceName$ passWord��6:   .[�5M      �� -   5         ��Name$# OnMouseEnter1_BeginStoryboard��5M      #��[  6E   5N      :� 5O   
   $ UIElement.MouseLeave��6   $ passWord��6:   .[�5P      �� -   5        $# OnMouseLeave1_BeginStoryboard��5P      #��[ 6E   5Q      :� 5R   
   $! PasswordBox.PasswordChanged��6   $ passWord��6A   .[�5S      �� -   5        $ mehdi_BeginStoryboard��5S      #��[ 6=   5T      :� 5U   
   $ UIElement.MouseEnter��6   $ connexionLabel��6:   .[�5V      �� -   5        $' !mouseEntreCnxnBtn_BeginStoryboard��5V      #��[ 6I   5W      :� 5X   
   $ UIElement.MouseLeave��6   $ connexionLabel��6:   .[�5Y      �� -   5        $) #OnMouseLeaveCnxnBtn_BeginStoryboard��5Y      #��[ 6K   5Z      :� 5[   
   $ UIElement.MouseEnter��6   $ 
activeUser��6:   .[�5\      �� -   5        $* $listeUsersMouseEnter_BeginStoryboard��5\      #��[ 6L   5]      :� 5^   
   $ UIElement.MouseLeave��6   $ 
activeUser��6:   .[�5_      �� -   5        $) #listUsersMouseLeave_BeginStoryboard��5_      #��[	 6K   5`      :� 5a   
   $ UIElement.MouseEnter��6   $ 
activeUser��6:   .[�5b      �� -   5        $# OnMouseEnter2_BeginStoryboard��5b      #��[ 6E   5c      .��5e      � $��Right=�6   $
��1280��6'   $��0,-75,-410,75q�64    � ColumnDefinitions 5f   
   �� 5g      .+�5i   
   �� -	   5         ��Name$
 back��5i      $��img/back.png��6   $��380,75.833,0,0q�64    J� OpacityMask �	#FFDE0000$��584.167��6d   $	��Top=�6u   $
��Left=�6�   $��495.868��6�   |�. 6�   �� 5j   
   -
   5        $ profilPhoto��5j      $��img/profilPhoto.png��6%   $
��Fill=�6B   $��0,216,587,330q�6Q    J� RenderTransformOrigin$ 0.786,-0.087&�6h    K� ZIndex$ 1��6�   $��Right=�6�   $	��109��6�   z�5k      V� 5l      .~�5m      �� �� 5n      �� 5o      T� 5p      5q      5s      �� 5t   
   -   5         ��Name$ rectMove��5t      $��33.999��6&   $��0,154.001,485.5,0q�66   $	��Top=�6Q   ���	#FF267391$��Right=�6�   $��240.233��6�   �� 5v   
   -   5        $ newSessionBtn��5v      $"��Buttons/newSessionButton.png��6'   $
��Fill=�6M   $��476.646,0,0,9.169q�6\   $ 2��6w   $ 0.5,0.5&�6�   $��65��6�   $��Bottom=�6�   $
��Left=�6�   $��65��6  z�5w      V� 5x      .~�5y      �� �� 5z      �� 5{      T� 5|      5}      5      �� 5�   
   -   5        $ newSessionBtnHover��5�       � ToolTip$, &Créer un nouveau compte d'utilisateur��6,    ^� ShowDuration$
 2000��5�   	   $ 0.5,0.5&�6,   $��65��6L   $��65��6W   $��Bottom=�6c   $
��Left=�6~   $
��Fill=�6�   $��476.646,0,0,9.169q�6�   $'��!Buttons/newSessionButtonHover.png��6�   $ 2��6�   
 �   �$y�Hidden=�6y  �� 5�   
   -   5         ��Name$ 
activeUser��5�      $��0,0,539.002,237q�6'   $��Comic Sans MS)�6@   $	 0,0&�6[   $��Center=�6w   $ 2��6�   $��Right=�6�   $��200.231��6�   $��26��6�   $��Bottom=�6�   $ �� IsSynchronizedWithCurrentItem$ FalseY�6%  $��0q�6b  ���	#FF267391��6K  Z� ��6�  Z� 6�  G� 5�   
   -   5         G�Name$ passWord��5�      $��540.767,0,539.002,195q�6(   ���	#00000000&   System.Windows.Media.TextOptions   TextHintingMode$ Animated=�6�   $��Segoe Script)�6�   $��14(�6�   ���	#FF1C3976$��Center=�6�   $��Center=�6  
 � Tag$ *��6<  $ 2��6D  $��26��6U  $��Bottom=�6a   G� SelectionBrush 6H   Z� ��6b   Z� 6|  �� 5�   
   -   5          ��Name$  border��5�      $��1q�6!   $��0,0,539.002,195q�65   ���	#FF267391$ 0.651,0.163&�6}   $ 2��6�   $��26��6�   $��Bottom=�6�   $��Right=�6�   $��200.231��6�    6f   Z� 6�   �� 5�   
   -   5        $ 	iconClose��5�      $��Right=�6#   $��12��6?   $��icons/closeIcon.png��6K   $
��Fill=�6h   $	��Top=�6w   $��12��6�   $��0,165.328,492.416,0q�6�   $ 1��6�   
 �  ��6  �� 5�   
   -   5        $ iconCloseHover��5�      $��12��6(   $��icons/closeIconHover.png��64   $
��Fill=�6V   $	��Top=�6e   $��0,165.328,492.416,0q�6}   $ 3��6�   $��Right=�6�   $��12��6	  $y�Hidden=�6  �� 5�   
   -   5        $ minimizeHover��5�      $��3��6'   $��icons/minimizeHover.png��62   $
��Fill=�6S   $	��Top=�6b   $��0,169.833,518.452,0q�6z   $ 1��6�   $��Right=�6  $��12��66   6�   Z� 66  �� 5�   
   -   5        $ minimize��5�      $��3��6"   $��icons/minimize.png��6-   $
��Fill=�6I   $	��Top=�6X   $��0,169.833,518.33,0q�6p   $ 1��6�   $��Right=�6�   $��12��6  �� 5�   
   -   5        $ minimizeBtn��5�      $ Minimiser la fenêtre��6)   $
 2000��5�   	   $��33.999��6,   $	��Top=�6<   $��741.67,154.001,0,0q�6T   $ 0��6p   $
��Left=�6�   $��26��6�   ! J� Opacity$! 0Q�6  
���   �6  �� 5�   
   -   5        $ closeBtnBack��5�      $ Fermer la fenêtre��6*   $
 2000��5�   	   $��33.999��6,   $	��Top=�6<   $��0,154.001,485.5,0q�6T   $! 0Q�6�   
�������$��Right=�6�   $��26��6�   �� 5�   
   -   5        " ��Name$" connexionLabel��5�      $��	Connexion��6(   $��631.67,0,0,162.49q�6<   $��14(�6W   $��Comic Sans MS)�6e   
�������# � Cursor$
# Hand��6�   $��Bottom=�6�   $	��150��6�   $
��Left=�6�   $��Center=�6�   $��Center=�6  $ 0.5,0.5&�6)  $
��Bold"�6I  $��0q�6q  z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      5�      �� 5�   
   -   5        $" mdpLabel��5�      $��mot de passe��6"   $��541,0,539,194q�69   $��Bottom=�6P   ���	#4C000000$��Center=�6�   $��31��6�   $��Comic Sans MS)�6�   $��Center=�6�   $��14(�6  $��0q�6  ��6k   Z� 6  �� 5�   
   -   5        $  border1��5�      ���	#FF267391$��1q�6:   $��26��6N   $��540.767,0,539.002,237q�6Z   $��Bottom=�6y   $ 2��6�   �� 5�   
   -   5        $ image2��5�      $	��128��6    $��
467,0,0,81q�6-   $��Bottom=�6A   $��icons/logo.png��6\   $
��Left=�6t   $	��132��6�   5�      5�      