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
using System.Windows.Media.Animation;

namespace IntelliWatch
{
	/// <summary>
	/// UCBottomComputer.xaml 的交互逻辑
	/// </summary>
	public partial class UCBottomComputer : UserControl, INotifyPropertyChanged
	{
		Storyboard sbMain;

		private bool _IsCheck;

		public bool IsCheck
		{
			get { return _IsCheck; }
			set
			{
				_IsCheck = value;
				RaisePropertyChanged("IsCheck");
				if (value)
				{
					rectangle.Visibility = System.Windows.Visibility.Visible;
					sbMain.Begin();
				}
				else
				{
					BorderMain.Visibility = System.Windows.Visibility.Collapsed;
					sbMain.Stop();
					rectangle.Visibility = System.Windows.Visibility.Hidden;
				}
			}
		}


		private string _CPUName;

		public string CPUName
		{
			get { return _CPUName; }
			set
			{
				_CPUName = value;
				RaisePropertyChanged("CPUName");
			}
		}

		public UCBottomComputer()
		{
			this.InitializeComponent();
			this.DataContext = this;
			CPUName = "线路1";
			sbMain = this.FindResource("StoryboardSelected") as Storyboard;
		}

		private void btn_MouseEnter(object sender, MouseEventArgs e)
		{
			Button btn = sender as Button;
			btn.Foreground = new SolidColorBrush(Color.FromRgb(0, 228, 255));
		}

		private void btn_MouseLeave(object sender, MouseEventArgs e)
		{
			Button btn = sender as Button;
			btn.Foreground = new SolidColorBrush(Colors.White);
		}

		private void StackPanelMain_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (IsCheck)
			{
				BorderMain.Visibility = System.Windows.Visibility.Visible;
			}
		}

		private void btnDelete_Click(object sender, RoutedEventArgs e)
		{
			BorderMain.Visibility = System.Windows.Visibility.Collapsed;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}