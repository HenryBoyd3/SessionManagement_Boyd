using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionManagement
{
	public partial class WebForm1 : System.Web.UI.Page
	{
		string user;
		string pass;
		protected void Page_Load(object sender, EventArgs e)
		{
			user = Request.QueryString["u"];
			pass = Request.QueryString["p"];

			lblUser.Text = "Hello, " + user + "! Your password is " + pass;
		}
		protected void btnLogIn_Click(object sender, EventArgs e)
		{
			Response.Redirect("MembersMain.aspx?u=" + user + "&p=" + pass);
		}
	}
}