using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.ComponentModel;
using System.Windows.Input;

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
		private double cameraMinLeft;
		private double cameraMaxLeft;
		private double cameraMinTop;
		private double cameraMaxTop;

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

		private void InitBackImg()
		{
			string path = AppDomain.CurrentDomain.BaseDirectory;
			UCMainPage uc1 = r1.Content as UCMainPage;
			uc1.SetBackImg(path + @"Image\1.png");

			UCMainPage uc2 = r2.Content as UCMainPage;
			uc2.SetBackImg(path + @"Image\2.png");

			UCMainPage uc3 = r3.Content as UCMainPage;
			uc3.SetBackImg(path + @"Image\3.png");

			UCMainPage uc4 = r4.Content as UCMainPage;
			uc4.SetBackImg(path + @"Image\4.png");
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			if (!DesignerProperties.GetIsInDesignMode(this))
			{
				InitBackImg();
			}
		}

		private void ShowCameraControl(double left, double top)
		{
			UCCamera.Visibility = System.Windows.Visibility.Visible;
			UCCamera.Margin = new Thickness(left, top, 0, 0);
			Grid.SetRow(UCCamera, 0);
			Grid.SetColumn(UCCamera, 1);
			Grid.SetRowSpan(UCCamera, 1);
			Grid.SetColumnSpan(UCCamera, 1);
		}

		private void HideCameraControl()
		{
			if ((bool)UCCamera.chbShow.IsChecked)
			{
				UCCamera.chbShow.IsChecked = false;
				UCCamera.Visibility = System.Windows.Visibility.Hidden;
			}
		}

		private void UserControl_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			if (e.RightButton == System.Windows.Input.MouseButtonState.Pressed)
			{
				Point mousePoint = Mouse.GetPosition(LayoutRoot);
				double right = this.ActualWidth - 215;//右侧显示极限
				double bottom = this.ActualHeight - 270;//下侧显示极限
				if (mousePoint.X <= 10)
				{
					mousePoint.X = 10;
				}
				if (mousePoint.X >= right)
				{
					return;
				}
				if (mousePoint.Y >= bottom)
				{
					mousePoint.Y = bottom;
				}

				//ShowCameraControl(-(this.ActualWidth - 215 - mousePoint.X + 70), mousePoint.Y - 40);
				ShowCameraControl(-(this.ActualWidth - 215 - mousePoint.X), mousePoint.Y);
				//ShowCameraControl(mousePoint.X, mousePoint.Y);

				cameraMinLeft = mousePoint.X - 12;
				cameraMaxLeft = mousePoint.X + 260;
				cameraMinTop = mousePoint.Y;
				cameraMaxTop = mousePoint.Y + 260 + 12;
			}
		}

		private void LayoutRoot_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Point mousePoint = Mouse.GetPosition(LayoutRoot);
			{
				if (mousePoint.X < cameraMinLeft || mousePoint.X > cameraMaxLeft)
				{
					HideCameraControl();
				}

				if (mousePoint.Y < cameraMinTop || mousePoint.Y > cameraMaxTop)
				{
					UCCamera.Visibility = System.Windows.Visibility.Hidden;
					HideCameraControl();

				}
			}
		}
	}
}