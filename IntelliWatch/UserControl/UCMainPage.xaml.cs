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
	/// UCMainPage.xaml 的交互逻辑
	/// </summary>
	public partial class UCMainPage : UserControl
	{
		public UCMainPage()
		{
			this.InitializeComponent();
		}

		public void SetBackImg(string path)
		{
			ImageBrush mapBrush = new ImageBrush();
			mapBrush.ImageSource = new BitmapImage(new Uri(path, UriKind.Relative));
			this.BorderMain.Background = mapBrush;
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			//ContextMenu cmMain = new ContextMenu();
			//cmMain.Items.Add(new UCControlCamera());
			//this.ContextMenu = cmMain;

			//Style st = this.FindResource("MyContextMenu") as Style;
			//cmMain.Style = st;
			//Style stItem = this.FindResource("MyMenuItem") as Style;
		}

		private void UserControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.RightButton == MouseButtonState.Pressed)
			{
				//UCCC.Visibility = System.Windows.Visibility.Visible;

			}
		}
	}
}