   M S B A M L   `   `   `  ����M  IQnAMakerChatClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:QnAMakerChatClientQnAMakerChatClient  5   	   #    QnAMakerChatClient.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:QnAMakerChatClient     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    � DataContext 5	      "   QnAMakerChatClient.ViewModel  5
   
    � 	Resources 5      1   +QnAMakerChatClient.ListBoxItemStyleSelector   styleSelector �� 
TargetType  sendItemStyle �� Property �� Value  receiveItemStyle1   +QnAMakerChatClient.ChatItemTemplateSelector  itemTemplateSelector  sendTemplate �� Path  receiveTemplate �� StringFormat��%�  &	        &	      &	 ^     &	 �     &	 �     &	 �      5   
   6)   �� 5   
   " ��6   .�5      ��  � ��$ Right=�6;   5      �� 5   
   " ��6   .�5      ��  � ��$
 Left=�6;   5        5   
   6)   �� 5   
   .R�5      �� $��50,0,5,0q�6   .+�5      �� $��12(�6   
�������$��Right=�6<   ��5      �� $
 From��� 5      
������._�5      �� $��10q�6    $��WrapWithOverflow=�6,   ��5       �� $ Message�5      5      5      �� 5   
   .R�5       �� $��5,0,50,0q�6   .+�5!      �� $��12(�6   
�������$
��Left=�6<   ��5"      �� $
 From��� 5#      
����ح�._�5$      �� $��10q�6    $��WrapWithOverflow=�6,   ��5%       �� $ Message�5&      �� 5'      $��12(�6   
�������$��Right=�6<   �� 5(      $�Score : ��6    �� 5)      �6   �� $ Score�$ {0:N2}��5*      5+      5,      5-      .��5.      �  � ColumnDefinitions 5/   
   �� 50      $
��Auto �6   �� 51      	 � RowDefinitions	 53   
   �� 54      �� 55      $
��Auto �6   .+�57   
   �� -   5        $��chatList��57   &   $��2��6   $	��5,0q�66   $��Disabled=�58      |�.  #��[ 5:      #��[  5;      ��5<      �� $ 	ChatItems��� 5>   
   $��1��6   
 �� Orientation$
 
Horizontal=�6"   $��Center=�5?      $��Center=�62   .+�5@      	� -   5        $��female��5@      $	��女��6(    	� 	GroupName$ gender��64    d� 	IsChecked$
 TrueY�5A      	� 5B      -   5        $
��male��5B      $	��男��6&   $ gender��62    5C      �� *Male+ �� UpdateSourceTrigger$ PropertyChanged=�5D      ]� 5E   
   $��1��6   $��1��6$   ��. $	��5,0q�6F   .+�5F      �� $��Right=�6   $��送信��6,   ��69   �� $ SendCommand��� 5G      $
��Left=�6    �� AcceptsReturn . $ �� HorizontalScrollBarVisibility$
 Auto=�5H      ��5I      �� $ Question�$ PropertyChanged=�5K      5L      5M      