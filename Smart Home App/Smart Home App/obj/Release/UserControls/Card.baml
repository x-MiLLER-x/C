   M S B A M L   `   `   `  ����   Smart Home App&     Smart_Home_App.UserControls.Card   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -   $
��card��.����   �� CornerRadius$  25�� �� Padding$ 20q�$	��150��$��Stretch=� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 1Q�   
BlurRadius$ 20Q�   Opacity$	 0.5Q�����  �� 
TargetType" ��.���  �� Property � �� �� Value$	 150��	 �� Triggers	 �� 
 �� Binding
 ��  �� ElementName$ toggle�� �� Path$ 	IsChecked� �� Value True.a���  � �� �#3256f1�� 
 �� $ toggle��$ 	IsChecked�	 False.a���  � �� �#efefee�� 
 �� $
 card��$ IsHorizontal� True.a���  � ��$	 190���� 
 �� $
 card��$ IsHorizontal�	 False.a���  � ��$	 150��._�� .+��� $��SemiBold"�$	��Top=�$
��Left=�$��0 5 0 0q����� " ��	 �� 
 �� $ toggle��$ 	IsChecked� True.a���  � ��$ On����  � �� �#ffffff�� 
 �� $ toggle��$ 	IsChecked�	 False.a���  � ��$	 Off����  � �� �#3256f1�� -    ��Name$ toggle��$��Right=� d� 	IsChecked �� $
 card��$ 	IsChecked����� " ��   toggleButton �� BasedOn# [  .���  � ��$	 Top=�	 �� 
 �� $
 card��$ IsHorizontal� True.a���  � ��$ Center=��� 
 �� $
 card��$ IsHorizontal�	 False.a���  � ��$	 Top=��� $��Center=�$��40��$��40��$
��Left=����� " ��	 �� 
 �� $ toggle��$ 	IsChecked� True.a���  � �� �� $
 card��$ ImageOn��� 
 �� $ toggle��$ 	IsChecked�	 False.a���  � �� �� $
 card��$ ImageOff��� $��Bottom=�$��SemiBold"����� $
 card��$ Title����� " ��	 �� 
 �� $ toggle��$ 	IsChecked� True.a���  � �� �#ffffff�� 
 �� $ toggle��$ 	IsChecked�	 False.a���  � �� �#2f2c37