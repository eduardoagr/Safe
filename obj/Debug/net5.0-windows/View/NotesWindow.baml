   M S B A M L   `   `   `  ����D  @FluentWPF, Version=0.9.0.1, Culture=neutral, PublicKeyToken=nullP6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPFSourceChord.FluentWPF  5   	   ? ;Safe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Safe.ViewModelSafe.ViewModel 5	   	   7 clr-namespace:Safe.View.ControlsSafe.View.Controls 5
   	      Safe.View.NotesWindow   5   	   =fw6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPF  5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   M IFluent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546fFluenturn:fluent-ribbon  5   	   ,	viewmodelclr-namespace:Safe.ViewModel  5	   	   /controls clr-namespace:Safe.View.Controls  5
   	   _	 [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors 	 5   	   -   5          �Name$  window��5   	    � Title$ NotesWindow��5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������ )   #SourceChord.FluentWPF.AcrylicWindow   Enabled$
 True��5   	      TintOpacity$ .4Q�5   	   $	��700��5   	   $
��1400��5   	    � 	Resources 5      "  Safe.ViewModel.NotesWindowVM   vm��%   &	          5   
   6"   5      .��5      �  � DataContext 6   ��  �� Source# [   � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
     Fluent.Ribbon  $��Center=�6   	   Tabs.	 5        Fluent.RibbonTabItem  
   Header$

 File��6#      Groups. 5        Fluent.RibbonGroupBox  $��Group��6(   .@�5         Fluent.Button     Header$ New Notebook��6$      	LargeIcon$ /Resources/diary.png��5"   $   ��5!   $   �� *NewNotebookCommand+5"   $     5#      $ New Note��6$   $ /Resources/post-it.png��5&   $   ��5$   $   �� *NewNoteCommand+��5%   $   �� *SelectedNoteBook+ �� Mode$ TwoWay=�5&   $     5'      $
 Exit��6$   $��40,0,0,0q�5(   $   $ /Resources/exit.png��5)   $   ��5*   $   �� *ExitCommand+  5+      $ Log Out��6$   $��
1170,0,0,0q�5,   $   $ /Resources/logout.png��5-   $   ��5.   $   �� *CloseWidowCommand+$ OneWay=���5/   $   ��  �� ElementName$ window��50      51      52      �� 53   
   $��2��6   6#   � 54   
   $��1��6   $��2��55       � ColumnDefinitions 56      �� 57      $
��auto �6#   �� 58      $
��auto �6#   �� 59      $��* �6#   .+�5<      �� 
���p���5=      �� *	Notebooks+ �� SelectedItem 5>      �� *SelectedNoteBook+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���5?      �� 5@      .R�5A      � .+�5B      .  (Safe.View.Controls.CustomNotebookControl     Notebook 6=   ��  � ContextMenu 5C   "   �� 5D   &   .@�5E   *   m� $��Rename��63    m� Command 5F   3   �� # [   �� Path$ RenameCommand� m� Icon 5G   .   �� 5H   2   $��/Resources/rename.png��68   5J   +   5K   '   5M      �� 5N      $
��Bold"�5O   &   ��5N   &   �� *Name+y�5P   &   �� # [  $ 	IsVisible�.��6h   * 	 $Microsoft.Xaml.Behaviors.Interaction   Triggers 5Q   "   +	 	 %Microsoft.Xaml.Behaviors.EventTrigger	  5R   &    	  	EventName$ 	LostFocus��65   *
 	 $Microsoft.Xaml.Behaviors.TriggerBase 
  Actions. 5S   *   2 	 ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6@   �� # [  $# RenameNotebookCompleteCommand�5U   '   .��5V   :   5W      5X      5Y      5[      �� 5\      $��1��6   ���#FCFCFC��5^      �� *Notes+ 5_      �� *SelectedNote+$ TwoWay=�$ PropertyChanged=���5`      �� 5a      .R�5b      � .+�5c      *  $Safe.View.Controls.CustomNoteControl     Note 69   ��  5d   "   �� 5e   &   .@�5f   *   m� $��Rename��63    5g   3   �� # [  $ RenameCommand� 5h   .   �� 5i   2   $��/Resources/rename.png��68   5k   +   5l   '   5n      �� 5o      $
��Bold"�5p   &   ��5o   &   �� *Title+y�5q   &   �� # [  $ 	IsVisible�.��6h    5r   "   	  5s   &   $ 	LostFocus��65   . 5t   *      6@   �� # [  $ RenameNoteCompleteCommand�5v   '   .��5w   :   5x      5y      5z      5|      � 5}      $��2��6    5~      �� 5      $
��auto �6$   �� 5�      $��1* �6$   �� 5�      $
��auto �6$   .+�5�      `� $	��Top=�6   .�5�      c� .@�5�      ��  �� Orientation$ 
Horizontal=�6%   (   "SourceChord.FluentWPF.AcrylicPanel   	TintColor$ 	AliceBlue��5�   %   .+�5�      d� -   5        $��
SpeechBton��5�   +   
������ 
������ $��18(�5�   +   
 � Tag$ 0��5�   +   {�5�   +   �� *	IsEnabled+.��5�   "   �� $��Speech��6,   5�      d� 5�      -   5        $��boldBton��5�   +   $��10,0,0,0q�5�   +   $��18(�5�   +   $ 1��5�   +   
������ 
������ {�5�   +   �� *	IsEnabled+.��5�   "   �� $��B��6,   5�      d� 5�      -   5        $��
italicBton��5�   +   $��10,0,0,0q�5�   +   $��18(�5�   +   $ 2��5�   +   
������ 
������ {�5�   +   �� *	IsEnabled+.��5�   "   �� $��I��6,   5�      d� 5�      -   5        $��UndelineBton��5�   +   $��18(�5�   +   $��10,0,0,0q�5�   +   $ 3��5�   +   
������ 
������ {�5�   +   �� *	IsEnabled+.��5�   "   �� $��U��6,   5�        Fluent.ComboBox  5�      -   5           Name$  FontsComboBox��5�   .   $	��100��5�   .   ! �� 
IsEditable$! False��5�   .   {�5�   .   �� *	IsEnabled+��5�   .   �� *Fonts+5�   .     5�      -   5        $  SizeConboBox��5�   .   $��50��5�   .   $! False��5�   .   ��5�   .   �� *	FontSizes+{�5�   .   �� *	IsEnabled+5�   .   �� 5�      -   5        $��SaveBton��5�   %   $��10,0,0,0q�5�   %   
������ 
������ $��50��5�   %   $��30��5�   %   {�5�   %   �� *	IsEnabled+.��5�   "   �� $��/Resources/save.png��6(   6G   5�      5�      5�      5�      �� 5�      -	   5        " ��Name$" NoteContent��5�      $��1��5�      
���   �{�5�      �� *	IsEnabled+5�      �� 5�      $��2��6   .@�5�      �� -
   5        # ��Name$# NumOfCharacters��5�       5�      5�      5�      5�      5�      