using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;

namespace SessionManagement
{
    public class TheModuel :IHttpModule
    {

		Dictionary<string, string> vdt = new Dictionary<string, string>();
		public void Dispose()
		{
			// nothing to dispose 
		}

		public void OnBeginRequest(object sender, EventArgs e)
		{
			var context = ((HttpApplication)sender).Context;
			var URL = context.Request.Path;
			string user =context.Request.QueryString["u"];
			string pass = context.Request.QueryString["p"];
			string eUser = string.Empty;
			string ePass = string.Empty;
			//so nothing will happen on defalt
			if (user != null)
			{
				//checks if the current encrypted value exists
				if (!vdt.ContainsKey(eUser))
				{
					eUser = encryptStuff(user);
					ePass = encryptStuff(pass);
					vdt.Add(eUser, user);
					vdt.Add(ePass, pass);
				}
			}
			//second check for diffrent things
			if (!string.IsNullOrEmpty(user)) 
			{
				//to make be able to go to the third page
				if (URL.Contains("WebForm1") && vdt.Count > 4)
				{
					URL = "MembersMain.aspx";
				}
				//putting the encrypted string into url 
				context.RewritePath(URL, string.Empty, "u=" + eUser + "&p=" + ePass, true);
				//this is to check if the web page has changed or and the browser url
				if (vdt.ContainsKey(user) && vdt.ContainsValue(user))
				{
					context.Response.Write(vdt[user]);
					context.Response.Write(vdt[eUser]);

					context.RewritePath(URL, string.Empty, "u=" + vdt[user] + "&p=" + vdt[pass], true);
				}
				//this is the basic change that will change the url to the encrypted value
				else if (vdt.ContainsValue(user))
				{
					context.Response.Redirect(context.Request.Url.ToString());
				}
			}

		}

		public void Init(HttpApplication context)
		{
			context.BeginRequest += new EventHandler(OnBeginRequest);

		}

		public string encryptStuff(string info)
		{
			Random r = new Random(DateTime.Now.Millisecond);
			Thread.Sleep(1);
			string salt = r.Next(100000, 999999).ToString();
			int a;
			byte[] b;
			byte[] h;
			b = ASCIIEncoding.ASCII.GetBytes(info);
			h = new MD5CryptoServiceProvider().ComputeHash(b);
			StringBuilder output = new StringBuilder(h.Length);
			for (a = 0; a < h.Length; a++)
			{
				output.Append(h[a].ToString("X2"));
			}
			return output.ToString().Substring(0, 6) + salt + output.ToString().Substring(6);
		}
	}
}
