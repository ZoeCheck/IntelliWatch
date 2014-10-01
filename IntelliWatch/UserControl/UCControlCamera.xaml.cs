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
	/// UCControlCamera.xaml 的交互逻辑
	/// </summary>
	public partial class UCControlCamera : UserControl
	{
		#region 变量
		double r = 80;//半径
		RotateTransform rt;//角度
		double allowHeightTop;//允许高度范围
		double allowHeightBottom;//允许高度范围
		Storyboard storyboardShow;//展开控件动画
		Storyboard storyboardHide;//收缩控件动画
		#endregion

		#region 委托事件

		#endregion

		#region 属性

		#endregion

		#region 构造函数
		public UCControlCamera()
		{
			this.InitializeComponent();
		}
		#endregion

		#region 业务

		#endregion

		private void CanvasMain_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			var targetElement = e.Source as IInputElement;
			if (targetElement != null)
			{
				//开始捕获鼠标
				targetElement.CaptureMouse();
			}
		}

		private void CanvasMain_PreviewMouseMove(object sender, MouseEventArgs e)
		{
			//确定鼠标左键处于按下状态并且有元素被选中
			var targetElement = Mouse.Captured as UIElement;

			if (e.LeftButton == MouseButtonState.Pressed && targetElement != null)
			{
				Point pCanvas = e.GetPosition(CanvasMain);
				if (pCanvas.Y < allowHeightTop)
				{
					pCanvas.Y = allowHeightTop;
				}
				if (pCanvas.Y > allowHeightBottom)
				{
					pCanvas.Y = allowHeightBottom;
				}
				double locationY = pCanvas.Y - r;
				double locationX = Math.Sqrt(r * r - locationY * locationY);

				//设置最终位置
				Canvas.SetLeft(rtMover, locationX - rtMover.Width / 2);
				Canvas.SetTop(rtMover, pCanvas.Y - rtMover.Height / 2);
				if (pCanvas.Y <= CanvasMain.Height / 2)
				{
					rt.Angle = Math.Round(Math.Asin(locationX / r) / Math.PI * 180, 2);
				}
				else
				{
					rt.Angle = Math.Round(180 - Math.Asin(locationX / r) / Math.PI * 180, 2);
				}
				//this.Cursor = System.Windows.Input.Cursors.ScrollAll;
			}
		}

		private void CanvasMain_PreviewMouseUp(object sender, MouseButtonEventArgs e)
		{
			//取消捕获鼠标   
			Mouse.Capture(null);
			//this.Cursor = System.Windows.Input.Cursors.Arrow;
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			r = CanvasMain.Width;

			rt = new RotateTransform();
			rt.CenterX = rtMover.Width / 2;
			rt.CenterY = rtMover.Height / 2;

			rtMover.RenderTransform = rt;

			allowHeightTop = 38;
			allowHeightBottom = CanvasMain.Height - allowHeightTop;

			//设置Mover的初始位置
			double left = Math.Round(Math.Sqrt(r * r - (allowHeightTop - r) * (allowHeightTop - r)), 2);
			Canvas.SetLeft(rtMover, left - rtMover.Width / 2);
			Canvas.SetTop(rtMover, allowHeightTop - rtMover.Height / 2);
			rt.Angle = Math.Round(Math.Asin(left / r) / Math.PI * 180, 2);

			storyboardShow = this.FindResource("StoryboardShow") as Storyboard;
			storyboardHide = this.FindResource("StoryboardHide") as Storyboard;

			foreach (Button item in plbControl.Items)
			{
				ScaleTransform st = ((TransformGroup)item.RenderTransform).Children[0] as ScaleTransform;
				st.ScaleX = 0;
				st.ScaleY = 0;
			}
		}

		private void chbShow_Checked(object sender, RoutedEventArgs e)
		{
			if (storyboardShow != null)
			{
				storyboardShow.Begin();
			}
		}

		private void chbShow_Unchecked(object sender, RoutedEventArgs e)
		{
			if (storyboardHide != null)
			{
				storyboardHide.Begin();
			}
		}
	}
}