   M S B A M L   `   `   `  ����I  ETheHangmanGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:TheHangmanGame.ViewsTheHangmanGame.Views  5      '    !TheHangmanGame.Views.SettingsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .local"clr-namespace:TheHangmanGame.Views  5      
���   �.��5
      �   � ColumnDefinitions  5   
   �� 5      $��1* �6   �� 5      $	��700 �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��1* �6   �� 5      $	��100 �6   .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $��10q�6   $	��Top=�6%   $
��Left=�6=   .+�5      �� $��60��6   $��40��6$      MaterialDesignRaisedButton#��[  60   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��5   !   $��2q�6O   
�������
�������
������� � ToolTip$ Login��5   F   ��6V   ��  �� Path$ BackCommand�.��6}   Back5      5      �� 5       $ 
Horizontal=�6   $��10q�62   $
��Left=�6>   .+�5!      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 User=�6*   $��25��66   $��25��6A   
�������6b   �� 5"      $
��10 0q�6d   $��Impact)�6r   $��20(�6�   
�������$	��250��6�   ��6   �� *CurrentUsername+ �� UpdateSourceTrigger$ PropertyChanged=�6�   5#      5$      �� 5&   
   -   5        $	��plm��5&      $��1��6   $��1��6+   $��Uniform=�68   ��6J   �� *	ImagePath+�� 5'   
   $��2��6   $��1��6"   $ 
Horizontal=�62   $��Center=�6K   .+�5(      �� $��10q�6   $	��Top=�6%   $
��Left=�6=   .+�5)      �� $��80��6   $��40��6$   #��[  60   $ 10��5*   !   $��2q�6O   
�������
�������
�������$ previous image��5+   F   ��6_   �� *PreviousImageButton+.��6�   
Previous5,      5-      �� 5.      $��10q�6   $	��Top=�6%   $��Right=�6=   .+�5/      �� $��80��6   $��40��6$   #��[  60   $ 10��50   !   $��2q�6O   
�������
�������
�������$ 
next image��51   F   ��6[   �� *NextImageButton+.��6   Next52      53      54      �� 55   
   $��80��6   $��40��6   #��[  6(   $ 10��56   !   $��5q�6O   
�������
�������
���  ��$ 
next image��57   D   $��2��6Y   $��2��6i   ��6v   �� *UpdateAvatar+.��6�   Update58      �� 59   
   $	��140��6   $��40��6   #��[  6)   $ 10��5:   !   $��5q�6O   
�������
�������
���  ��$ 
next image��5;   D   $��0��6Y   $��2��6i   ��6v   �� *DeleteAccount+.��6�   Delete Account5<      5=      5>      