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
	/// UCMainPage.xaml 的交互逻辑
	/// </summary>
	public partial class UCMainPage : UserControl, INotifyPropertyChanged
	{
		Storyboard sbShow;
		Storyboard sbHide;

		private bool _IsChecked;

		public bool IsChecked
		{
			get { return _IsChecked; }
			set
			{
				_IsChecked = value;
				RaisePropertyChanged("IsChecked");
			}
		}

		public UCMainPage()
		{
			this.InitializeComponent();
			this.DataContext = this;
			sbShow = this.FindResource("StoryboardShow") as Storyboard;
			sbHide = this.FindResource("StoryboardHide") as Storyboard;
		}

		public void SetBackImg(string path)
		{
			ImageBrush mapBrush = new ImageBrush();
			mapBrush.ImageSource = new BitmapImage(new Uri(path, UriKind.Relative));
			this.BorderMain.Background = mapBrush;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		private void ucBottom_MouseEnter(object sender, MouseEventArgs e)
		{
			if (IsChecked)
			{
				sbShow.Begin();
			}
		}

		private void ucBottom_MouseLeave(object sender, MouseEventArgs e)
		{
			if (IsChecked)
			{
				sbHide.Begin();
			}
		}
	}
}