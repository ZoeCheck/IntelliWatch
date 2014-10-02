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
	/// UCTractBar.xaml 的交互逻辑
	/// </summary>
	public partial class UCTractBar : UserControl, INotifyPropertyChanged
	{
		public double CutLeft
		{
			get { return (double)GetValue(LeftProperty); }
			set { SetValue(LeftProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Left.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty LeftProperty =
			DependencyProperty.Register("Left", typeof(double), typeof(UCTractBar), new UIPropertyMetadata(0.0));



		public double CutLength
		{
			get { return (double)GetValue(CutLengthProperty); }
			set { SetValue(CutLengthProperty, value); }
		}

		// Using a DependencyProperty as the backing store for CutLength.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CutLengthProperty =
			DependencyProperty.Register("CutLength", typeof(double), typeof(UCTractBar), new UIPropertyMetadata(0.0));



		public UCTractBar()
		{
			this.InitializeComponent();
			this.DataContext = this;
		}

		private void CanvasCut_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			var targetElement = e.Source as IInputElement;
			if (targetElement != null)
			{
				//开始捕获鼠标
				targetElement.CaptureMouse();
			}
		}

		private void CanvasCut_PreviewMouseMove(object sender, MouseEventArgs e)
		{
			//确定鼠标左键处于按下状态并且有元素被选中
			var targetElement = Mouse.Captured as UIElement;

			if (e.LeftButton == MouseButtonState.Pressed && targetElement != null)
			{
				Point pCanvas = e.GetPosition(CanvasCut);
				Button btn = targetElement as Button;
				if (btn != null)
				{
					//设置剪切按钮的最终位置
					Canvas.SetLeft(btn, pCanvas.X - btn.Width / 2);
					Canvas.SetTop(btn, CanvasCut.ActualHeight / 2 - btn.Height / 2);

					//设置范围rectangle的左边距和长度
					Canvas.SetLeft(rtCut, Canvas.GetLeft(btnBegin));
					CutLength = Canvas.GetLeft(btnEnd) - Canvas.GetLeft(btnBegin);
				}

				//this.Cursor = System.Windows.Input.Cursors.ScrollAll;
			}
		}

		private void CanvasCut_PreviewMouseUp(object sender, MouseButtonEventArgs e)
		{
			//取消捕获鼠标   
			Mouse.Capture(null);
			//this.Cursor = System.Windows.Input.Cursors.Arrow;
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