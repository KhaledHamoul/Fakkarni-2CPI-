   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	       WpfApplication1.contacts   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	   Dec5http://schemas.microsoft.com/expression/2010/controls     5   	     � Title$  contacts��5	   	   $	��720��6   $
��1280��6'    � WindowStyle$
 None=�64    � 
ResizeMode$ NoResize=�6G    � WindowStartupLocation$ CenterScreen=�6]    � 	Resources 5
         OnMouseEnter1  contactEnter �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  contactLeave  	homeLeave  
eventLeave  hollidayLeave  	homeEnter  
eventEnter  holidayEnter��%�  &	        &	      &	 �    &	 '    &	 �    &	 6    &	 �    &	 F	    &	 �
    �� 5   
   6   �� 5   
   .��5      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6,   $ contactIcon��6�   .\�5        $ 0��6'   $ 0Q�63     5      $ 0:0:0.1��6'   $ 10Q�69     5      $ 0:0:0.2��6'   $ 0Q�69     5      $ 0:0:0.3��6'   $	 -10Q�69     5      $ 0:0:0.4��6'   $ 0Q�69   5      5      �� 5   
   .��5      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6,   $ contactIcon��6�   .\�5        $ 0��6'   $ 0Q�63     5      $ 0:0:0.1��6'   $	 -10Q�69     5      $ 0:0:0.2��6'   $ 0Q�69     5      $ 0:0:0.3��6'   $ 10Q�69     5      $ 0:0:0.4��6'   $ 0Q�69   5      5      �� 5   
   .��5       U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6,   $ homeIcon��6�   .\�5!        $ 0��6'   $ 0Q�63     5"      $ 0:0:0.1��6'   $	 -10Q�69     5#      $ 0:0:0.2��6'   $ 0Q�69     5$      $ 0:0:0.3��6'   $ 10Q�69     5%      $ 0:0:0.4��6'   $ 0Q�69   5&      5'      �� 5(   
   .��5)      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6,   $ 	eventIcon��6�   .\�5*        $ 0��6'   $ 0Q�63     5+      $ 0:0:0.1��6'   $	 -10Q�69     5,      $ 0:0:0.2��6'   $ 0Q�69     5-      $ 0:0:0.3��6'   $ 10Q�69     5.      $ 0:0:0.4��6'   $ 0Q�69   5/      50      �� 51   
   .��52      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6,   $ 
hoidayIcon��6�   .\�53        $ 0��6'   $ 0Q�63     54      $ 0:0:0.1��6'   $	 -10Q�69     55      $ 0:0:0.2��6'   $ 0Q�69     56      $ 0:0:0.3��6'   $ 10Q�69     57      $ 0:0:0.4��6'   $ 0Q�69   58      59      �� 5:   
   .��5;      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6,   $ homeIcon��6�   .\�5<        $ 0��6'   $ 0Q�63     5=      $ 0:0:0.1��6'   $ 10Q�69     5>      $ 0:0:0.2��6'   $ 0Q�69     5?      $ 0:0:0.3��6'   $	 -10Q�69     5@      $ 0:0:0.4��6'   $ 0Q�69   5A      5B      �� 5C   
   .��5D      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6,   $ 	eventIcon��6�   .\�5E        $ 0��6'   $ 0Q�63     5F      $ 0:0:0.1��6'   $ 10Q�69     5G      $ 0:0:0.2��6'   $ 0Q�69     5H      $ 0:0:0.3��6'   $	 -10Q�69     5I      $ 0:0:0.4��6'   $ 0Q�69   5J      5K      �� 5L   
   .��5M      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6,   $ 
hoidayIcon��6�   .\�5N        $ 0��6'   $ 0Q�63     5O      $ 0:0:0.1��6'   $ 10Q�69     5P      $ 0:0:0.2��6'   $ 0Q�69     5Q      $ 0:0:0.3��6'   $	 -10Q�69     5R      $ 0:0:0.4��6'   $ 0Q�69   5S      5T      5V      	 � Triggers	 5W      :� 5X   
   
 :� RoutedEvent$
 UIElement.MouseEnter��6    :� 
SourceName$ contactBorder��6:   .[�5Y      �� -   5         ��Name$" contactEnter_BeginStoryboard��5Y      #��[ 6D   5Z      :� 5[   
   $
 UIElement.MouseEnter��6   $ 
homeBorder��6:   .[�5\      �� -   5        $ homeEnter_BeginStoryboard��5\      #��[ 6A   5]      :� 5^   
   $
 UIElement.MouseEnter��6   $ eventBorder��6:   .[�5_      �� -   5        $  eventEnter_BeginStoryboard��5_      #��[ 6B   5`      :� 5a   
   $
 UIElement.MouseEnter��6   $ holidayBorder��6:   .[�5b      �� -   5        $" holidayEnter_BeginStoryboard��5b      #��[ 6D   5c      :� 5d   
   $
 UIElement.MouseLeave��6   $ contactBorder��6:   .[�5e      �� -   5        $" contactLeave_BeginStoryboard��5e      #��[ 6D   5f      :� 5g   
   $
 UIElement.MouseLeave��6   $ 
homeBorder��6:   .[�5h      �� -   5        $ homeLeave_BeginStoryboard��5h      #��[ 6A   5i      :� 5j   
   $
 UIElement.MouseLeave��6   $ eventBorder��6:   .[�5k      �� -   5        $  eventLeave_BeginStoryboard��5k      #��[ 6B   5l      :� 5m   
   $
 UIElement.MouseLeave��6   $ holidayBorder��6:   .[�5n      �� -   5        $# hollidayLeave_BeginStoryboard��5n      #��[ 6E   5o      :� 5p   
   $
 UIElement.MouseEnter��6   $ documentIcon��6:   .[�5q      �� -	   5        $' !documentIconEnter_BeginStoryboard��5q       	 documentEnter#��[	 6I   5r      :� 5s   
   $
 UIElement.MouseLeave��6   $ documentIcon��6:   .[�5t      �� -
   5        $' !documentIconLeave_BeginStoryboard��5t       
 documentLeave#��[
 6I   5u      .��5w      � |�. .+�5x   
   �� -   5         ��Name$
 back��5x      $��img/home_Page.png��6   $��-10,-10,-14,-4q�69   $	��734��6Q   $
��1304��6^   |�. 6|   �� 5y   
   -   5        $��1q�5y      $��40��6%   $��0,0,72,0q�61   $	��Top=�6C   ���	#00EA3F3F6r   �� 5{   
   -   5        $ 	iconClose��5{      $��Right=�6#   $��12��6?   $��icons/closeIcon.png��6K   $
��Fill=�6h   $	��Top=�6w   $��12��6�   $��	0,15,10,0q�6�    K� ZIndex$ 1��6�    J� OpacityMask
 �  ��6  �� 5|   
   -   5        $ iconCloseHover��5|      $��12��6(   $��icons/closeIconHover.png��64   $
��Fill=�6V   $	��Top=�6e   $��	0,15,10,0q�6}   $ 3��6�   $��Right=�6�   $��12��6�   $y�Hidden=�6
  �� 5}   
   -   5        $ minimizeHover��5}      $��3��6'   $��icons/minimizeHover.png��62   $
��Fill=�6S   $	��Top=�6b   $��	0,19,47,0q�6z   $ 1��6�   $��Right=�6  $��12��6,   6�   Z� 6,  �� 5~   
   -   5        $ minimize��5~      $��3��6"   $��icons/minimize.png��6-   $
��Fill=�6I   $	��Top=�6X   $��	0,19,47,0q�6p   $ 1��6�   $��Right=�6�   $��12��6  �� 5   
   -   5         ��Name$ minimizeBtn��5       � ToolTip$ Minimiser la fenêtre��6)    ^� ShowDuration$
 2000��6H   $��40��6k   $	��Top=�6w   $��
1208,0,0,0q�6�   $ 0��6�   $
��Left=�6�   $��38��6�    J� Opacity$ 0Q�65  
���   �6A  �� 5�   
   -   5        $ closeBtnBack��5�      $ Fermer la fenêtre��6*   $
 2000��6F   $��40��6i   $	��Top=�6u   $ 0Q�6�   
�������$��Right=�6�   $��35��6  $��0,0,-1,0q�6  �� 5�   
   ���	#FF2A84A8$	��5,1q�6)   $��Right=�6?   $��0,167.512,566,-1.512q�6[   $��5��6y   �� 5�   
   -   5        $ documentIcon��5�      $ 	Documents��6&   $
 2000��6:   $
��Left=�6]   $��75��6x   $��1111,74,0,0q�6�   $	��Top=�6�   $��93��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��icons/IconDocument.png��6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      5�      �� 5�   
   -   5         ��Name$ listeContactes��5�      ���	#FF3F7988��. $��Disabled=�6}   $��Visible=�6�   $��270,172.666,570,0q�6�   $	��371��6  $	��Top=�6  $��0,2,0,0q�6<  ��6B   Z� ��6&  Z� ��5�      �� 5�       �� 
TargetType" ��6   .�5�      ��  �� Property � �� �� Value$ 40��6/   �� 5�       � �� �	#FF56A5BA63   �� 5�       � ��$ 20(�61   �� 5�       � ��$
 Bold"�63   5�      5�      �� 5�   
   -   5         ��Name$ ajouterContact��5�      $��Ajouter contacte��6)   $��495,0,625,83.04q�6D   $��Bottom=�6]   $��29.96��6x   $��16(�6�   �� 5�   
   -   5        $ ajouterContact_confirm��5�      $��	Confirmer��61   $��495,0,625,83.04q�6E   $��Bottom=�6^   $��29.96��6y   $y�Hidden=�6�   $��16(�6�   �� 5�   
   $��img/profilPhoto.png��6   $��0,186,428,0q�6-   $��Right=�6B   $	��110��6^   $	��120��6j   $	��Top=�6w   �� 5�   
   -   5         ��Name$	 nom��5�      $��0,219.68,8.425,0q�6!   $��32(�6;   $��366.575��6I   $��Comic Sans MS)�6Y    �� Padding$ 3,6,0,0q�6t   $ 0.5,0.5&�6�    � UseLayoutRounding .  $��Right=�6�   $	��Top=�6�   $
��Bold"�6�   ���	#FF2673916  �� 5�   
   -   5        $ image��5�      $��Right=�6   $��0,0,470,316q�6;   $��25��6P   $��img/phone.png��6[   $��30��6r   $��Bottom=�6~   �� 5�   
   -   5        $ 	telephone��5�      $��0,358.957,142,315.043q�6'   $��16(�6F   $	��239��6T   $��Comic Sans MS)�6`   $ 6,6,0,0q�6{   $ 0.5,0.5&�6�    .  $��Right=�6�   �� 5�   
   -   5        $ image1��5�      $��Right=�6    $��30��6<   $��0,0,470,240q�6H   $��Bottom=�6]   $��30��6x   $��img/position.png��6�   $ 1.271,2.521&�6�   �� 5�   
   -   5        $ adresse��5�      $��0,0,71.788,233.043q�6%   $��16(�6A   $��309.212��6O   $��Comic Sans MS)�6_   $ 5,6,0,0q�6z   $ 0.5,0.5&�6�    .  $��Right=�6�   $��Bottom=�6�   $��46.957��6�   �� 5�   
   -   5        $ image1_Copy��5�      $��Right=�6%   $��30��6A   $��0,0,462,166q�6M   $��Bottom=�6b   $��30��6}   $��img/Mail.png��6�   $ 1.271,2.521&�6�   �� 5�   
   -   5        $ image1_Copy1��5�      $��Right=�6&   $��30��6B   $��0,0,462,83.04q�6N   $��Bottom=�6e   $��30��6�   $��img/website.png��6�   $ 1.271,2.521&�6�   �� 5�   
   -   5        $ email��5�      $��0,0,71.788,151.536q�6#   $��16(�6?   $��309.212��6M   $��Comic Sans MS)�6]   $ 5,6,0,0q�6x   $ 0.5,0.5&�6�    .  $��Right=�6�   $��Bottom=�6�   $��46.957��6�   �� 5�   
   -   5        $
 site��5�      $��0,0,71.788,66.083q�6"   $��16(�6=   $��309.212��6K   $��Comic Sans MS)�6[   $ 5,6,0,0q�6v   $ 0.5,0.5&�6�    .  $��Right=�6�   $��Bottom=�6�   $��46.957��6�   �� 5�   
   -    5        $ modif��5�      $��modifier��6    $��	0,0,34,25q�63   $��Bottom=�6F   $��29.96��6a   $��Right=�6p   $	��116��6�   $��16(�6�   6�   �� 5�   
   -!   5        $ 	supprimer��5�      $��	supprimer��6$   $��
0,0,168,25q�68   $��Bottom=�6L   $��30��6g   $��Right=�6t   $	��116��6�   $��Comic Sans MS)�6�   $��16(�6�   $y�Hidden=�6�   �� 5�   
   ���	#FF267391$��2q�6)   $��Right=�6=   $��0,119.093,213.219,218.053q�6Y   $��5��6|   $ 0.5,0.5&�6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�       �� Angle$ 90Q�6&   T� 5�      5�      5�      �� 5�   
   -"   5        $ homeIcon��5�      $��icons/homeIcon.png��6"   $��80��6>   $��80��6J   $
��Left=�6U   $��
335,70,0,0q�6p   $	��Top=�6�   $ 0.5,0.5&�6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      5�      �� 5�   
   -#   5         ��Name$ 
homeBorder��5�      $ Acceuil��6%   $
 2000��67   $��1q�6Z   $
��Left=�6n   $��80��6�   $��
335,70,0,0q�6�   $	��Top=�6�   $��80��6�   ���	#000000006�   �� 5�   
   -$   5        $ 	eventIcon��5�      $��icons/eventIcon.png��6#   $��80��6@   $��80��6L   $��
545,70,0,0q�6W   $	��Top=�6k   $
��Left=�6�   $ 0.5,0.5&�6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      5�      �� 5�   
   -%   5        $ eventBorder��5�      $ Planning��6&   $
 2000��69   $��1q�6\   $
��Left=�6p   $��80��6�   $��
545,70,0,0q�6�   $	��Top=�6�   $��80��6�   ���	#000000006�   �� 5�   
   -&   5        $ contactIcon��5�      $��icons/contactIcon.png��6%   $��80��6D   $��80��6P   $��
0,70,460,0q�6[   $	��Top=�6o   $��Right=�6�   $ 0.5,0.5&�6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      5�      �� 5�   
   -'   5        $ contactBorder��5�      $ Contacts��6(   $
 2000��6;   $��1q�6^   $��Right=�6r   $��80��6�   $��
0,70,460,0q�6�   $	��Top=�6�   $��80��6�   ���	#000000006�   �� 5�   
   -(   5        $ 
hoidayIcon��5�      $��icons/holidayIcon.png��6$   $��80��6C   $	��100��6O   $��0,72.241,250.518,0q�6[   $	��Top=�6w   $��Right=�6�   $ 0.5,0.5&�6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      5�      �� 5�   
   -)   5        $ holidayBorder��5�      $ Jours fériés��6(   $
 2000��6?   $��1q�6b   $��Right=�6v   $��80��6�   $��
0,70,255,0q�6�   $	��Top=�6�   $��95.518��6�   ���	#000000006�   �� 5�   
   -*   5        $ confirm��5�      $��	confirmer��6"   $��	0,0,34,25q�66   $��Bottom=�6I   $��30��6d   $��Right=�6�   $	��116��6�   $y�Hidden=�6�   �� 5�   
   -+   5         ��Name$ 	nomChange��5�      $��Right=�6%   $��0,219.68,40.425,0q�6A   $��32(�6\   $��334.575��6j   $��Comic Sans MS)�6z   $��0,5,0,0q�6�   $ 0.5,0.5&�6�    .  $	��Top=�6�   $
��Bold"�6�   ���	#FF267391���	#FF267391$��0,0,0,1q�6P  $��58��6j  $y�Hidden=�6v  ��6:  Z� 6v  �� 5�   
   -,   5        $ adresseCange��5�      $��0,0,71.788,233.043q�6(   $��16(�6D   $	��307��6R   $��Comic Sans MS)�6^   $��0,5,0,0q�6y   $ 0.5,0.5&�6�    .  $��Right=�6�   $��Bottom=�6�   $��46.957��6�   ���	#FF267391$��0,0,0,1q�6:  $y�Hidden=�6T  ��6$  Z� 6T  �� 5�   
   --   5        $ telephoneChange��5�      $��0,0,71,315.043q�6,   $��16(�6D   $	��307��6R   $��Comic Sans MS)�6^   $��0,5,0,0q�6y   $ 0.5,0.5&�6�    .  $��Right=�6�   $��Bottom=�6�   $��46��6�   ���	#FF267391$��0,0,0,1q�66  $y�Hidden=�6P  ��6   Z� 6P  �� 5�   
   -.   5        $ emailChange��5�      $��0,0,71.788,151.536q�6'   $��16(�6C   $	��307��6Q   $��Comic Sans MS)�6]   $��0,5,0,0q�6x   $ 0.5,0.5&�6�    .  $��Right=�6�   $��Bottom=�6�   $��46.957��6�   $y�Hidden=�6  ���	#FF267391$��0,0,0,1q�6M  ��6  Z� 6M  �� 5�   
   -/   5        $ 
siteChange��5�      $��0,0,71.788,66.083q�6&   $��16(�6A   $	��307��6O   $��Comic Sans MS)�6[   $��0,5,0,0q�6v   $ 0.5,0.5&�6�    .  $��Right=�6�   $��Bottom=�6�   $��46.957��6�   $y�Hidden=�6	  ���	#FF267391$��0,0,0,1q�6K  ��6  Z� 6K  �� 5�   
   -0   5          ��Name$  label��5�      $��Fakkarni��6   $��8,5,0,0q�62   $	��212��6C   $��36��6O   $	��Top=�6[   $
��Left=�6s   $��40,0,5,5q�6�   $��18(�6�   $��Segoe Print)�6�   $
��Bold"�6�   ���	#FF0F688B$��0q�6  ��6�   Z� 6  �� 5�   
   -1   5        $ image2��5�      $
��Left=�6    $��28��6;   $��9,6,0,0q�6G   $	��Top=�6X   $��34��6p   $��icons/logo.png��6{   o� 5�   
   -2   5        ! o�Name$! userMenu��5�      $	��159��6!   $��44��6-   $
��Left=�69   $��
16,170,0,0q�6T   $	��Top=�6h   $y�Hidden=�6�   .@�5�      m� -3   5        $��_Modifier le compte��5�   )   $	��159��6F   $��22��6R   ���	#FF0F688B��6u   Z� " m� Icon" 5�      �� 5�      $��icons/configIcon.png��6   $��12��6:   $��Right=�6E   $��0,2,2,2q�6a   5�      m� 5      -4   5        $��_Déconnecter��5      $��22��6-   $	��159��69   ���	#FF0F688B��6E   Z� " 5     �� 5     $��icons/logoutIcon.png��6   $��12��6:   $��Right=�6E   $��0,2,2,2q�6a   5     5     �� 5  
   $��	-1,72,0,0q�6   $
��Left=�6(   $	��271��6C   $	��100��6O   $	��Top=�6\   .+�5     �� -5   5        $ avatar��5     $��64��6$   $��0q�60   $��48��6;   $��img/Person1.png��6F   # � Cursor$
# Hand��6_   $��Center=�6�   �� 5
     -6   5        $  	cnctdUser��5
     $��0q�6(   
�������$	��228��6F   $��14(�6R   $
��Bold"�6w   $
# Hand��6�   $��42��6�   $ 0.478,-0.833&�6�   $��hamoul khaled��6�   $��Center=�6�   $��Center=�6  $��Center=�65  $��Center=�6W  ��6`   Z� 6W  5     5     5     