   M S B A M L   `   `   `  ����E  ADentest.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Dentest.UI.PagesDentest.UI.Pages  5      #    Dentest.UI.Pages.PaccientPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:Dentest.UI.Pages     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        $��
mainWindow��5        N� Title$  MainPage��5
         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper N� 
Background# �  5        MaterialDesignFont N� 
FontFamily# �  5      .��5      � .+�5   
   � -   5        $��progressBar��5       % !MaterialDesignCircularProgressBar#���  5      $��Center=�5      $��16q�5       � IsIndeterminate .  � Value$ 0Q�5       K� ZIndex$ 1��5      $y�Hidden=�5      #  MaterialDesignThemes.Wpf.Card  5   
   $��10q�6   $��16q�5       .��5"      �� .+�5$      ��  �� Orientation$ 
Horizontal=�6   .+�5&      �� -   5        $��txSearch��51       ( $MaterialDesignFilledTextFieldTextBox#��[ 5&      $	��Top=�5'      	 �� AcceptsReturn	 . 
 �� TextWrapping$

 Wrap=�5)      $	��395��5*      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ HIZLI ARAMA��5+      $��5q�5-      $��0��5.      $��1��5/      $
��Left=�52      {�5,      ��  �� Path$ 	IsChecked� �� ElementName$9 3MaterialDesignFilledTextFieldTextBoxEnabledComboBox��52      �� 54      -   5        $	��add��57      $	��170��54      $��20 0 0 0q�55      $��Center=�56      .��58   /   
Hasta Ekle6;   5;      � 5=      .+�5>      &   System.Windows.Controls.DataGrid  -   5        $��	mDataGrid��5>      $��0 8 0 0q�5?         CanUserSortColumns .    CanUserAddRows .     AutoGenerateColumns .  -  'MaterialDesignThemes.Wpf.DataGridAssist   CellPadding$ 13 8 8 8q�5C         ColumnHeaderPadding$ 8q�5D      $	��500��5E         Columns 5H      1  +MaterialDesignThemes.Wpf.DataGridTextColumn  5J      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6@      
IsReadOnly .    Header$
 Adı��5M   @   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 5L   @   �� *NAME+5M   @     5O      $ * 6@    . $ SoyaAdı��5R   @    5Q   @   �� *	SURNAME+5R   @     5T      $ * 6@    . $ Telefon��5W   @    5V   @   �� *PHONE+5W   @     5Y      $ * 6@    . $ TC��5\   @    5[   @   �� *
PERSONELID+5\   @     5_      $
 1.2* 6@    . $ Doğum Tarihi��5b   @    5a   @   �� *
BIRTHDAY+ �� StringFormat$ {0:dd.MM.yyyy}��5b   @     5d      $ 1* 6@    . $ Cinsiyet��5g   @    5f   @   �� *GENDER+5g   @     5i      $ 1* 6@    . $ Sigorta No.��5l   @    5k   @   �� *INSURANCENO+5l   @     5n      $ 2* 6@    . $ Adres��5q   @    5p   @   �� *ADRESS+5q   @   4
  .System.Windows.Controls.DataGridTemplateColumn
  5t      $
 0.7* 66    
  CellTemplate 5v   "   �� 5x   &   .R�5z   *   �� $��Delete��5}   1   -   5         $  MaterialDesignRaisedAccentButton#��[ 5z   1   ���#f44336 � ToolTip$	 Sil��5   1   ��5|   1   0  *MaterialDesignThemes.Wpf.PackIconExtension  *DeleteEmpty+ � 	Resources 5�   .     SecondaryAccentBrush �� Color��%/   &	       �� 5�   2   $ #f44336��5�   B   5�   /   5�   +   5�   '   5�      
  5�      $
 0.7* 66    5�   "   �� 5�   &   .R�5�   *   ��  ��Name$
 Edit��63   -   5        $ Düzenle��5�   3   ��5�   3     *
ModeEdit+5�   3   5�   '   5�      5�      5�      5�      5�      5�      5�      