   M S B A M L   `   `   `  ���� C  ?MagicPan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MagicPanMagicPan      MagicPan.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     (localclr-namespace:MagicPan       � Title$  魔盘��$	��300��$	��300��   WindowStyle#���    � 
ResizeMode$ CanResizeWithGrip=� � ShowInTaskbar .   � Topmost .  � 	Resources   BoolToVisibilityConverter   MagicPan.PanKey �� 
TargetType �� Property �� Value  Btn �� Triggers	 �� Binding
 �� RelativeSource �� Mode �� AncestorType �� Value  Btn2 P� Property P� ValueO Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  �� 
TargetType �� CornerRadius   Value J� SnapsToDevicePixels��%�  &	       '       '�� �     &	     &	 M    �� �� "  .���  � ��$ 30(���  � ��# �   �� 	 �� *IsImagePanKey+
 �� $ FindAncestor=�$ WindowL� True.a���  � ��# �  �� " ��.���  � ��
 ����� P�  �@J�IsMouseOver . . ���  � ��
 � � ��� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    ,s&clr-namespace:System;assembly=mscorlib  :x,http://schemas.microsoft.com/winfx/2006/xaml     "  .R�� $��gd��$��2q�.+��� $��bg��$ 5��
���iii�._�(� .���� $��ct��#��z $��Center=�$��Center=�#��z��
��������� "  .R��� $��Chrome��#��z��#��z��$ 5�� . .���� $ 5��
�������$��
10,0,10,10q�._��  � Cursor$
 Hand��.+��� -    ��Name$ lbTime��$��Center=�$	��Top=�
�������$��
0,-35,30,0q�$��12(� � ToolTip$ 耗时���� -   $ lbPng��$	��☆��$��Right=�$	��Top=�$��
0,-41,90,0q�$��20(�$ 高级设置�� � ContextMenu �� -    ��Name$ cmPng��.@�m� -   $��使用本地图片��$H B为保证拼图质量，请尽量使用不含透明区域的图片��m� -   $��切换数字/图片���� -   $ lbTip��$��?��$��Right=�$	��Top=�$��
0,-40,70,0q�$��20(��� -   $
 lbGo��$��Go��$��Right=�$	��Top=�$��
0,-35,45,0q�$��12(�$ 开始新的一局���� -   $ lbSetUp��$	��↑��$��Right=�$	��Top=�$��
0,-37,30,0q�$��15(�$ 提高难度���� -	   $ 	lbSetDown��$	��↓��$��Right=�$	��Top=�$��
0,-37,15,0q�$��15(�$ 降低难度��� -
    �Name$ gd�� � RowDefinitions �� $��* ��� $��* ��� $��* ��� $��* � � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* �� -   $ gdTip��
�������y��� *IsMouseOver+ �� ElementName$ lbTip�� �� 	Converter# [ 