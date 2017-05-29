/*
 * Created by SharpDevelop.
 * User: Furkan
 * Date: 21.05.2017
 * Time: 00:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ADSLChangeNotify
{
	/// <summary>
	/// Description of Settings.
	/// </summary>
	public class Settings
	{
		private int refreshInterval;
		private bool notifyEnabled;
		
		public int RefreshInterval {
			get { return refreshInterval; }
			set {
				int old_value = refreshInterval;
				refreshInterval = value;
				if (onRefreshIntervalChanged != null && value != old_value) {
					onRefreshIntervalChanged(this, new SettingsRefreshEventArgs(RefreshInterval));
				}				
			}
		}
		
		public bool NotifyEnabled {
			get { return notifyEnabled; }
			set {
				bool old_value = notifyEnabled;
				notifyEnabled = value;
				if (onNotifyEnabledChanged != null && value != old_value) {
					onNotifyEnabledChanged(this, new SettingsNotifyEventArgs(NotifyEnabled));
				}
			}
		}
		
		public delegate void RefreshIntervalEventHandler(object sender, SettingsRefreshEventArgs e);
		public delegate void NotifyEnabledEventHandler(object sender, SettingsNotifyEventArgs e);
		
		private RefreshIntervalEventHandler onRefreshIntervalChanged;
		private NotifyEnabledEventHandler onNotifyEnabledChanged;
		
		public Settings(int refreshInterval = 30, bool notifyEnabled = false)
		{
			this.RefreshInterval = refreshInterval;
			this.NotifyEnabled = notifyEnabled;
		}
		
		public Settings(Settings settings)
		{
			GetSettingsFrom(settings);
		}
		
		public void GetSettingsFrom(Settings settings)
		{
			this.RefreshInterval = settings.RefreshInterval;
			this.NotifyEnabled = settings.NotifyEnabled;
		}
		
		public event RefreshIntervalEventHandler RefreshIntervalChanged {
			add {
				onRefreshIntervalChanged = (RefreshIntervalEventHandler)Delegate.Combine(onRefreshIntervalChanged, value);
			} remove {
				onRefreshIntervalChanged = (RefreshIntervalEventHandler)Delegate.Remove(onRefreshIntervalChanged, value);
			}
		}
		
		public event NotifyEnabledEventHandler NotifyEnabledChanged {
			add {
				onNotifyEnabledChanged = (NotifyEnabledEventHandler)Delegate.Combine(onNotifyEnabledChanged, value);
			} remove {
				onNotifyEnabledChanged = (NotifyEnabledEventHandler)Delegate.Remove(onNotifyEnabledChanged, value);
			}
		}
	}
}
