   M S B A M L   `   `   `  ����E  ADentest.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Dentest.UI.PagesDentest.UI.Pages  5      7 clr-namespace:Dentest.UI.HelpersDentest.UI.Helpers  5          Dentest.UI.Pages.ListPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:Dentest.UI.Pages     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -local1 clr-namespace:Dentest.UI.Helpers  5      -   5        $��
mainWindow��5        N� Title$  MainPage��5
         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper N� 
Background# �  5        MaterialDesignFont N� 
FontFamily# �  5      .��5      � .+�5   
   � -   5        $��progressBar��5       % !MaterialDesignCircularProgressBar#���  5      $��Center=�5      $��16q�5       � IsIndeterminate .  � Value$ 0Q�5       K� ZIndex$ 1��5      $y�Hidden=�5      #  MaterialDesignThemes.Wpf.Card  5   
   $��10q�6   $��16q�5      .��5!      �� .+�5#      ��  �� Orientation$ 
Horizontal=�6   .+�5%      �� -   5        $��txSearch��50       ( $MaterialDesignFilledTextFieldTextBox#��[ 5%      $	��Top=�5&      	 �� AcceptsReturn	 . 
 �� TextWrapping$

 Wrap=�5(      $	��395��5)      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ HIZLI ARAMA��5*      $��5q�5,      $��0��5-      $��1��5.      $
��Left=�51      {�5+      ��  �� Path$ 	IsChecked� �� ElementName$9 3MaterialDesignFilledTextFieldTextBoxEnabledComboBox��51      �� 53      -   5        $	��add��56      $	��170��53      $��20 0 0 0q�54      $��Center=�55      .��57   /   Rendevo Ekle6=   5;      � 5=      .+�5>      &   System.Windows.Controls.DataGrid  -   5        $��	mDataGrid��5>      $��0 8 0 0q�5?         CanUserSortColumns .    CanUserAddRows .     AutoGenerateColumns .  -  'MaterialDesignThemes.Wpf.DataGridAssist   CellPadding$ 13 8 8 8q�5C         ColumnHeaderPadding$ 8q�5D      $	��500��5E         Columns 5H      1  +MaterialDesignThemes.Wpf.DataGridTextColumn  5J      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6@      
IsReadOnly .    Header$ 
Hasta Adı��5M   @   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 5L   @   �� *PATIENTFULLNAME+5M   @     5O      $ 1* 6@    . $ Doktor Adı��5R   @    5Q   @   �� *DOCTORFULLNAME+5R   @     5T      $ 1* 6@    . $ Tarih��5W   @    5V   @   �� *DATE+ �� StringFormat$ {0:dd.MM.yyyy}��5W   @     5Y      $ 1* 6@    . $
 Saat��5\   @    5[   @   �� *HOUR+5\   @     5_      $ 1* 6@    . $ Fiyat��5b   @    5a   @   �� *PRICE+5b   @     5d      $ 1* 6@    . $ İşlem��5g   @    5f   @   �� *TYPE+5g   @     5i      $ 1* 6@    . $ 
Açıklama��5l   @    5k   @   �� *DESCRIPTION+5l   @   4
  .System.Windows.Controls.DataGridTemplateColumn
  5o      $ * 66    
  CellTemplate 5p   "   �� 5r   &   .R�5s   *   ��  � 	Resources 5t   .   5   /Dentest.UI.Helpers.NotBoolToVisibilityConverter   NotBoolToVisibilityConverter2   ,Dentest.UI.Helpers.BoolToVisibilityConverter  BoolToVisibilityConverter��%:   &	       &	        5v   2   6V     5w   2   6S   5x   /   .��5y   .   �� $ 
Horizontal=�69   .+�5z   2   �� $��	BEKLEMEDE��69     MaterialDesignFlatButton#��[ 5}   9   $��25��5~   9    � Cursor$
 None��5   9   
���  ����5{   9   �� *ISCAME+y�5|   9   �� *ISCAME+ �� 	Converter# [ 5�   9   �� 5�   2   $��GELDİ��69   $��25��5�   9   $
 None��5�   9   #��[ 5�   9   
��� � ���5�   9   �� *ISCAME+y�5�   9   �� *ISCAME+# [ 5�   9   5�   /   5�   +   5�   '      HeaderTemplate 5�   "   �� 5�   &   .R�5�   *   �� $��Center=�60   $��Durumu��5�   0   6C   5�   '   5�      
  5�      $ * 66    5�   "   �� 5�   &   .R�5�   *   ��  5�   .   ��%:   &	       &	        5�   2   6V     5�   2   6S   5�   /   .��5�   .   �� $ 
Horizontal=�69   .+�5�   2   �� $��
ÖDENMEDİ��69   #��[ 5�   9   $��25��5�   9   $
 None��5�   9   
���  ����5�   9   �� *ISPAID+y�5�   9   �� *ISPAID+# [ 5�   9   �� 5�   2   $��ÖDENDİ��69   $��25��5�   9   $
 None��5�   9   #��[ 5�   9   
��� � ���5�   9   �� *ISPAID+y�5�   9   �� *ISPAID+# [ 5�   9   5�   /   5�   +   5�   '    5�   "   �� 5�   &   .R�5�   *   �� $��Center=�60   $��Ödeme��5�   0   6B   5�   '   5�      
  5�      $
 0.7* 66    5�   "   �� 5�   &   .R�5�   *   �� $��Delete��5�   1   -   5         $  MaterialDesignRaisedAccentButton#��[ 5�   1   ���#f44336 � ToolTip$	 Sil��5�   1   ��5�   1   0  *MaterialDesignThemes.Wpf.PackIconExtension  *DeleteEmpty+ 5�   .    	 SecondaryAccentBrush �� Color��%/   &		       �� 5�   2   $ #f44336��5�   B   5�   /   5�   +   5�   '   5�      
  5�      $
 0.7* 66    5�   "   �� 5�   &   .R�5�   *   ��   ��Name$
  Edit��63   -   5        $ Düzenle��5�   3   ��5�   3     *
ModeEdit+5�   3   5�   '   5�      5�      5�      5�      5�      5�      5�      