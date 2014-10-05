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
using System.Windows.Media.Animation;

namespace IntelliWatch
{
	/// <summary>
	/// UCRT2.xaml 的交互逻辑
	/// </summary>
	public partial class UCRT2 : UserControl
	{
		private Storyboard stortyBoardShowDate;
		private Storyboard stortyBoardHideDate;
		private bool isShow = false;
		private Style middleItemStyle1;
		private Style middleItemStyle2;

		public UCRT2()
		{
			this.InitializeComponent();
			InitAnimation();
			tbcMain.SelectionChanged += TabControlUC_SelectionChanged;
			middleItemStyle1 = this.FindResource("TabItemStyleTreeView12") as Style;
			middleItemStyle2 = this.FindResource("TabItemStyleTreeView22") as Style;
		}

		private void InitAnimation()
		{
			//显示日期动画
			stortyBoardShowDate = new Storyboard();
			DoubleAnimation daShowHeight = new DoubleAnimation();
			daShowHeight.To = 180;
			daShowHeight.Duration = TimeSpan.FromSeconds(0.5);
			daShowHeight.EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut };
			Storyboard.SetTarget(daShowHeight, ucDatePicker);
			Storyboard.SetTargetProperty(daShowHeight, new PropertyPath(System.Windows.Controls.UserControl.HeightProperty));
			stortyBoardShowDate.Children.Add(daShowHeight);

			//隐藏日期动画
			stortyBoardHideDate = new Storyboard();
			DoubleAnimation daHideHeight = new DoubleAnimation();
			daHideHeight.To = 0;
			daHideHeight.Duration = TimeSpan.FromSeconds(0.5);
			daHideHeight.EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut };
			Storyboard.SetTarget(daHideHeight, ucDatePicker);
			Storyboard.SetTargetProperty(daHideHeight, new PropertyPath(System.Windows.Controls.UserControl.HeightProperty));
			stortyBoardHideDate.Children.Add(daHideHeight);
		}

		private void btnOpenDatePicker_Click(object sender, RoutedEventArgs e)
		{
			if (isShow)
			{
				isShow = false;
				stortyBoardHideDate.Begin(this, true);
			}
			else
			{
				isShow = true;
				stortyBoardShowDate.Begin(this, true);
			}
		}

		private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			TreeViewItem tviNew = e.NewValue as TreeViewItem;
			TreeViewItem tviOld = e.OldValue as TreeViewItem;

			if (tviNew != null)
			{
				tviNew.Foreground = new SolidColorBrush(Color.FromRgb(137, 243, 236));
			}

			if (tviOld != null)
			{
				tviOld.Foreground = new SolidColorBrush(Colors.White);
			}
		}

		private void TabControlUC_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			int index = tbcMain.SelectedIndex;
			if (index == 0)//选择第一页
			{
				tabMiddle.Style = middleItemStyle1;
			}
			else if (index == 2)//选择最后一页
			{
				tabMiddle.Style = middleItemStyle2;
			}
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
				tiNew.Foreground = new SolidColorBrush(Colors.White);
			}
			if (tiOld != null)
			{
				//tiOld.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 120));
				tiOld.Foreground = new SolidColorBrush(Color.FromRgb(177, 206, 239));
			}

			e.Handled = true;
		}
	}
}