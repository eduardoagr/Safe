   M S B A M L   `   `   `  ����D  @FluentWPF, Version=0.9.0.1, Culture=neutral, PublicKeyToken=nullP6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPFSourceChord.FluentWPF  5   	   ? ;Safe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Safe.View	Safe.View 5   	   7 clr-namespace:Safe.View.ControlsSafe.View.Controls 5   	   /clr-namespace:Safe.ViewModelSafe.ViewModel 5   	      Safe.View.LoginWindow   5   	   =fw6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPF  5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Safe.View     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5	   	   l	 hSyncfusion.SfTextInputLayout.WPF, Version=19.1500.0.69, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a
 ]Syncfusion.Shared.WPF, Version=19.1500.0.69, Culture=neutral, PublicKeyToken=3d67ed1f87d44c895inputLayout!http://schemas.syncfusion.com/wpf 	 
 5
   	   1controls clr-namespace:Safe.View.Controls 	 
 5   	   'vmclr-namespace:Safe.ViewModel 	 
 5   	   -   5          �Name$  window��5   	    � Title$ LoginWindow��5   	   $	��500��5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������ )   #SourceChord.FluentWPF.AcrylicWindow   Enabled$
 True��5   	      TintOpacity$ .8Q�5   	   $	��600��5   	    � 	Resources 5        Safe.ViewModel.LoginVM   vm�� 5   
   %   &	          5      6   5      .��5      �  � DataContext# [  6   .+�5   
   �� $��20q�65   y�6   �� *
LoginVis+.+�5      : 	 4Syncfusion.UI.Xaml.TextInputLayout.SfTextInputLayout     Hint$ Email��6,   	   	InputView.	 5       �� ���#9B855C��6   �� *Email+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5!      5"      .  (Safe.View.Controls.CustomPasswordControl  5#         Password 6-   �� *
Password+$
 TwoWay=�$ PropertyChanged=��� 5$        
MyBtnStyle#��[ 6   $��Login��5%      $��30��5&      $	��200��5'      ��5(      �� *LoginCommand+�� 5)      $��Do not have an account?��6   $��Center=�5*      
������$��	Underline{�5,      $��20q�5-      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5.      +  %Microsoft.Xaml.Behaviors.EventTrigger  5/         	EventName$ 	MouseDown��6%   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 50      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 60   �� *SwitchViewsCommand+51      53      54      �� 55   
   $��20q�68   y�6   �� *RegisterVis+.+�56        $ Email��6,   .	 57      �� ���#9B855C��6   �� *Email+$
 TwoWay=�$ PropertyChanged=�58      59        5:       6-   �� *
Password+$
 TwoWay=�$ PropertyChanged=�  5;       6-   �� *ConfirmPassword+$
 TwoWay=�$ PropertyChanged=��� 5<      #��[ 6   $��Create Account��5=      $��30��5>      $	��200��5?      ��5@      �� *CreateAccountCommand+�� 5A      $��Login��6   
������$��Center=�5C      $��	Underline{�5D      $��20q�5E       5F        5G      $ 	MouseDown��6%   . 5H         60   �� *SwitchViewsCommand+5I      5K      5L      5M      5N      