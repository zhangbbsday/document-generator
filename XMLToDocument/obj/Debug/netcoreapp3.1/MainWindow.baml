   M S B A M L   `   `   `  ����H  DXMLToDocument, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:XMLToDocumentXMLToDocument  5   	   E AComponents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:Components;assembly=Components
Components 5   	       XMLToDocument.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:XMLToDocument     5   	   C
components,clr-namespace:Components;assembly=Components     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6,   $	��300��6;   $	��400��6K    J� CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ components:Commands.Open��5      6<     5   
   -   5        $  components:Commands.SaveAs��5      6`     5   
   -   5        $ components:Commands.Exit��5      6<     5   
   -   5        $  components:Commands.Delete��5      6>     5   
   -   5        $! components:Commands.Produce��5      6?     5   
   -   5        $! components:Commands.Preview��5      6?   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
     Components.TopMenu  -   5          Name$ topMenu��5      $��0��6.   6=     Components.XMLContent  5   
   -   5          Name$ 
xmlContent��5       $��1��64   6C     Components.BottomBar  5   
   -	   5          Name$ 	buttonBar��5      $��2��62   
�������6X   5      5      