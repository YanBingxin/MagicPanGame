   M S B A M L   `   `   `  ���� C  ?MagicPan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MagicPanMagicPan      MagicPan.App   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     (localclr-namespace:MagicPan       �� 	Resources   �� Color   EditWindowBG  BtnForeground  DisabledForegroundColor  ControlLightColor  ControlMediumColor  ControlMouseOverColor �� EndPoint �� 
StartPoint � Color � Offset  
GlyphColor  BorderLightColor  BorderMediumColor 	 BorderDarkColor 
 MenuPopupBrush �� 
TargetType �� Property �� Value	 �� 
TargetType
 ��Name K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation �� Triggers P� Property P� Value �� 
TargetName �Name m� IsSubmenuOpen � AllowsTransparency J� SnapsToDevicePixels P� 
SourceName � ColumnDefinitions z� SharedSizeGroup ��Name F�Name ��Name m� InputGestureText � HorizontalOffset �� Triggers  m� TopLevelHeaderTemplateKey m� TopLevelItemTemplateKey  m� SubmenuHeaderTemplateKey! m� SubmenuItemTemplateKey 	 BtnBG  WindowStyle" �� CornerRadius# �� Padding$ � RowDefinitions% � Title    MagicPan.WindowStyleHelper&   CanDragMove'   IsCloseActive( � ToolTip) �� ContentStringFormat* �� ContentStringFormat+ ��Name��%�  &	        &	      &	 *     &	 =     &	 L     &	 _     &	 �     &	 �     &	 �     &		     &	
      '�� �    7 
 7  '�� ,    (�� �    *$"MenuItem.TopLevelHeaderTemplateKey+)(�� 2    *" MenuItem.TopLevelItemTemplateKey+)(��     *!MenuItem.SubmenuItemTemplateKey+)(�� �    *#!MenuItem.SubmenuHeaderTemplateKey+)'m� �    &	 -    &	 �    '_� �    �� $ 	#FE3E3B3A���� $ 	#FFEEEEEE����	#FF888888����	White����	#FF7381F9���� $	 0,0&�$	 0,1&�.��� $ 	#FF0C375C��$ 0Q�� $ 	#FF4F9DB2��$ 1Q�� $ 	#FF34738E��$ 0.755Q���	#FF444444����	#FFCCCCCC����DimGray����	#FF444444���� $	 0,0&�$	 0,1&�.��� $ 	#FF383635��$ 0Q�� $ 	#FF726767��$ 1Q�� $ 	#FF494747��$ 0.755Q��� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  �@�IsSharedSizeScope . ��  �@��HasDropShadow . ��  � �� �� "	 ��.R��� $
 Border��8��  $��1q����� 8  ._���  . $ Cycle=� P�  �@��HasDropShadow . . ��� $ Border�� �@��Padding$ 0,3,0,3q��� $ Border�� �@��CornerRadius$ 4���� " ��.���  � ��$ 1����  � ��$ 0,4,0,4q���  � �� �� "	 ��.R��� $��1q����� # �  �� "	 m�.R��� $
 Border��._�� .+��� $��6,3,6,3q�$��Header����. � $ Popup��$��Bottom=�#��z  . |�.  $
��Fade=�.���� $
 SubmenuBorder�� . $��1q�#��� 
 ���� # �  ._���  . $ Cycle=� P� " �@m�IsSuspendingPopupAnimation . . ��� $ Popup�� � ��$
 None=�P�  �@m�IsHighlighted . . ��� $ Border�� � ��
 ���� �� $ Border��# �   � ��P� $ Popup�� �@�AllowsTransparency . . ��� $ SubmenuBorder�� �@��CornerRadius$ 0,0,4,4���� $ SubmenuBorder�� �@��Padding$ 0,0,0,3q�P�  � {� .  . ���  � �� �� # �  �� "	 m�.R��� $
 Border��._�� .+��� $��6,3,6,3q�$��Header����.  P�  �@m�IsHighlighted . . ��� $ Border��# �   � ��P�  � {� .  . ���  � �� �� # �  �� "	 m�.R��� $
 Border��$��1q�._��  �� $
��Auto �$
 Icon���� $��* ��� $
��Auto �$ Shortcut���� $��13 �.+��� $
 Icon��$��6,0,6,0q�$��Center=�$
��Icon���� $
 Check��$��13��$��13��$y�	Collapsed=�$��6,0,6,0q�$��1q����� $	 0,0&�$	 0,1&���� � # �  $	 0.0Q�� # � 	 $	 1.0Q����� $	 0,0&�$	 0,1&���� � # �  � # �  $	 1.0Q�._�F� $ 	CheckMark��$��7��$��7��$y�Hidden=� .  $��2��+����        ���j ��j �    ��j ���j     	���� # �  �� $ 
HeaderHost��$��1��$��Header����. �� $ InputGestureText��$��2��#��z $��5,2,0,2q�$��Right=� P�  Z�  � ��P�  Z�  �@m�Icon. ��� $
 Icon�� � y�$ Hidden=�P�  �@m�	IsChecked . . ��� $ 	CheckMark�� � y�$ Visible=�P�  �@m�IsCheckable . . ��� $ Check�� � y�$ Visible=��� $
 Icon�� � y�$ Hidden=�P�  �@m�IsHighlighted . . ��� $ Border��# �   � ���� $ Border�� � �� �� $ 0.5,1&�$ 0.5,0&�.��� # �  $ 0Q�� $ Transparent��$ 1Q�P�  � {� .  . ���  � �� �� # �  �� "	 m�.R��� $
 Border��$��1q�._��  �� $
��Auto �$
 Icon���� $��* ��� $
��Auto �$ Shortcut���� $��13 �.+��� $
 Icon��$��6,0,6,0q�$��Center=�$
��Icon���� $ 
HeaderHost��$��1��$��Header����. �� $ InputGestureText��$��2��#��z $��5,2,2,2q�$��Right=�F� $��3��$��Center=�$��Center=�"����        �    ��j � 	= �g5 	���� # �  � $ Popup��$��Right=�$ -4��#��z  . |�.  $
��Fade=�.���� $
 SubmenuBorder�� . #��� 
 $��1q����� # �  ._���  . $ Cycle=� P�  Z�  �@m�Icon. ��� $
 Icon�� � y�$ 	Collapsed=�P�  �@m�IsHighlighted . . ��� $ Border��# �   � ���� $ Border�� � �� �� $ 0.5,1&�$ 0.5,0&�.��� # �  $ 0Q�� $ Transparent��$ 1Q�P� $ Popup�� �@�AllowsTransparency . . ��� $ SubmenuBorder�� �@��CornerRadius$ 4���� $ SubmenuBorder�� �@��Padding$ 0,3,0,3q�P�  � {� .  . ���  � �� �� # �  �� " m�.���  � ��
 �������  � ��$ 13(���  �@�OverridesDefaultStyle .  P�  �@m�Role$ TopLevelHeader=�. ���  � ��# �  ��  �@�IsSharedSizeScope . P�  �@m�Role$ TopLevelItem=�. ���  � ��# �  P�  �@m�Role$ SubmenuHeader=�. ���  � ��# �   P�  �@m�Role$ SubmenuItem=�. ���  � ��# � ! �� $	 0,0&�$	 0,1&�.��� $ 	#FF383635��$ 0Q�� $ 	#FF726767��$ 1Q�� $ 	#FF494747��$ 0.755Q��� " �.���  �@�ShowInTaskbar .  ��  � ��# �  ��  � ��# �   ��  �@�WindowStyle$
 None=���  � ��$ 17(���  �@�
ResizeMode$ CanResizeWithGrip=���  �@�AllowsTransparency . ��  � �� �� "	 �.R��� $" 0,0,5,5��#��z��#��z��#��z��$# 2,5,2,2q�._��� .u�� $ �� $��40 ��� $��* �.+��� #��z% #��z��$��0��#��z��& . $
��auto���� 
������ $��×��$��25(�$��0��$��Right=�$
��auto��$	��Top=�' . $��0,-5,0,0q�$( by 颜������ " ��.���  � ��# �   P�  �@J�IsMouseOver . . ���  � ��
 �  ���� $��1��$��Stretch=�#��z��#��z��#* z) �� $+ WindowResizeGrip��$��1��$��Right=���.  $y�Visible=�$��Bottom=��� " _�.���  � ��
 �iii���  � ��# �  ��  � �� �� "	 _�.R��� #��z��$" 3��._��� $��10q�#��z��$��Center=�$��Center=�