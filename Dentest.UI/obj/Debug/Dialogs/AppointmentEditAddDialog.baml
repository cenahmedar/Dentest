   M S B A M L   `   `   `  ����E  ADentest.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Dentest.UI.DialogsDentest.UI.Dialogs  5      1    +Dentest.UI.Dialogs.AppointmentEditAddDialog   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Dentest.UI.Dialogs     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
      -   5        $��
mainWindow��5      $	��460��5      $	��800��5	         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      � .+�5   
   � -   5        $��progressBar��5       % !MaterialDesignCircularProgressBar#���  5      $��Center=�5      $��16q�5       � IsIndeterminate .  � Value$ 0Q�5       K� ZIndex$ 1��5      $y�Hidden=�5      � 5   
   $��10q�6    � RowDefinitions 5!      �� 5"      $��7* �6    6.   �� 5#      $��* �6    6-   .+�5'      �� $��0��6   $��Center=�5(       �� Orientation$ Vertical=�5)      .+�5+      �� $��Center=�6   $ 
Horizontal=�5,      .+�5-      �� $ Vertical=�6!   $	��350��5.   !   $��0 0 0 0q�5/   !   .+�51      �� 
�������Doktor6>   �� 52      -   5        $��comboDoctor��56   #   $	��350��52   #   $��0 0 0 0q�53   #   $��Bottom=�54   #   $��50��55   #   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton .  & "MaterialDesignFloatingHintComboBox#��[ 58   #    �� DisplayMemberPath$
 NAME��59   #   5;      5=      �� 5?      $ Vertical=�6!   $	��350��5@   !   $��20 0 0 0q�5A   !   .+�5C      �� 
�������Hasta6=   �� 5D      -   5        $��
comboHasta��5H   #   $	��350��5D   #   $��0 0 0 0q�5E   #   $��Bottom=�5F   #   $��50��5G   #    . #��[ 5J   #   $
 NAME��5K   #   5L      5N      5P      �� 5R      $��Center=�6   $ 
Horizontal=�5S      $��0 20 0 0q�5T      .+�5U      (  "System.Windows.Controls.DatePicker  -   5        $��
pickerDate��5Y   !   $	��350��5U   !   )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Tarih��5V   !    " MaterialDesignFilledDatePicker#��[ 5W   !   $��0 0 0 0q�5X   !   5Z   !   �� 5\      $ Vertical=�6!   $	��350��5]   !   $��20 0 0 0q�5^   !   .+�5`      �� 
�������Saat6<   �� 5a      -   5        $��	comboHour��5e   #   $	��350��5a   #   $��0 0 0 0q�5b   #   $��Bottom=�5c   #   $��50��5d   #    . #��[ 5g   #   $
 NAME��5h   #   5i      5k      5l      �� 5n      $��Center=�6   $ 
Horizontal=�5o      $��0 20 0 0q�5p      .+�5q      �� -   5        $��txPrice��5w       ( $MaterialDesignFilledTextFieldTextBox#��[ 5q      $	��Top=�5r      
 �� AcceptsReturn
 .  �� TextWrapping$
 Wrap=�5t      $	 Fiyat��5u      $	��350��5v      .��5y   I   5z      �� 5|      $ Vertical=�6!   $	��350��5}   !   $��20 0 0 0q�5~   !   .+�5�      �� 
�������	İşlem6=   �� 5�      -   5        $��	comboType��5�   #   $	��350��5�   #   $��0 0 0 0q�5�   #   $��Bottom=�5�   #   $��50��5�   #    . #��[ 5�   #   $
 NAME��5�   #   5�      5�      5�      �� 5�      $��Center=�6   $ 
Horizontal=�5�      $��0 20 0 0q�5�      .+�5�      �� -	   5        $��txDescription��5�      #��[ 5�      $	��Top=�5�      
 . $
 Wrap=�5�      $	 
Açıklama��5�      $	��720��5�      .��5�   3   5�      5�      �� 5�      $��Center=�6   $ 
Horizontal=�5�      $��0 20 0 0q�5�      .+�5�      �� $ 
Horizontal=�6!   $	��350��5�   !   $��0 0 0 0q�5�   !   .+�5�      �� 
�������$��Center=�66   
Geldi Mi6[   �� 5�      -
   5        $��chCame��5�   #   $��Center=�5�   #   $��	260 0 0 0q�5�   #    � LayoutTransform 5�      �� 5�   "    �� ScaleX$ 2Q�61    �� ScaleY$ 2Q�5�   1   5�      5�      �� 5�      $ 
Horizontal=�6!   $	��350��5�   !   $��20 0 0 0q�5�   !   .+�5�      �� 
�������$��Center=�5�   $   
Ödendi Mi6J   �� 5�      -   5        $��chPaid��5�   #   $��Center=�5�   #   $��	250 0 0 0q�5�   #    5�      �� 5�   "   $ 2Q�61   $ 2Q�5�   1   5�      5�      5�      5�      �� 5�      $��1��6   $��Right=�5�      $��0 0 20 0q�5�      $ 
Horizontal=�5�      .+�5�      �� -   5        $��close��5�      $	��100��5�      $��0 0 30 0q�5�       $  MaterialDesignRaisedAccentButton#��[ 5�      ���#f44336
�������$�� IPTAL��5�       � 	Resources 5�        SecondaryAccentBrush �� Color��%/   &	       �� 5�      $ #f44336��5�   *   5�      5�      �� 5�      -   5        $
��save��5�      $	��100��5�      #��[ 5�      
�������$��KAYDET��5�      5�      5�      5�      5�      5�      