   M S B A M L   `   `   `  ���� F  BBase_Slider, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:Base_Slider;assembly=Base_SliderBase_Slider  B0clr-namespace:Control_Tools;assembly=Base_SliderControl_Tools  F BPlott_o_mat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:Plott_o_mat;assembly=Plott_o_matPlott_o_mat  
Live_Tuner&    controller_design.WPF.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     FBase_Slider.clr-namespace:Base_Slider;assembly=Base_Slider     JControl_Tools0clr-namespace:Control_Tools;assembly=Base_Slider     FPlott_o_mat.clr-namespace:Plott_o_mat;assembly=Plott_o_mat       � Title$  
Live Tuner��$	��755��$
��1140�� � Icon ��Titel_Bild.png��.��� -    �Name$ grid_parant��$��0,0,2,2q�.+��� -    ��Name$ TabControl_Strecke��$��	10,32,0,0q���. $
��Left=�$	��Top=�$	��216��$	��494��.@��� -    ��Name$ tab_Strecke_PT1��$	��PT1��$��-2,-2,-5,-1q�.��� $
��Left=�$	��191��$	��Top=�$	��489��$��0,0,-5,0q�.+�   Control_Tools.Base_Slider  -     Name$ Base_Slider_PT1_Vs��$
��Left=�$��	10,10,0,0q�$	��Top=�$��35��$	��486��  -   $ Base_Slider_PT1_T1��$
��Left=�$��	10,59,0,0q�$	��Top=�$��35��$	��486��   Label$
 T1 =���� $
��Left=�$��
13,157,0,0q�$
��Wrap=�$	��Top=�$��82�� � ToolTip$# Laplace Übertragungsfunktion����  � Language$ de-de�$�Fs = ---------���� $
��Left=�$��
52,148,0,0q�$
��Wrap=�$	��Top=�$��20��$��13���� $ de-de�$�Vs���� $
��Left=�$��
40,168,0,0q�$
��Wrap=�$	��Top=�$��43��$��15���� $ de-de�$�1+p*T1���� $
��Left=�$��	10,10,0,0q�$
��Wrap=�$	��Top=�$ Streckenverstärkung��$��35��$��17���� $ de-de�$	�   ���� $
��Left=�$��	10,59,0,0q�$
��Wrap=�$	��Top=�$ Zeitkonstante T1��$��35��$��17���� $ de-de�$	�   ���� -   $ tab_Strecke_IT1��$	��IT1��$��-2,-2,-5,-1q�.��� $
��Left=�$	��191��$	��Top=�$	��489��.+�  -   $ Base_Slider_IT1_Ti��$
��Left=�$��	10,10,0,0q�$	��Top=�$��35��$	��486��$
 Ti =��  -   $ Base_Slider_IT1_T2��$
��Left=�$��	10,59,0,0q�$	��Top=�$��35��$	��486��$
 T2 =���� $
��Left=�$��
13,157,0,0q�$
��Wrap=�$	��Top=�$��96��$# Laplace Übertragungsfunktion���� $ de-de�$�Fs = -------------���� $
��Left=�$��
68,148,0,0q�$
��Wrap=�$	��Top=�$��20��$��13���� $ de-de�$�1���� $
��Left=�$��
40,168,0,0q�$
��Wrap=�$	��Top=�$��79��$��23���� $ de-de�$�
pTi(1+pT2)���� $
��Left=�$��	10,10,0,0q�$
��Wrap=�$	��Top=�$ Integrationszeitkonstante��$��35��$��17���� $ de-de�$	�   ���� $
��Left=�$��	10,59,0,0q�$
��Wrap=�$	��Top=�$ Zeitkonstante T2��$��35��$��17���� $ de-de�$	�   ���� -	   $ tab_Strecke_PT2_wdb1��$��PT2 d>1��$��-2,-2,-5,-1q�.��� $
��Left=�$	��191��$	��Top=�$	��489��.+�  -
   $ Base_Slider_PT2_wdb1_Vs��$
��Left=�$��	10,10,0,0q�$	��Top=�$��35��$	��486��$
 Vs =��  -   $ Base_Slider_PT2_wdb1_T1��$
��Left=�$��	10,59,0,0q�$	��Top=�$��35��$	��486��$
 T1 =��  -   $ Base_Slider_PT2_wdb1_T2��$
��Left=�$��
10,108,0,0q�$	��Top=�$��35��$	��486��$
 T2 =���� $
��Left=�$��
13,157,0,0q�$
��Wrap=�$	��Top=�$	��114��$# Laplace Übertragungsfunktion���� $ de-de�$�Fs = ------------------���� $
��Left=�$��
76,148,0,0q�$
��Wrap=�$	��Top=�$��20��$��13���� $ de-de�$�Vs���� $
��Left=�$��
40,168,0,0q�$
��Wrap=�$	��Top=�$��87��$��23���� $ de-de�$�(1+pT1)(1+pT2)���� $
��Left=�$��	10,10,0,0q�$
��Wrap=�$	��Top=�$ Streckenverstärkung��$��35��$��17���� $ de-de�$	�   ���� $
��Left=�$��	10,59,0,0q�$
��Wrap=�$	��Top=�$ Zeitkonstante T1��$��35��$��17���� $ de-de�$	�   ���� $
��Left=�$��
10,108,0,0q�$
��Wrap=�$	��Top=�$ Zeitkonstante T2��$��35��$��17���� $ de-de�$	�   ���� -   $ tab_Strecke_PT2_wdse1��$��PT2 d<=1��$��-2,-2,-6,-1q�.��� $
��Left=�$	��191��$	��Top=�$	��489��.+�  -   $ Base_Slider_PT2_wdse1_Vs��$
��Left=�$��	10,10,0,0q�$	��Top=�$��35��$	��486��$
 Vs =��  -   $ Base_Slider_PT2_wdse1_d��$
��Left=�$��	10,59,0,0q�$	��Top=�$��35��$	��486��$
 d  =��  -   $ Base_Slider_PT2_wdse1_T��$
��Left=�$��
10,108,0,0q�$	��Top=�$��35��$	��486��$
 T  =���� $
��Left=�$��
13,157,0,0q�$
��Wrap=�$	��Top=�$	��133��$# Laplace Übertragungsfunktion���� $ de-de�$�Fs = --------------------���� $
��Left=�$��
78,148,0,0q�$
��Wrap=�$	��Top=�$��20��$��13���� $ de-de�$�Vs���� $
��Left=�$��
40,168,0,0q�$
��Wrap=�$	��Top=�$	��106��$��23���� $ de-de�$�1+p2dT+p  T���� $
��Left=�$��	10,10,0,0q�$
��Wrap=�$	��Top=�$ Streckenverstärkung��$��35��$��17���� $ de-de�$	�   ���� $
��Left=�$��	10,59,0,0q�$
��Wrap=�$	��Top=�$ 	Dämpfung��$��35��$��17���� $ de-de�$	�   ���� $
��Left=�$��
10,108,0,0q�$
��Wrap=�$	��Top=�$ Zeitkonstante��$��35��$��17���� $ de-de�$	�   ���� $
��Left=�$��
97,168,0,0q�$
��Wrap=�$	��Top=�$��8(��� $ de-de�$�2���� $
��Left=�$��111,168,0,0q�$
��Wrap=�$	��Top=�$��8(��� $ de-de�$�2���� -   $ tab_Strecke_Beliebig��$��Beliebig��$��-2,-2,-5,-1q�.��� $
��Left=�$	��191��$	��Top=�$	��489��.+��� $
��Left=�$��
13,157,0,0q�$
��Wrap=�$	��Top=�$	��172��$# Laplace Übertragungsfunktion���� $ de-de�$#�Fs = ------------------------���� $
��Left=�$��
40,148,0,0q�$
��Wrap=�$	��Top=�$	��169��$��20��$) #Nichtrekursive Filter Koeffizienten���� $ de-de�$�b���� $��8(�$ de-de�$�0���� $ de-de�$�+b���� $��8(�$ de-de�$�1*���� $ de-de�$�p   +b���� $��8(�$ de-de�$�2*���� $ de-de�$�	p   + ...���� $
��Left=�$��
40,168,0,0q�$
��Wrap=�$	��Top=�$	��158��$��23��$$ Rekursive Filter Koeffizienten���� $ de-de�$�1 - a���� $��8(�$ de-de�$�1*���� $ de-de�$�p    - a���� $��8(�$ de-de�$�2*���� $ de-de�$�
p    - ...���� �� $ de-de�$� ���� $
��Left=�$��	10,10,0,0q�$
��Wrap=�$	��Top=�$ Streckenverstärkung��$��35��$��17���� $ de-de�$	�   ���� $
��Left=�$��	10,59,0,0q�$
��Wrap=�$	��Top=�$ Zeitkonstante T1��$��35��$��17���� $ de-de�$	�   ���� $
��Left=�$��
82,146,0,0q�$
��Wrap=�$	��Top=�$��8(��� $ de-de�$�-1���� $
��Left=�$��122,146,0,0q�$
��Wrap=�$	��Top=�$��8(��� $ de-de�$�-2���� $
��Left=�$��
82,168,0,0q�$
��Wrap=�$	��Top=�$��8(��� $ de-de�$�-1���� $
��Left=�$��122,168,0,0q�$
��Wrap=�$	��Top=�$��8(��� $ de-de�$�-2���� -   	 ��Name$	 	textbox_b��$
��Left=�$��23��$��	51,16,0,0q�
 �� TextWrapping$

 Wrap=�$��0 ; 400��$	��Top=�$	��246���� $
��Left=�$��	16,18,0,0q�$
��Wrap=�$	��Top=�$) #Nichtrekursive Filter Koeffizienten���� $ de-de�$	�b =���� $
��Left=�$��40,8,0,0q�$
��Wrap=�$	��Top=�$��47��$��11��$��24(��� $ de-de�$�[���� $
��Left=�$��	302,8,0,0q�$
��Wrap=�$	��Top=�$��47��$��27��$��24(��� $ de-de�$�]���� -   $	 	textbox_a��$
��Left=�$��23��$��	65,67,0,0q�$

 Wrap=�$
��-200��$	��Top=�$	��232���� $
��Left=�$��	17,67,0,0q�$
��Wrap=�$	��Top=�$$ Rekursive Filter Koeffizienten���� $ de-de�$	�a =���� $
��Left=�$��	40,59,0,0q�$
��Wrap=�$	��Top=�$��47��$��20��$��24(��� $ de-de�$�[���� $
��Left=�$��
302,59,0,0q�$
��Wrap=�$	��Top=�$��47��$��27��$��24(��� $ de-de�$�]���� $
��Left=�$��	51,70,0,0q�$
��Wrap=�$	��Top=��� $ de-de�$�1;���� $��Strecke��$
��Left=�$��10,6,0,0q�$	��Top=�$��89��$��Italic$��� -   $ TabControl_Regler��$��
10,306,0,0q���. $
��Left=�$	��Top=�$	��167��$	��494��.@��� -   $ tab_Regler_I��$	�� I ��$��-2,-2,-5,-1q�.��� $
��Left=�$	��142��$	��Top=�$	��489��$��0,0,-5,0q�.+�  -   $ Base_Slider_I_Ti��$
��Left=�$��	10,10,0,0q�$	��Top=�$��35��$	��486��$
 Ti =���� -    ��Name$ butten_auslegen_I��$��Auslegen��$
��Left=�$��404,108,0,0q�$	��Top=�$��75���� $
��Left=�$��13,108,0,18q�$
��Wrap=�$��82��$# Laplace Übertragungsfunktion���� $ de-de�$�	Fs = ----���� $
��Left=�$��	44,99,0,0q�$
��Wrap=�$	��Top=�$��32��$��13���� $ de-de�$�1���� $
��Left=�$��
40,119,0,0q�$
��Wrap=�$	��Top=�$��45��$��23���� $ de-de�$	�pTi���� $
��Left=�$��	10,10,0,0q�$
��Wrap=�$	��Top=�$ Integrationszeitkonstante��$��35��$��17���� $ de-de�$	�   ���� -   $ tab_Regler_P��$	�� P ��$��-2,-2,-5,-1q�.��� $
��Left=�$	��191��$	��Top=�$	��489��.+�  -   $ Base_Slider_P_Vr��$
��Left=�$��	10,10,0,0q�$	��Top=�$��35��$	��486��$
 Vr =���� -   $ butten_auslegen_P��$��Auslegen��$
��Left=�$��404,108,0,0q�$	��Top=�$��75���� $
��Left=�$��
13,108,0,0q�$
��Wrap=�$	��Top=�$��82��$# Laplace Übertragungsfunktion���� $ de-de�$�Fs = Vr���� $
��Left=�$��	10,10,0,0q�$
��Wrap=�$	��Top=�$ Proportional Verstärkung��$��35��$��17���� $ de-de�$	�   ���� -   $ tab_Regler_PI��$
�� PI ��$��-2,-2,-5,-1q�.��� $
��Left=�$	��140��$	��Top=�$	��489��$��0,0,-5,0q�.+�  -   $ Base_Slider_PI_Vr��$
��Left=�$��	10,10,0,0q�$	��Top=�$��35��$	��486��$
 Vr =��  -   $ Base_Slider_PI_Tn��$
��Left=�$��	10,59,0,0q�$	��Top=�$��35��$	��486��$
 Tn =���� -   $ butten_auslegen_PI��$��Auslegen��$
��Left=�$��404,108,0,0q�$	��Top=�$��75���� $
��Left=�$��
13,108,0,0q�$
��Wrap=�$	��Top=�$	��108��$# Laplace Übertragungsfunktion���� $ de-de�$�Fs = Vr ---------���� $
��Left=�$��	57,99,0,0q�$
��Wrap=�$	��Top=�$��43��$��15���� $ de-de�$�1+pTn���� $
��Left=�$��
67,119,0,0q�$
��Wrap=�$	��Top=�$��54��$��23���� $ de-de�$	�pTn���� $
��Left=�$��	10,10,0,0q�$
��Wrap=�$	��Top=�$ Proportional Verstärkung��$��35��$��17���� $ de-de�$	�   ���� $
��Left=�$��	10,59,0,0q�$
��Wrap=�$	��Top=�$ Nachhaltezeit��$��35��$��17���� $ de-de�$	�   ���� -   $ tab_Regler_PID��$	��PID��$��-2,-2,-5,-1q�.��� $
��Left=�$	��142��$	��Top=�$	��489��$��0,0,-5,0q�.+��� $
��Left=�$��
13,108,0,0q�$
��Wrap=�$	��Top=�$	��143��$# Laplace Übertragungsfunktion���� $ de-de�$�Fs = Vr -------- ���� $
��Bold"�$ de-de�$�(1+pTv)���� $
��Left=�$��	53,99,0,0q�$
��Wrap=�$	��Top=�$��51��$��15���� $ de-de�$�1+pTn���� $
��Left=�$��
59,119,0,0q�$
��Wrap=�$	��Top=�$��45��$��23���� $ de-de�$	�pTn���� $
��Left=�$��	44,28,0,0q�$
��Wrap=�$	��Top=�$��51��$	��361���� $ de-de�$�Benutzen Sie den ���� $
��Bold"�$ de-de�$�	D-Anteil ���� $ de-de�$^�Xfür eine Pole-Nullstellen Kompensation und verwenden Sie anschließend einen PI-Regler.���� $
��Left=�$��	10,28,0,0q�$
��Wrap=�$	��Top=�$��	Underline{��� $ de-de�$�Tipp:  ���� $��Regler��$
��Left=�$��
10,280,0,0q�$	��Top=�$��89��$��Italic$��� -    $ TabControl_Infos��$��
10,530,0,0q���. $
��Left=�$	��Top=�$	��167��$	��494��.@��� $��
Regelkreis��$��-2,-2,-5,-1q�.��� $
��Left=�$	��142��$	��Top=�$	��489��$��0,0,-5,0q�.+��� -!    ��Name$ image_Regelkreis��$
��Left=�$	��142��$	��Top=�$	��485��$��Regelkreis3.png���� $��Störung��$��-2,-2,-5,-1q�.��� $
��Left=�$	��142��$	��Top=�$	��489��.+�  -"   $ Base_Slider_St_Vz��$
��Left=�$��	10,10,0,0q�$	��Top=�$��35��$	��486��$	 Vz=���� $
��Left=�$��13,108,0,12q�$
��Wrap=�$	��151��$ Zeitfunktion���� $ de-de�$�z(t) = Vz*Sprung(t-Tz)��  -#   $ Base_Slider_St_Tz��$
��Left=�$��
10,59,-7,0q�$	��Top=�$��35��$	��486��$
 Tz =���� $
��Left=�$��	10,10,0,0q�$
��Wrap=�$	��Top=�$ Störungssprungwert��$��35��$��17���� $ de-de�$	�   ���� $
��Left=�$��	10,59,0,0q�$
��Wrap=�$	��Top=�$ Zeit des Sprunges��$��35��$��17���� $ de-de�$	�   ���� $��Solver��$��-2,-2,-5,-1q�.��� $
��Left=�$	��142��$	��Top=�$	��489��.+��� $
��Left=�$��	10,10,0,0q�$
��Wrap=�$	��Top=�$��58��$	��438���� $ de-de�$>�8Der Solver besitzt eine diskrete, feste Schrittweite Ts.���� �� $ de-de�$L�FEs wird das Trapezoidal-Verfahren zum simulieren der DGLs eingesetzt. ���� $
��Left=�$��	10,73,0,0q�$
��Wrap=�$	��Top=�$ Sample Zeit���� $ de-de�$�Ts = ���� -$   $	 
textBox_Ts��$
��Left=�$��23��$��	36,70,0,0q�$

 Wrap=�$	��200��$	��Top=�$��59���� -%    ��Name$ combmBox_Zeit��$
��Left=�$��	99,70,0,0q�$	��Top=�$��47��$��23��.@��� -&    ��Name$ 
comboBox_s��$��s���� -'   $ comboBox_ms��$��ms���� -(   $ comboBox_µs��$	��µs�� �� 
IsSelected . �� -)   $ comboBox_ns��$��ns���� $
��Left=�$��
10,101,0,0q�$
��Wrap=�$	��Top=�$! Endzeitpunkt der Simulation���� $ de-de�$�T  = ���� -*   $	 textBox_Tend��$
��Left=�$��23��$��	36,98,0,0q�$

 Wrap=�$	��200��$	��Top=�$��59���� -+   $ combmBox_Zeit_Tend��$
��Left=�$��	99,98,0,0q�$	��Top=�$��47��$��23��.@��� -,   $ comboBox_Tend_s��$��s���� --   $ comboBox_Tend_ms��$��ms�� . �� -.   $ comboBox_Tend_µs��$	��µs���� -/   $ comboBox_Tend_ns��$��ns���� $
��Left=�$��
14,111,0,0q�$
��Wrap=�$	��Top=�$  ��$��7(�$��12��$��15���� $ de-de�$	�end���� $
��Left=�$��
196,86,0,0q�$
��Wrap=�$	��Top=�$��31��$	��266���� $ de-de�$2�,Es wird jeder             te Wert geplottet.���� �� $ de-de�$2�,(Rechenaufw. Plot >> Rechenaufw. Simulation)���� -0   $	 textBox_plot_count��$
��Left=�$��23��$��
268,79,0,0q�$

 Wrap=�$��5��$	��Top=�$��33���� $��Quellen��$��-2,-2,-5,-1q�.��� $
��Left=�$	��142��$	��Top=�$	��489��.+��� $
��Left=�$��10,4,0,0q�$
��Wrap=�$	��Top=�$	��132��$	��438���� $ de-de�$�Skripte:�� �� TextDecorations$ 	Underline{��� �� $ de-de�$>�8- Regelungstechnik Skript      Prof. Dr. Konstantin Meyl���� �� $ de-de�$?�9- Systemtheorie Skript           Prof. Dr. Peter Strobach���� �� $ de-de��� �� $ de-de�$�Fachliteratur:��$ 	Underline{��� �� $ de-de�$/�)- Auf der Fährte von C#         Springer���� �� $ de-de�$-�'- C# Quick Reference             Apress���� �� $ de-de�$/�)- C# 3.0 Design Patterns        O'Reilly ���� $��Infos & Einstellungen��$
��Left=�$��
10,504,0,0q�$	��Top=�$	��142��$��Italic$�  Plott_o_mat.UserControl1  -1     Name$ Graph��$��
526,37,0,0q�$	��Top=�$	��588�� J� RenderTransformOrigin$ 0.5,0.5&�$
��Left=��� -2   $ butten_load��$
��Load��$
��Left=�$��283,531,0,0q�$	��Top=�$��40���� -3   $ butten_save��$
��Save��$
��Left=�$��243,531,0,0q�$	��Top=�$��40������  �� EndPoint$	 0,1&� �� 
StartPoint$	 0,0&�.���  � Color$ 	#FFF3F3F3�� � Offset$ 0Q�� $ 	#FFEBEBEB��$	 0.5Q�� $ 	#FFDDDDDD��$	 0.5Q�� $ 	#FFCDCDCD��$ 1Q��� -4    ��Name$ CheckBox_LivePlotOn��$��Live Plot on��$
��Left=�$��328,534,0,0q�$	��Top=� d� 	IsChecked$
 TrueY�