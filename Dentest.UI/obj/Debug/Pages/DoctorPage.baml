   M S B A M L   `   `   `  ����E  ADentest.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Dentest.UI.PagesDentest.UI.Pages  5      !    Dentest.UI.Pages.DoctorPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:Dentest.UI.Pages     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        $��
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
��Left=�51      {�5+      ��  �� Path$ 	IsChecked� �� ElementName$9 3MaterialDesignFilledTextFieldTextBoxEnabledComboBox��51      �� 53      -   5        $	��add��56      $	��170��53      $��20 0 0 0q�54      $��Center=�55      .��57   /   Doktor Ekle6<   5:      � 5<      .+�5=      &   System.Windows.Controls.DataGrid  -   5        $��	mDataGrid��5=      $��0 8 0 0q�5>         CanUserSortColumns .    CanUserAddRows .     AutoGenerateColumns .  -  'MaterialDesignThemes.Wpf.DataGridAssist   CellPadding$ 13 8 8 8q�5B         ColumnHeaderPadding$ 8q�5C      $	��500��5D         Columns 5G      1  +MaterialDesignThemes.Wpf.DataGridTextColumn  5I      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6@      
IsReadOnly .    Header$
 Adı��5L   @   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 5K   @   �� *NAME+5L   @     5N      $ * 6@    . $ SoyaAdı��5Q   @    5P   @   �� *	SURNAME+5Q   @     5S      $ * 6@    . $ Telefon��5V   @    5U   @   �� *PHONE+5V   @     5X      $ * 6@    . $ TC��5[   @    5Z   @   �� *
PERSONELID+5[   @     5^      $
 1.2* 6@    . $ Doğum Tarihi��5a   @    5`   @   �� *
BIRTHDAY+ �� StringFormat$ {0:dd.MM.yyyy}��5a   @     5c      $ 2* 6@    . $ Adres��5f   @    5e   @   �� *ADRESS+5f   @   4
  .System.Windows.Controls.DataGridTemplateColumn
  5i      $
 0.5* 66    
  CellTemplate 5k   "   �� 5m   &   .R�5o   *   �� $��Delete��5r   1   -   5         $  MaterialDesignRaisedAccentButton#��[ 5o   1   ���#f44336 � ToolTip$	 Sil��5t   1   ��5q   1   0  *MaterialDesignThemes.Wpf.PackIconExtension  *DeleteEmpty+ � 	Resources 5u   .     SecondaryAccentBrush �� Color��%/   &	       �� 5v   2   $ #f44336��5w   B   5x   /   5y   +   5{   '   5~      
  5�      $
 0.5* 66    5�   "   �� 5�   &   .R�5�   *   ��  ��Name$
 Edit��63   -   5        $ Düzenle��5�   3   ��5�   3     *
ModeEdit+5�   3   5�   '   5�      5�      5�      5�      5�      5�      5�      