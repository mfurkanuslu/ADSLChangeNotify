/*
 * Created by SharpDevelop.
 * User: Furkan
 * Date: 21.05.2017
 * Time: 03:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ADSLChangeNotify
{
	/// <summary>
	/// Description of SettingsRefreshEventArgs.
	/// </summary>
	public class SettingsRefreshEventArgs : EventArgs
	{
		private readonly int interval;
		
		public int Interval {
			get {
				return interval;
			}
		}
		
		public SettingsRefreshEventArgs(int interval)
		{
			this.interval = interval;
		}
	}
}
