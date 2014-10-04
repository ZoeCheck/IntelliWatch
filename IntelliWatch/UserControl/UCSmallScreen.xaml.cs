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
	/// UCSmallScreen.xaml 的交互逻辑
	/// </summary>
	public partial class UCSmallScreen : UserControl
	{
		public bool IsMouseOver
		{
			get { return (bool)GetValue(IsMouseOverProperty); }
			set { SetValue(IsMouseOverProperty, value); }
		}

		// Using a DependencyProperty as the backing store for IsMouseOver.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IsMouseOverProperty =
			DependencyProperty.Register("IsMouseOver", typeof(bool), typeof(UCSmallScreen), new UIPropertyMetadata(false));



		public UCSmallScreen()
		{
			this.InitializeComponent();
			this.DataContext = this;
		}

		private void UserControl_MouseEnter(object sender, MouseEventArgs e)
		{
			IsMouseOver = true;
		}

		private void UserControl_MouseLeave(object sender, MouseEventArgs e)
		{
			IsMouseOver = false;
		}
	}
}