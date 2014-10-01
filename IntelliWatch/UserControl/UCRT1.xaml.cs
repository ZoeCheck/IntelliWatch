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
	/// UCRT1.xaml 的交互逻辑
	/// </summary>
	public partial class UCRT1 : UserControl
	{
		private Storyboard stortyBoardShowDate;
		private Storyboard stortyBoardHideDate;
		private bool isShow = false;

		public UCRT1()
		{
			this.InitializeComponent();
			InitAnimation();
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
	}
}