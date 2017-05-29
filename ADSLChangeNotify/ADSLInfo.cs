/*
 * Created by SharpDevelop.
 * User: Furkan
 * Date: 21.05.2017
 * Time: 03:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace ADSLChangeNotify
{
	/// <summary>
	/// Description of ADSLInfo.
	/// </summary>
	public class ADSLInfo
	{
		string downLinkRate;
		string upLinkRate;
		string sessionId;
		string IP;
		bool logged;
		
		public ADSLInfo()
		{
			logged = false;
		}
		
		public bool TryLogin(string IP, string password)
		{
			if (logged) {
				LogOut();
			}
			this.IP = IP;
			var nameValueCollection = new NameValueCollection();
			nameValueCollection.Add("redirect", "");
			nameValueCollection.Add("user", "admin");
			nameValueCollection.Add("password", password);
			string cookieStr = null;
			using (var webClient = new WebClient()) {
				webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
				webClient.UploadValues("http://" + this.IP + "/cgi-bin/login", "POST", nameValueCollection);
				cookieStr = webClient.ResponseHeaders.Get("Set-Cookie");
			}
			if (!String.IsNullOrEmpty(cookieStr)) {
				sessionId = cookieStr.Split(';')[0].Split('=')[1];
			}
			logged = sessionId != null;
			return logged;
		}
		
		public bool RequestRates()
		{
			using (var webClient = new WebClient()) {
				webClient.Headers.Add("X-Requested-With", "XMLHttpRequest");
				webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
				webClient.Headers.Add("Cookie", "AIRTIESSESSION=" + sessionId);
				var xmlRes = webClient.UploadString("http://" + this.IP + "/cgi-bin/webapp", "<xmlrequest version=\"1.0.1\"><query inst=\"dsl-0\"><key>downlink</key><value/></query><query inst=\"dsl-0\"><key>uplink</key><value/></query></xmlrequest>");
				using (var xmlReader = XmlReader.Create(new StringReader(xmlRes))) {
					while (xmlReader.Read()) {
						if (xmlReader.Name != "dsl-0")
							continue;
						if (!xmlReader.IsStartElement())
							continue;
						using (var subXmlReader = xmlReader.ReadSubtree()) {
							subXmlReader.ReadStartElement();
							if (subXmlReader.Name == "key") {
								var c = subXmlReader.ReadElementContentAsString();
								if (c == "downlink.rate") {
									downLinkRate = subXmlReader.ReadElementContentAsString("value", "");
								} else if (c == "uplink.rate") {
									upLinkRate = subXmlReader.ReadElementContentAsString("value", "");
								}
							}
						}
					}
				}
			}
			return true;
		}
		
		public string GetDownLinkRate()
		{
			return downLinkRate;
		}
		public string GetUpLinkRate()
		{
			return upLinkRate;
		}
		
		public void LogOut()
		{
			if (!string.IsNullOrEmpty(sessionId)) {
				using (var webClient = new WebClient()) {
					webClient.Headers.Add("X-Requested-With", "XMLHttpRequest");
					webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
					webClient.Headers.Add("Cookie", "AIRTIESSESSION=" + sessionId);
					webClient.UploadString("http://" + this.IP + "/cgi-bin/webapp", "<xmlrequest version=\"1.0.1\"><command inst=\"webui-0\"><key>delete_session</key><value/></command></xmlrequest>");
				}
				sessionId = null;
				logged = false;
			}
		}
	}
}
