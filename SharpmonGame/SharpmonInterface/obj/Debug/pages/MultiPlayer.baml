   M S B A M L   `   `   `  ����L  HSharpmonInterface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:SharpmonInterface.pagesSharpmonInterface.pages  5      )    #SharpmonInterface.pages.MultiPlayer   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:SharpmonInterface.pages     5      $	��700��5   7   $	��700��6C   .��5	      � -   5          �Name$  view_multiplayerGame��5	      
�������.+�5
   
   ��  �� TextAlignment$
 Left=�6    �� Padding$
 10pxq�6)   
�������$
��Left=�6P   $
��Wrap=�6k   $	��Top=�6   $��61��6�   $	��422��6�   $
��28px(�6�    J� RenderTransformOrigin$ 0.521,-0.198&�6�   $��Partie multijoueur��6�   �� 5   
   -   5         ��Name$ view_PlayerCo��5      $
 Left=�6+   $
 12pxq�6@   
�������$
��Left=�6g   $
��Wrap=�6�   $	��Top=�6�   $��61��6�   $	��278��6�   $
��24px(�6�   $ 0.521,-0.198&�6�   $��Joueurs en ligne :��6�   $��	422,0,0,0q�6  �� 5   
   -   5        $ view_statutPlayer��5   /   $
��Left=�6   $
��22px(�6�   $	 5pxq�6�   
�������$��43��6�   $��	10,85,0,0q�6�   $
��Wrap=�6�   $	��Top=�6�   $	��279��6  ��6J   ��  �� Path$
 Text� �� ElementName$ view_statutPlayer��6  �� 5   
   -   5        $ view_versusPlayer��5   C   $
��Left=�6   
��� � �$ Center=�6�   $
��22px(�6�   $	 5pxq�6�   
�������$��43��6�   $��
342,85,0,0q�6�   $
��Wrap=�6  $	��Top=�6  $	��145��60  ��6^   �� $
 Text�$ view_versusPlayer��60  �� 5   
   -   5        $ view_versus��5   0   $
��Left=�6   $��VS��6E   $
��22px(�6O   $	 5pxq�6_   $��43��6n   $��
492,85,0,0q�6z   $ Center=�6�   $
��Wrap=�6�   $	��Top=�6�   $��36��6�   $ 3.046,-0.411&�6�   �� 5   
   -   5        $ view_versusopponant��5   A   $
��Left=�6   
���  ��$
��22px(�6�   $ Center=�6�   $	 5pxq�6�   
�������$��43��6�   $��
533,85,0,0q�6�   $
��Wrap=�6  $	��Top=�6  $	��145��62  ��6^   �� $
 Text�$ view_versusopponant��62  �� 5   
   $
��Left=�6   $��22��6/   $��	0,151,0,0q�6;   $	��Top=�6N   $	��700��6f   �� 5   
   -   5         ��Name$ view_statSharpmon��5      ���	#FFF4F4F5$
��Left=�6A   $	��226��6\   $��
44,198,0,0q�6i   
�������$	��Top=�6�   $	��316��6�   �� 5   
   -   5        $ view_blocAction��5      $y�Hidden=�6.   ���	#FFF4F4F5$
��Left=�6S   $	��178��6n   $��
37,445,0,0q�6{   
�������$	��Top=�6�   $	��323��6�   �� 5   
   ���	#FFF4F4F5$
��Left=�6%   $	��425��6@   $��394,198,0,0q�6M   
�������$	��Top=�6q   $	��252��6�   �� 5   
   $
��Left=�6   
�������$ Center=�6E   $��36��6\   $��394,198,0,0q�6h   $
��22px(�6}   $
��Wrap=�6�   $��Rapport du combat��6�   $	��Top=�6�   $	��252��6�   �� 5   
   -	   5        $ view_titleAction��5      $y�Hidden=�6/   
�������$
��Left=�6[   $ Center=�6v   $��36��6�   $��
37,445,0,0q�6�   $
��22px(�6�   $
��Wrap=�6�   $��Action��6�   $	��Top=�6�   $	��323��6�   �� 5   
   -
   5         ��Name$ view_button1Action��5      $y�Hidden=�6K   $
��18px(�6`   $
��Left=�6p   $��117,508,0,0q�6�   $	��Top=�6�   $	��156��6�   $��42��6�   �� 5   
   -   5        $ view_button2Action��5      $y�Hidden=�6K   $
��18px(�6_   $
��Left=�6o   $��117,568,0,0q�6�   $	��Top=�6�   $	��156��6�   $��42��6�   �� 5   
   -   5        $ view_rapport��5      $ Center=�6+   $
 20pxq�6B   
��� � �$
��Left=�6d   $	��185��6   $��394,239,0,0q�6�   $
��Wrap=�6�   $	��Top=�6�   $	��252��6�   �� 5   
   -   5        $ view_rapportOpponant��5      $ Center=�63   $
 20pxq�6J   
���  ��$
��Left=�6j   $	��185��6�   $��394,438,0,0q�6�   $
��Wrap=�6�   $	��Top=�6�   $	��252��6�   �� 5   
   $
��Left=�6   $��33��6/   
�������$��
46,201,0,0q�6Q   $
��Wrap=�6e   $ Center=�6y   $��Stat Généraux ��6�   $	��Top=�6�   $
��22px(�6�   $	��314��6�   �� 5   
   $
��Left=�6   $	��190��6,   
�������$��201,234,0,0q�6O   $	��Top=�6d   $��6��6|   $ 0.5,0.5&�6�   5      �� 5   
   -   5        $ view_Stat_namePlayer��5      $
��Left=�62   $ Center=�6M   
��� � �$��28��6w   $��
46,277,0,0q�6�   $
��Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��155��6�   �� 5    
   -   5        $ view_Stat_currentHpPlayer��5       $
��Left=�68   $ Center=�6S   
��� � �$��28��6}   $��
46,328,0,0q�6�   $
��Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��155��6�   $ 0.406,0.607&�6�   �� 5!   
   -   5        $ view_Stat_nameOpponent��5!      $
��Left=�64   $ Center=�6O   
���  ��$��28��6w   $��212,277,0,0q�6�   $
��Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��141��6�   �� 5"   
   -   5        $" view_Stat_currentHpOpponnent��5"      $
��Left=�6:   $ Center=�6U   
���  ��$��28��6}   $��212,328,0,0q�6�   $
��Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��141��6�   �� 5#   
   
�������$
��Left=�6$   $��9��6?   $��394,429,0,0q�6J   $	��Top=�6`   $	��252��6x   5*      5+      