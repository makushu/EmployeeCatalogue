   M S B A M L   `   `   `  ����M  IEmployeeCatalogue3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:EmployeeCatalogue3.ViewEmployeeCatalogue3.View  5      7 clr-namespace:EmployeeCatalogue3EmployeeCatalogue3  5      *    $EmployeeCatalogue3.View.EmployeeView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:EmployeeCatalogue3.View     5      6	viewModel clr-namespace:EmployeeCatalogue3     5        N� Title$  EmployeeView��5
       N� 
Background
 �   � � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType   dataGridColumnHeader �� Property �� Value*  $System.Windows.Controls.DataGridCell  cellBackgroundColor �� Triggers �� Binding �� Value 
 button	 �� 
TargetType
 �� CornerRadius P� Property P� Value 	 label��%H  &	        &	 J     &	 �    &	 �    �� 5      "  6   .�5      ��  � ��$
 Bold"�6/   5      �� 5      "  6   .�5      ��  � ��
 ��  �6/    5      �� 5       6"   �� *Gender+ Male6=   .a�5      ��  � �� �#0099CC67   �� 5       � ��
 �   �67   5      �� 5       6"   �� *Gender+
 Female6=   .a�5      ��  � ��
 �����67   �� 5       � ��
 �   �67   5       5"      �� 5%      " ��6   .�5&      ��  � �� 5'      �� 5(      "	 ��6*   .R�5)      �� #��z��6%   $
 5��5*      $��1q�5+      
����  �._�5.   "   �� $��Center=�63   $��Center=�6P   5/   #   50      51      53       54      P� 55       �@J�IsMouseOver . . �56      ��  � �� �#0099CC67   �� 57       � ��
 �   �67   58      P� 59       �@J�IsMouseOver .  . �5:      ��  � ��
 �����67   �� 5;       � ��
 �   �67   5<      5>      �� 5A      " ��6   .�5B      ��  � ��
 �����6/   5C      5F      .��5I   
   � $��Center=�6   .+�5K      �� $
��Left=�6   $��/Images/search.png��6/   $��23��6K   $��	645,6,0,0q�6W   $	��Top=�6j   $��25��6�   �� 5L      -   5         ��Name$ txtSearchEmployeee��5L       � ToolTip$! Search for employee details��63   $
��Left=�6Y   $��23��6t   $��	670,6,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   .��6�    5M      ��%^   '��       �� 5N      " ��6   .�5O      ��  �@��CornerRadius$ 5��69   5P      5R      .��6%   5S      &   System.Windows.Controls.DataGrid  5W      -   5          Name$ grdEmployee��5W         AutoGenerateColumns .     
IsReadOnly . $
��Left=�6Z   $	��167��6u   $��	10,38,0,0q�6�   $	��Top=�6�   $	��800��6�    5X      ��%^   '��       �� 5Y      " ��6   .�5Z      ��  �@��CornerRadius$ 5��69   5[      5\       � ContextMenu 5^      �� 5_      .@�5`      m� -   5        $
��View��5`   #   6C   m� 5a      -   5        $
��Edit��5a   #   6D   5c         Columns 5f      0  *System.Windows.Controls.DataGridTextColumn  5g      ,  &System.Windows.Controls.DataGridColumn   	CellStyle# [ 6B      Header$
 NAME��6t      Width5  /System.Windows.Controls.DataGridLengthConverter$	 160 6�      HeaderStyle# [  6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *Name+6�     5h      # [ 6E   $ SURNAME��6v   $	 160 6�   # [  6�    6)   �� *	Surname+6�     5i      # [ 6h   $ DATE OF BIRTH��6�   $
 AUTO 6�   # [  6�    6)   �� *DateOfBirth+ �� StringFormat$ {0:dd/MM/yyyy}��6�     5j      # [ 6D   $ GENDER��6u   $
 AUTO 6�   -   5        
gender��# [  5j   �    6)   �� *Gender+6�     5k      # [ 6I   $ HOME ADDRESS��6z   $	 300 6�   # [  6�    6)   �� *HomeAddress+6�   5m      �� 5p      -   5         ��Name$ 
btnShowAdd��5p      #��[ 6)   $ Double click to add��6d   $	��Add��6�   $
��Left=�6�   $��
10,214,0,0q�6�   $	��Top=�6�   $��75��6�   ��6I   �� *Adding+6�   �� 5q      -   5        $ btnShowEdit��5q      #��[ 6*   $ Double click to edit��6J   $
��Edit��6i   $
��Left=�6x   $��715,214,0,0q�6�   $	��Top=�6�   $��75��6�   6�   � 5t      -   5         �Name$ grdAdd��5t      $
��Left=�6#   $	��202��6>   $��100,215,0,0q�6K   $	��Top=�6`   $	��265��6x   $y�Visible=�6�    � RowDefinitions 5u      �� 5v      $	��93* �6$   �� 5w      $	��47* �6$   �� 5x      $	��62* �6$   .+�5z      �� $
��Name��6   #��[ 6'   $
��Left=�6F   $	��Top=�6a    J� RenderTransformOrigin$ 0.615,0.617&�6y   $��10,0,0,0q�6�   �� 5{      -	   5        $ 
txtAddName��5{   D   $  Please enter employee name��6X   $
��Left=�6}   $��26��6�   $��95,0,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6   �� *Name+ �� Mode$ OneWayToSource=�6�   �� 5|      $��*��6   
���  ��$��20(�65   $
��Left=�6C   $��	220,0,0,0q�6^   $	��Top=�6q   $��18��6�   $��26��6�   �� 5~      $��Surname��6   #��[ 6*   $
��Left=�6I   $��	10,35,0,0q�6d   $	��Top=�6w   �� 5      -
   5        $ txtAddSurname��5   F   $# Please enter employee surname��6]   $
��Left=�6�   $��23��6�   $��	95,39,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6   �� *	Surname+$ OneWayToSource=�6�   �� 5�      $��*��6   
���  ��$��20(�65   $
��Left=�6C   $��
220,39,0,0q�6^   $	��Top=�6r   $��18��6�   $��26��6�   �� 5�      $��Date Of Birth��6   #��[ 60   $
��Left=�6O   $��	10,74,0,0q�6j   $	��Top=�6}   $��2��6�   (  "System.Windows.Controls.DatePicker  5�      -   5           Name$  dpAddDateOfBirth��5�   O   $* $Please select employee date of birth��6i   !   DisplayDateStart$! 1/1/1955X�6�   "   DisplayDateEnd$" 
12/31/2005X�6�   $
��Left=�6�   $��	95,76,0,0q�6�   $	��Top=�6�   $��2��6  #   Text# 6   �� *DateOfBirth+$ OneWayToSource=�6  �� 5�      $��*��6   
���  ��$��20(�65   $
��Left=�6C   $��
220,75,0,0q�6^   $	��Top=�6r   $��18��6�   $��26��6�   $��2��6�   �� 5�      $��Gender��6   #��[ 6)   $
��Left=�6H   $��10,12.4,0,0q�6c   $	��Top=�6x   $��1��6�   �� 5�      -   5        $��cboAddGender��5�   G   $# Please select employee gender��6[   $
��Left=�6�   $��95,15.4,0,0q�6�   $	��Top=�6�   $	��120��6�   $��1��6�   $ �� Text$ 6   �� *Gender+$ OneWayToSource=�.@�5�      �� $��Female��6#   �� 5�      $
��Male��6#   5�      �� 5�      $��*��6   
���  ��$��20(�65   $
��Left=�6C   $��220,20.2,0,0q�6^   $	��Top=�6t   $��18��6�   $��26��6�   $��1��6�   $ 0.725,0.846&�6�   �� 5�      $��Home Address��6   #��[ 6/   $
��Left=�6N   $��10,2,0,0q�6i   $	��Top=�6{   $��2��6�   �� 5�      -   5        $ txtAddHomeAddress��5�   K   $( "Please enter employee home address��6f   $
��Left=�6�   $��23��6�   $��95,5,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��2��6  ��6   �� *HomeAddress+$ OneWayToSource=�6  �� 5�      $��*��6   
���  ��$��20(�65   $
��Left=�6C   $��	220,2,0,0q�6^   $	��Top=�6q   $��18��6�   $��26��6�   $��2��6�   $ 0.725,0.846&�6�   �� 5�      -   5        $ btnAddEmployee��5�      #��[ 61   $��Add Employee��6Q   $
��Left=�6h   $	��Top=�6�   $��89��6�   $��	10,33,0,0q�6�   $��2��6�   6�   �� 5�      -   5        $ btnCloseAddGrid��5�      #��[ 62   $��Close��6R   $
��Left=�6b   $��
140,33,0,0q�6}   $��2��6�   $	��Top=�6�   $��75��6�   $ 
0.936,0.51&�6�   6�   5�      � 5�      -   5        $ grdEdit��5�      $
��Left=�6$   $	��269��6?   $��447,215,0,0q�6L   $	��Top=�6a   $	��263��6y   $y�Visible=�6�   .+�5�      �� $��Employee Id��6   #��[ 6.   $
��Left=�6M   $	��Top=�6h   $ 0.615,0.617&�6�   $��10,0,0,0q�6�   �� 5�      -   5        $ txtEditEmployeeId��5�   >   $ Please enter employee Id��6Y   $
��Left=�6|   $��26��6�   $��95,0,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6   �� *Id+$ TwoWay=�6�   �� 5�      $��*��6   
���  ��$��20(�65   $
��Left=�6C   $��	220,0,0,0q�6^   $	��Top=�6q   $��18��6�   $��26��6�   �� 5�      $
��Name��6   #��[ 6'   $
��Left=�6F   $��	10,35,0,0q�6a   $	��Top=�6t   �� 5�      -   5        $ txtEditName��5�   ?   $  Please enter employee name��6T   $
��Left=�6y   $��23��6�   $��	95,39,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6   �� *Name+$ TwoWay=�6�   �� 5�      $��*��6   
���  ��$��20(�65   $
��Left=�6C   $��
220,39,0,0q�6^   $	��Top=�6r   $��18��6�   $��26��6�   �� 5�      $��Surname��6   #��[ 6*   $
��Left=�6I   $��	10,74,0,0q�6d   $	��Top=�6w   �� 5�      -   5        $ txtEditSurname��5�   B   $# Please enter employee surname��6Z   $
��Left=�6�   $��23��6�   $��	95,74,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6   �� *	Surname+$ TwoWay=�6�   �� 5�      $��*��6   
���  ��$��20(�65   $
��Left=�6C   $��
220,74,0,0q�6^   $	��Top=�6r   $��18��6�   $��26��6�   $ 0.422,1.846&�6�   �� 5�      $��Date Of Birth��6   #��[ 60   $
��Left=�6O   $��
10,105,0,0q�6j   $	��Top=�6~     5�      -   5        $  dpEditDateOfBirth��5�   J   $* $Please select employee date of birth��6e   $! 1/1/1955X�6�   $" 
12/31/2005X�6�   $
��Left=�6�   $��
95,107,0,0q�6�   $	��Top=�6�   # 6   �� *DateOfBirth+$ TwoWay=�6�   �� 5�      $��*��6   
���  ��$��20(�65   $
��Left=�6C   $��220,107,0,0q�6^   $	��Top=�6s   $��18��6�   $��26��6�   $ 0.422,1.846&�6�   �� 5�      $��Gender��6   #��[ 6)   $
��Left=�6H   $��
10,142,0,0q�6c   $	��Top=�6w   �� 5�      -   5        $��cboEditGender��5�      $# Please select employee gender��6X   $
��Left=�6�   $��
95,145,0,0q�6�   $	��Top=�6�   $	��120��6�   $ 60   �� *Gender+$ TwoWay=�.@�5�      �� $��Female��6#   �� 5�      $
��Male��6#   5�      �� 5�      $��*��6   
���  ��$��20(�65   $
��Left=�6C   $��220,145,0,0q�6^   $	��Top=�6s   $��18��6�   $��26��6�   $ 0.422,1.846&�6�   �� 5�      $��Home Address��6   #��[ 6/   $
��Left=�6N   $��
10,175,0,0q�6i   $	��Top=�6}   �� 5�      -   5        $ txtEditHomeAddress��5�      $( "Please enter employee home address��6b   $
��Left=�6�   $��23��6�   $��
95,179,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��66   �� *HomeAddress+$ TwoWay=�6�   �� 5�      $��*��6   
���  ��$��20(�65   $
��Left=�6C   $��220,179,0,0q�6^   $	��Top=�6s   $��18��6�   $��26��6�   $ 0.422,1.846&�6�   �� 5�      -   5        $ btnEditEmployee��5�      #��[ 62   $��Edit Employee��6R   $
��Left=�6j   $	��Top=�6�   $��89��6�   $��	9,206,0,0q�6�   6�   �� 5�      -   5        $ btnCloseEditGrid��5�      #��[ 63   $��Close��6T   $
��Left=�6d   $��140,206,0,0q�6   $	��Top=�6�   $��75��6�   6�   5�      5�      5�      