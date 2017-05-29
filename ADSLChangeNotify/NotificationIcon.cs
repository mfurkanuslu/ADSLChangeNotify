using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

using Timer = System.Windows.Forms.Timer;

namespace ADSLChangeNotify
{
	public sealed class NotificationIcon
	{
		private NotifyIcon notifyIcon;
		private ContextMenu notificationMenu;
		private Timer timer;
		private Settings settings;
		private ADSLInfo adslInfo;
		private string downRate;
		private string upRate;
		
		#region Initialize icon and menu
		public NotificationIcon()
		{
			notifyIcon = new NotifyIcon();
			notificationMenu = new ContextMenu(InitializeMenu());
			
			notifyIcon.DoubleClick += IconDoubleClick;
			notifyIcon.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
			notifyIcon.ContextMenu = notificationMenu;
			timer = new Timer();
			timer.Tick += timer_Tick;
			settings = new Settings();
			settings.NotifyEnabledChanged += settings_NotifyEnabledChanged;
			settings.RefreshIntervalChanged += settings_RefreshIntervalChanged;
			settings.NotifyEnabled = true;
			settings.RefreshInterval = 1;
			adslInfo = new ADSLInfo();
		}
		
		private MenuItem[] InitializeMenu()
		{
			MenuItem[] menu = new MenuItem[] {
				new MenuItem("Ayarlar", MenuSettingsClick),
				new MenuItem("Çıkış", MenuExitClick)
			};
			return menu;
		}
		#endregion
		
		#region Main - Program entry point
		/// <summary>Program entry point.</summary>
		/// <param name="args">Command Line Arguments</param>
		[STAThread]
		public static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			bool isFirstInstance;
			using (Mutex mtx = new Mutex(true, "ADSLChangeNotify", out isFirstInstance)) {
				if (isFirstInstance) {
					NotificationIcon notificationIcon = new NotificationIcon();
					if (notificationIcon.TryLogin()) {
						notificationIcon.notifyIcon.Visible = true;
						notificationIcon.UpdateStatusInfo(false);
						Application.Run();
					}
					notificationIcon.adslInfo.LogOut();
					notificationIcon.notifyIcon.Dispose();
				} else {
					
				}
			}
		}
		#endregion
		
		public bool TryLogin(string info = "")
		{
			var loginForm = new LoginForm(info);
			if (loginForm.ShowDialog() != DialogResult.OK)
				return false;
			
			var IP = loginForm.GetIp();
			var password = loginForm.GetPassword();
			
			try {
				if (adslInfo.TryLogin(IP, password)) {
					return true;
				}
			} catch (WebException) {
				return TryLogin("Modeminize erişilemedi!");
			}
			return TryLogin("Şifre yanlış!");
		}
		
		private void ShowSettings()
		{
			var settingsForm = new SettingsForm(settings);
			if (settingsForm.ShowDialog() == DialogResult.OK) {
				settings.GetSettingsFrom(settingsForm.getSettings());
			}
		}
		
		#region Event Handlers
		private void MenuSettingsClick(object sender, EventArgs e)
		{
			ShowSettings();
		}
		
		private void MenuExitClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
		
		private void IconDoubleClick(object sender, EventArgs e)
		{
			UpdateStatusInfo(notifyVerbose: true);
		}

		void settings_NotifyEnabledChanged(object sender, SettingsNotifyEventArgs e)
		{
			timer.Enabled = e.Enabled;
		}

		void settings_RefreshIntervalChanged(object sender, SettingsRefreshEventArgs e)
		{
			timer.Interval = e.Interval * 60000;
		}
		
		bool UpdateStatusInfo(bool withNotify = true, bool notifyVerbose = false)
		{
			string oldDownRate = downRate;
			string oldUpRate = upRate;
			try {
				adslInfo.RequestRates();
				downRate = adslInfo.GetDownLinkRate();
				upRate = adslInfo.GetUpLinkRate();
				notifyIcon.Text = String.Format("İndirme: {0}, Gönderme: {1}", downRate, upRate);
				bool isChanged = downRate != oldDownRate || upRate != oldUpRate;
				if (withNotify && settings.NotifyEnabled) {
					if (isChanged) {
						notifyIcon.ShowBalloonTip(5000, "ADSL hızı değişti", String.Format("İndirme: {0}, Gönderme: {1}", downRate, upRate), ToolTipIcon.Info);
					} else if (notifyVerbose) {
						notifyIcon.ShowBalloonTip(5000, "ADSL hız değişikliği yok.", "Hız son kontrolden beri aynı.", ToolTipIcon.Info);
					}
				}
				return isChanged;
			} catch (WebException ex) {
				notifyIcon.ShowBalloonTip(5000, "Modeme erişirken hata!", "Modemden bilgi alınamadı!", ToolTipIcon.Error);
				return true;
			}
		}

		void timer_Tick(object sender, EventArgs e)
		{
			UpdateStatusInfo();
		}
		
		#endregion
	}
}
