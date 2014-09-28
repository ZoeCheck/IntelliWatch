using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IntelliWatch
{
	/// <summary>
	/// UCDatePicker.xaml 的交互逻辑
	/// </summary>
	public partial class UCDatePicker : UserControl
	{
		public int year { get; set; }
		public int month { get; set; }
		DateModel dm = new DateModel();

		public UCDatePicker()
		{
			this.InitializeComponent();
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			year = 2014;
			month = 9;
			dm.SetDayModel(year, month);
			SetControlShow();
			cmbYear.SelectionChanged +=new SelectionChangedEventHandler(cmbYear_SelectionChanged);
			cmbMonth.SelectionChanged +=new SelectionChangedEventHandler(cmbMonth_SelectionChanged);
		}

		private void cmbYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (e.AddedItems != null)
			{
				ComboBoxItem cbi = ((object[])(e.AddedItems))[0] as ComboBoxItem;
				year = Convert.ToInt32(cbi.Content);

				dm.SetDayModel(year, month);
				SetControlShow();
			}
		}

		private void cmbMonth_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (e.AddedItems != null)
			{
				ComboBoxItem cbi = ((object[])(e.AddedItems))[0] as ComboBoxItem;
				month = Convert.ToInt32(cbi.Content);

				dm.SetDayModel(year, month);
				SetControlShow();
			}
		}

		private void SetControlShow()
		{
			r1.Content = dm.dayModelList[0].Day;
			r2.Content = dm.dayModelList[1].Day;
			r3.Content = dm.dayModelList[2].Day;
			r4.Content = dm.dayModelList[3].Day;
			r5.Content = dm.dayModelList[4].Day;
			r6.Content = dm.dayModelList[5].Day;
			r7.Content = dm.dayModelList[6].Day;
			r8.Content = dm.dayModelList[7].Day;
			r9.Content = dm.dayModelList[8].Day;
			r10.Content = dm.dayModelList[9].Day;
			r11.Content = dm.dayModelList[10].Day;
			r12.Content = dm.dayModelList[11].Day;
			r13.Content = dm.dayModelList[12].Day;
			r14.Content = dm.dayModelList[13].Day;
			r15.Content = dm.dayModelList[14].Day;
			r16.Content = dm.dayModelList[15].Day;
			r17.Content = dm.dayModelList[16].Day;
			r18.Content = dm.dayModelList[17].Day;
			r19.Content = dm.dayModelList[18].Day;
			r20.Content = dm.dayModelList[18].Day;
			r21.Content = dm.dayModelList[20].Day;
			r22.Content = dm.dayModelList[21].Day;
			r23.Content = dm.dayModelList[22].Day;
			r24.Content = dm.dayModelList[23].Day;
			r25.Content = dm.dayModelList[24].Day;
			r26.Content = dm.dayModelList[25].Day;
			r27.Content = dm.dayModelList[26].Day;
			r28.Content = dm.dayModelList[27].Day;
			r29.Content = dm.dayModelList[28].Day;
			r30.Content = dm.dayModelList[29].Day;
			r31.Content = dm.dayModelList[30].Day;
			r32.Content = dm.dayModelList[31].Day;
			r33.Content = dm.dayModelList[32].Day;
			r34.Content = dm.dayModelList[33].Day;
			r35.Content = dm.dayModelList[34].Day;
			r36.Content = dm.dayModelList[35].Day;
			r37.Content = dm.dayModelList[36].Day;
			r38.Content = dm.dayModelList[37].Day;
			r39.Content = dm.dayModelList[38].Day;
			r40.Content = dm.dayModelList[39].Day;
			r41.Content = dm.dayModelList[40].Day;
			r42.Content = dm.dayModelList[41].Day;
		}
	}
}