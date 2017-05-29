/*
 * Created by SharpDevelop.
 * User: Furkan
 * Date: 21.05.2017
 * Time: 03:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ADSLChangeNotify
{
	/// <summary>
	/// Description of SettingsNotifyEventArgs.
	/// </summary>
	public class SettingsNotifyEventArgs : EventArgs
	{
		private readonly bool enabled;
		
		public bool Enabled {
			get {
				return enabled;
			}
		}
		
		public SettingsNotifyEventArgs(bool enabled)
		{
			this.enabled = enabled;
		}
	}
}
