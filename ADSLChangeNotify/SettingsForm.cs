/*
 * Created by SharpDevelop.
 * User: Furkan
 * Date: 21.05.2017
 * Time: 00:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ADSLChangeNotify
{
	/// <summary>
	/// Description of SettingsForm.
	/// </summary>
	public partial class SettingsForm : Form
	{
		public SettingsForm(Settings settings)
		{
			InitializeComponent();
			notifyCheckBox.Checked = settings.NotifyEnabled;
			refreshIntervalUpDown.Value = settings.RefreshInterval;
		}
		public Settings getSettings() {
			return new Settings((int)refreshIntervalUpDown.Value, notifyCheckBox.Checked);
		}
	}
}
