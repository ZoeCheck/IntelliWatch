using System;
using System.Collections.Generic;
using System.Linq;
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
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			//WindowTest wt = new WindowTest();
			//wt.ShowDialog();
		}

		private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			TabItem tiNew = null;
			TabItem tiOld = null;
			if (e.AddedItems.Count > 0)
			{
				tiNew = e.AddedItems[0] as TabItem;
			}
			if (e.RemovedItems.Count > 0)
			{
				tiOld = e.RemovedItems[0] as TabItem;
			}
			if (tiNew != null)
			{
				tiNew.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 120));
			}
			if (tiOld != null)
			{
				tiOld.Foreground = new SolidColorBrush(Colors.White);
			}
		}
	}
}
