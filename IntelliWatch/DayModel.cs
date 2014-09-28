using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace IntelliWatch
{
	/// <summary>
	/// 作者：xxh 
	/// 时间：2014-09-28 9:33:32
	/// 版本：V1.0.0 	 
	/// </summary>
	public class DayModel
	{

		private DayStruct _DayPoint;

		public DayStruct DayPoint
		{
			get { return _DayPoint; }
			set
			{
				_DayPoint = value;
				//RaisePropertyChanged("DayPoint");
			}
		}

		
		private string _Day;

		public string Day
		{
			get { return _Day; }
			set
			{
				_Day = value;
				//RaisePropertyChanged("Day");
			}
		}

		public DayModel()
		{
			DayPoint = new DayStruct(0, 0);
		}
	}
}
