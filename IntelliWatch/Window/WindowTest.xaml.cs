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
using System.Windows.Shapes;

namespace IntelliWatch
{
	/// <summary>
	/// WindowTest.xaml 的交互逻辑
	/// </summary>
	public partial class WindowTest : Window
	{
		double r = 80;//半径
		RotateTransform rt;//角度
		double allowHeightTop;//允许高度范围
		double allowHeightBottom;//允许高度范围

		public WindowTest()
		{
			this.InitializeComponent();
			
			// 在此点之下插入创建对象所需的代码。
		}

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
				Canvas.SetLeft(btnMover, locationX - btnMover.Width / 2);
				Canvas.SetTop(btnMover, pCanvas.Y - btnMover.Height / 2);
				if (pCanvas.Y <= CanvasMain.Height / 2)
				{
					rt.Angle = Math.Asin(locationX / r) / Math.PI * 180;
				}
				else
				{
					rt.Angle = 180 - Math.Asin(locationX / r) / Math.PI * 180;
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

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			r = CanvasMain.Width;

			rt = new RotateTransform();
			rt.Angle = 0;
			rt.CenterX = btnMover.Width / 2;
			rt.CenterY = btnMover.Height / 2;

			btnMover.RenderTransform = rt;

			allowHeightTop = 20;
			allowHeightBottom = CanvasMain.Height - allowHeightTop;			
		}
	}
}