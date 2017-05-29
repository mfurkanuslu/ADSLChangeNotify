/*
 * Created by SharpDevelop.
 * User: Furkan
 * Date: 21.05.2017
 * Time: 04:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ADSLChangeNotify
{
	/// <summary>
	/// Description of LoginForm.
	/// </summary>
	public partial class LoginForm : Form
	{
		public LoginForm(string info = "")
		{
			InitializeComponent();
			infoLabel.Text = info;
		}
		public string GetPassword()
		{
			return passwordTextBox.Text;
		}
		public string GetIp()
		{
			return ipTextBox.Text;
		}
	}
}
