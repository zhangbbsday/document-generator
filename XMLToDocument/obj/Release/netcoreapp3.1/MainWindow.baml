   M S B A M L   `   `   `  ���� H  DXMLToDocument, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:XMLToDocumentXMLToDocument  E AComponents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:Components;assembly=Components
Components     XMLToDocument.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:XMLToDocument     C
components,clr-namespace:Components;assembly=Components       � Title$  
MainWindow��$	��450��$	��800�� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$ components:Commands.New��  -   $ components:Commands.Open��  -   $ components:Commands.Save��  -   $  components:Commands.SaveAs��  -   $  components:Commands.Output��  -   $ components:Commands.Exit��  -   $  components:Commands.Delete��  -   $! components:Commands.Produce��  -	   $! components:Commands.Preview��.���  � ShowGridLines$
 True�� � RowDefinitions �� $
��auto ��� $��* ��� $
��auto � � ColumnDefinitions �� $��* ��� $��* �.+�  Components.TopMenu  -
     Name$ topMenu��$��0��$��0��$��2��
�������  Components.XMLContent  -     Name$ 
xmlContent��$��1��$��0��
����  �  Components.MemberContent  -     Name$ memberContent��$��1��$��1��
���  ��  Components.BottomBar  -   	  Name$	 	buttonBar��$��2��$��0��$��2��
�������