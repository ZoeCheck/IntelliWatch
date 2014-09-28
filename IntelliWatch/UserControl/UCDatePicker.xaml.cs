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
using System.ComponentModel;

namespace IntelliWatch
{
	/// <summary>
	/// UCDatePicker.xaml 的交互逻辑
	/// </summary>
	public partial class UCDatePicker : UserControl, INotifyPropertyChanged
	{

		DateModel dm = new DateModel();

		private int _Year;

		public int Year
		{
			get { return _Year; }
			set
			{
				_Year = value;
				RaisePropertyChanged("Year");
			}
		}

		private int _Month;

		public int Month
		{
			get { return _Month; }
			set
			{
				if (value > 12)
				{
					value = 12;
				}
				if (value < 1)
				{
					value = 1;
				}
				_Month = value;
				RaisePropertyChanged("Month");
			}
		}

		public int Day { get; set; }



		public string SelectDate
		{
			get { return (string)GetValue(SelectDateProperty); }
			set { SetValue(SelectDateProperty, value); }
		}

		// Using a DependencyProperty as the backing store for SelectDate.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty SelectDateProperty =
			DependencyProperty.Register("SelectDate", typeof(string), typeof(UCDatePicker), new UIPropertyMetadata(""));



		public UCDatePicker()
		{
			this.InitializeComponent();
			this.DataContext = this;
			SelectDate = DateTime.Now.ToString("yyyy-MM-dd");
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			Year = DateTime.Now.Year;
			Month = DateTime.Now.Month;
			dm.SetDayModel(Year, Month);
			SetControlShow();
			InitRadioButtonCheckedEvent();
			string dayNow = DateTime.Now.Day.ToString();
			//设置选中的radiobutton
			foreach (var item in GridRadio.Children)
			{
				if (item.GetType() == typeof(RadioButton))
				{
					RadioButton rbt = (RadioButton)item;
					if (rbt.Content.ToString().Equals(dayNow))
					{
						rbt.IsChecked = true;
					}
				}
			}
		}

		private void InitRadioButtonCheckedEvent()
		{
			foreach (var item in GridRadio.Children)
			{
				if (item.GetType() == typeof(RadioButton))
				{
					RadioButton rbt = (RadioButton)item;
					rbt.Checked += rbt_Checked;
				}
			}
		}

		void rbt_Checked(object sender, RoutedEventArgs e)
		{
			Day = Convert.ToInt32(((RadioButton)sender).Content);
			SelectDate = string.Format("{0}-{1}-{2}", Year, Month, Day);
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
			r20.Content = dm.dayModelList[19].Day;
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

			CheckSelected();
		}

		private void btnPreviewYear_Click(object sender, RoutedEventArgs e)
		{
			Year--;
			dm.SetDayModel(Year, Month);
			SetControlShow();
			SelectDate = string.Format("{0}-{1}-{2}", Year, Month, Day);
		}

		private void btnNextYear_Click(object sender, RoutedEventArgs e)
		{
			Year++;
			dm.SetDayModel(Year, Month);
			SetControlShow();
			SelectDate = string.Format("{0}-{1}-{2}", Year, Month, Day);
		}

		private void btnPreviewMonth_Click(object sender, RoutedEventArgs e)
		{
			Month--;
			dm.SetDayModel(Year, Month);
			SetControlShow();
			SelectDate = string.Format("{0}-{1}-{2}", Year, Month, Day);
		}

		private void btnNextMonth_Click(object sender, RoutedEventArgs e)
		{
			Month++;
			dm.SetDayModel(Year, Month);
			SetControlShow();
			SelectDate = string.Format("{0}-{1}-{2}", Year, Month, Day);
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		private void CheckSelected()
		{
			foreach (var item in GridRadio.Children)
			{
				if (item.GetType() == typeof(RadioButton))
				{
					if (((RadioButton)item).IsChecked == true)
					{
						RadioButton rbt = (RadioButton)item;
						if (rbt.Content == "")
						{
							rbt.IsChecked = false;
						}
					}
				}
			}
		}
	}
}