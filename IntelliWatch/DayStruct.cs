using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntelliWatch
{
	/// <summary>
	/// 作者：xxh 
	/// 时间：2014-09-28 11:13:14
	/// 版本：V1.0.0 	 
	/// </summary>
	public struct DayStruct
	{
		/// <summary>
		/// 第一周~第六周
		/// </summary>
		public int X;

		/// <summary>
		/// 星期几
		/// </summary>
		public int Y;

		public DayStruct(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
}
