   M S B A M L   `   `   `  ����J  FWpfApp1-Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApp1_ProjectWpfApp1_Project  5   	        WpfApp1_Project.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApp1_Project     5   	     � Title$3  -Employee Manager Made By Tuan Anh and Group 6��5   	   $	��450��6?   $	��800��6L   .��5	      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Employee Manager��6    �� TextAlignment$ Center=�6,   $��20(�6C   �� 5   
   $��0��6    �� Orientation$ Vertical=�6"   $��20q�69   .+�5      �� $ 
Horizontal=�6   $��0 0 0 5q�62   .+�5      �� $
��Name��6   $��5q�6(   $��Center=�63   �� 5      -   5         ��Name$ txtName��5      $	��150��6+   $��5q�67   $�� ��6B   5      �� 5      $ 
Horizontal=�6   $��0 0 0 5q�62   .+�5      �� $	��Age��6   $��5q�6'   $��Center=�62   �� 5      -   5        $ txtAge��5      $��50��6*   $��5q�65   $�� ��6@   5      �� 5      $ 
Horizontal=�6   $��0 0 0 5q�62   .+�5      �� $��Salary��6   $��5q�6*   $��Center=�65   �� 5      -   5        $ 	txtSalary��5      $	��100��6-   $��5q�69   $�� ��6D   5      �� 5      $ 
Horizontal=�6   $��0 0 0 5q�62   .+�5      �� $��Bonus Salary:��6   $��5q�61   $��Center=�6<   �� 5       -   5        $ txtBonus��5       $	��100��6,   $��5q�68   $�� ��6C   5!      �� 5"      $ 
Horizontal=�6   $��0 0 0 5q�62   .+�5#      �� $��
Department��6   $��5q�6.   $��Center=�69   �� 5$      -   5        $ txtDepartment��5$      $	��150��61   $��5q�6=   $�� ��6H   5%      �� 5&      $ 
Horizontal=�6   $��0 0 0 5q�62   .+�5'      �� $
��City��6   $��5q�6(   $��Center=�63   �� 5(      -   5        $ txtCity��5(      $	��100��6+   $��5q�67   $�� ��6B   5)      �� 5*      $ 
Horizontal=�6   $��0 0 0 5q�62   .+�5+      �� -   5         ��Name$ btnAddEmployee��5+      $��Add Employee��61   $	��120��6H   $��5q�6T   6_   �� 5,      -   5        $ 
btnShowAll��5,      $��Show All Employee��6-   $	��150��6I   $��5q�6U   6`   �� 5-      -	   5        $ 	btnDelete��5-      $��Delete Employee��6,   $
��150 ��6F   $��5q�6S   6^   �� 5.      -
   5        $ btnShowAllSalaries��5.      $��Show All Salaries��65   $	��150��6Q   $��5q�6]   6h   �� 5/      50      �� 51      $ 
Horizontal=�6   $��0 0 0 5q�62   .+�52      �� $��Search By Name:��6   $��5q�63   $��Center=�6>   �� 53      -   5        $ txtSearchName��53      $	��150��61   $��5q�6=   $�� ��6H   �� 54      -   5        $ 	btnSearch��54      $��Search��6,   $��80��6=   $��5q�6H   6S   56      57      �� 59   
   -   5         ��Name$ listViewEmployees��59      $��1��6.   $��10q�6;    �� View 5:      �� 5;      ! �� ColumnHeaderContainerStyle 5<      �� 5=      	 �� 
TargetType"	 ��6    .�5>      �� 
 �� Property
 � �� �� Value$ Center=�6K   5?      .P�5A      �� $
��Name��6%    �� DisplayMemberBinding 65   �� *Name+�� 5B      $	��Age��6%    62   �� *Age+�� 5C      $��Salary��6%    65   �� *Salary+�� 5D      $��Bonus Salary��6%    6;   �� *BonusSalary+�� 5E      $��
Department��6%    69   �� *
Department+�� 5F      $
��City��6%    63   �� *City+5G      5I      5J      5K      