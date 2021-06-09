using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionManagement
{
	public partial class MembersMain : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string user = Request.QueryString["u"];
			string pass = Request.QueryString["p"];
			if (user == "bgates" || user == "rsawnson")
			{
				lblUser.Text = "Hello, " + user + "! Your password is " + pass;
			}
			else
			{ lblUser.Text = "no user log in"; }
		}
	}
}