using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace IntelliWatch
{
	/// <summary>
	/// 作者：xxh 
	/// 时间：2014-09-28 9:33:14
	/// 版本：V1.0.0 	 
	/// </summary>
	public class DateModel
	{
		public List<DayModel> dayModelList = new List<DayModel>();

		private int _Yaer;

		public int Yaer
		{
			get { return _Yaer; }
			set
			{
				_Yaer = value;
				//RaisePropertyChanged("Yaer");
			}
		}


		private int _Month;

		public int Month
		{
			get { return _Month; }
			set
			{
				_Month = value;
				//RaisePropertyChanged("Month");
			}
		}

		/// <summary>
		/// 初始化创建31个日期对象
		/// </summary>
		public DateModel()
		{
			for (int i = 0; i < 42; i++)
			{
				dayModelList.Add(new DayModel());
			}
		}

		public void SetDayModel(int year, int month)
		{
			DateTime dtFirstDay = Convert.ToDateTime(string.Format("{0}-{1}-1", year, month));
			int days = DateTime.DaysInMonth(year, month);//此月有几天
			////不足31天的部分日期置空
			//if (Days < 31)
			//{
			//    for (int i = 31; i > Days; i--)
			//    {
			//        dayModelList[i - 1].Day = "";
			//    }
			//}

			int dayInWeekIndex = Convert.ToInt32(dtFirstDay.DayOfWeek);//星期几
			int dayInListIndex = 0;//日期索引(42格)
			int dayIndex = 1;//不超过days的值，1号开始

			for (int i = 0; i < 6; i++)//1~6周
			{
				for (int j = 0; j < 7; j++, dayInListIndex++)//星期日~星期六
				{
					DayStruct dayPoint = new DayStruct(0, 0);
					if (i == 0)//第一周，判断第一行的数据
					{
						if (j < dayInWeekIndex)//上个月的
						{
							dayModelList[dayInListIndex].Day = "";//置空
							continue;
						}
						else
						{
							dayPoint.X = j;
							dayPoint.Y = 0;
							dayModelList[dayInListIndex].Day = (dayIndex).ToString();
						}
					}
					else
					{
						dayPoint.X = j;
						dayPoint.Y = i;
						if (dayIndex <= days)
						{
							dayModelList[dayInListIndex].Day = (dayIndex).ToString();
						}
						else//超过的部分都是空
						{
							dayModelList[dayInListIndex].Day = "";
						}
					}

					dayModelList[dayInListIndex].DayPoint = dayPoint;
					dayIndex++;
				}
			}
		}
	}
}
